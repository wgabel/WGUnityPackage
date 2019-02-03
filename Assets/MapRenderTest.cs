using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using WG.CORE.Voxels;
using WGPackage.Maps.GridMap;

public class MapRenderTest : MonoBehaviour
{
    [ContextMenu ( "Run test" )]
    void RunTest ()
    {
        //In play mode.
        if ( !Application.isPlaying )
        {
            return;
        }
        //Build map
        MapData testMap = new MapData ( "testMap", 100, 100 );
        RenderData renderData = new RenderData ()
        {
            MapCellSize = 0.2f,
            MapStartYPosition = 0,
            MapStartPosition = new IntVector2 ( 0, 0 )
        };

        //Render map on sreen
        MapRenderer renderer = new MapRenderer ();
        renderer.RenderMap ( testMap, renderData );
    }
}

internal class MapRenderer
{
    public void RenderMap ( MapData testMap, RenderData renderData )
    {
        //Helper.CreateCubeObjects ( testMap.GetTilesPositions (), renderData.MapCellSize, Color.yellow, 0.2f );
        ProceduralMesh pm = new ProceduralMesh ();
        var voxels = testMap.GetTilesPositions ().Aggregate (new List<Voxel>(), (sum, next) => 
            {
                sum.Add ( new Voxel ( next) );
                return sum;
             } ).ToArray();
        BasicMaterialProvider materialProvider = new BasicMaterialProvider ()
        {
            materials = new Material[] { Resources.Load<Material> ( "materials/testMaterial" ) }
    };
        pm.CreateMesh (voxels, testMap.Width, new List<MonoBehaviour>(), renderData.MapCellSize, materialProvider );
    }
}

internal class RenderData
{
    public float MapCellSize { get; internal set; }
    public int MapStartYPosition { get; internal set; }
    public IntVector2 MapStartPosition { get; internal set; }
}