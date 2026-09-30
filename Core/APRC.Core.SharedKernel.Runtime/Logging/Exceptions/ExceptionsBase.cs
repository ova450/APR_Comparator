using System;

namespace APRC.Core.SharedKernel.GlobalServices.Logging.Exceptions
{
    internal static class Extensions
    {
        internal static string NonZeroValue(this string variable, string prefix = " //", string suffix = ".")
        {
            bool isnull = variable != null && variable != string.Empty;
            return isnull ? prefix + variable : string.Empty;
        }
    }

    internal abstract class LoggingExceptionAbstract : Exception 
    {
        internal LoggingExceptionAbstract(string typename, string comment = null, Exception exception = null, object paramvalue = null, string paramname = null)
            : base(GetMessage(typename, comment, exception,paramvalue,paramname), exception) { }

        static string GetMessage(string typename, string comment, Exception exception, object paramvalue, string paramname)
        {
            string res = typename + "."
              + paramname.NonZeroValue(" //Wrong parameter /name: ")
              + (paramvalue ??= string.Empty)
              + paramvalue.ToString() != string.Empty ? paramvalue.ToString().NonZeroValue(" /value: ") : string.Empty
              + exception.Message.NonZeroValue()
              + comment.NonZeroValue();
            return res;
        }
    }
}


