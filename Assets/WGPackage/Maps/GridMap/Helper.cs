using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WGPackage.Maps.GridMap
{
    public static class Helper
    {
        public static IntVector2 Convert1dTo2d ( int index, int heightOfArray )
        {
            return new IntVector2 ( index / heightOfArray, index % heightOfArray );
        }

        public static int Convert2dto1d ( int posX, int posZ, int heightOfArray )
        {
            return posZ + ( heightOfArray * posX );
        }

        public static int Convert2dto1d ( IntVector2 p, int heightOfArray )
        {
            return p.z + ( heightOfArray * p.x );
        }

        public readonly static IntVector2 [] neighbourCoordsCross = new IntVector2 [ 4 ] {
            new IntVector2 (-1, 0),
            new IntVector2 (0, 1),
            new IntVector2 (1, 0),
            new IntVector2 (0, -1)
        };

        public readonly static IntVector2 [] neighbourCoords = new IntVector2 [ 8 ] {
            new IntVector2 (-1, -1),
            new IntVector2 (-1, 0),
            new IntVector2 (-1, 1),
            new IntVector2 (0, 1),
            new IntVector2 (1, 1),
            new IntVector2 (1, 0),
            new IntVector2 (1, -1),
            new IntVector2 (0, -1)
        };

        public static void CreateOneCubeObject ( out GameObject go, Vector3 newPosition, Color color, Transform optionalParent = null, string newName = "cube" )
        {
            go = GameObject.CreatePrimitive ( PrimitiveType.Cube );
            go.GetComponent<BoxCollider> ().enabled = false;
            go.transform.name = newName;
            go.transform.localPosition = newPosition;
            go.transform.SetParent ( optionalParent );
            Renderer rend = go.GetComponent<Renderer> ();
            if (rend)
            {
                rend.material.color = color;
            }
        }

        public static List<Transform> CreateCubeObjects ( IntVector2 [] locations, float cellSize, Color color, float newScale = 1f )
        {
            List<Transform> cubes = new List<Transform> ();
            
            foreach ( IntVector2 point in locations )
            {
                GameObject go = null;
                CreateOneCubeObject ( out go, point.ToVector3Scaled ( cellSize ), color, null, point.ToString () );
                cubes.Add ( go.transform );
                go.transform.localScale = new Vector3 ( newScale, newScale, newScale );
            }
            return cubes;
        }

        public static IntVector2 CreateRandomPoint ( int marginToBorders, IntVector2 mapSize )
        {
            return new IntVector2 ( Random.Range ( marginToBorders, mapSize.x - marginToBorders ), Random.Range ( marginToBorders, mapSize.z - marginToBorders ) );
        }

        public static IntVector2 [] CreateRandomPoints ( int nrOfPoints, int marginToBorders, IntVector2 mapSize )
        {
            IntVector2 [] returnValue = new IntVector2 [ nrOfPoints ];
            for ( int i = 0; i < nrOfPoints; i++ )
            {
                returnValue [ i ] = CreateRandomPoint ( marginToBorders, mapSize );
            }
            return returnValue;
        }
    }
}
