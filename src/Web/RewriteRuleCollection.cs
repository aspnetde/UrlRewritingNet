using System;
using System.Collections.Generic;

namespace UrlRewritingNet.Web
{
    internal class RewriteRuleCollection : List<RewriteRule>
    {
        public void RemoveByName(string ruleName)
        {
            RewriteRule forRemove = null;

            foreach (RewriteRule rule in this)
            {
                if (rule.Name == ruleName)
                {
                    forRemove = rule;
                    break;
                }
            }

            if (forRemove != null)
                Remove(forRemove);
        }

        public void ReplaceRuleByName(string ruleName, RewriteRule rule)
        {
            int idx = GetIndexByName(ruleName);

            if (idx != -1)
            {
                rule.Name = ruleName;
                this[idx] = rule;
            }
            else
            {
                throw new ArgumentException(string.Format("UrlRewritingNet: Unknown ruleName '{0}'", ruleName), "ruleName");
            }
        }

        public void InsertRuleBeforeName(string positionRuleName, string ruleName, RewriteRule rule)
        {
            int idx = GetIndexByName(positionRuleName);

            if (idx != -1)
            {
                rule.Name = ruleName;
                Insert(idx, rule);
            }
            else
            {
                throw new ArgumentException(string.Format("UrlRewritingNet: Unknown ruleName '{0}'", ruleName), "ruleName");
            }
        }

        private int GetIndexByName(string ruleName)
        {
            int foundIndex = -1;

            for (int i = 0; i < Count; i++)
            {
                if (this[i].Name == ruleName)
                {
                    foundIndex = i;
                    break;
                }
            }

            return foundIndex;
        }
    }
}
