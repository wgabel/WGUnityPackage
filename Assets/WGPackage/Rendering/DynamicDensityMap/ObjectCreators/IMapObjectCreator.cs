using UnityEngine;

namespace WGPackage.Rendering.DynamicDensityMap.ObjectCreators
{
    public interface IMapObjectCreator
    {
        GameObject Create ( IMapDefinition mapDefinition );
    }
}
