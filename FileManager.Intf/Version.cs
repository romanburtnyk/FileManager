using System;

namespace FileManager.Intf
{
    public class Version:IComparable<Version>
    {
        public int MinorVersion { get; private set; }
        public int MajorVersion { get; private set; }

        public Version( int majorVersion, int minorVersion)
        {
            MinorVersion = minorVersion;
            MajorVersion = majorVersion;
        }

        public bool IsCompartibleWith(Version version)
        {
            return MajorVersion == version.MajorVersion;
        }

        public int CompareTo(Version other)
        {
            
            int result = MajorVersion.CompareTo(other.MajorVersion);
            if (result == 0)
            {
                result = MinorVersion.CompareTo(other.MinorVersion);
            }
            return result;
        }

        public override string ToString()
        {
            return "" + MajorVersion + "." + MinorVersion;
        }
    }
}