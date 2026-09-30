namespace APRC.Core.SharedKernel.GlobalServices.Logging.Templates
{
    public abstract class TemplateAbstract<T>
    {
        private protected T[] _items = null;
        internal TemplateAbstract(params T[] items) => _items = items;

        internal static string GetPrefix(string prefix) => prefix;
        internal static string GetNamedItem(object item, string itemname) => item is not null && item.ToString() != string.Empty ? $"{itemname}: {item}" : null;
        internal static string GetNoNamedItem(object item) => item is not null && item.ToString() != string.Empty ? item.ToString() : null;
    }
    public abstract class TemplateTerm : TemplateAbstract<string>
    {
        internal TemplateTerm(params string[] items) : base(items) { }
        public override string ToString()
        {
            string ret = string.Empty;
            bool thisnotnull = false;
            foreach (string item in _items) { if (item is not null) { ret += " /" + item; thisnotnull = true; } }
            return thisnotnull ? " /" + ret[1..] : null;
        }
    }
    public abstract class TemplateTermList : TemplateAbstract<TemplateTerm>
    {
        internal TemplateTermList(params TemplateTerm[] items) : base(items) { }
        public override string ToString()
        {
            string ret = null;
            foreach (TemplateTerm item in _items) { if (item is not null) { ret += item; } }
            return ret is not null && ret.ToString() != string.Empty ? ret : null;
        }
    }
}

