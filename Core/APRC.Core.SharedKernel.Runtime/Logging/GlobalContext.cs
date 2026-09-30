using Serilog.Context;

namespace APRC.Core.SharedKernel.GlobalServices.Logging
{
    /// <summary>
    /// The internal static class GlobalContext is designed to set the global properties of the context, which are then available anywhere in the code.
    /// The only method of the SetGlobalContex class takes four parameters and, after setting the context, provides five properties: FilePath, FileName, MethodName, LineNumber, ParameterName.
    /// Typically, the SetGlobalContex input parameters are taken from the caller*-attributed input parameters of the calling method.    
    /// </summary>
    internal static class GlobalContext
    {

        internal static string Paramname = null;

        /// <summary>
        /// Sets five global context properties.
        /// </summary>
        /// <param name="filepath">Sets property FilePath.</param>
        /// <param name="method">Sets property MethodName.</param>
        /// <param name="linenumber">Sets property LineNumber.</param>
        /// <param name="paramname">Sets property ParameterName. By default is null.</param>
        internal static void SetGlobalContext(string filepath, string method, int linenumber, string paramname = null)
        {
            GlobalLogContext.PushProperty("FilePath", filepath);
            string fn = new System.IO.FileInfo(filepath).Name;    // substring name of file
            GlobalLogContext.PushProperty("FileName", fn.Substring(0, fn.Length - 3));   // sets short filename
            GlobalLogContext.PushProperty("MethodName", method);
            GlobalLogContext.PushProperty("LineNumber", linenumber);
            GlobalLogContext.PushProperty("ParamName", paramname);

            Paramname = !(paramname is null) ? $".{{ParamName}}" : null;
        }

        //internal static void SetGlobalContext(string paramname)
        //{
        //    GlobalLogContext.PushProperty("ParamName", paramname);

        //    Paramname = !(paramname is null) ? $".{{ParamName}}" : null;
        //}

        ////internal static string GetAsString => //$"{{Filename}}.{{Methodname}}.{{Linenumber}}" + $"{{ParameterName}}" != "" ? $".{{ParameterName}}" : "";
        //internal static string GetAsString => $"{{FileName}}.{{MethodName}}.{{LineNumber}}{Paramname}";
        internal static string GetAsString => $"{{FileName}}.{{MethodName}}.{{LineNumber}}";
    }
}

