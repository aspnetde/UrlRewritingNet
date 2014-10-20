using System.Configuration;

namespace UrlRewritingNet.Configuration
{
    [ConfigurationCollection(typeof(RewriteSettings))]
    public sealed class RewriteSettingsCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement() 
        {
            return new RewriteSettings();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((RewriteSettings)element).Name;
        }

        public RewriteSettings this[int index]
        {
            get
            {
                return (RewriteSettings)BaseGet(index);
            }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                
                BaseAdd(index, value);
            }
        }

        new public RewriteSettings this[string key]
        {
            get
            {
                return (RewriteSettings)BaseGet(key);
            }
        }
    }
}
