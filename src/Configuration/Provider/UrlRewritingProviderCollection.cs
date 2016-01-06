using System;
using System.Configuration.Provider;
using System.Threading;
namespace UrlRewritingNet.Configuration.Provider
{
    public class UrlRewritingProviderCollection : ProviderCollection
    {
        private object lockObject = new object();
        public new UrlRewritingProvider this[string name]
        {
            get
            {
                return (UrlRewritingProvider)base[name];
            }
        }
        public override void Add(ProviderBase provider)
        {
            if (provider == null)
            {
                throw new ArgumentNullException("provider");
            }
            if (!(provider is UrlRewritingProvider))
            {
                string message = string.Format("Provider must implement type {0}", typeof(UrlRewritingProvider).ToString());
                throw new ArgumentException(message, "provider");
            }
            object obj;
            Monitor.Enter(obj = this.lockObject);
            try
            {
                if (base[provider.Name] == null)
                {
                    base.Add(provider);
                }
            }
            finally
            {
                Monitor.Exit(obj);
            }
        }
        public void CopyTo(UrlRewritingProvider[] providers, int index)
        {
            object obj;
            Monitor.Enter(obj = this.lockObject);
            try
            {
                base.CopyTo(providers, index);
            }
            finally
            {
                Monitor.Exit(obj);
            }
        }
    }
}
