using UnityEngine;

namespace WGPackage.Rendering.DynamicDensityMap
{
    public interface IMapDefinition
    {
        string MapName { get; }
        int Width { get; }
        int Height { get; }
        int CellFidelity { get; }
        int CellsPerObject { get; }
        float CellScale { get; }
        Vector3Int StartPosition { get; }
        bool IsValid { get; }
    }
}
