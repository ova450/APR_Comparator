using System;
using static APRC.Core.SharedKernel.Runtime.Logging.SerilogShell;

namespace APRC.Core.SharedKernel.GlobalServices.Logging.Exceptions
{
    /// <summary>
    /// Static test class for logging events of various levels.
    /// </summary>
    public static class ExceptionsByLevelTest
    {
        static int i = 54321;

        /// <summary>
        /// Method for logging a simple fatal level event.
        /// <param name="message">Additional developer message</param>   
        /// </summary>
        public static void ExceptionFatalTest(string message=null)
        {
            try { throw new FatalException(message); }
            catch (FatalException e) { logError(e.Message); }
        }
    }
}
