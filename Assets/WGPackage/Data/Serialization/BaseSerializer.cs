using Newtonsoft.Json;
using System.IO;
using System.Text;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace WGPackage.Data.Serialization
{
    /// <summary>
    /// Basic Json Serializer
    /// </summary>
    public static class BaseSerializer
    {
        private static readonly JsonSerializerSettings SERIALIZER_SETTINGS =
            new JsonSerializerSettings () { TypeNameHandling = TypeNameHandling.All };

        private static string GetPath<T> ( string fileUniqueNamePart, string pathRoot = "" )
        {
            return GetDirectoryPath ( pathRoot ) + Path.DirectorySeparatorChar + typeof ( T ) + "_" + fileUniqueNamePart + ".json";
        }
           

        private static string GetDirectoryPath ( string pathRoot )
        {
            return Application.dataPath + Path.DirectorySeparatorChar + pathRoot;
        }


        public static string SaveToJson<T> ( T objectToSerialize, string fileUniqueNamePart, string pathRoot = "", bool overwrite = false )
        {
            string path = GetPath<T> ( fileUniqueNamePart, pathRoot );
            if ( File.Exists ( path ) && !overwrite )
                throw new System.FormatException ( "File Exists! Use Overwrite parameter!" );

            if ( !Directory.Exists ( GetDirectoryPath ( pathRoot ) ) )
                throw new System.FormatException ( "Directory does not exist!" );

            string json = JsonConvert.SerializeObject ( objectToSerialize, SERIALIZER_SETTINGS );
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
            if ( string.IsNullOrEmpty ( path ) )
                throw new System.FormatException ( "Path is Empty!" );

            if ( !File.Exists ( path ) )
                throw new System.FormatException ( "Path is not a file!" );

            var stream = new FileStream ( path, FileMode.Open );
            TextReader tr = new StreamReader ( stream );
            var deserializedProduct = JsonConvert.DeserializeObject ( tr.ReadToEnd (), SERIALIZER_SETTINGS );
            stream.Close ();
            tr.Close ();
            return deserializedProduct;
        }
    }
}