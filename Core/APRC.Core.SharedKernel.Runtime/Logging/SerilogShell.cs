using APRC.Core.SharedKernel.GlobalServices.Logging.Exceptions;
using APRC.Core.SharedKernel.GlobalServices.Logging.Templates;
using APRC.Core.SharedKernel.GlobalServices.Logging.Hosting.Serilog;
using APRC.Core.SharedKernel.GlobalServices.Logging.Hosting.Serilog.Events;
using System.Runtime.CompilerServices;
using static APRC.Core.SharedKernel.GlobalServices.Logging.GlobalContext;

namespace APRC.Core.SharedKernel.Runtime.Logging
{
    /// <summary>
    /// Static class providing logging simple methods according to the event level.
    /// </summary>
    public static class SerilogShell
    {
        #region Simple methods

        /// <summary>
        /// Writes a Verbose level message to the log.
        /// </summary>
        /// <param name="message">Message of event.</param>
        /// <param name="filepath">Optional global context variable, do not change it.</param>
        /// <param name="methodname">Optional global context variable, do not change it.</param>
        /// <param name="linenumber">Optional global context variable, do not change it.</param>
        public static void logVerbose(string message, [CallerFilePath] string filepath = "", [CallerMemberName] string methodname = "", [CallerLineNumber] int linenumber = 0)
        { SetGlobalContext(filepath, methodname, linenumber); Log.Verbose(message.gcTemplate()); }

        /// <summary>
        /// Writes a Debug level message to the log.
        /// </summary>
        /// <param name="message">Message of event.</param>
        /// <param name="filepath">Optional global context variable, do not change it.</param>
        /// <param name="methodname">Optional global context variable, do not change it.</param>
        /// <param name="linenumber">Optional global context variable, do not change it.</param>
        public static void logDebug(string message, [CallerFilePath] string filepath = "", [CallerMemberName] string methodname = "", [CallerLineNumber] int linenumber = 0)
        { SetGlobalContext(filepath, methodname, linenumber); Log.Debug(message.gcTemplate()); }

        /// <summary>
        /// Writes a Indormation level message to the log.
        /// </summary>
        /// <param name="message">Message of event.</param>
        /// <param name="filepath">Optional global context variable, do not change it.</param>
        /// <param name="methodname">Optional global context variable, do not change it.</param>
        /// <param name="linenumber">Optional global context variable, do not change it.</param>
        public static void logIndormation(string message, [CallerFilePath] string filepath = "", [CallerMemberName] string methodname = "", [CallerLineNumber] int linenumber = 0)
        { SetGlobalContext(filepath, methodname, linenumber); Log.Information(message.gcTemplate()); }

        /// <summary>
        /// Writes a Warning level message to the log.
        /// </summary>
        /// <param name="message">Message of event.</param>
        /// <param name="filepath">Optional global context variable, do not change it.</param>
        /// <param name="methodname">Optional global context variable, do not change it.</param>
        /// <param name="linenumber">Optional global context variable, do not change it.</param>
        public static void logWarning(string message, [CallerFilePath] string filepath = "", [CallerMemberName] string methodname = "", [CallerLineNumber] int linenumber = 0)
        { SetGlobalContext(filepath, methodname, linenumber); Log.Warning(message.gcTemplate()); }

        /// <summary>
        /// Writes an Error level message to the log. The method is simple and works without exception handling, but has an overload with exception handling.
        /// </summary>
        /// <param name="message">Message of event.</param>
        /// <param name="filepath">Optional global context variable, do not change it.</param>
        /// <param name="methodname">Optional global context variable, do not change it.</param>
        /// <param name="linenumber">Optional global context variable, do not change it.</param>
        public static void logError(string message, [CallerFilePath] string filepath = "", [CallerMemberName] string methodname = "", [CallerLineNumber] int linenumber = 0)
        { SetGlobalContext(filepath, methodname, linenumber); Log.Error(message.gcTemplate()); }

        #endregion

        #region Difficult method

        /// <summary>
        /// Writes a Fatal level message to the log. This method is simple and works without exception handling, but once logs, the method throws an exception to the caller.
        /// </summary>
        /// <param name="message">Message of event.</param>
        /// <param name="filepath">Optional global context variable, do not change it.</param>
        /// <param name="methodname">Optional global context variable, do not change it.</param>
        /// <param name="linenumber">Optional global context variable, do not change it.</param>
        public static void logFatal(string message,
            [CallerFilePath] string filepath = "", [CallerMemberName] string methodname = "", [CallerLineNumber] int linenumber = 0)
        {
            SetGlobalContext(filepath, methodname, linenumber);
            FatalException ex = new(message);
            Log.Fatal(ex.gcTemplateException(LogEventLevel.Fatal));
            //throw ex;
        }

        public static void logFatal(string message, Exception exceptiion,
            [CallerFilePath] string filepath = "", [CallerMemberName] string methodname = "", [CallerLineNumber] int linenumber = 0)
        {
            SetGlobalContext(filepath, methodname, linenumber);
            FatalException ex = new(message,exceptiion);
            Log.Fatal(ex.gcTemplateException(LogEventLevel.Fatal));
            throw ex;
        }


        //public static void logError(string message, Exception exceptiion,
        //    [CallerFilePath] string filepath = "", [CallerMemberName] string methodname = "", [CallerLineNumber] int linenumber = 0)
        //{
        //    SetGlobalContext(filepath, methodname, linenumber);
        //    Log.Error(exception.gcTemplateException(message, LogEventLevel.Error));
        //    throw exception;
        //}

        #endregion 


        //public delegate void OnError<T>(ref T p);

        //public static void logError<T>(string comment, ref T wronginstance, OnError<T> OnErrotHadler = null, Exception exception = null,
        //    [CallerArgumentExpression("wronginstance")] string paramname = null,
        //    [CallerFilePath] string filepath = null, [CallerMemberName] string methodname = null, [CallerLineNumber] int linenumber = 0)
        //{
        //    SetGlobalContext(filepath, methodname, linenumber, paramname);

        //    if (OnErrotHadler != null)
        //    {
        //        OnErrotHadler.Invoke(ref wronginstance);

        //    }
        //    Log.Error(comment.gcTemplate());

    }
}

