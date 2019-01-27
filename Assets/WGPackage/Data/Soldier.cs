using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using UnityEngine;
using Newtonsoft.Json;
#if UNITY_EDITOR
using UnityEditor;
#endif

[System.Serializable]
public class Soldier
{
    [SerializeField]
    public string SoldierName { get; set; }

    public string someText = "";

    public virtual string SaveToXml<T> ( )
    {
        var serializer = new XmlSerializer ( typeof ( T ) );
        string path = GetPath<T> ();
        var stream = new FileStream ( path, FileMode.Create );
        serializer.Serialize ( stream, this );
        stream.Close ();
        return path;
    }

    public virtual string SaveToJson<T> ( )
    {
        string json = JsonConvert.SerializeObject ( this );
        string path = GetPath<T> ("json");
        var stream = new FileStream ( path, FileMode.Create );
        byte[] info = new UTF8Encoding ( true ).GetBytes ( json );
        stream.Write ( info, 0, info.Length );
        stream.Close();
#if UNITY_EDITOR
        AssetDatabase.Refresh ();
#endif
        return path;
    }

    protected string GetPath<T>(string extension = "txt") =>
        Application.dataPath + Path.DirectorySeparatorChar + typeof ( T ) + "_" + SoldierName + "."+ extension;

    public virtual T LoadFromXml <T>( string path = "" ) where T : Soldier
    {
        var serializer = new XmlSerializer ( typeof ( T ) );
        var stream = new FileStream ( string.IsNullOrEmpty ( path ) ? GetPath<T>() : path, FileMode.Open );
        var container = serializer.Deserialize ( stream ) as T;
        stream.Close ();
        return container;
    }
}
