using System;
using UrlRewritingNet.Configuration.Provider;
using System.Web.Configuration;
using UrlRewritingNet.Configuration;
using System.Configuration;
using System.Web;

namespace UrlRewritingNet.Web
{
    static public class UrlRewriting
    {
        static UrlRewritingProviderCollection providers;

        static bool initialized;

        static private void Initialize()
        {
            if (!initialized)
            {
                providers = new UrlRewritingProviderCollection();
                ProvidersHelper.InstantiateProviders(Configuration.Providers, providers, typeof(UrlRewritingProvider));
                if (providers["RegEx"] == null)
                {
                    var prov = new RegExUrlRewritingProvider();
                    providers.Add(prov);
                }

                if (providers[Configuration.DefaultProvider] == null)
                {
                    string msg = string.Format("Missing the DefaultProvider {0} in the list of providers for UrlRewritingNet", Configuration.DefaultProvider);
                    throw new ApplicationException(msg);
                }
                initialized = true;
            }
        }

        static private UrlRewriteSection configuration;
        static private object configurationLock = new object();

        static public UrlRewriteSection Configuration
        {
            get
            {
                if (configuration == null)
                {
                    lock (configurationLock)
                    {
                        if (configuration == null)
                        {
                            var tmpConf = (UrlRewriteSection)ConfigurationManager.GetSection("urlrewritingnet");
                            configuration = tmpConf;
                        }
                    }
                }
                return configuration;
            }
        }

        static public UrlRewritingProviderCollection Providers
        {
            get
            {
                Initialize();
                return providers;
            }
        }

        static public RewriteRule CreateRewriteRule()
        {
            return CreateRewriteRule(Configuration.DefaultProvider);
        }

        public static RewriteRule CreateRewriteRule(string providerName)
        {
            if (providerName == null)
                throw new ArgumentNullException("providerName");

            UrlRewritingProvider provider = Providers[providerName];
            if (provider == null)
            {
                string msg = string.Format("Unknown UrlRewritingProvider {0} in list of rules", providerName);
                throw new ArgumentException(msg, "providerName");
            }
            return provider.CreateRewriteRule();
        }

        public static void AddRewriteRule(string ruleName, RewriteRule rewriteRule)
        {
            if (rewriteRule == null)
                throw new ArgumentNullException("rewriteRule");
            rewriteRule.Name = ruleName;
            HttpModuleCollection modules = HttpContext.Current.ApplicationInstance.Modules;
            foreach (string moduleName in modules)
            {
                UrlRewriteModule rewriteModule = modules[moduleName] as UrlRewriteModule;
                if (rewriteModule != null)
                {
                    rewriteModule.AddRewriteRuleInternal(rewriteRule);
                }
            }
        }

        public static void RemoveRewriteRule(string ruleName)
        {
            HttpModuleCollection modules = HttpContext.Current.ApplicationInstance.Modules;
            foreach (string moduleName in modules)
            {
                UrlRewriteModule rewriteModule = modules[moduleName] as UrlRewriteModule;
                if (rewriteModule != null)
                {
                    rewriteModule.RemoveRewriteRuleInternal(ruleName);
                }
            }
        }

        public static void ReplaceRewriteRule(string ruleName, RewriteRule rewriteRule)
        {
            if (rewriteRule == null)
                throw new ArgumentNullException("rewriteRule");
            rewriteRule.Name = ruleName;
            HttpModuleCollection modules = HttpContext.Current.ApplicationInstance.Modules;
            foreach (string moduleName in modules)
            {
                UrlRewriteModule rewriteModule = modules[moduleName] as UrlRewriteModule;
                if (rewriteModule != null)
                {
                    rewriteModule.ReplaceRewriteRuleInternal(ruleName, rewriteRule);
                }
            }
        }

        public static void InsertRewriteRule(string positionRuleName, string ruleName, RewriteRule rewriteRule)
        {
            if (rewriteRule == null)
                throw new ArgumentNullException("rewriteRule");
            rewriteRule.Name = ruleName;
            HttpModuleCollection modules = HttpContext.Current.ApplicationInstance.Modules;
            foreach (string moduleName in modules)
            {
                UrlRewriteModule rewriteModule = modules[moduleName] as UrlRewriteModule;
                if (rewriteModule != null)
                {
                    rewriteModule.InsertRewriteRuleBeforeInternal( positionRuleName, ruleName, rewriteRule);
                }
            }
        }
    }
}
