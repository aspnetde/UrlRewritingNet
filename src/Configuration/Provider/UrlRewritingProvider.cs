using System.Configuration.Provider;
using UrlRewritingNet.Web;

namespace UrlRewritingNet.Configuration.Provider
{
    public abstract class UrlRewritingProvider : ProviderBase
    {
        public abstract RewriteRule CreateRewriteRule();
    }
}
