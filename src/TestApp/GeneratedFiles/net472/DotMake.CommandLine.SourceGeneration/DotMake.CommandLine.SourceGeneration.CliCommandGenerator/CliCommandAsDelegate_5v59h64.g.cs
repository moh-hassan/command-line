﻿// <auto-generated />
// Generated by DotMake.CommandLine.SourceGeneration v1.8.7.0
// Roslyn (Microsoft.CodeAnalysis) v4.900.24.12101
// Generation: 1

namespace GeneratedCode
{
    /// <inheritdoc />
    [DotMake.CommandLine.CliCommandAttribute]
    public class CliCommandAsDelegate_5v59h64 : DotMake.CommandLine.CliCommandAsDelegate
    {
        /// <inheritdoc />
        [DotMake.CommandLine.CliArgumentAttribute]
        public string argument1 { get; set; }

        /// <inheritdoc />
        [DotMake.CommandLine.CliOptionAttribute]
        public bool option1 { get; set; }

        /// <inheritdoc />
        public void Run()
        {
            InvokeDelegate
            (
                "5v59h64",
                new object[]
                {
                    argument1, 
                    option1, 
                }
            );
        }

        [System.Runtime.CompilerServices.ModuleInitializerAttribute]
        internal static void Initialize()
        {
            // Register this definition class so that it can be found by the command as delegate hash.
            Register<GeneratedCode.CliCommandAsDelegate_5v59h64>("5v59h64");
        }
    }
}
