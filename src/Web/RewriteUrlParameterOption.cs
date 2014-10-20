using System;

namespace UrlRewritingNet.Web
{
    [Flags] 
    public enum RewriteUrlParameterOption
    {
        None = 0x00,
        ExcludeFromClientQueryString = 0x01,
        StoreInContextItems = 0x02,
        IncludeQueryStringForRewrite = 0x04
    }
}
