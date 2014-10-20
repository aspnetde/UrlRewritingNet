using System;

namespace UrlRewritingNet.Web
{
    [Flags] 
    public enum RedirectOption
    {
        None = 0x00,
        Application = 0x01,
        Domain = 0x02
    }
}
