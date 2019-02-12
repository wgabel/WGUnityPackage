using UnityEngine;

namespace WGPackage.Rendering.DynamicDensityMap
{
    public interface IPoxel
    {
        Vector3Int PostionInMap { get; set; }
        Vector3 PositionIn3d { get; set; }
        Poxel[] InnerPoxels { get; set; }
        bool IsCreated { get; set; }
    }
}
