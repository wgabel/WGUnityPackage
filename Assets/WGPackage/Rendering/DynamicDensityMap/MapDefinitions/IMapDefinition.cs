using UnityEngine;

namespace WGPackage.Rendering.DynamicDensityMap
{
    public interface IMapDefinition
    {
        string MapName { get; }
        int Width { get; }
        int Height { get; }
        int Division { get; }
        int DivisionDepth { get; }
        Vector3Int StartPosition { get; }

        int GetPoxelsDivisionLength { get; }
    }
}
