// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using CommandLine;
using Microsoft.DotNet.Darc.Operations;

namespace Microsoft.DotNet.Darc.Options
{
    [Verb("gather-drop", HelpText = "Gather a drop of the outputs for a build")]
    internal class GatherDropCommandLineOptions : CommandLineOptions
    {
        [Option('i', "id", SetName = "rootbuild", HelpText = "BAR ID of build.")]
        public int RootBuildId { get; set; }

        [Option('r', "repo", SetName = "rootbuild", HelpText = "If set, gather a build drop for a build of this repo. Requires --commit.")]
        public string RepoUri { get; set; }

        [Option('c', "commit", HelpText = "Branch, commit or tag to look up and gather a build drop for.")]
        public string Commit { get; set; }

        [Option('o',"output-dir", Required = true, HelpText = "Output directory to place build drop.")]
        public string OutputDirectory { get; set; }

        [Option('f', "full", HelpText = "Gather the full drop (build and all input builds).")]
        public bool Transitive { get; set; }

        [Option('s', "separated", HelpText = "Separate out each source repo in the drop into separate directories.")]
        public bool Separated { get; set; }

        [Option("continue-on-error", HelpText = "Continue on error rather than halting.")]
        public bool ContinueOnError { get; set; }

        [Option("non-shipping", HelpText = "Include non-shipping assets.")]
        public bool IncludeNonShipping { get; set; }

        [Option("overwrite", HelpText = "Overwrite existing files at the destination.")]
        public bool Overwrite { get; set; }

        [Option("dry-run", HelpText = "Do not actually download files, but print what we would do.")]
        public bool DryRun { get; set; }

        [Option("include-toolset", HelpText = "Include toolset dependencies.")]
        public bool IncludeToolset { get; set; }

        public override Operation GetOperation()
        {
            return new GatherDropOperation(this);
        }
    }
}
