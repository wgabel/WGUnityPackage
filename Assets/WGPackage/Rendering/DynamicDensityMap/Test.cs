using UnityEngine;
using WGPackage.Rendering.DynamicDensityMap.Renderers;

namespace WGPackage.Rendering.DynamicDensityMap
{
    public class Test : MonoBehaviour
    {
        [ContextMenu ( "Run Test" )]
        public void RunTest ()
        {
            IMapDefinition mapDefinition = new MapDefinition ( 
                name: "test map",
                width: 1, 
                height: 1, 
                division: 1, 
                divisionDepth: 3, 
                startPosition: new Vector3Int ( 0, 0, 0 ) );
            IMapRenderer renderer = new DefaultMapRenderer ().Render ( mapDefinition );
        }
    }
}
