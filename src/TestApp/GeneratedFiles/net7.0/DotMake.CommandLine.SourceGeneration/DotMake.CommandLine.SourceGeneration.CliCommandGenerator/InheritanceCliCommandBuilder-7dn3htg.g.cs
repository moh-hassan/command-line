// <auto-generated />
// Generated by DotMake.CommandLine.SourceGeneration v1.8.5.0
// Roslyn (Microsoft.CodeAnalysis) v4.900.24.12101
// Generation: 1

namespace TestApp.Commands.GeneratedCode
{
    /// <inheritdoc />
    public class InheritanceCliCommandBuilder : DotMake.CommandLine.CliCommandBuilder
    {
        /// <inheritdoc />
        public InheritanceCliCommandBuilder()
        {
            DefinitionType = typeof(TestApp.Commands.InheritanceCliCommand);
            ParentDefinitionType = null;
            NameCasingConvention = DotMake.CommandLine.CliNameCasingConvention.KebabCase;
            NamePrefixConvention = DotMake.CommandLine.CliNamePrefixConvention.DoubleHyphen;
            ShortFormPrefixConvention = DotMake.CommandLine.CliNamePrefixConvention.SingleHyphen;
            ShortFormAutoGenerate = true;
        }

        private TestApp.Commands.InheritanceCliCommand CreateInstance()
        {
            return new TestApp.Commands.InheritanceCliCommand();
        }

        /// <inheritdoc />
        public override System.CommandLine.CliCommand Build()
        {
            // Command for 'InheritanceCliCommand' class
            var rootCommand = new System.CommandLine.CliRootCommand()
            {
            };

            var defaultClass = CreateInstance();

            // Option for 'Username' property
            var option0 = new System.CommandLine.CliOption<string>
            (
                "--username"
            )
            {
                Description = "Username of the identity performing the command",
                Required = false,
                DefaultValueFactory = _ => defaultClass.Username,
                CustomParser = GetArgumentParser<string>
                (
                    null
                ),
            };
            option0.Aliases.Add("-u");
            rootCommand.Add(option0);

            // Option for 'Password' property
            var option1 = new System.CommandLine.CliOption<string>
            (
                "--password"
            )
            {
                Description = "Password of the identity performing the command",
                Required = true,
                CustomParser = GetArgumentParser<string>
                (
                    null
                ),
            };
            option1.Aliases.Add("-p");
            rootCommand.Add(option1);

            // Option for 'Department' property
            var option2 = new System.CommandLine.CliOption<string>
            (
                "--department"
            )
            {
                Description = "Department of the identity performing the command (interface)",
                Required = false,
                DefaultValueFactory = _ => defaultClass.Department,
                CustomParser = GetArgumentParser<string>
                (
                    null
                ),
            };
            option2.Aliases.Add("-d");
            rootCommand.Add(option2);

            // Add nested or external registered children
            foreach (var child in Children)
            {
                rootCommand.Add(child.Build());
            }

            BindFunc = (cliBindContext) =>
            {
                var targetClass = CreateInstance();

                //  Set the parsed or default values for the options
                targetClass.Username = GetValueForOption(cliBindContext.ParseResult, option0);
                targetClass.Password = GetValueForOption(cliBindContext.ParseResult, option1);
                targetClass.Department = GetValueForOption(cliBindContext.ParseResult, option2);

                //  Set the parsed or default values for the arguments

                //  Set the values for the parent command references

                return targetClass;
            };

            rootCommand.SetAction(parseResult =>
            {
                var cliBindContext = new DotMake.CommandLine.CliBindContext(parseResult);
                var targetClass = (TestApp.Commands.InheritanceCliCommand) BindFunc(cliBindContext);

                //  Call the command handler
                var cliContext = new DotMake.CommandLine.CliContext(parseResult);
                var exitCode = 0;
                targetClass.Run();
                return exitCode;
            });

            return rootCommand;
        }

        [System.Runtime.CompilerServices.ModuleInitializerAttribute]
        internal static void Initialize()
        {
            var commandBuilder = new TestApp.Commands.GeneratedCode.InheritanceCliCommandBuilder();

            // Register this command builder so that it can be found by the definition class
            // and it can be found by the parent definition class if it's a nested/external child.
            commandBuilder.Register();
        }
    }
}
