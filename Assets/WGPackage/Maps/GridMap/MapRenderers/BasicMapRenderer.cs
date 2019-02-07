using System.Collections.Generic;
using UnityEngine;
using WG.CORE.Voxels;
using WGPackage.Rendering.DynamicDensityMap;
using WGPackage.Rendering.DynamicDensityMap.MaterialProviders;
using WGPackage.Rendering.ProceduralMap;

namespace WGPackage.Maps.GridMap.MapRenderers
{
    public class BasicMapRenderer : IMapRenderer
    {
        private readonly IProceduralMesh _proceduralBuilder;
        private readonly IMaterialProvider _materialProvider;

        public BasicMapRenderer ( IProceduralMesh proceduralBuilder, IMaterialProvider materialProvider )
        {
            this._proceduralBuilder = proceduralBuilder;
            this._materialProvider = materialProvider;
        }

        //public IMapRenderer RenderMap ( MapData testMap, RenderData renderData )
        //{
        //    //For every tile
        //    //Generate mesh object
        //    //IntVector2 position = new IntVector2 ( renderData.MapStartPosition );
        //    //for ( int i = 0; i < testMap.grid.Length;i++  )
        //    //{
        //    //    position = position + Helper.Convert1dTo2d ( i, testMap.Height );
        //    //    int length = ( renderData.MapCellDivision + 1 ) * ( renderData.MapCellDivision + 1 );
        //    //    Voxel[] voxels = new Voxel[length];
        //    //    for ( int v = 0; v < length; v++ )
        //    //    {
        //    //        voxels[v] = new Voxel ( position + Helper.Convert1dTo2d ( v, length ), true );
        //    //    }
        //    //    testMap.grid[i].voxels = voxels;
        //    //    //_proceduralBuilder.CreateMesh ( testMap.grid[i].voxels, length - 1, new List<MonoBehaviour> (), renderData.MapCellSize, _materialProvider );
        //    //    _proceduralBuilder.Create ( new MeshInputData () {
        //    //        DataPoints = voxels,
        //    //        CellDivision = renderData.MapCellDivision,
        //    //        QuadSize = renderData.MapCellSize
        //    //    } );
        //    //}
        //    return this;
        //}

        public IMapRenderer RenderMap ( IMapDefinition testMap, RenderData renderData )
        {
            throw new System.NotImplementedException ();
        }
    }
}
