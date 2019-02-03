using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WGPackage.Data.Inventory;
using WGPackage.Data.Serialization.Test;
using System.Linq;

public class InventoryTest : MonoBehaviour
{
    [ContextMenu("Run test")]
    public void RunTest()
    {
        InventoryService inventoryService = new InventoryService ();

        Pesant p = new Pesant ();
        Soldier s = new Soldier ();
        ChildPesant cp = new ChildPesant ();
        inventoryService.Put<BaseEntityModel> ( p );
        inventoryService.Put<BaseEntityModel> ( s );
        inventoryService.Put<BaseEntityModel> ( cp );
        IEnumerable<object> pList = inventoryService.GetItems<BaseEntityModel> ();

        foreach ( object o in pList )
            Debug.Log (o as BaseEntityModel );
    }
}
