using System;
using UnityEngine;

namespace WGPackage.Rendering.DynamicDensityMap.MaterialProviders
{
    public class DefaultMaterialProvider : IMaterialProvider
    {
        private readonly string _materialAssetPath;
        private readonly Material[] _materials;

        public DefaultMaterialProvider() : this ( "materials/testMaterial" )
        {
        }

        public DefaultMaterialProvider ( string materialAssetPath )
        {
            this._materialAssetPath = materialAssetPath;
            _materials = new Material[] { Resources.Load<Material> ( _materialAssetPath ) };
        }

        public Material GetMaterial ()
        {
            if ( _materials == null || _materials[0] == null )
            {
                Debug.LogWarning ( "Could not find material at provided path : ../Resources/" + _materialAssetPath+". Will apply standard material." );
                return new Material ( Shader.Find ( "Transparent/Diffuse" ) );
            }
            return _materials[0];
        }
    }
}
