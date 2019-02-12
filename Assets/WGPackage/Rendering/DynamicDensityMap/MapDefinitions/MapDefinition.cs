using System.Linq;
using UnityEngine;
using WGPackage.Rendering.DynamicDensityMap.Helpers;

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

        public bool IsValid
        {
            get
            {
                //return Width % 2 == 0 && Height % 2 == 0;
                return true;
            }
        }

        public MapDefinition ( string name, int width, int height, int cellFidelity, float cellScale, Vector3Int startPosition )
        {
            this.MapName = name;
            this.Width = width;
            this.Height = height;
            this.CellFidelity = cellFidelity;
            this.CellsPerObject = MathExtensions.GetCommonNumbers ( 
                MathExtensions.GetAllDivisors ( width ), 
                MathExtensions.GetAllDivisors ( height ) ).Last ();
            this.StartPosition = startPosition;
            this.CellScale = cellScale;
        }

    }
}
