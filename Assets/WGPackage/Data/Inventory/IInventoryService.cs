using System.Collections.Generic;

namespace WGPackage.Data.Inventory
{
    public interface IInventoryService
    {
        IEnumerable<T> GetItems<T> ();
        void Put<T> ();
    }
}