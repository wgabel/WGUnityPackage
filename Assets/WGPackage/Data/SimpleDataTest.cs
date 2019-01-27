using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public class SimpleDataTest : MonoBehaviour
{
    public string someText;
    public List<SimpleDataTest> somecollection;
    public TextAsset file;

    [ContextMenu("Run test")]
    public void TestSerialisation()
    {
        Soldier solider = new Soldier ();
        solider.SoldierName = "Jerry";
        solider.someText = "ssdsd";
        solider.SaveToJson<Soldier> ();

        Pesant pesant = new Pesant ();
        pesant.SoldierName = "Bob";
        pesant.Hp = 2;
        pesant.Soldiers = new List<Soldier> () { new Soldier () { SoldierName="PesantSoldier 1" }, new Soldier () { SoldierName = "PesantSoldier 2" } };
        string peasentPath = pesant.SaveToJson<Pesant> ();

        var loaded = Soldier.LoadFromJson ( peasentPath );
        Debug.Log ( loaded + " >> "+ loaded.GetType () );
    }
}
