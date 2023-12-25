﻿// <auto-generated />
// Generated by DotMake.CommandLine.SourceGeneration v1.5.4.0
// Roslyn (Microsoft.CodeAnalysis) v4.800.23.57201
// Generation: 1

namespace TestApp.Commands
{
    public class NullableReferenceCommandBuilder : DotMake.CommandLine.CliCommandBuilder
    {
        public NullableReferenceCommandBuilder()
        {
            DefinitionType = typeof(TestApp.Commands.NullableReferenceCommand);
            ParentDefinitionType = null;
            NameCasingConvention = DotMake.CommandLine.CliNameCasingConvention.KebabCase;
            NamePrefixConvention = DotMake.CommandLine.CliNamePrefixConvention.DoubleHyphen;
            ShortFormPrefixConvention = DotMake.CommandLine.CliNamePrefixConvention.SingleHyphen;
            ShortFormAutoGenerate = true;
        }

        public override System.CommandLine.RootCommand Build()
        {
            // Command for 'NullableReferenceCommand' class
            var rootCommand = new System.CommandLine.RootCommand()
            {
            };

            var defaultClass = new TestApp.Commands.NullableReferenceCommand();

            // Option for 'Display' property
            var option0 = new System.CommandLine.Option<string>
            (
                "--display"
            )
            {
                Description = "Description for Display",
                IsRequired = true,
            };
            System.CommandLine.OptionExtensions.FromAmong(option0, new[] {"Big", "Small"});
            option0.AddAlias("-d");
            rootCommand.Add(option0);

            // Argument for 'Arg' property
            var argument0 = new System.CommandLine.Argument<string[]>
            (
                "arg"
            )
            {
            };
            argument0.SetDefaultValue(defaultClass.Arg);
            rootCommand.Add(argument0);

            // Add nested or external registered children
            foreach (var child in Children)
            {
                rootCommand.Add(child.Build());
            }

            BindFunc = (parseResult) =>
            {
                var targetClass = new TestApp.Commands.NullableReferenceCommand();

                //  Set the parsed or default values for the options
                targetClass.Display = parseResult.GetValueForOption(option0);

                //  Set the parsed or default values for the arguments
                targetClass.Arg = parseResult.GetValueForArgument(argument0);

                return targetClass;
            };

            System.CommandLine.Handler.SetHandler(rootCommand, context =>
            {
                var targetClass = (TestApp.Commands.NullableReferenceCommand) BindFunc(context.ParseResult);

                //  Call the command handler
                targetClass.Run(context);
            });

            return rootCommand;
        }

        [System.Runtime.CompilerServices.ModuleInitializerAttribute]
        public static void Initialize()
        {
            var commandBuilder = new TestApp.Commands.NullableReferenceCommandBuilder();

            // Register this command builder so that it can be found by the definition class
            // and it can be found by the parent definition class if it's a nested/external child.
            commandBuilder.Register();
        }
    }
}
