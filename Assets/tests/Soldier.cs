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

namespace WGPackage.Data.Serialization.Test
{
    [System.Serializable]
    public class BaseEntityModel
    {
        public string baseName;
        [SerializeField]
        public virtual string BaseName
        {
            get
            {
                return BaseName;
            }
            set
            {
                baseName = value;
            }
        }

    }
}