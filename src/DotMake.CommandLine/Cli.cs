using System;
using System.CommandLine;
using System.CommandLine.Completions;
using System.CommandLine.Help;
using System.CommandLine.Invocation;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace DotMake.CommandLine
{
    /// <summary>
    /// Provides methods for parsing command line input and running an indicated command.
    /// </summary>
    /// <example>
    ///     <code id="gettingStartedDelegate" source="..\TestApp\CliExamples.cs" region="CliRunDelegate" language="cs" />
    ///     <code id="gettingStartedClass">
    ///         <code source="..\TestApp\Commands\RootCliCommand.cs" region="RootCliCommand" language="cs" />
    ///         <code source="..\TestApp\CliExamples.cs" region="CliRun" language="cs" />
    ///         <code source="..\TestApp\CliExamples.cs" region="CliParse" language="cs" />
    ///     </code>
    ///     <code>
    ///         <code source="..\TestApp\CliExamples.cs" region="CliRunWithReturn" language="cs" />
    ///         <code source="..\TestApp\CliExamples.cs" region="CliRunAsync" language="cs" />
    ///         <code source="..\TestApp\CliExamples.cs" region="CliRunAsyncWithReturn" language="cs" />
    ///         <code source="..\TestApp\CliExamples.cs" region="CliParseWithResult" language="cs" />
    ///     </code>
    ///     <code source="..\TestApp\CliExamples.cs" region="CliRunExceptions" language="cs" />
    ///     <code>
    ///         <code source="..\TestApp.NugetDI\Program.cs" region="Namespace" language="cs" />
    ///         <code source="..\TestApp.NugetDI\Program.cs" region="ConfigureServices" language="cs" />
    ///         <code source="..\TestApp.NugetDI\Commands\RootCliCommand.cs" region="RootCliCommand" language="cs" />
    ///     </code>
    /// </example>
    public static class Cli
    {
        /// <summary>
        /// <inheritdoc cref="CliExtensions" path="/summary/node()" />
        /// </summary>
        public static CliExtensions Ext { get; } = new CliExtensions();

        /// <summary>
        /// Returns a string array containing the command-line arguments for the current process.
        /// <para>
        /// Uses <see cref="Environment.GetCommandLineArgs"/> but skips the first element which is the executable file name,
        /// so the following zero or more elements that contain the remaining command-line arguments are returned,
        /// i.e. returns the same as the special variable <c>args</c> available in <c>Program.cs</c> (new style with top-level statements)
        /// or as the string array passed to the program's <c>Main</c> method (old style).
        /// </para>
        /// <para>Also on Windows platform, backslash + double quote (<c>\&quot;</c>) at the end of an argument,
        /// is usually a path separator and not an escape for double quote, so it will be trimmed to prevent unnecessary path errors.</para>
        /// </summary>
        /// <returns>An array of strings where each element contains a command-line argument.</returns>
        public static string[] GetArgs()
        {
            if (Environment.GetCommandLineArgs() is { Length: > 0 } args)
                return FixArgs(args.Skip(1).ToArray());

            return Array.Empty<string>();
        }



        /// <summary>
        /// Gets a CLI configuration for the indicated command.
        /// </summary>
        /// <typeparam name="TDefinition">The definition class for the command. A command builder for this class should be automatically generated by the source generator.</typeparam>
        /// <param name="settings">The settings for the parser's grammar and behaviors.</param>
        /// <returns>A <see cref="CommandLineConfiguration"/> on which the parser's grammar and behaviors are based.</returns>
        public static CommandLineConfiguration GetConfiguration<TDefinition>(CliSettings settings = null)
        {
            var definitionType = typeof(TDefinition);

            return GetConfiguration(definitionType, settings);
        }

        /// <inheritdoc cref = "GetConfiguration{TDefinition}" />
        /// <param name="definitionType">The definition class type for the command. A command builder for this class should be automatically generated by the source generator.</param>
        /// <param name="settings"><inheritdoc cref="GetConfiguration{TDefinition}" path="/param[@name='settings']/node()" /></param>
        public static CommandLineConfiguration GetConfiguration(Type definitionType, CliSettings settings = null)
        {
            var commandBuilder = CliCommandBuilder.Get(definitionType);
            var command = commandBuilder.Build();

            settings ??= new CliSettings();
            var configuration = new CommandLineConfiguration(command)
            {
                EnablePosixBundling = settings.EnablePosixBundling,
                EnableDefaultExceptionHandler = settings.EnableDefaultExceptionHandler,
                ProcessTerminationTimeout = settings.ProcessTerminationTimeout,
                ResponseFileTokenReplacer = settings.ResponseFileTokenReplacer
            };

            if (settings.Output != null) //Console.Out is NOT being used
                configuration.Output = settings.Output;
            if (settings.Error != null) //Console.Error is NOT being used
                configuration.Error = settings.Error;

            if (command is RootCommand rootCommand)
            {
                //CliRootCommand constructor already adds HelpOption and VersionOption so remove them
                foreach (var option in rootCommand.Options.Where(option => option is HelpOption or VersionOption).ToArray())
                    rootCommand.Options.Remove(option);

                var helpOption = new HelpOption(
                    "help".AddPrefix(commandBuilder.NamePrefixConvention),
                    //Regardless of convention, add all short-form aliases as help is a special option
                    "-h", "/h", "-?", "/?"
                )
                {
                    Action = new HelpAction
                    {
                        Builder = new CliHelpBuilder(settings.Theme, Console.IsOutputRedirected ? int.MaxValue : Console.WindowWidth)
                    }
                };
                rootCommand.Options.Add(helpOption);

                var versionOption = new VersionOption(
                    "version".AddPrefix(commandBuilder.NamePrefixConvention),
                    commandBuilder.ShortFormAutoGenerate
                        ? new []{ "v".AddPrefix(commandBuilder.ShortFormPrefixConvention) }
                        : Array.Empty<string>()
                )
                {
                    Action = new VersionOptionAction()
                };
                rootCommand.Options.Add(versionOption);

                //CliRootCommand constructor already adds SuggestDirective so remove it
                foreach (var directive in rootCommand.Directives.Where(directive => directive is SuggestDirective).ToArray())
                    rootCommand.Directives.Remove(directive);

                if (settings.EnableSuggestDirective)
                    rootCommand.Directives.Add(new SuggestDirective());
                if (settings.EnableDiagramDirective)
                    rootCommand.Directives.Add(new DiagramDirective());
                if (settings.EnableEnvironmentVariablesDirective)
                    rootCommand.Directives.Add(new EnvironmentVariablesDirective());
            }

            return configuration;
        }



        /// <summary>
        /// Parses a command line string array and runs the handler for the indicated command.
        /// </summary>
        /// <typeparam name="TDefinition"><inheritdoc cref="GetConfiguration{TDefinition}" path="/typeparam[@name='TDefinition']/node()" /></typeparam>
        /// <param name="args">
        /// The string array typically passed to a program. This is usually
        /// the special variable <c>args</c> available in <c>Program.cs</c> (new style with top-level statements)
        /// or the string array passed to the program's <c>Main</c> method (old style).
        /// If not specified or <see langword="null"/>, <c>args</c> will be retrieved automatically from the current process via <see cref="GetArgs"/>.
        /// </param>
        /// <param name="settings"><inheritdoc cref="GetConfiguration{TDefinition}" path="/param[@name='settings']/node()" /></param>
        /// <returns>The exit code for the invocation.</returns>
        /// <example>
        ///     <code source="..\TestApp\CliExamples.cs" region="CliRun" language="cs" />
        ///     <code source="..\TestApp\CliExamples.cs" region="CliRunWithReturn" language="cs" />
        /// </example>
        public static int Run<TDefinition>(string[] args = null, CliSettings settings = null)
        {
            settings ??= new CliSettings();

            using (new CliSession(settings))
            {
                var configuration = GetConfiguration<TDefinition>(settings);

                return configuration.Invoke(FixArgs(args) ?? GetArgs());
            }
        }

        /// <summary>
        /// Parses a command line string value and runs the handler for the indicated command.
        /// </summary>
        /// <typeparam name="TDefinition"><inheritdoc cref="GetConfiguration{TDefinition}" path="/typeparam[@name='TDefinition']/node()" /></typeparam>
        /// <param name="commandLine">The command line string that will be split into tokens as if it had been passed on the command line. Useful for testing command line input by just specifying it as a single string.</param>
        /// <param name="settings"><inheritdoc cref="GetConfiguration{TDefinition}" path="/param[@name='settings']/node()" /></param>
        /// <returns><inheritdoc cref="Run{TDefinition}(string[], CliSettings)" path="/returns/node()" /></returns>
        /// <example>
        ///     <code source="..\TestApp\CliExamples.cs" region="CliRunString" language="cs" />
        ///     <code source="..\TestApp\CliExamples.cs" region="CliRunStringWithReturn" language="cs" />
        /// </example>
        public static int Run<TDefinition>(string commandLine, CliSettings settings = null)
        {
            settings ??= new CliSettings();

            using (new CliSession(settings))
            {
                var configuration = GetConfiguration<TDefinition>(settings);

                return configuration.Invoke(commandLine);
            }
        }

        /// <summary>
        /// Parses the command line arguments and runs the indicated command as delegate.
        /// </summary>
        /// <param name="cliCommandAsDelegate">
        /// The command as delegate.
        /// <code>
        /// ([CliArgument] string argument1, bool option1) => { }
        ///
        /// ([CliArgument] string argument1, bool option1) => { return 0; }
        ///
        /// async ([CliArgument] string argument1, bool option1) => { await Task.Delay(1000); }
        /// 
        /// MethodReference
        /// </code>
        /// </param>
        /// <param name="settings"><inheritdoc cref="GetConfiguration{TDefinition}" path="/param[@name='settings']/node()" /></param>
        /// <returns><inheritdoc cref="Run{TDefinition}(string[], CliSettings)" path="/returns/node()" /></returns>
        /// <example>
        ///     <code source="..\TestApp\CliExamples.cs" region="CliRunDelegate" language="cs" />
        ///     <code source="..\TestApp\CliExamples.cs" region="CliRunDelegateWithReturn" language="cs" />
        /// </example>
        public static int Run(Delegate cliCommandAsDelegate, CliSettings settings = null)
        {
            settings ??= new CliSettings();

            using (new CliSession(settings))
            {
                var definitionType = CliCommandAsDelegate.Get(cliCommandAsDelegate);
                var configuration = GetConfiguration(definitionType, settings);

                return configuration.Invoke(GetArgs());
            }
        }



        /// <summary>
        /// Parses a command line string array and runs the handler asynchronously for the indicated command.
        /// </summary>
        /// <typeparam name="TDefinition"><inheritdoc cref="GetConfiguration{TDefinition}" path="/typeparam[@name='TDefinition']/node()" /></typeparam>
        /// <param name="args"><inheritdoc cref="Run{TDefinition}(string[], CliSettings)" path="/param[@name='args']/node()" /></param>
        /// <param name="settings"><inheritdoc cref="GetConfiguration{TDefinition}" path="/param[@name='settings']/node()" /></param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns><inheritdoc cref="Run{TDefinition}(string[], CliSettings)" path="/returns/node()" /></returns>
        /// <example>
        ///     <code source="..\TestApp\CliExamples.cs" region="CliRunAsync" language="cs" />
        ///     <code source="..\TestApp\CliExamples.cs" region="CliRunAsyncWithReturn" language="cs" />
        /// </example>
        public static async Task<int> RunAsync<TDefinition>(string[] args = null, CliSettings settings = null, CancellationToken cancellationToken = default)
        {
            settings ??= new CliSettings();

            using (new CliSession(settings))
            {
                var configuration = GetConfiguration<TDefinition>(settings);

                return await configuration.InvokeAsync(FixArgs(args) ?? GetArgs(), cancellationToken);
            }
        }

        /// <summary>
        /// Parses a command line string value and runs the handler asynchronously for the indicated command.
        /// </summary>
        /// <typeparam name="TDefinition"><inheritdoc cref="GetConfiguration{TDefinition}" path="/typeparam[@name='TDefinition']/node()" /></typeparam>
        /// <param name="commandLine"><inheritdoc cref="Run{TDefinition}(string, CliSettings)" path="/param[@name='commandLine']/node()" /></param>
        /// <param name="settings"><inheritdoc cref="GetConfiguration{TDefinition}" path="/param[@name='settings']/node()" /></param>
        /// <param name="cancellationToken"><inheritdoc cref="RunAsync{TDefinition}(string[], CliSettings, CancellationToken)" path="/param[@name='cancellationToken']/node()" /></param>
        /// <returns><inheritdoc cref="Run{TDefinition}(string[], CliSettings)" path="/returns/node()" /></returns>
        /// <example>
        ///     <code source="..\TestApp\CliExamples.cs" region="CliRunAsyncString" language="cs" />
        ///     <code source="..\TestApp\CliExamples.cs" region="CliRunAsyncStringWithReturn" language="cs" />
        /// </example>
        public static async Task<int> RunAsync<TDefinition>(string commandLine, CliSettings settings = null, CancellationToken cancellationToken = default)
        {
            settings ??= new CliSettings();

            using (new CliSession(settings))
            {
                var configuration = GetConfiguration<TDefinition>(settings);

                return await configuration.InvokeAsync(commandLine, cancellationToken);
            }
        }

        /// <summary>
        /// Parses the command line arguments and runs the indicated command as delegate.
        /// </summary>
        /// <param name="cliCommandAsDelegate"><inheritdoc cref="Run(Delegate, CliSettings)" path="/param[@name='cliCommandAsDelegate']/node()" /></param>
        /// <param name="settings"><inheritdoc cref="GetConfiguration{TDefinition}" path="/param[@name='settings']/node()" /></param>
        /// <param name="cancellationToken"><inheritdoc cref="RunAsync{TDefinition}(string[], CliSettings, CancellationToken)" path="/param[@name='cancellationToken']/node()" /></param>
        /// <returns><inheritdoc cref="Run{TDefinition}(string[], CliSettings)" path="/returns/node()" /></returns>
        /// <example>
        ///     <code source="..\TestApp\CliExamples.cs" region="CliRunAsyncDelegate" language="cs" />
        ///     <code source="..\TestApp\CliExamples.cs" region="CliRunAsyncDelegateWithReturn" language="cs" />
        /// </example>
        public static async Task<int> RunAsync(Delegate cliCommandAsDelegate, CliSettings settings = null, CancellationToken cancellationToken = default)
        {
            settings ??= new CliSettings();

            using (new CliSession(settings))
            {
                var definitionType = CliCommandAsDelegate.Get(cliCommandAsDelegate);
                var configuration = GetConfiguration(definitionType, settings);

                return await configuration.InvokeAsync(GetArgs(), cancellationToken);
            }
        }



        /// <summary>
        /// Parses a command line string array and returns the parse result.
        /// </summary>
        /// <typeparam name="TDefinition"><inheritdoc cref="GetConfiguration{TDefinition}" path="/typeparam[@name='TDefinition']/node()" /></typeparam>
        /// <param name="args"><inheritdoc cref="Run{TDefinition}(string[], CliSettings)" path="/param[@name='args']/node()" /></param>
        /// <param name="settings"><inheritdoc cref="GetConfiguration{TDefinition}" path="/param[@name='settings']/node()" /></param>
        /// <returns>A <see cref="ParseResult" /> providing details about the parse operation.</returns>
        /// <example>
        ///     <code source="..\TestApp\CliExamples.cs" region="CliParseWithResult" language="cs" />
        /// </example>
        public static ParseResult Parse<TDefinition>(string[] args = null, CliSettings settings = null)
        {
            var configuration = GetConfiguration<TDefinition>(settings);

            return configuration.Parse(FixArgs(args) ?? GetArgs());
        }

        /// <summary>
        /// Parses a command line string and returns the parse result.
        /// </summary>
        /// <typeparam name="TDefinition"><inheritdoc cref="GetConfiguration{TDefinition}" path="/typeparam[@name='TDefinition']/node()" /></typeparam>
        /// <param name="commandLine"><inheritdoc cref="Run{TDefinition}(string, CliSettings)" path="/param[@name='commandLine']/node()" /></param>
        /// <param name="settings"><inheritdoc cref="GetConfiguration{TDefinition}" path="/param[@name='settings']/node()" /></param>
        /// <returns><inheritdoc cref="Parse{TDefinition}(string[], CliSettings)" path="/returns/node()" /></returns>
        /// <example>
        ///     <code source="..\TestApp\CliExamples.cs" region="CliParseStringWithResult" language="cs" />
        /// </example>
        public static ParseResult Parse<TDefinition>(string commandLine, CliSettings settings = null)
        {
            var configuration = GetConfiguration<TDefinition>(settings);

            return configuration.Parse(commandLine);
        }

        private static string[] FixArgs(string[] args)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
                && args != null)
            {
                /*
                  On Windows, trim ending double quote:
                  For example, if a path parameter is passed like this:
                   --source "C:\myfiles\"
                  The value comes as
                   C:\myfiles"
                  due to CommandLineToArgvW reading backslash as an escape for double quote character.
                  As on Windows, backslash at the end is usually a path separator, trim it to prevent unnecessary errors.
                  Note that this is not required for commandLine string as in that case SplitCommandLine is used,
                  and it already trims double quote characters

                  https://devblogs.microsoft.com/oldnewthing/20100917-00/?p=12833
                  https://github.com/dotnet/command-line-api/issues/2334
                  https://github.com/dotnet/command-line-api/issues/2276
                  https://github.com/dotnet/command-line-api/issues/354
                */
                for (var index = 0; index < args.Length; index++)
                {
                    args[index] = args[index].TrimEnd('"');
                }
            }

            return args;
        }

        private sealed class VersionOptionAction : SynchronousCommandLineAction
        {
            public override int Invoke(ParseResult parseResult)
            {
                parseResult.Configuration.Output.WriteLine(ExecutableInfo.Version);
                return 0;
            }
        }
    }
}
