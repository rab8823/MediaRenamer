using System;
using System.Collections.Generic;
using System.Text;

namespace MediaRenamer
{
    public abstract class BaseRenameRule : IRenameRule
    {
        protected internal static string[] _articlesPrepositionsConjunctions = new string[]
        {
            "the", "a", "an",
            "of", "in", "to", "for", "with", "on", "at", "from", "by", "about", "as", "into", "like", "through", "after", "over", "between", "out", "against", "during", "without", "before", "under", "around", "among",
            "and", "or", "but"
        };
        protected internal static char[] _separators = new char[]
        {
            ' ',
            '.',
            '\t'
        };
        /// <summary>
        /// Determines if a word is an article preposition or conjunction.
        /// </summary>
        /// <returns><c>true</c> if the word is an article preposition or conjunction; otherwise, <c>false</c>.</returns>
        /// <param name="word">Word.</param>
        public static bool IsArticlePrepositionConjunction(string word)
        {
            bool result = !string.IsNullOrEmpty(word);
            if (!result)
            {
                string test = word.ToLower();
                for (int i = 0; i < _articlesPrepositionsConjunctions.Length && !result; i++)
                {
                    result = string.Equals(test, _articlesPrepositionsConjunctions[i], StringComparison.CurrentCulture);
                }
            }
            return result;
        }

        public static bool IsSeparator(char character){
            bool match = false;
            for (int c = 0; c < _separators.Length && !match; c++)
            {
                match = character == _separators[c];
            }
            return match;
        }

        public static string[] Split(string words, StringSplitOptions splitOptions, bool splitOnCaseDifference)
        {
            if (string.IsNullOrEmpty(words))
            {
                return new string[] { words };
            }
            string[] initial = words.Split(_separators, splitOptions);
            List<string> final = new List<string>();
            int finalIndex = 0;
            for (int i = 0; i < initial.Length; i++)
            {
                StringBuilder sb = new StringBuilder();
                string w = initial[i];
                bool isUpper = char.IsUpper(w[0]);
                sb.Append(w[0]);
                for (int c = 1; c < w.Length; c++)
                {
                    if (splitOnCaseDifference && char.IsUpper(w[c]))
                    {
                        final.Insert(finalIndex++, sb.ToString());
                        sb.Clear();
                    } 
                    sb.Append(w[c]);
                }
                if (sb.Length > 0)
                {
                    final.Insert(finalIndex++, sb.ToString());
                    sb.Clear();
                }
            }
            return final.ToArray();
        }

        public abstract string Rename(string name);
    }
}

