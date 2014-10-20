using System.Configuration;

namespace UrlRewritingNet.Configuration
{
    public sealed class UrlRewriteSection : ConfigurationSection
    {
        [ConfigurationProperty("rewriteOnlyVirtualUrls", DefaultValue = true)]
        public bool RewriteOnlyVirtualUrls
        {
            get
            {
                return (bool)base["rewriteOnlyVirtualUrls"];
            }
            set
            {
                base["rewriteOnlyVirtualUrls"] = value;
            }
        }

        [ConfigurationProperty("defaultProvider", IsRequired = false, DefaultValue = "RegEx")]
        public string DefaultProvider
        {
            get
            {
                return (string)base["defaultProvider"];
            }
            set
            {
                base["defaultProvider"] = value;
            }
        }

        [ConfigurationProperty("defaultPage", IsRequired = false, DefaultValue = "")]
        public string DefaultPage
        {
            get
            {
                return (string)base["defaultPage"];
            }
            set
            {
                base["defaultPage"] = value;
            }
        }

        [ConfigurationProperty("providers")]
        public ProviderSettingsCollection Providers
        {
            get
            {
                return (ProviderSettingsCollection)base["providers"];
            }
        }

        [ConfigurationProperty("rewrites")]
        public RewriteSettingsCollection Rewrites
        {
            get
            {
                return (RewriteSettingsCollection)base["rewrites"];
            }
        }

        [ConfigurationProperty("contextItemsPrefix", DefaultValue = "")]
        public string ContextItemsPrefix
        {
            get
            {
                return (string)base["contextItemsPrefix"];
            }
            set
            {
                base["contextItemsPrefix"] = value;
            }
        }

        [ConfigurationProperty("xmlns", DefaultValue = "")]
        public string XmlNs
        {
            get
            {
                return (string)base["xmlns"];
            }
            set
            {
                base["xmlns"] = value;
            }
        }
    }
}
