using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WGPackage.Maps.GridMap.MapRenderers
{
    public interface IMapRenderer
    {
        IMapRenderer RenderMap ( MapData testMap, RenderData renderData );
    }
}
