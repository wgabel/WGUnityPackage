using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using WGPackage.Rendering.DynamicDensityMap.Helpers;
using WGPackage.Rendering.DynamicDensityMap.MeshCreators;
using WGPackage.Rendering.DynamicDensityMap.Renderers;

namespace WGPackage.Rendering.DynamicDensityMap
{
    public class Test : MonoBehaviour
    {
        [Header ( "New map definition" )]
        public string mapName = "unnamed Map";
        public int width = 2;
        public int height = 2;
        public int fidelity = 1;
        public float cellScale = 1f;
        public Vector3Int startPosition = new Vector3Int(0,0,0);

        public int number = 1;
        public int number2 = 1;
        [ContextMenu ( "Run Test" )]
        public void RunTest ()
        {

            IMapRenderer renderer = new DefaultMapRenderer ()
                .Render ( new MapDefinition ( 
                    mapName, 
                    width, 
                    height, 
                    fidelity, 
                    cellScale, 
                    startPosition ) );
        }
    }
}
