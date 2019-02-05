using System.Collections.Generic;
using UnityEngine;
using WG.CORE.Voxels;

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

        public IMapRenderer RenderMap ( MapData testMap, RenderData renderData )
        {
            //For every tile
            //Generate mesh object
            foreach ( Tile tile in testMap.grid )
            {
                tile.voxels = new Voxel[ ( renderData.MapCellDivision + 1 ) * ( renderData.MapCellDivision + 1 )];

                // TODO : Set every tile voxel position.

                _proceduralBuilder.CreateMesh ( tile.voxels, testMap.Width, new List<MonoBehaviour> (), renderData.MapCellSize, _materialProvider );
            }
            return this;
        }
    }
}
