using UnityEngine;
using WGPackage.Data.Serialization;
using WGPackage.Data.Serialization.Test;
using WGPackage.Maps.GridMap;

public class GridTest : MonoBehaviour
{
    [ContextMenu ( "Run Test" )]
    public void RunTest ()
    {
        MapData testMap = new MapData ( "testMap", 10, 10 );
        Pesant p = new Pesant () { BaseName = "johny", Hp = 10 };

        testMap.grid[1].entites.Put<BaseEntityModel> ( p );

        string saved = BaseSerializer.SaveToJson<MapData> ( testMap, testMap.MapName, pathRoot: "tests/maps", overwrite: true );

        testMap = (MapData)BaseSerializer.LoadFromJson ( saved );

        var c = testMap.grid[1].entites;
        var pesant = c.GetItems<BaseEntityModel> ();
    }
}