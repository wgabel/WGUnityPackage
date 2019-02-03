using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WG.CORE.NoiseGeneration
{
    public class NoiseGenerator : MonoBehaviour
    {
        [SerializeField]
        protected NoiseSystemBase noiseSystem;

        [ContextMenu("Test noise genration")]
        public void Test()
        {
            ( noiseSystem as INoise ).GenerateNoiseData ();
        }
    }
}