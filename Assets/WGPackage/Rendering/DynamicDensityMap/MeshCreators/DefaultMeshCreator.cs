using UnityEngine;
using WGPackage.Maps.GridMap;

namespace WGPackage.Rendering.DynamicDensityMap.MeshCreators
{
    public class DefaultMeshCreator : IMeshCreator
    {
        private IntVector2[] neighbours = new IntVector2[]
        {
            new IntVector2(-1,0),
            new IntVector2(-1,1),
            new IntVector2(0,1),
            new IntVector2(1,1),
            new IntVector2(1,0),
            new IntVector2(1,-1),
            new IntVector2(0,-1),
            new IntVector2(-1,-1),
        };

        public Mesh Create ( IMapDefinition mapDefinition, Poxel[] allPoxels, int i, string newMeshName = "" )
        {

            return new Mesh ();
        }

        bool IsNeighbourValid ( Poxel poxel, Poxel[] allpoxels, int neighbourIndex, IMapDefinition mapDefinition )
        {
            if ( IsPoxelOutOfMapBounds ( poxel, mapDefinition ) )
                return false;
            //TODO : Other checks
            return true;
        }

        private bool IsPoxelOutOfMapBounds ( Poxel poxel, IMapDefinition mapDefinition ) =>
            poxel.PostionInMap.x < 0 || 
            poxel.PostionInMap.x >= mapDefinition.Width || 
            poxel.PostionInMap.z < 0 || 
            poxel.PostionInMap.z >= mapDefinition.Height;

        private bool isNeghbourDone()
        {
            return false;
        }
    }
}
