﻿// <auto-generated />
// Generated by DotMake.CommandLine.SourceGeneration v1.8.2.0
// Roslyn (Microsoft.CodeAnalysis) v4.900.24.8111
// Generation: 1

namespace GeneratedCode
{
    /// <inheritdoc />
    public class CliCommandAsDelegate_fsqgtf8Builder : DotMake.CommandLine.CliCommandBuilder
    {
        /// <inheritdoc />
        public CliCommandAsDelegate_fsqgtf8Builder()
        {
            DefinitionType = typeof(GeneratedCode.CliCommandAsDelegate_fsqgtf8);
            ParentDefinitionType = null;
            NameCasingConvention = DotMake.CommandLine.CliNameCasingConvention.KebabCase;
            NamePrefixConvention = DotMake.CommandLine.CliNamePrefixConvention.DoubleHyphen;
            ShortFormPrefixConvention = DotMake.CommandLine.CliNamePrefixConvention.SingleHyphen;
            ShortFormAutoGenerate = true;
        }

        private GeneratedCode.CliCommandAsDelegate_fsqgtf8 CreateInstance()
        {
            return new GeneratedCode.CliCommandAsDelegate_fsqgtf8();
        }

        /// <inheritdoc />
        public override System.CommandLine.CliCommand Build()
        {
            // Command for 'CliCommandAsDelegate_fsqgtf8' class
            var rootCommand = new System.CommandLine.CliRootCommand()
            {
            };

            var defaultClass = CreateInstance();

            // Option for 'option2' property
            var option0 = new System.CommandLine.CliOption<bool>
            (
                "--option-2"
            )
            {
                Required = false,
                DefaultValueFactory = _ => defaultClass.option2,
                CustomParser = GetArgumentParser<bool>
                (
                    null
                ),
            };
            option0.Aliases.Add("-o");
            rootCommand.Add(option0);

            // Argument for 'argument2' property
            var argument0 = new System.CommandLine.CliArgument<string>
            (
                "argument-2"
            )
            {
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
                targetClass.option2 = GetValueForOption(parseResult, option0);

                //  Set the parsed or default values for the arguments
                targetClass.argument2 = GetValueForArgument(parseResult, argument0);

                return targetClass;
            };

            rootCommand.SetAction(async (parseResult, cancellationToken) =>
            {
                var targetClass = (GeneratedCode.CliCommandAsDelegate_fsqgtf8) BindFunc(parseResult);

                //  Call the command handler
                var cliContext = new DotMake.CommandLine.CliContext(parseResult, cancellationToken);
                var exitCode = 0;
                await targetClass.RunAsync();
                return exitCode;
            });

            return rootCommand;
        }

        [System.Runtime.CompilerServices.ModuleInitializerAttribute]
        internal static void Initialize()
        {
            var commandBuilder = new GeneratedCode.CliCommandAsDelegate_fsqgtf8Builder();

            // Register this command builder so that it can be found by the definition class
            // and it can be found by the parent definition class if it's a nested/external child.
            commandBuilder.Register();
        }
    }
}
