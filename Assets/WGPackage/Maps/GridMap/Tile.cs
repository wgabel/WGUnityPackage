using WGPackage.Data.Inventory;

namespace WGPackage.Maps.GridMap
{
    public class Tile
    {
        public int X { get; set; }
        public int Y { get; set; }
        public InventoryService entites;

        public Tile ()
        {

        }

        public Tile ( int x, int y )
        {
            X = x;
            Y = y;
            entites = new InventoryService ();
        }
    }
}
