using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DebtMan.DomainModel
{
    public static class CompanyExtensions
    {
        public static string CompanyToDisplayName(this Company company)
        {
            var enumName = company.ToString();
            var displayAttribute = GetAttribute<DisplayAttribute>(typeof(Company), enumName);
            return displayAttribute != null ? displayAttribute.GetName() : enumName;
        }

        public static Company DisplayNameToCompany(this string companyName)
        {
            Company result;

            if (Dictionary.TryGetValue(companyName, out result))
                return result;

            throw new ArgumentException("companyName");
        }

        private static T GetAttribute<T>(Type enumType, string enumName) where T : Attribute
        {
            var memberInfo = enumType.GetMember(enumName).FirstOrDefault();

            if (memberInfo == null)
                return null;

            return memberInfo.GetCustomAttributes(typeof(T), false).FirstOrDefault() as T;
        }

        private static Dictionary<string, Company> _dictionary;

        private static Dictionary<string, Company> Dictionary
        {
            get
            {
                if (_dictionary == null) {
                    _dictionary = new Dictionary<string, Company>();
                    var enumType = typeof(Company);
                    var enumValues = Enum.GetValues(enumType);
                    foreach (Company enumValue in enumValues)
                    {
                        var enumName = enumValue.ToString();
                        var displayAttribute = GetAttribute<DisplayAttribute>(enumType, enumName);
                        if (displayAttribute != null)
                            _dictionary.Add(displayAttribute.GetName(), enumValue);
                    }
                }

                return _dictionary;
            }
        }
    }
}
