using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomCommandsCS.Framework
{
    internal class Errors
    {
        private Utils utils = new();

        public void HandleException(Exception exception)
        {
            string msg = exception.Message;
            string source = utils.HandleIsNull<string>(exception.Source, string.Empty);
            string message = utils.AdjustString("[An Exception Occurred]", new string[]
            {
                $"Source: {utils.HandleString(source, "unknown")}",
                $"Message: {msg}"
            });

            Console.WriteLine(message);
        }

        // https://gist.github.com/iVitaliya/3e2fb92fd1f3c6085ac8cab42707a03c
    }
}
