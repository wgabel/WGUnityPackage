using System.Collections.Generic;
using System.Linq;

namespace WGPackage.Maps.GridMap
{
    public class MapData
    {
        public string MapName { get; }
        public int Width { get; }
        public int Height { get; }
        public Tile[] grid;

        public MapData ( string name, int width, int height )
        {
            MapName = name;
            Width = width;
            Height = height;
            grid = new Tile[width * height];

            for ( int i = 0; i < width * height; i++ )
            {
                grid[i] = new Tile (
                    Helper.Convert1dTo2d ( i, height ).x,
                    Helper.Convert1dTo2d ( i, height ).z
                    );
            }
        }

        public IntVector2[] GetTilesPositions()
        {
            return grid.Aggregate ( new List<IntVector2>(), (sum, next) => AddAndReturn(sum, new IntVector2(next.X,next.Y)) ).ToArray();
        }

        private List<IntVector2> AddAndReturn ( List<IntVector2> list, IntVector2 element )
        {
            list.Add (element);
            return list;
        }
    }
}