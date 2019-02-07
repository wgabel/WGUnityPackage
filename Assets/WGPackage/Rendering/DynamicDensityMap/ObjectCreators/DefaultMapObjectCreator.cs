using System.IO;
using UnityEngine;
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
            string newObjectName = GetObjectName ();

            GameObject root = CreateHolder ( 0, mapDefinition );

            return root;

            //return new GameObject ( mapDefinition.MapName + newObjectName )
            //    .AddComponent<MeshRenderer> ().SetSharedMaterial ( _materialProvider.GetMaterial () ).gameObject
            //    .AddComponent<MeshFilter> ().ApplyMesh ( _meshCreator.Create ( mapDefinition, newObjectName ) ).gameObject;
        }

        

        private GameObject CreateHolder ( int currentDepth, IMapDefinition mapDefinition )
        {
            //Cells are width * height
            //FOr each cell:
                //Create one object?
                //Create SPECIFIED objects.

            string newObjectName = GetObjectName () + "_" + currentDepth;
            GameObject g = new GameObject ( newObjectName );



            for ( int d = 0; d < mapDefinition.GetPoxelsDivisionLength; d++ )
            {
                GameObject gInner = CreateHolder ( ++currentDepth, mapDefinition );
                gInner.transform.SetParent ( g.transform );
            }


            if ( currentDepth < mapDefinition.DivisionDepth )
            {
                
            }
            return g;
        }
    }
}
