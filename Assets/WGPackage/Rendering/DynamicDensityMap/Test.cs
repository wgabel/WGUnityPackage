using UnityEngine;
using WGPackage.Rendering.DynamicDensityMap.Renderers;

namespace WGPackage.Rendering.DynamicDensityMap
{
    public class Test : MonoBehaviour
    {
        [ContextMenu ( "Run Test" )]
        public void RunTest ()
        {
            IMapDefinition mapDefinition = new MapDefinition ( "test map", 1, 1, 1, 1, new Vector3Int ( 0, 0, 0 ) );
            IMapRenderer renderer = new DefaultMapRenderer ().Render ( mapDefinition );
        }
    }
}
