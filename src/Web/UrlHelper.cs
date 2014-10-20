using System;
using System.Web;

namespace UrlRewritingNet.Web
{
    public class UrlHelper
    {
        private string _applicationPath;

        public UrlHelper()
        {
            _applicationPath = (HttpRuntime.AppDomainAppVirtualPath.Length > 1) ? HttpRuntime.AppDomainAppVirtualPath : String.Empty;

        }
        public string HandleRootOperator(string url)
        {
            if (string.IsNullOrEmpty(url)) 
                return url;

            if (url.StartsWith("^~/"))
                return "^" + _applicationPath + url.Substring(2);
                
            if (url.StartsWith("~/"))
                return _applicationPath + url.Substring(1);
            
            return url;
        }
    }
}
