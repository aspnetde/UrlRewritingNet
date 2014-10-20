using System;
using UrlRewritingNet.Configuration;

namespace UrlRewritingNet.Web
{
    public abstract class RewriteRule
    {
        private RedirectOption _redirect = RedirectOption.None;

        public RedirectOption Redirect
        {
            get { return _redirect; }
            set { _redirect = value; }
        }

        private RewriteOption _rewrite = RewriteOption.Application;

        public RewriteOption Rewrite
        {
            get { return _rewrite; }
            set { _rewrite = value; }

        }

        public string Name { get; internal set; }

        private RedirectModeOption _redirectMode = RedirectModeOption.Temporary;

        public RedirectModeOption RedirectMode
        {
            get { return _redirectMode; }
            set { _redirectMode = value; }
        }
        private RewriteUrlParameterOption _rewriteUrlParameter = RewriteUrlParameterOption.ExcludeFromClientQueryString;

        public RewriteUrlParameterOption RewriteUrlParameter
        {
            get { return _rewriteUrlParameter; }
            set { _rewriteUrlParameter = value; }
        }

        private bool _ignoreCase;

        public bool IgnoreCase
        {
            get { return _ignoreCase; }
            set { _ignoreCase = value; }
        }

        public abstract bool IsRewrite(string requestUrl);
        public abstract string RewriteUrl(string url);

        public virtual void Initialize(RewriteSettings rewriteSettings)
        {
            if (rewriteSettings == null)
                throw new ArgumentNullException("rewriteSettings");

            _redirect = rewriteSettings.Redirect;
            _rewrite = rewriteSettings.Rewrite;
            _redirectMode = rewriteSettings.RedirectMode;
            _rewriteUrlParameter = rewriteSettings.RewriteUrlParameter;
            _ignoreCase = rewriteSettings.IgnoreCase;

            Name = rewriteSettings.Name;
        }
    }
}
