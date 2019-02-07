using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace WGPackage.Rendering.DynamicDensityMap.Helpers
{
    public static class ObjectCreationExtensions
    {
        public static MeshRenderer SetSharedMaterial ( this MeshRenderer renderer, Material material )
        {
            renderer.sharedMaterial = material;
            return renderer;
        }

        public static MeshFilter ApplyMesh ( this MeshFilter meshFilter, Mesh mesh )
        {
            meshFilter.mesh = mesh;
            return meshFilter;
        }
    }
}
