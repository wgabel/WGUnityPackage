using System.IO;
using System.Linq;
using UnityEngine;
using WGPackage.Maps.GridMap;
using WGPackage.Rendering.DynamicDensityMap.Helpers;
using WGPackage.Rendering.DynamicDensityMap.MaterialProviders;
using WGPackage.Rendering.DynamicDensityMap.MeshCreators;

namespace WGPackage.Rendering.DynamicDensityMap.ObjectCreators
{
    public class DefaultMapObjectCreator : IMapObjectCreator
    {
        private IMaterialProvider _materialProvider;
        private IMeshCreator _meshCreator;
        private string GetObjectName () => Path.GetRandomFileName ();
        private Poxel[] mapData;

        public DefaultMapObjectCreator () : this (
            new DefaultMaterialProvider (),
            new DefaultMeshCreator () )
        {

        }

        public DefaultMapObjectCreator ( IMaterialProvider materialProvider, IMeshCreator meshCreator )
        {
            this._materialProvider = materialProvider;
            this._meshCreator = meshCreator;
        }

        public GameObject Create ( IMapDefinition mapDefinition )
        {
            mapData = CreateData ( mapDefinition );
            return CreateRootWithObjects ( mapDefinition.Width * mapDefinition.Height, mapDefinition, mapData );
        }

        private Poxel[] CreateData ( IMapDefinition mapDefinition )
        {
            return new Poxel[mapDefinition.Width * mapDefinition.Height]
                .Select ( ( item, indexer ) => CreatePoxel ( indexer, mapDefinition ) ).ToArray<Poxel> ();

        }

        private Poxel CreatePoxel ( int index, IMapDefinition mapDefinition ) =>
            new Poxel ()
            {
                PostionInMap = Helper.Convert1dTo2d ( index, mapDefinition.Height ).ToVector3Int,
                PositionIn3d = Helper.Convert1dTo2d ( index, mapDefinition.Height ).ToVector3Scaled ( mapDefinition.CellScale )
            };

        private GameObject CreateRootWithObjects ( int length, IMapDefinition mapDefinition, Poxel[] allPoxels )
        {
            GameObject root = new GameObject ( GetObjectName () );
            for ( int i = 0; i < length; i++ )
            {
                if ( i % mapDefinition.CellsPerObject == 0 )
                {
                    string objName = GetObjectName ();
                    CreateGameObject ( objName, mapDefinition, allPoxels, i )
                        .transform.SetParent ( root.transform );
                }
            }
            return root;
        }

        private GameObject CreateGameObject ( string objName, IMapDefinition mapDefinition, Poxel[] allPoxels, int index ) =>
            new GameObject ( objName )
                .AddComponent<MeshRenderer> ().SetSharedMaterial ( _materialProvider.GetMaterial () )
                .gameObject.AddComponent<MeshFilter> ()
                    .ApplyMesh ( _meshCreator.Create ( mapDefinition, allPoxels, index, objName ) )
                .gameObject;

    }
}
