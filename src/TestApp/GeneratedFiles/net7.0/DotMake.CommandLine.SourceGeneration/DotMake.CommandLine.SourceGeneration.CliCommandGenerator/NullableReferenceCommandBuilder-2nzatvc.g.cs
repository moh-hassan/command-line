﻿// <auto-generated />
// Generated by DotMake.CommandLine.SourceGeneration v1.8.7.0
// Roslyn (Microsoft.CodeAnalysis) v4.900.24.12101
// Generation: 1

namespace TestApp.Commands.GeneratedCode
{
    /// <inheritdoc />
    public class NullableReferenceCommandBuilder : DotMake.CommandLine.CliCommandBuilder
    {
        /// <inheritdoc />
        public NullableReferenceCommandBuilder()
        {
            DefinitionType = typeof(TestApp.Commands.NullableReferenceCommand);
            ParentDefinitionType = null;
            NameCasingConvention = DotMake.CommandLine.CliNameCasingConvention.KebabCase;
            NamePrefixConvention = DotMake.CommandLine.CliNamePrefixConvention.DoubleHyphen;
            ShortFormPrefixConvention = DotMake.CommandLine.CliNamePrefixConvention.SingleHyphen;
            ShortFormAutoGenerate = true;
        }

        private TestApp.Commands.NullableReferenceCommand CreateInstance()
        {
            return new TestApp.Commands.NullableReferenceCommand();
        }

