using System;

namespace UrlRewritingNet.Web
{
    [Flags] 
    public enum RedirectModeOption
    {
        Permanent = 0x00,
        Temporary = 0x01
    }
}
