using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

namespace WGPackage.Data.Serialization.Test
{
    [System.Serializable]
    public class Pesant : BaseEntityModel
    {
        [SerializeField]
        public int Hp { get; set; }
        public List<BaseEntityModel> Soldiers { get; set; }
    }

    [System.Serializable]
    public class Soldier : BaseEntityModel
    {
        [SerializeField]
        public int Hp { get; set; }
        public List<BaseEntityModel> Soldiers { get; set; }
    }

    [System.Serializable]
    public class ChildPesant : Pesant
    {
        public IEnumerable<object> toys;
    }
}