using System;

namespace UrlRewritingNet.Web
{
    [Flags] 
    public enum RewriteOption
    {
        Application = 0x00,
        Domain = 0x01
    }
}
