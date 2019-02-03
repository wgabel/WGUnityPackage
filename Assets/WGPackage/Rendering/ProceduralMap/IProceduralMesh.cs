using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WG.CORE.Voxels
{
    public interface IProceduralMesh
    {
        void CreateMesh ( Voxel [] points, int mapSize, List<MonoBehaviour> noiseProviders, float scale, IMaterialProvider materialProvider );
    }
}
