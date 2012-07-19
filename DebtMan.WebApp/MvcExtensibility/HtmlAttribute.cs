using System.Web;

namespace DebtMan.WebApp.MvcExtensibility
{
    // http://stackoverflow.com/questions/3800473/how-to-concisely-create-optional-html-attributes-with-razor-view-engine/4232630#4232630
    public class HtmlAttribute : IHtmlString
    {
        private string _internalValue = string.Empty;
        private readonly string _seperator;

        public string Name { get; set; }
        public string Value { get; set; }
        public bool Condition { get; set; }

        public HtmlAttribute(string name)
            : this(name, null)
        {
        }

        public HtmlAttribute(string name, string seperator)
        {
            Name = name;
            _seperator = seperator ?? " ";
        }

        public HtmlAttribute Add(string value)
        {
            return Add(value, true);
        }

        public HtmlAttribute Add(string value, bool condition)
        {
            if (!string.IsNullOrWhiteSpace(value) && condition)
                _internalValue += value + _seperator;

            return this;
        }

        public string ToHtmlString()
        {
            if (!string.IsNullOrWhiteSpace(_internalValue))
                _internalValue = string.Format("{0}=\"{1}\"", Name, _internalValue.Substring(0, _internalValue.Length - _seperator.Length));

            return _internalValue;
        }
    }
}
