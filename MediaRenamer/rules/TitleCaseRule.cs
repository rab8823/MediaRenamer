using System;
using System.Text;

namespace MediaRenamer
{
    public sealed class TitleCaseRule : BaseRenameRule
    {
        public TitleCaseRule()
        {
        }
        #region IRenameRule implementation

        public override string Rename(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }
            if (string.IsNullOrEmpty(name))
            {
                return name;
            }
            bool atSeparator = false;
            int separatorIndex = -1;
            StringBuilder result = new StringBuilder();
            for (int c = 0; c < name.Length; c++)
            {
                atSeparator = BaseRenameRule.IsSeparator(name[c]);
                if (atSeparator)
                {
                    StringBuilder sb = new StringBuilder();
                    separatorIndex = c++;
                    while (!BaseRenameRule.IsSeparator(name[c]) && c < name.Length)
                    {
                        sb.Append(name[c]);
                        c++;
                    }
                    if (!BaseRenameRule.IsArticlePrepositionConjunction(sb.ToString()))
                    {
                        sb[0] = char.ToUpper(sb[0]);
                    }
                    result.Append(sb);
                }
            }
            return result.ToString();
        }
        #endregion
    }
}

