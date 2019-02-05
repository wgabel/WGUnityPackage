using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMaterialProvider : IMaterialProvider
{
    public Material[] materials { get; private set; }

    public BasicMaterialProvider ( string path )
    {
        materials = new Material[] { Resources.Load<Material> ( "materials/testMaterial" ) };
    }

    public Material GetMaterial ()
    {
        return materials[0];
    }
}
