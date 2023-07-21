using System;
using System.Security;

namespace CustomCommands.Framework
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
                $"Source: {utils.HandleString(source, utils.UnknownString)}",
                $"Message: {msg}"
            });

            Console.WriteLine(message);
        }

        public void HandleArgumentException(ArgumentException exception)
        {
            string msg = exception.Message;
            string onParam = utils.HandleIsNull<string>(exception.ParamName, string.Empty);
            string source = utils.HandleIsNull<string>(exception.Source, string.Empty);
            string message = utils.AdjustString("[An Argument Exception Occurred]", new string[]
            {
                $"On Parameter: {utils.HandleString(onParam, "undefined")}",
                $"Source: {utils.HandleString(source, utils.UnknownString)}",
                $"Message: {msg}"
            });

            Console.WriteLine(message);
        }

        public void HandleIOException(IOException exception)
        {
            string msg = exception.Message;
            string source = utils.HandleIsNull<string>(exception.Source, string.Empty);
            string message = utils.AdjustString("[An IO Exception Occurred]", new string[]
            {
                $"Source: {utils.HandleString(source, utils.UnknownString)}",
                $"Message: {msg}"
            });

            Console.WriteLine(message);
        }

        public void HandleSecurityException(SecurityException exception)
        {
            string msg = exception.Message;
            string source = utils.HandleIsNull<string>(exception.Source, string.Empty);
            string permissionState = utils.HandleIsNull<string>(exception.PermissionState, string.Empty);
            string demanded = utils.HandleObject(exception.Demanded);
            string message = utils.AdjustString("[An Security Exception Occurred]", new string[]
            {
                $"Source: {utils.HandleString(source, utils.UnknownString)}",
                $"Message: {msg}",
                $"Permission State: {utils.HandleString(permissionState, utils.UnknownString)}",
                $"Demanded: {demanded}"
            });

            Console.WriteLine(message);
        }
    }
}
