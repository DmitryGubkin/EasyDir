using System;

namespace EasyDir
{
    [Flags]
    public enum SearchTypes
    {
        None,
        TopFolder,
        AllSubFolders
    }
    [Flags]
    public enum NameMatchModes
    {
        None,
        MatchName,
        AbsoluteMatch
    }
    [Flags]
    public enum ComboBoxTypes
    {
        Search,
        NameMatch
    }
}
