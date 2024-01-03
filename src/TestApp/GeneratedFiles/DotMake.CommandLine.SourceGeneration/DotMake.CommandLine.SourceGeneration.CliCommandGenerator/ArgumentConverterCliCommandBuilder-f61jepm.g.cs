﻿// <auto-generated />
// Generated by DotMake.CommandLine.SourceGeneration v1.5.8.0
// Roslyn (Microsoft.CodeAnalysis) v4.800.23.57201
// Generation: 1

namespace TestApp.Commands
{
    public class ArgumentConverterCliCommandBuilder : DotMake.CommandLine.CliCommandBuilder
    {
        public ArgumentConverterCliCommandBuilder()
        {
            DefinitionType = typeof(TestApp.Commands.ArgumentConverterCliCommand);
            ParentDefinitionType = null;
            NameCasingConvention = DotMake.CommandLine.CliNameCasingConvention.KebabCase;
            NamePrefixConvention = DotMake.CommandLine.CliNamePrefixConvention.DoubleHyphen;
            ShortFormPrefixConvention = DotMake.CommandLine.CliNamePrefixConvention.SingleHyphen;
            ShortFormAutoGenerate = true;
        }

        public override System.CommandLine.Command Build()
        {
            // Command for 'ArgumentConverterCliCommand' class
            var rootCommand = new System.CommandLine.RootCommand()
            {
            };

            var defaultClass = new TestApp.Commands.ArgumentConverterCliCommand();

            // Option for 'Opt' property
            var option0 = new System.CommandLine.Option<TestApp.Commands.ClassWithConstructor>
            (
                "--opt",
                GetParseArgument<TestApp.Commands.ClassWithConstructor>
                (
                    input => new TestApp.Commands.ClassWithConstructor(input)
                )
            )
            {
                IsRequired = true,
            };
            option0.AddAlias("-o");
            rootCommand.Add(option0);

            // Option for 'OptArray' property
            var option1 = new System.CommandLine.Option<TestApp.Commands.ClassWithConstructor[]>
            (
                "--opt-array",
                GetParseArgument<TestApp.Commands.ClassWithConstructor[], TestApp.Commands.ClassWithConstructor>
                (
                    array => (TestApp.Commands.ClassWithConstructor[])array,
                    item => new TestApp.Commands.ClassWithConstructor(item)
                )
            )
            {
                AllowMultipleArgumentsPerToken = true,
                IsRequired = true,
            };
            rootCommand.Add(option1);

            // Option for 'OptNullable' property
            var option2 = new System.CommandLine.Option<TestApp.Commands.CustomStruct?>
            (
                "--opt-nullable",
                GetParseArgument<TestApp.Commands.CustomStruct?>
                (
                    input => new TestApp.Commands.CustomStruct(input)
                )
            )
            {
                IsRequired = true,
            };
            rootCommand.Add(option2);

            // Option for 'OptEnumerable' property
            var option3 = new System.CommandLine.Option<System.Collections.Generic.IEnumerable<TestApp.Commands.ClassWithConstructor>>
            (
                "--opt-enumerable",
                GetParseArgument<System.Collections.Generic.IEnumerable<TestApp.Commands.ClassWithConstructor>, TestApp.Commands.ClassWithConstructor>
                (
                    array => (TestApp.Commands.ClassWithConstructor[])array,
                    item => new TestApp.Commands.ClassWithConstructor(item)
                )
            )
            {
                IsRequired = true,
            };
            rootCommand.Add(option3);

            // Option for 'OptList' property
            var option4 = new System.CommandLine.Option<System.Collections.Generic.List<TestApp.Commands.ClassWithConstructor>>
            (
                "--opt-list",
                GetParseArgument<System.Collections.Generic.List<TestApp.Commands.ClassWithConstructor>, TestApp.Commands.ClassWithConstructor>
                (
                    array => new System.Collections.Generic.List<TestApp.Commands.ClassWithConstructor>((TestApp.Commands.ClassWithConstructor[])array),
                    item => new TestApp.Commands.ClassWithConstructor(item)
                )
            )
            {
                IsRequired = true,
            };
            rootCommand.Add(option4);

            // Option for 'OptCustomList' property
            var option5 = new System.CommandLine.Option<TestApp.Commands.CustomList<TestApp.Commands.ClassWithConstructor>>
            (
                "--opt-custom-list",
                GetParseArgument<TestApp.Commands.CustomList<TestApp.Commands.ClassWithConstructor>, TestApp.Commands.ClassWithConstructor>
                (
                    array => new TestApp.Commands.CustomList<TestApp.Commands.ClassWithConstructor>((TestApp.Commands.ClassWithConstructor[])array),
                    item => new TestApp.Commands.ClassWithConstructor(item)
                )
            )
            {
                IsRequired = true,
            };
            rootCommand.Add(option5);

            // Argument for 'Arg' property
            var argument0 = new System.CommandLine.Argument<System.Collections.Generic.IEnumerable<TestApp.Commands.ClassWithParser>>
            (
                "arg",
                GetParseArgument<System.Collections.Generic.IEnumerable<TestApp.Commands.ClassWithParser>, TestApp.Commands.ClassWithParser>
                (
                    array => (TestApp.Commands.ClassWithParser[])array,
                    item => TestApp.Commands.ClassWithParser.Parse(item)
                )
            )
            {
            };
            argument0.Arity = System.CommandLine.ArgumentArity.OneOrMore;
            rootCommand.Add(argument0);

            // Add nested or external registered children
            foreach (var child in Children)
            {
                rootCommand.Add(child.Build());
            }

            BindFunc = (parseResult) =>
            {
                var targetClass = new TestApp.Commands.ArgumentConverterCliCommand();

                //  Set the parsed or default values for the options
                targetClass.Opt = GetValueForOption(parseResult, option0);
                targetClass.OptArray = GetValueForOption(parseResult, option1);
                targetClass.OptNullable = GetValueForOption(parseResult, option2);
                targetClass.OptEnumerable = GetValueForOption(parseResult, option3);
                targetClass.OptList = GetValueForOption(parseResult, option4);
                targetClass.OptCustomList = GetValueForOption(parseResult, option5);

                //  Set the parsed or default values for the arguments
                targetClass.Arg = GetValueForArgument(parseResult, argument0);

                return targetClass;
            };

            System.CommandLine.Handler.SetHandler(rootCommand, context =>
            {
                var targetClass = (TestApp.Commands.ArgumentConverterCliCommand) BindFunc(context.ParseResult);

                //  Call the command handler
                targetClass.Run();
            });

            return rootCommand;
        }

        [System.Runtime.CompilerServices.ModuleInitializerAttribute]
        public static void Initialize()
        {
            var commandBuilder = new TestApp.Commands.ArgumentConverterCliCommandBuilder();

            // Register this command builder so that it can be found by the definition class
            // and it can be found by the parent definition class if it's a nested/external child.
            commandBuilder.Register();
        }
    }
}
