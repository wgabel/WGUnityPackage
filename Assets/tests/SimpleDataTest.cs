using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;
using WGPackage.Data.Serialization;

namespace WGPackage.Data.Serialization.Test
{
    public class SimpleDataTest : MonoBehaviour
    {
        [ContextMenu ( "Run test" )]
        public void TestSerialisation ()
        {
            BaseEntityModel solider = new BaseEntityModel ();
            solider.BaseName = "Jerry";
            string soldierPath = BaseSerializer.SaveToJson<BaseEntityModel> ( solider, solider.BaseName, "tests", overwrite: true );

            Pesant pesant = new Pesant ()
            {
                BaseName = "bob",
                Hp = 4,
                Soldiers = new List<BaseEntityModel> ()
            {
                new BaseEntityModel () { BaseName="PesantSoldier 1" },
                new BaseEntityModel () { BaseName = "PesantSoldier 2" }
            }
            };

            string peasentPath = BaseSerializer.SaveToJson<Pesant> ( pesant, pesant.BaseName, "tests", overwrite:true );

            var loaded = BaseSerializer.LoadFromJson ( peasentPath );
            Debug.Log ( loaded + " >> " + loaded.GetType () );

            loaded = BaseSerializer.LoadFromJson ( soldierPath );
            Debug.Log ( loaded + " >> " + loaded.GetType () );

        }
    }
}