using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace WGPackage.Rendering.DynamicDensityMap.MeshCreators
{
    public interface IMeshCreator
    {
        Mesh Create ( IMapDefinition mapDefinition, IPoxel[] allPoxels, int i, string newMeshName = "" );
    }
}
