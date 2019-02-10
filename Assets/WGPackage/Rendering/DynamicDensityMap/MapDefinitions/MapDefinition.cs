using UnityEngine;

namespace WGPackage.Rendering.DynamicDensityMap
{
    [System.Serializable]
    public struct MapDefinition : IMapDefinition
    {
        public string MapName { get; }
        public int Width { get; }
        public int Height { get; }
        public int CellFidelity { get; }
        public int CellsPerObject { get; }
        public Vector3Int StartPosition { get; }
        public float CellScale { get; }

        public int GetPoxelsDivisionLength
        {
            get
            {
                return 1;
            }
        }

        public bool IsValid
        {
            get
            {
                //return Width % 2 == 0 && Height % 2 == 0;
                return true;
            }
        }

        public MapDefinition ( string name, int width, int height, int cellFidelity, int cellsPerObject, float cellScale, Vector3Int startPosition )
        {
            this.MapName = name;
            this.Width = width;
            this.Height = height;
            this.CellFidelity = cellFidelity;
            this.CellsPerObject = cellsPerObject;
            this.StartPosition = startPosition;
            this.CellScale = cellScale;
        }
    }
}
