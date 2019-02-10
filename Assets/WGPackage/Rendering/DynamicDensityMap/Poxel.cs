using UnityEngine;

namespace WGPackage.Rendering.DynamicDensityMap
{
    public class Poxel : IPoxel
    {
        public Vector3Int PostionInMap { get; set; }
        public Vector3 PositionIn3d { get; set; }
        public Poxel[] InnerPoxels { get; set; }
    }
}
