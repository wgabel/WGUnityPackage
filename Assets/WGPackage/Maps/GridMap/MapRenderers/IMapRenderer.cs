using WGPackage.Rendering.DynamicDensityMap;

namespace WGPackage.Maps.GridMap.MapRenderers
{
    public interface IMapRenderer
    {
        IMapRenderer RenderMap ( IMapDefinition testMap, RenderData renderData );
    }
}
