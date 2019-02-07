using UnityEngine;
using WGPackage.Rendering.DynamicDensityMap.ObjectCreators;

namespace WGPackage.Rendering.DynamicDensityMap.Renderers
{
    public class DefaultMapRenderer : IMapRenderer
    {
        private readonly IMapObjectCreator _mapObjectCreator;

        //TODO : Get creator by interface from IOC(By attribute - add to IOC when registered by attribute)
        public DefaultMapRenderer () : this ( new DefaultMapObjectCreator() )
        {
            
        }

        public DefaultMapRenderer ( IMapObjectCreator mapObjectCreator )
        {
            this._mapObjectCreator = mapObjectCreator;
        }

        public IMapRenderer Render ( IMapDefinition mapDefinition )
        {
            GameObject go = _mapObjectCreator.Create ( mapDefinition );
            return this;
        }
    }
}
