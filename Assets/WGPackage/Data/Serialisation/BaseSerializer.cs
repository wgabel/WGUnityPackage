using Newtonsoft.Json;
using System.IO;
using System.Text;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace WGPackage.Data.Serialization
{
    public static class BaseSerializer
    {
        private static readonly JsonSerializerSettings SERIALIZER_SETTINGS =
            new JsonSerializerSettings () { TypeNameHandling = TypeNameHandling.All };

        private static string GetPath<T> ( string fileUniqueNamePart ) =>
            Application.dataPath + Path.DirectorySeparatorChar + typeof ( T ) + "_" + fileUniqueNamePart + ".json";

        public static string SaveToJson<T> ( T objectToSerialize, string fileUniqueNamePart )
        {
            string json = JsonConvert.SerializeObject ( objectToSerialize, SERIALIZER_SETTINGS );
            string path = GetPath<T> ( fileUniqueNamePart );
            var stream = new FileStream ( path, FileMode.Create );
            byte[] info = new UTF8Encoding ( true ).GetBytes ( json );
            stream.Write ( info, 0, info.Length );
            stream.Close ();
#if UNITY_EDITOR
            AssetDatabase.Refresh ();
#endif
            return path;
        }

        public static object LoadFromJson ( string path )
        {
            var stream = new FileStream ( path, FileMode.Open );
            TextReader tr = new StreamReader ( stream );
            var deserializedProduct = JsonConvert.DeserializeObject ( tr.ReadToEnd (), SERIALIZER_SETTINGS );
            stream.Close ();
            tr.Close ();
            return deserializedProduct;
        }
    }
}