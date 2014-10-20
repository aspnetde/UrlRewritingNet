using System;
using System.Configuration;
using UrlRewritingNet.Web;
using System.Collections.Specialized;

namespace UrlRewritingNet.Configuration
{
    public class RewriteSettings : ConfigurationElement
    {
        [ConfigurationProperty("provider", IsRequired = false)]
        public string Provider
        {
            get
            {
                return (string)base["provider"];
            }
            set
            {
                base["ruleProvider"] = value;
            }
        }

        [ConfigurationProperty("name", IsRequired = true)]
        public string Name
        {
            get
            {
                return (string)base["name"];
            }
            set
            {
                base["name"] = value;
            }
        }

        [ConfigurationProperty("redirect", IsRequired = false, DefaultValue = RedirectOption.None)]
        public RedirectOption Redirect
        {
            get
            {
                return (RedirectOption)base["redirect"];
            }
            set
            {
                base["redirect"] = value;
            }
        }

        [ConfigurationProperty("rewrite", IsRequired = false, DefaultValue = RewriteOption.Application)]
        public RewriteOption Rewrite
        {
            get
            {
                return (RewriteOption)base["rewrite"];
            }
            set
            {
                base["rewrite"] = value;
            }
        }

        [ConfigurationProperty("redirectMode", IsRequired = false, DefaultValue = RedirectModeOption.Temporary)]
        public RedirectModeOption RedirectMode
        {
            get
            {
                return (RedirectModeOption)base["redirectMode"];
            }
            set
            {
                base["redirectMode"] = value;
            }
        }

        [ConfigurationProperty("rewriteUrlParameter", DefaultValue = RewriteUrlParameterOption.ExcludeFromClientQueryString)]
        public RewriteUrlParameterOption RewriteUrlParameter
        {
            get
            {
                return (RewriteUrlParameterOption)base["rewriteUrlParameter"];
            }
            set
            {
                base["rewriteUrlParameter"] = value;
            }
        }

        [ConfigurationProperty("ignoreCase", IsRequired = false, DefaultValue = false)]
        public bool IgnoreCase
        {
            get
            {
                return (bool)base["ignoreCase"];
            }
            set
            {
                base["ignoreCase"] = value;
            }
        }

        private readonly NameValueCollection _attributes = new NameValueCollection();

        public NameValueCollection Attributes
        {
            get
            {
                return _attributes;
            }
        }

        public string GetAttribute(string name, string defaultValue)
        {
            if (_attributes[name] == null)
                return defaultValue;

            return _attributes[name];
        }

        public int GetInt32Attribute(string name, int defaultValue)
        {
            return _attributes[name] == null ? defaultValue : Convert.ToInt32(_attributes[name]);
        }

        public bool GetBooleanAttribute(string name, bool defaultValue)
        {
            return _attributes[name] == null ? defaultValue : bool.Parse(_attributes[name]);
        }

        public T GetEnumAttribute<T>(string name, T defaultValue)
        {
            return _attributes[name] == null ? defaultValue : (T) Enum.Parse(typeof (T), _attributes[name]);
        }

        protected override bool OnDeserializeUnrecognizedAttribute(string name, string value)
        {
            _attributes.Add(name, value);
            return true;
        }

    }
}
