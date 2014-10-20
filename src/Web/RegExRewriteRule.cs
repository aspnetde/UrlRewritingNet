using System.Text.RegularExpressions;
using UrlRewritingNet.Configuration;

namespace UrlRewritingNet.Web
{
    public class RegExRewriteRule : RewriteRule
    {
        private Regex _regex;

        public override void Initialize(RewriteSettings rewriteSettings)
        {
            base.Initialize(rewriteSettings);
            
            RegexOptions = rewriteSettings.GetEnumAttribute("regexOptions", RegexOptions.None);
            VirtualUrl = rewriteSettings.GetAttribute("virtualUrl", "");
            _destinationUrl = rewriteSettings.GetAttribute("destinationUrl", "");
        }

        private void CreateRegEx()
        {
            var urlHelper = new UrlHelper();

            if (IgnoreCase)
                _regex = new Regex(urlHelper.HandleRootOperator(_virtualUrl), RegexOptions.IgnoreCase | RegexOptions.Compiled | _regexOptions);
            else
                _regex = new Regex(urlHelper.HandleRootOperator(_virtualUrl), RegexOptions.Compiled | _regexOptions);
        }

        private string _virtualUrl = string.Empty;

        public string VirtualUrl
        {
            get { return _virtualUrl; }
            set
            {
                _virtualUrl = value;
                CreateRegEx();
            }
        }

        private string _destinationUrl = string.Empty;

        public string DestinationUrl
        {
            get { return _destinationUrl; }
            set { _destinationUrl = value; }
        }

        private RegexOptions _regexOptions = RegexOptions.None;

        public RegexOptions RegexOptions
        {
            get { return _regexOptions; }
            set
            {
                _regexOptions = value;
                CreateRegEx();
            }
        }

        public override bool IsRewrite(string requestUrl)
        {
            return _regex.IsMatch(requestUrl);
        }

        public override string RewriteUrl(string url)
        {
            return _regex.Replace(url, _destinationUrl, 1);
        }
    }
}
