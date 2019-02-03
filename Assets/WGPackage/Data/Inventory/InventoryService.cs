using System;
using System.Collections.Generic;

namespace WGPackage.Data.Inventory
{
    class InventoryService
    {
        private class InventoryItem<T> 
        {
            public List<T> Items { get; set; }
        }

        private Dictionary<Type, InventoryItem<object>> inventory;

        public IEnumerable<object> GetItems<T> ()
        {
            IEnumerable<object> t = inventory[typeof ( T )].Items;
            return t;

        }

        public void Put<T> ( T item ) where T : class
        {
            if ( inventory == null )
                inventory = new Dictionary<Type, InventoryItem<object>> ();

            if ( !inventory.ContainsKey ( typeof ( T ) ) )
                inventory[typeof ( T )] = new InventoryItem<object> ()
                {
                    Items = new List<object> ()
                };
            
            inventory[typeof ( T )].Items.Add ( item );
        }
    }
}
