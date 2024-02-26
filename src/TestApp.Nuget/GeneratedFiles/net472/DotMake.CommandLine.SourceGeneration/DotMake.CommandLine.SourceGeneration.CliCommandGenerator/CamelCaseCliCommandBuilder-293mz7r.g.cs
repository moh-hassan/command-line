﻿// <auto-generated />
// Generated by DotMake.CommandLine.SourceGeneration v1.8.2.0
// Roslyn (Microsoft.CodeAnalysis) v4.900.24.8111
// Generation: 1

namespace TestApp.Commands.CasingConvention
{
    /// <inheritdoc />
    public class CamelCaseCliCommandBuilder : DotMake.CommandLine.CliCommandBuilder
    {
        /// <inheritdoc />
        public CamelCaseCliCommandBuilder()
        {
            DefinitionType = typeof(TestApp.Commands.CasingConvention.CamelCaseCliCommand);
            ParentDefinitionType = null;
            NameCasingConvention = DotMake.CommandLine.CliNameCasingConvention.CamelCase;
            NamePrefixConvention = DotMake.CommandLine.CliNamePrefixConvention.DoubleHyphen;
            ShortFormPrefixConvention = DotMake.CommandLine.CliNamePrefixConvention.SingleHyphen;
            ShortFormAutoGenerate = true;
        }

        private TestApp.Commands.CasingConvention.CamelCaseCliCommand CreateInstance()
        {
            return new TestApp.Commands.CasingConvention.CamelCaseCliCommand();
        }

        /// <inheritdoc />
        public override System.CommandLine.CliCommand Build()
        {
            // Command for 'CamelCaseCliCommand' class
            var rootCommand = new System.CommandLine.CliRootCommand()
            {
                Description = "A cli command with camelCase convention",
            };

            var defaultClass = CreateInstance();

            // Option for 'Option1' property
            var option0 = new System.CommandLine.CliOption<string>
            (
                "--option1"
            )
            {
                Description = "Description for Option1",
                Required = false,
                DefaultValueFactory = _ => defaultClass.Option1,
                CustomParser = GetArgumentParser<string>
                (
                    null
                ),
            };
            option0.Aliases.Add("-o");
            rootCommand.Add(option0);

            // Argument for 'Argument1' property
            var argument0 = new System.CommandLine.CliArgument<string>
            (
                "argument1"
            )
            {
                Description = "Description for Argument1",
                CustomParser = GetArgumentParser<string>
                (
                    null
                ),
            };
            rootCommand.Add(argument0);

            // Add nested or external registered children
            foreach (var child in Children)
            {
                rootCommand.Add(child.Build());
            }

            BindFunc = (parseResult) =>
            {
                var targetClass = CreateInstance();

                //  Set the parsed or default values for the options
                targetClass.Option1 = GetValueForOption(parseResult, option0);

                //  Set the parsed or default values for the arguments
                targetClass.Argument1 = GetValueForArgument(parseResult, argument0);

                return targetClass;
            };

            rootCommand.SetAction(parseResult =>
            {
                var targetClass = (TestApp.Commands.CasingConvention.CamelCaseCliCommand) BindFunc(parseResult);

                //  Call the command handler
                var cliContext = new DotMake.CommandLine.CliContext(parseResult);
                var exitCode = 0;
                cliContext.ShowHelp();
                return exitCode;
            });

            return rootCommand;
        }

        [System.Runtime.CompilerServices.ModuleInitializerAttribute]
        internal static void Initialize()
        {
            var commandBuilder = new TestApp.Commands.CasingConvention.CamelCaseCliCommandBuilder();

            // Register this command builder so that it can be found by the definition class
            // and it can be found by the parent definition class if it's a nested/external child.
            commandBuilder.Register();
        }
    }
}
