using System;
using System.Runtime.InteropServices;

namespace net.r_eg.BugsReview.NJ.CoreLibrary
{
    /// <summary>
    /// Type of available processing modes
    /// </summary>
    [Guid("F7E15CE6-F7B1-44A6-AB55-62F1C8BEDE26")]
    public enum ModeType
    {
        /// <summary>
        /// External handling with files.
        /// </summary>
        File,

        /// <summary>
        /// Processing with external interpreter.
        /// generally, it's a stream processor etc.
        /// </summary>
        Interpreter,

        /// <summary>
        /// DTE-commands - operations with EnvDTE.
        /// </summary>
        Operation,

        /// <summary>
        /// Script processing.
        /// generally, it's internal handling with MSBuild / SBE-Scripts cores, and similar
        /// </summary>
        Script,

        /// <summary>
        /// MSBuild targets
        /// </summary>
        Targets,

        /// <summary>
        /// C# code
        /// </summary>
        CSharp,
    }
}
