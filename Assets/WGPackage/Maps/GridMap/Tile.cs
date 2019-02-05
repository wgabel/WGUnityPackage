using WG.CORE.Voxels;
using WGPackage.Data.Inventory;
using UnityEngine;

namespace WGPackage.Maps.GridMap
{
    public class Tile
    {
        public int X { get; set; }
        public int Y { get; set; }
        public InventoryService entites;
        public Voxel[] voxels;
        public Transform CellMeshObject;

        public Tile ( int x, int y )
        {
            X = x;
            Y = y;
            entites = new InventoryService ();
        }
    }
}
