using UrlRewritingNet.Web;

namespace UrlRewritingNet.Configuration.Provider
{
    public class RegExUrlRewritingProvider : UrlRewritingProvider
    {
        public override RewriteRule CreateRewriteRule()
        {
            return new RegExRewriteRule();
        }
    }
}
