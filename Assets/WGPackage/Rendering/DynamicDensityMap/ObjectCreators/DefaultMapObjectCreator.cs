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
            return new GameObject ( mapDefinition.MapName + newObjectName )
                .AddComponent<MeshRenderer> ().SetSharedMaterial ( _materialProvider.GetMaterial () ).gameObject
                .AddComponent<MeshFilter> ().ApplyMesh ( _meshCreator.Create ( mapDefinition, newObjectName ) ).gameObject;
        }
    }
}
