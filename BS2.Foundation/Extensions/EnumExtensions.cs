using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BS2.Foundation.Extensions
{
    public static class EnumExtensions
    {
        public static string DisplayDescription(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attributes = field.GetCustomAttributes(false);

            DisplayAttribute displayAttribute = null;

            if (attributes.Any())
            {
                displayAttribute = attributes.ElementAt(0).As<DisplayAttribute>();
            }

            return displayAttribute?.Description ?? "Display description not found.";
        }

        public static string TryDisplayDescription(this Enum value, string defaultValue = null)
        {
            try
            {
                return value.DisplayDescription();
            }
            catch
            {
                return defaultValue;
            }
        }
    }
}