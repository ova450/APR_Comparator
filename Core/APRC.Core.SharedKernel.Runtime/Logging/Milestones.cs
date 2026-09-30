using APRC.Core.SharedKernel.GlobalServices.Logging.Templates;
using Serilog;
using System.Runtime.CompilerServices;
using static APRC.Core.SharedKernel.GlobalServices.Logging.GlobalContext;

namespace APRC.Core.SharedKernel.GlobalServices.Logging
{
    /// <summary>
    /// The LogMilestone class provides methods for logging events related to the execution of a single method, namely:
    /// - logMilestoneValue logs the current value of the variable;
    /// - logMilestoneOpen logs the entry point to the method;
    /// - logMilestoneClose  logs the method exit point;
    /// 
    /// The new log entry contains info about Logging Global Context, including:
    /// - filename of file that contains given method;
    /// - methodname of given method;
    /// - linenumber of calling milestone;
    /// - for milestones that contains single variable as parameter adds name and value this variable to the log entry.
    /// 
    /// For milestone with parameter will be set LogEventLevel.Debug else Verbose.
    /// </summary>
    public static partial class Milestones
    {
        public enum msMode { opened, closed }
        public static msMode Open = msMode.opened;
        public static msMode Close = msMode.closed;

        static string msMilestoneOnlyMessage(msMode mode) => $"Code block has been {mode}.";

        private static void logMilestone(this msMode mode, object message = null)
            => Log.Verbose($"{msMilestoneOnlyMessage(mode)}{(message is null || message.ToString().Length==0 ? string.Empty : " // " + message)}".gcTemplate());

        /// <summary>
        /// Writes only MilestoneOpen to mark the start of a method or block of code, with no message or parameter.
        /// </summary>
        /// <param name="message">Additional message from MilestoneOpen</param>
        /// <param name="filepath">Optional global context variable, do not change it.</param>
        /// <param name="methodname">Optional global context variable, do not change it.</param>
        /// <param name="linenumber">Optional global context variable, do not change it.</param>
        public static void logMilestoneOpen(object message = null,
            [CallerFilePath] string filepath = "", [CallerMemberName] string methodname = "", [CallerLineNumber] int linenumber = 0)
        {
            SetGlobalContext(filepath, methodname, linenumber);
            Open.logMilestone(message);
        }

        /// <summary>
        /// Writes only MilestoneClose to mark the end of a method or block of code, with no message or parameter.
        /// </summary>
        /// <param name="message">Additional message from MilestoneClose</param>
        /// <param name="filepath">Optional global context variable, do not change it.</param>
        /// <param name="methodname">Optional global context variable, do not change it.</param>
        /// <param name="linenumber">Optional global context variable, do not change it.</param>
        public static void logMilestoneClose(object message = null, 
            [CallerFilePath] string filepath = "", [CallerMemberName] string methodname = "", [CallerLineNumber] int linenumber = 0)
        {
            SetGlobalContext(filepath, methodname, linenumber);
            Close.logMilestone(message);
        }
    }
}
