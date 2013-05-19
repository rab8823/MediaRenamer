using System;

namespace MediaRenamer
{
    /// <summary>
    /// Interface for a rule for renaming files
    /// </summary>
    public interface IRenameRule
    {
        /// <summary>
        /// Rename the specified name.
        /// </summary>
        /// <param name="name">Name.</param>
        string Rename(string name);
    }
}

