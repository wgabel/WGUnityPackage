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
        [SerializeField]
        public virtual string BaseName { get; set; }
    }
}