using UnityEngine;

namespace WGPackage.Rendering.DynamicDensityMap
{
    public class Poxel
    {
        public bool isRoot = false;
        public Vector3 PositionIn3d;
        public int indexInParent;
        public bool hasParent;
        public Poxel[] innerCells;
        public int depth;
    }
}
