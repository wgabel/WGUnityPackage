using UnityEngine;

namespace WGPackage.Rendering.DynamicDensityMap
{
    public struct MapDefinition : IMapDefinition
    {
        public string MapName { get; }
        public int Width { get; }
        public int Height { get; }
        public int Division { get; }
        public int DivisionDepth { get; }
        public Vector3Int StartPosition { get; }

        public MapDefinition ( string name, int width, int height, int division, int divisionDepth, Vector3Int startPosition )
        {
            this.MapName = name;
            this.Width = width;
            this.Height = height;
            this.Division = division;
            this.DivisionDepth = divisionDepth;
            this.StartPosition = startPosition;
        }
    }
}
