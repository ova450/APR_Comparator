using Serilog.Events;

namespace APRC.Core.SharedKernel.GlobalServices.Logging.Templates
{

    public static class GlobalContextTemplates
    {
        #region Old GlobalContext templates 
        public static string gcTemplate(this string message) => $"{GlobalContext.GetAsString} {message}";

        public static string gcTemplate(this string message, string variable = null)
            => $"{GlobalContext.GetAsString}" + $" = {variable}{(message == null ? "" : " // " + message)}";

        public static string gcTemplateException(this Exception exception, LogEventLevel level)
        {
            string result = $"The logging system took an exception as an input parameter and threw a {level} level exception. See accepted exception in inner exception.";
            return gcTemplate(exception.ToString(), exception.Message + " // " + result);
        }

        public static string gcTemplateHandled(this Exception exception, string message, LogEventLevel level)
        {
            string result = $"{GlobalContext.GetAsString} was caught by the logging system and recognised as {level}";
            return gcTemplate(exception.ToString(), message + " // " + result);
        }

        public static string TemplateReferenceType(this object variable, string message, bool withparam = true)
            => gcTemplate(variable.ToString(), message);

        #endregion
        
        #region New GlobalContext templates

        public static string GlobalContextTemplate(this Abstractions.TemplateTermList message) => $"{GlobalContext.GetAsString} {message}";
        public static string GlobalContextTemplate(this TemplateTerm message) => $"{GlobalContext.GetAsString} {message}";
        //internal static string GlobalContextTemplate(this string message) => $"{GlobalContext.GetAsString} {message}";

        #endregion
    }



}

