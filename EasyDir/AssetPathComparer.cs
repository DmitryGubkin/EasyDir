using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDir
{
    public class AssetPathComparer : IEqualityComparer<Asset>
    {
        public bool Equals (Asset x, Asset y)
        {
            return x.FullPath.Equals(y.FullPath,StringComparison.Ordinal);
        }

        public int GetHashCode( Asset obj)
        {
            return obj.FullPath.GetHashCode();
        }
    }
}
