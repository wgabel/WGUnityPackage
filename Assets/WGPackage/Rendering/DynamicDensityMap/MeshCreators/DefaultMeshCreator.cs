﻿using UnityEngine;

namespace WGPackage.Rendering.DynamicDensityMap.MeshCreators
{
    public class DefaultMeshCreator : IMeshCreator
    {
        
        public Mesh Create ( IMapDefinition mapDefinition, string newMeshName = "" )
        {
            Mesh mesh = new Mesh ();
            mesh.name = newMeshName ?? "procedural mesh(unnamed)";

            //Create root Poxel
            Poxel rootPoxel = CreateRootPoxel ( mapDefinition );
            
            for ( int i = 0; i < mapDefinition.DivisionDepth; i++ )
            {
                for ( int p = 0; p < mapDefinition.GetPoxelsDivisionLength; p++ )
                {
                    //Poxel innerPoxel = CreateInnerPoxel (rootPoxel, );

                }
            }
            return mesh;
        }

        //TODO : Move this to Poxel?
        private Poxel CreateRootPoxel ( IMapDefinition mapDefinition )
        {
            return new Poxel ()
            {
                hasParent = false,
                indexInParent = -1,
                isRoot = true,
                PositionIn3d = mapDefinition.StartPosition,
                innerCells = new Poxel[mapDefinition.GetPoxelsDivisionLength],
                depth = 0
            };
        }

        private Poxel CreateInnerPoxel ( Poxel parent, int indexInParent, Vector3Int position, int depth, IMapDefinition mapDefinition )
        {
            return new Poxel ()
            {
                hasParent = true,
                indexInParent = indexInParent,
                isRoot = false,
                PositionIn3d = position,
                innerCells = new Poxel[mapDefinition.GetPoxelsDivisionLength],
                depth = depth,
            };
        }
    }
}
