using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WG.CORE.NoiseGeneration
{
    public class PerlinNoise : NoiseSystemBase, INoise
    {
        [SerializeField]
        private float startValue = 1024f;
        [SerializeField]
        private float chunkSize = 32;
        [SerializeField]
        private float scale = 1f;
        [SerializeField]
        protected float amplitude = 1f;


        public void GenerateNoiseData (int chunkSize = 32 )
        {
            this.chunkSize = chunkSize;
        }

        public float SampleNoiseData ( float x, float z, IntVector3 chunkPosition )
        {
            float xCoord = ( startValue + chunkPosition.x ) + ( x / chunkSize ) * scale;
            float zCoord = ( startValue + chunkPosition.z ) + ( z / chunkSize ) * scale;
            return Mathf.PerlinNoise ( xCoord, zCoord ) * amplitude;
        }
    }
}