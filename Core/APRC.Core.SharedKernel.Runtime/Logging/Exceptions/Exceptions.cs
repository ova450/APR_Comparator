using System;
using System.Runtime.CompilerServices;

namespace APRC.Core.SharedKernel.GlobalServices.Logging.Exceptions
{
    internal class FatalException : LoggingExceptionAbstract
    {
        readonly static string message = $"Fatal error detected, the application will be stopped.";

        /// <summary>
        /// Exception class of fatal level.
        /// </summary>
        /// <param name="comment">Additional message</param>
        /// <param name="exception">The outer exception accepted by the logging system, written to the inner exception of the fatal exception of the logging system.</param>
        /// <param name="paramvalue">Wrong parameter value</param>
        /// <param name="paramname">Wrong parameter name optional</param>
        internal FatalException(string comment = null, Exception exception = null, object paramvalue = null,
            [CallerArgumentExpression("paramvalue")] string paramname = null)
            : base("FatalException", comment, exception, paramvalue, paramname) { }
    }

    internal class ArgumentNullOrEmptyException : LoggingExceptionAbstract
    {
        static string message = $"Input parameter value cannot be null or an empty string.";

        internal ArgumentNullOrEmptyException(string comment = null, object paramvalue = null, [CallerArgumentExpression("paramvalue")] string paramname = null)
            : base("ArgumentNullOrEmptyException", comment, null, paramvalue, paramname) { }
    }

    internal class ArgumentUnnamedException : LoggingExceptionAbstract
    {
        static string message = $"Logging an unnamed value instead of a named variable makes no sense and is therefore unnecessary.";

        internal ArgumentUnnamedException(string comment = null, object paramvalue = null, [CallerArgumentExpression("paramvalue")] string paramname = null)
            : base("ArgumentUnnamedException", comment, null, paramvalue, paramname) { }
    }
}


