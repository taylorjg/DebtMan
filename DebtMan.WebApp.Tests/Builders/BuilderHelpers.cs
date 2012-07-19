using System;
using System.Reflection;

namespace DebtMan.WebApp.Tests.Builders
{
    internal static class BuilderHelpers
    {
        public static void SetFieldUsingReflection(object target, string fieldName, object value)
        {
            var fieldInfo = target.GetType().GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance);

            if (fieldInfo == null) {
                throw new ApplicationException(
                    string.Format(
                        "SetFieldUsingReflection - failed to set field \"{0}\" to value \"{1}\".",
                        fieldName,
                        value));
            }

            fieldInfo.SetValue(target, value);
        }

        public static void SetIdUsingReflection(object target, int id)
        {
            SetFieldUsingReflection(target, "id", id);
        }
    }
}