        /// <inheritdoc />
        public override System.CommandLine.CliCommand Build()
        {
            // Command for 'NullableReferenceCommand' class
            var rootCommand = new System.CommandLine.CliRootCommand()
            {
            };

            var defaultClass = CreateInstance();

            // Add nested or external registered children
            foreach (var child in Children)
            {
                rootCommand.Add(child.Build());
            }

            Binder = (parseResult) =>
            {
                var targetClass = CreateInstance();

                //  Set the parsed or default values for the options

                //  Set the parsed or default values for the arguments

                //  Set the values for the parent command accessors

                return targetClass;
            };

            rootCommand.SetAction(parseResult =>
            {
                var targetClass = (TestApp.Commands.NullableReferenceCommand) Bind(parseResult);

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
            var commandBuilder = new TestApp.Commands.GeneratedCode.NullableReferenceCommandBuilder();

            // Register this command builder so that it can be found by the definition class
            // and it can be found by the parent definition class if it's a nested/external child.
            commandBuilder.Register();
        }

        /// <inheritdoc />
        public class NullableBuilder : DotMake.CommandLine.CliCommandBuilder
        {
            /// <inheritdoc />
            public NullableBuilder()
            {
                DefinitionType = typeof(TestApp.Commands.NullableReferenceCommand.Nullable);
                ParentDefinitionType = typeof(TestApp.Commands.NullableReferenceCommand);
                NameCasingConvention = DotMake.CommandLine.CliNameCasingConvention.KebabCase;
                NamePrefixConvention = DotMake.CommandLine.CliNamePrefixConvention.DoubleHyphen;
                ShortFormPrefixConvention = DotMake.CommandLine.CliNamePrefixConvention.SingleHyphen;
                ShortFormAutoGenerate = true;
            }

            private TestApp.Commands.NullableReferenceCommand.Nullable CreateInstance()
            {
                return new TestApp.Commands.NullableReferenceCommand.Nullable();
            }

            /// <inheritdoc />
            public override System.CommandLine.CliCommand Build()
            {
                // Command for 'Nullable' class
                var command = new System.CommandLine.CliCommand("nullable")
                {
                };

                var defaultClass = CreateInstance();

                // Option for 'Opt' property
                var option0 = new System.CommandLine.CliOption<string>
                (
                    "--opt"
                )
                {
                    Description = "Option with nullable reference type with no default value (should be required)",
                    Required = true,
                    CustomParser = GetArgumentParser<string>
                    (
                        null
                    ),
                };
                option0.AcceptOnlyFromAmong(new[] {"Big", "Small"});
                option0.Aliases.Add("-o");
                command.Add(option0);

                // Option for 'OptDefault' property
                var option1 = new System.CommandLine.CliOption<string>
                (
                    "--opt-default"
                )
                {
                    Description = "Option with nullable reference type with default value (should not be required)",
                    Required = false,
                    DefaultValueFactory = _ => defaultClass.OptDefault,
                    CustomParser = GetArgumentParser<string>
                    (
                        null
                    ),
                };
                option1.AcceptOnlyFromAmong(new[] {"Big", "Small"});
                command.Add(option1);

                // Argument for 'Arg' property
                var argument0 = new System.CommandLine.CliArgument<string>
                (
                    "arg"
                )
                {
                    Description = "Argument with nullable reference type with no default value (should be required)",
                    CustomParser = GetArgumentParser<string>
                    (
                        null
                    ),
                };
                command.Add(argument0);

                // Argument for 'ArgDefault' property
                var argument1 = new System.CommandLine.CliArgument<string>
                (
                    "arg-default"
                )
                {
                    Description = "Argument with nullable reference type with default value (should not be required)",
                    DefaultValueFactory = _ => defaultClass.ArgDefault,
                    CustomParser = GetArgumentParser<string>
                    (
                        null
                    ),
                };
                command.Add(argument1);

                // Add nested or external registered children
                foreach (var child in Children)
                {
                    command.Add(child.Build());
                }

                Binder = (parseResult) =>
                {
                    var targetClass = CreateInstance();

                    //  Set the parsed or default values for the options
                    targetClass.Opt = GetValueForOption(parseResult, option0);
                    targetClass.OptDefault = GetValueForOption(parseResult, option1);

                    //  Set the parsed or default values for the arguments
                    targetClass.Arg = GetValueForArgument(parseResult, argument0);
                    targetClass.ArgDefault = GetValueForArgument(parseResult, argument1);

                    //  Set the values for the parent command accessors

                    return targetClass;
                };

                command.SetAction(parseResult =>
                {
                    var targetClass = (TestApp.Commands.NullableReferenceCommand.Nullable) Bind(parseResult);

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
                var commandBuilder = new TestApp.Commands.GeneratedCode.NullableReferenceCommandBuilder.NullableBuilder();

                // Register this command builder so that it can be found by the definition class
                // and it can be found by the parent definition class if it's a nested/external child.
                commandBuilder.Register();
            }
        }

        /// <inheritdoc />
        public class NonNullableBuilder : DotMake.CommandLine.CliCommandBuilder
        {
            /// <inheritdoc />
            public NonNullableBuilder()
            {
                DefinitionType = typeof(TestApp.Commands.NullableReferenceCommand.NonNullable);
                ParentDefinitionType = typeof(TestApp.Commands.NullableReferenceCommand);
                NameCasingConvention = DotMake.CommandLine.CliNameCasingConvention.KebabCase;
                NamePrefixConvention = DotMake.CommandLine.CliNamePrefixConvention.DoubleHyphen;
                ShortFormPrefixConvention = DotMake.CommandLine.CliNamePrefixConvention.SingleHyphen;
                ShortFormAutoGenerate = true;
            }

            private TestApp.Commands.NullableReferenceCommand.NonNullable CreateInstance()
            {
                return new TestApp.Commands.NullableReferenceCommand.NonNullable();
            }

            /// <inheritdoc />
            public override System.CommandLine.CliCommand Build()
            {
                // Command for 'NonNullable' class
                var command = new System.CommandLine.CliCommand("non-nullable")
                {
                };

                var defaultClass = CreateInstance();

                // Option for 'Opt' property
                var option0 = new System.CommandLine.CliOption<string>
                (
                    "--opt"
                )
                {
                    Description = "Option with non-nullable reference type with SuppressNullableWarningExpression (should be required)",
                    Required = true,
                    CustomParser = GetArgumentParser<string>
                    (
                        null
                    ),
                };
                option0.AcceptOnlyFromAmong(new[] {"Big", "Small"});
                option0.Aliases.Add("-o");
                command.Add(option0);

                // Option for 'OptDefault' property
                var option1 = new System.CommandLine.CliOption<string>
                (
                    "--opt-default"
                )
                {
                    Description = "Option with non-nullable reference type with default value (should not be required)",
                    Required = false,
                    DefaultValueFactory = _ => defaultClass.OptDefault,
                    CustomParser = GetArgumentParser<string>
                    (
                        null
                    ),
                };
                option1.AcceptOnlyFromAmong(new[] {"Big", "Small"});
                command.Add(option1);

                // Argument for 'Arg' property
                var argument0 = new System.CommandLine.CliArgument<string>
                (
                    "arg"
                )
                {
                    Description = "Argument with non-nullable reference type type with SuppressNullableWarningExpression (should be required)",
                    CustomParser = GetArgumentParser<string>
                    (
                        null
                    ),
                };
                command.Add(argument0);

                // Argument for 'ArgDefault' property
                var argument1 = new System.CommandLine.CliArgument<string>
                (
                    "arg-default"
                )
                {
                    Description = "Argument with non-nullable reference type with default value (should not be required)",
                    DefaultValueFactory = _ => defaultClass.ArgDefault,
                    CustomParser = GetArgumentParser<string>
                    (
                        null
                    ),
                };
                command.Add(argument1);

                // Add nested or external registered children
                foreach (var child in Children)
                {
                    command.Add(child.Build());
                }

                Binder = (parseResult) =>
                {
                    var targetClass = CreateInstance();

                    //  Set the parsed or default values for the options
                    targetClass.Opt = GetValueForOption(parseResult, option0);
                    targetClass.OptDefault = GetValueForOption(parseResult, option1);

                    //  Set the parsed or default values for the arguments
                    targetClass.Arg = GetValueForArgument(parseResult, argument0);
                    targetClass.ArgDefault = GetValueForArgument(parseResult, argument1);

                    //  Set the values for the parent command accessors

                    return targetClass;
                };

                command.SetAction(parseResult =>
                {
                    var targetClass = (TestApp.Commands.NullableReferenceCommand.NonNullable) Bind(parseResult);

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
                var commandBuilder = new TestApp.Commands.GeneratedCode.NullableReferenceCommandBuilder.NonNullableBuilder();

                // Register this command builder so that it can be found by the definition class
                // and it can be found by the parent definition class if it's a nested/external child.
                commandBuilder.Register();
            }
        }

        /// <inheritdoc />
        public class RequiredBuilder : DotMake.CommandLine.CliCommandBuilder
        {
            /// <inheritdoc />
            public RequiredBuilder()
            {
                DefinitionType = typeof(TestApp.Commands.NullableReferenceCommand.Required);
                ParentDefinitionType = typeof(TestApp.Commands.NullableReferenceCommand);
                NameCasingConvention = DotMake.CommandLine.CliNameCasingConvention.KebabCase;
                NamePrefixConvention = DotMake.CommandLine.CliNamePrefixConvention.DoubleHyphen;
                ShortFormPrefixConvention = DotMake.CommandLine.CliNamePrefixConvention.SingleHyphen;
                ShortFormAutoGenerate = true;
            }

            private TestApp.Commands.NullableReferenceCommand.Required CreateInstance()
            {
                return System.Activator.CreateInstance<TestApp.Commands.NullableReferenceCommand.Required>();
            }

            /// <inheritdoc />
            public override System.CommandLine.CliCommand Build()
            {
                // Command for 'Required' class
                var command = new System.CommandLine.CliCommand("required")
                {
                };

                var defaultClass = CreateInstance();

                // Option for 'Opt' property
                var option0 = new System.CommandLine.CliOption<string>
                (
                    "--opt"
                )
                {
                    Description = "Option with required keyword with no default value (should be required)",
                    Required = true,
                    CustomParser = GetArgumentParser<string>
                    (
                        null
                    ),
                };
                option0.AcceptOnlyFromAmong(new[] {"Big", "Small"});
                option0.Aliases.Add("-o");
                command.Add(option0);

                // Option for 'OptDefault' property
                var option1 = new System.CommandLine.CliOption<string>
                (
                    "--opt-default"
                )
                {
                    Description = "Option with required keyword with default value (should not be required)",
                    Required = false,
                    DefaultValueFactory = _ => defaultClass.OptDefault,
                    CustomParser = GetArgumentParser<string>
                    (
                        null
                    ),
                };
                option1.AcceptOnlyFromAmong(new[] {"Big", "Small"});
                command.Add(option1);

                // Argument for 'Arg' property
                var argument0 = new System.CommandLine.CliArgument<string>
                (
                    "arg"
                )
                {
                    Description = "Argument with required keyword with no default value (should be required)",
                    CustomParser = GetArgumentParser<string>
                    (
                        null
                    ),
                };
                command.Add(argument0);

                // Argument for 'ArgDefault' property
                var argument1 = new System.CommandLine.CliArgument<string>
                (
                    "arg-default"
                )
                {
                    Description = "Argument with required keyword with default value (should not be required)",
                    DefaultValueFactory = _ => defaultClass.ArgDefault,
                    CustomParser = GetArgumentParser<string>
                    (
                        null
                    ),
                };
                command.Add(argument1);

                // Add nested or external registered children
                foreach (var child in Children)
                {
                    command.Add(child.Build());
                }

                Binder = (parseResult) =>
                {
                    var targetClass = CreateInstance();

                    //  Set the parsed or default values for the options
                    targetClass.Opt = GetValueForOption(parseResult, option0);
                    targetClass.OptDefault = GetValueForOption(parseResult, option1);

                    //  Set the parsed or default values for the arguments
                    targetClass.Arg = GetValueForArgument(parseResult, argument0);
                    targetClass.ArgDefault = GetValueForArgument(parseResult, argument1);

                    //  Set the values for the parent command accessors

                    return targetClass;
                };

                command.SetAction(parseResult =>
                {
                    var targetClass = (TestApp.Commands.NullableReferenceCommand.Required) Bind(parseResult);

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
                var commandBuilder = new TestApp.Commands.GeneratedCode.NullableReferenceCommandBuilder.RequiredBuilder();

                // Register this command builder so that it can be found by the definition class
                // and it can be found by the parent definition class if it's a nested/external child.
                commandBuilder.Register();
            }
        }
    }
}
