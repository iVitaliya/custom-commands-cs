using System.Text;

namespace CustomCommands.Framework
{
    internal class Utils
    {
        public string UnknownString = "unknown";

        public T HandleIsNull<T>(T? value, T fallback_value)
        {
            T result;

            if (value is null) result = fallback_value;
            else result = value;

            return result;
        }

        public bool HandleIsEmptyObject(string value)
        {
            if (value == "{}") return true;
            else return false;
        }

        public string AdjustString(string message, string[] additions)
        {
            StringBuilder msgBldr = new StringBuilder();

            foreach (string addition in additions)
            {
                string ToString = HandleIsNull<string>(addition!.ToString(), message);
                msgBldr.Append(ToString);
            }

            return msgBldr.ToString();
        }

        public T[] HandleNonNullableArray<T>(T[] array, T? value)
        {
            T[] arr = array;

            if (value is null) return arr;
            else arr.Append(value);

            return arr;
        }

        public string HandleString(string value, string handling)
        {
            string result = string.Empty;

            if (value == string.Empty && handling == UnknownString) result = "Unknown";
            else result = handling;

            return result;
        }

        public string HandleObject(object? value)
        {
            if (value is null) return "{}";
            else return value.ToString() ?? "{}";
        }
    }
}
