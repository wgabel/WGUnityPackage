using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WG.CORE.NoiseGeneration
{
    [System.Serializable]
    public class PerliNoiseTexture : NoiseSystemBase, INoise
    {
        [SerializeField]
        protected Texture2D noiseTexture;

        [SerializeField]
        protected GameObject qobjectToVisualise;
        [SerializeField]
        protected float xOrigin = 0f;
        [SerializeField]
        protected float yOrigin = 0f;
        [SerializeField]
        protected float scale = 1f;
        [SerializeField]
        protected int textureSize = 32;

        private Color [] pixels = new Color [ 0 ];
        private float lastScale = 1f;
        private float lastX = 0f;
        private float lastY = 0f;
        private int lastTextureSize = 0;

        private float startValue = 1024f;

        public void GenerateNoiseData ( int chunkSize = 32 )
        {
            textureSize = chunkSize;
            GeneratePerlinDataTexture ();
            ApplyTextureToRenderer ();
            lastX = xOrigin;
            lastY = yOrigin;
        }

        public float SampleNoiseData ( float x, float y, IntVector3 chunkPosition )
        {
            if ( noiseTexture == null )
            {
                GeneratePerlinDataTexture ();
            }

            // TODO : out of boundd hanndling. Scaling value? Normalisation?

            return pixels [ ( int )( y * noiseTexture.width + x ) ].r;
        }

        private void GeneratePerlinDataTexture ( )
        {
            noiseTexture = new Texture2D ( textureSize, textureSize, TextureFormat.ARGB32, false, true );
            noiseTexture.filterMode = FilterMode.Point;
            float y = 0;
            pixels = new Color [ noiseTexture.width * noiseTexture.height ];
            while ( y < noiseTexture.height )
            {
                float x = 0;
                while ( x < noiseTexture.width )
                {
                    float xCoord = (startValue + xOrigin) + ( x / noiseTexture.width ) * scale;// / noiseTexture.width * scale;
                    float yCoord = (startValue + yOrigin) + ( y / noiseTexture.height ) * scale;// / noiseTexture.height * scale;
                    float sample = Mathf.PerlinNoise ( xCoord, yCoord );
                    pixels [ ( int )( y * noiseTexture.width + x ) ] = new Color ( sample, sample, sample );
                    x++;
                }
                y++;
            }
            noiseTexture.SetPixels ( pixels );
            noiseTexture.Apply ();
        }

        private void ApplyTextureToRenderer ( )
        {
            Renderer renderer = qobjectToVisualise.GetComponent<Renderer> ();
            if ( renderer == null )
            {
                return;
            }
            renderer.sharedMaterial.mainTexture = noiseTexture;
        }

        private void Update ( )
        {
            if ( noiseTexture == null )
            {
                return;
            }

            if ( scale != lastScale )
            {
                GenerateNoiseData ();

            }

            if ( lastTextureSize != textureSize )
            {
                GenerateNoiseData ();
            }

            if ( !AreEqual ( xOrigin, lastX ) || !AreEqual ( yOrigin, lastY ) )
            {
                GenerateNoiseData ();
            }

            lastScale = scale;
            lastTextureSize = textureSize;
            lastX = xOrigin;
            lastY = yOrigin;
        }

        private bool AreEqual ( float a, float b )
        {
            if ( a == b )
            {
                return true;
            }

            if ( Mathf.Abs ( a - b ) > Mathf.Epsilon )
            {
                return false;
            }
            return false;
        }
    }
}