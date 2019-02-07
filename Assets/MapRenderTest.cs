using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using WG.CORE.Voxels;
using WGPackage.Maps.GridMap;
using WGPackage.Maps.GridMap.MapRenderers;
using WGPackage.Rendering.ProceduralMap;

public class MapRenderTest : MonoBehaviour
{
    [ContextMenu ( "Run test" )]
    void RunTest ()
    {
        //In play mode.
        if ( !Application.isPlaying )
            return;
        //Render map on sreen
        //BasicMapRenderer renderer = new BasicMapRenderer ( )
        //    .RenderMap ( 
        //    new MapData ( "testMap", 3, 3 ),  
        //    new RenderData ( 0.2f, new Vector3(), 1 ) ) as BasicMapRenderer;
    }
}
















//var voxels = testMap.GetTilesPositions ().Aggregate (new List<Voxel>(), (sum, next) => 
//    {
//        sum.Add ( new Voxel ( next) );
//        return sum;
//     } ).ToArray();

//_proceduralBuilder.CreateMesh (voxels, testMap.Width, new List<MonoBehaviour>(), renderData.MapCellSize, _materialProvider );