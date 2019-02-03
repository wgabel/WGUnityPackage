using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WG.CORE.NoiseGeneration
{
    public interface INoise
    {
        void GenerateNoiseData ( int chunkSize = 32 );
        float SampleNoiseData ( float x, float y, IntVector3 chunkPosition );
    }
}