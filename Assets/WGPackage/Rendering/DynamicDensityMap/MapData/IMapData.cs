using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WGPackage.Rendering.DynamicDensityMap.MapData
{
    public interface IMapData
    {
        Poxel[] MapPoxels { get; }
    }
}
