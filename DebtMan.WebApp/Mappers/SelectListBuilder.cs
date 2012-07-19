using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace DebtMan.WebApp.Mappers
{
    public static class SelectListBuilder
    {
        public static IEnumerable<SelectListItem> FromEnum(Type enumType)
        {
            var enumNames = Enum.GetNames(enumType);

            return
                from enumName in enumNames
                let displayAttribute = GetAttribute<DisplayAttribute>(enumType, enumName)
                let bestNameToUse = (displayAttribute != null) ? displayAttribute.GetName() : enumName
                select new SelectListItem { Text = bestNameToUse, Value = bestNameToUse };
        }

        private static T GetAttribute<T>(Type enumType, string enumName) where T : Attribute
        {
            var memberInfo = enumType.GetMember(enumName).FirstOrDefault();

            if (memberInfo == null)
                return null;

            return memberInfo.GetCustomAttributes(typeof(T), false).FirstOrDefault() as T;
        }
    }
}
