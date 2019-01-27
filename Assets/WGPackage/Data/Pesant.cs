using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;


[System.Serializable]
public class Pesant : Soldier
{
    [SerializeField]
    public int Hp { get; set; }
    public List<Soldier> Soldiers { get; set; }
}
