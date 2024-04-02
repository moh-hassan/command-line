﻿// <auto-generated />
// Generated by DotMake.CommandLine.SourceGeneration v1.8.7.0
// Roslyn (Microsoft.CodeAnalysis) v4.900.24.12101
// Generation: 1

namespace TestApp.Commands.GeneratedCode
{
    /// <inheritdoc />
    public class RootWithNestedChildrenCliCommandBuilder : DotMake.CommandLine.CliCommandBuilder
    {
        /// <inheritdoc />
        public RootWithNestedChildrenCliCommandBuilder()
        {
            DefinitionType = typeof(TestApp.Commands.RootWithNestedChildrenCliCommand);
            ParentDefinitionType = null;
            NameCasingConvention = DotMake.CommandLine.CliNameCasingConvention.KebabCase;
            NamePrefixConvention = DotMake.CommandLine.CliNamePrefixConvention.DoubleHyphen;
            ShortFormPrefixConvention = DotMake.CommandLine.CliNamePrefixConvention.SingleHyphen;
            ShortFormAutoGenerate = true;
        }

        private TestApp.Commands.RootWithNestedChildrenCliCommand CreateInstance()
        {
            return new TestApp.Commands.RootWithNestedChildrenCliCommand();
        }

        /// <inheritdoc />
        public override System.CommandLine.CliCommand Build()
        {
            // Command for 'RootWithNestedChildrenCliCommand' class
            var rootCommand = new System.CommandLine.CliRootCommand()
            {
                Description = "A root cli command with nested children",
            };

            var defaultClass = CreateInstance();

            // Option for 'Option1' property
            var option0 = new System.CommandLine.CliOption<string>
            (
                "--option-1"
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
                "argument-1"
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

            Binder = (parseResult) =>
            {
                var targetClass = CreateInstance();

                //  Set the parsed or default values for the options
                targetClass.Option1 = GetValueForOption(parseResult, option0);

                //  Set the parsed or default values for the arguments
                targetClass.Argument1 = GetValueForArgument(parseResult, argument0);

                //  Set the values for the parent command accessors

                return targetClass;
            };

            rootCommand.SetAction(parseResult =>
            {
                var targetClass = (TestApp.Commands.RootWithNestedChildrenCliCommand) Bind(parseResult);

                //  Call the command handler
                var cliContext = new DotMake.CommandLine.CliContext(parseResult);
                var exitCode = 0;
                targetClass.Run(cliContext);
                return exitCode;
            });

            return rootCommand;
        }

        [System.Runtime.CompilerServices.ModuleInitializerAttribute]
        internal static void Initialize()
        {
            var commandBuilder = new TestApp.Commands.GeneratedCode.RootWithNestedChildrenCliCommandBuilder();

            // Register this command builder so that it can be found by the definition class
            // and it can be found by the parent definition class if it's a nested/external child.
            commandBuilder.Register();
        }

        /// <inheritdoc />
        public class Level1SubCliCommandBuilder : DotMake.CommandLine.CliCommandBuilder
        {
            /// <inheritdoc />
            public Level1SubCliCommandBuilder()
            {
                DefinitionType = typeof(TestApp.Commands.RootWithNestedChildrenCliCommand.Level1SubCliCommand);
                ParentDefinitionType = typeof(TestApp.Commands.RootWithNestedChildrenCliCommand);
                NameCasingConvention = DotMake.CommandLine.CliNameCasingConvention.KebabCase;
                NamePrefixConvention = DotMake.CommandLine.CliNamePrefixConvention.DoubleHyphen;
                ShortFormPrefixConvention = DotMake.CommandLine.CliNamePrefixConvention.SingleHyphen;
                ShortFormAutoGenerate = true;
            }

            private TestApp.Commands.RootWithNestedChildrenCliCommand.Level1SubCliCommand CreateInstance()
            {
                return new TestApp.Commands.RootWithNestedChildrenCliCommand.Level1SubCliCommand();
            }

            /// <inheritdoc />
            public override System.CommandLine.CliCommand Build()
            {
                // Command for 'Level1SubCliCommand' class
                var command = new System.CommandLine.CliCommand("level-1")
                {
                    Description = "A nested level 1 sub-command",
                };

                var defaultClass = CreateInstance();

                // Option for 'Option1' property
                var option0 = new System.CommandLine.CliOption<string>
                (
                    "--option-1"
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
                command.Add(option0);

                // Argument for 'Argument1' property
                var argument0 = new System.CommandLine.CliArgument<string>
                (
                    "argument-1"
                )
                {
                    Description = "Description for Argument1",
                    CustomParser = GetArgumentParser<string>
                    (
                        null
                    ),
                };
                command.Add(argument0);

                // Add nested or external registered children
                foreach (var child in Children)
                {
                    command.Add(child.Build());
                }

                Binder = (parseResult) =>
                {
                    var targetClass = CreateInstance();

                    //  Set the parsed or default values for the options
                    targetClass.Option1 = GetValueForOption(parseResult, option0);

                    //  Set the parsed or default values for the arguments
                    targetClass.Argument1 = GetValueForArgument(parseResult, argument0);

                    //  Set the values for the parent command accessors

                    return targetClass;
                };

                command.SetAction(parseResult =>
                {
                    var targetClass = (TestApp.Commands.RootWithNestedChildrenCliCommand.Level1SubCliCommand) Bind(parseResult);

                    //  Call the command handler
                    var cliContext = new DotMake.CommandLine.CliContext(parseResult);
                    var exitCode = 0;
                    targetClass.Run(cliContext);
                    return exitCode;
                });

                return command;
            }

            [System.Runtime.CompilerServices.ModuleInitializerAttribute]
            internal static void Initialize()
            {
                var commandBuilder = new TestApp.Commands.GeneratedCode.RootWithNestedChildrenCliCommandBuilder.Level1SubCliCommandBuilder();

                // Register this command builder so that it can be found by the definition class
                // and it can be found by the parent definition class if it's a nested/external child.
                commandBuilder.Register();
            }

            /// <inheritdoc />
            public class Level2SubCliCommandBuilder : DotMake.CommandLine.CliCommandBuilder
            {
                /// <inheritdoc />
                public Level2SubCliCommandBuilder()
                {
                    DefinitionType = typeof(TestApp.Commands.RootWithNestedChildrenCliCommand.Level1SubCliCommand.Level2SubCliCommand);
                    ParentDefinitionType = typeof(TestApp.Commands.RootWithNestedChildrenCliCommand.Level1SubCliCommand);
                    NameCasingConvention = DotMake.CommandLine.CliNameCasingConvention.KebabCase;
                    NamePrefixConvention = DotMake.CommandLine.CliNamePrefixConvention.DoubleHyphen;
                    ShortFormPrefixConvention = DotMake.CommandLine.CliNamePrefixConvention.SingleHyphen;
                    ShortFormAutoGenerate = true;
                }

                private TestApp.Commands.RootWithNestedChildrenCliCommand.Level1SubCliCommand.Level2SubCliCommand CreateInstance()
                {
                    return new TestApp.Commands.RootWithNestedChildrenCliCommand.Level1SubCliCommand.Level2SubCliCommand();
                }

                /// <inheritdoc />
                public override System.CommandLine.CliCommand Build()
                {
                    // Command for 'Level2SubCliCommand' class
                    var command = new System.CommandLine.CliCommand("level-2")
                    {
                        Description = "A nested level 2 sub-command",
                    };

                    var defaultClass = CreateInstance();

                    // Option for 'Option1' property
                    var option0 = new System.CommandLine.CliOption<string>
                    (
                        "--option-1"
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
                    command.Add(option0);

                    // Argument for 'Argument1' property
                    var argument0 = new System.CommandLine.CliArgument<string>
                    (
                        "argument-1"
                    )
                    {
                        Description = "Description for Argument1",
                        CustomParser = GetArgumentParser<string>
                        (
                            null
                        ),
                    };
                    command.Add(argument0);

                    // Add nested or external registered children
                    foreach (var child in Children)
                    {
                        command.Add(child.Build());
                    }

                    Binder = (parseResult) =>
                    {
                        var targetClass = CreateInstance();

                        //  Set the parsed or default values for the options
                        targetClass.Option1 = GetValueForOption(parseResult, option0);

                        //  Set the parsed or default values for the arguments
                        targetClass.Argument1 = GetValueForArgument(parseResult, argument0);

                        //  Set the values for the parent command accessors

                        return targetClass;
                    };

                    command.SetAction(parseResult =>
                    {
                        var targetClass = (TestApp.Commands.RootWithNestedChildrenCliCommand.Level1SubCliCommand.Level2SubCliCommand) Bind(parseResult);

                        //  Call the command handler
                        var cliContext = new DotMake.CommandLine.CliContext(parseResult);
                        var exitCode = 0;
                        targetClass.Run(cliContext);
                        return exitCode;
                    });

                    return command;
                }

                [System.Runtime.CompilerServices.ModuleInitializerAttribute]
                internal static void Initialize()
                {
                    var commandBuilder = new TestApp.Commands.GeneratedCode.RootWithNestedChildrenCliCommandBuilder.Level1SubCliCommandBuilder.Level2SubCliCommandBuilder();

                    // Register this command builder so that it can be found by the definition class
                    // and it can be found by the parent definition class if it's a nested/external child.
                    commandBuilder.Register();
                }
            }
        }
    }
}
