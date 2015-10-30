using UrlRewritingNet.Web;

namespace UrlRewritingNet.Configuration.Provider
{
    public class RegExUrlRewritingProvider : UrlRewritingProvider
    {
        public override string Name
        {
            get
            {
                return "RegEx";
            }
        }
        public override RewriteRule CreateRewriteRule()
        {
            return new RegExRewriteRule();
        }
    }
}
