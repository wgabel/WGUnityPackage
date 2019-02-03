using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMaterialProvider : IMaterialProvider
{
    public Material[] materials;

    public Material GetMaterial ()
    {
        return materials[0];
    }
}
