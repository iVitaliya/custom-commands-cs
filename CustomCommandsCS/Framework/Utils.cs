using System.Text;

namespace CustomCommandsCS.Framework
{
    internal class Utils
    {
        public T HandleIsNull<T>(T? value, T fallback_value)
        {
            T result;

            if (value is null) result = fallback_value;
            else result = value;

            return result;
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
            if (value == String.Empty && handling == "unknown") value = "Unknown";
            else value = handling;
            
            return value;
        }
    }
}
