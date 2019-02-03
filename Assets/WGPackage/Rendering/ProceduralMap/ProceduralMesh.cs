using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WG.CORE.NoiseGeneration;
using WGPackage.Maps.GridMap;

namespace WG.CORE.Voxels
{
    public class ProceduralMesh : IProceduralMesh
    {
        public Material material;
        private List<Vector3> vertices = new List<Vector3> ();
        private List<int> triangles = new List<int> ();
        private List<Vector2> uvs = new List<Vector2> ();

        private IntVector2 [] neighbours = new IntVector2 []
        {
            new IntVector2(-1,0),
            new IntVector2(-1,1),
            new IntVector2(0,1),
            new IntVector2(1,1),
            new IntVector2(1,0),
            new IntVector2(1,-1),
            new IntVector2(0,-1),
            new IntVector2(-1,-1),
        };

        int [] [] neighboursForVerts = new int [ 4 ] []
        {
            new int[3]{0,1,2},
            new int[3]{2,3,4},
            new int[3]{4,5,6},
            new int[3]{6,7,0},
        };

        int [] [] neighbourVertexes = new int [ 4 ] []
        {
            new int[3]{1,2,3},
            new int[3]{2,3,0},
            new int[3]{3,0,1},
            new int[3]{0,1,2},
        };

        int [] [] trisFromVerts = new int [ 4 ] []
        {
            new int [3]{ 0,1,4},
            new int [3]{ 1,2,4},
            new int [3]{ 2,3,4},
            new int [3]{ 3,0,4},
        };

        Vector3 [] vertsCoords = new Vector3 []
        {
            new Vector3(-0.5f,0, 0.5f ),
            new Vector3( 0.5f,0, 0.5f ),
            new Vector3( 0.5f,0,-0.5f ),
            new Vector3( -0.5f,0,-0.5f ),
            new Vector3( 0 ,0,0 ),
        };

        public void CreateMesh ( Voxel [] points, int mapSize, List<MonoBehaviour> noiseProviders, float scale, IMaterialProvider materialProvider )
        {
            //if ( noiseProviders == null )
            //{
            //    throw new System.NullReferenceException ( "INoise providers are NULL! *GASP!*" );
            //}
            for ( int p = 0; p < noiseProviders.Count; p++ )
            {
                ( noiseProviders[p] as INoise ).GenerateNoiseData (mapSize);
            }
            vertices = new List<Vector3> ();
            triangles = new List<int> ();
            uvs = new List<Vector2> ();
            Vector3 point = new Vector3 ();
            int vertNumber = 0;
            
            for ( int i = 0; i < points.Length; i++ )
            {
                float [] cornerHeights = new float [ 4 ];
                int [] tempVertsIndexes = new int [ 5 ];
                int [] tempTris = new int [ 12 ];
                Vector3 newV = new Vector3 ();
                if ( !points [ i ].Active ) continue;

                point = points [ i ].Position.ToVector3;

                for ( int v = 0; v < 4; v++ )
                {
                    bool inactiveNeighbour = false;
                    int goodVertIndex = HasNeighbourAVertToUse ( v, mapSize, points, points [ i ].Position, out inactiveNeighbour );
                    if ( goodVertIndex == -1 )
                    {
                        //Neighbours had no good vert. Use new one.
                        tempVertsIndexes [ v ] = vertNumber;
                        points [ i ].VertexIndexes [ v ] = vertNumber;
                        vertNumber++;
                        if ( !inactiveNeighbour ) GetPointY ( noiseProviders, new Vector2( point.x + vertsCoords [ v ].x, point.z + vertsCoords [ v ].z ),out point.y );
                        newV = ( point + vertsCoords [ v ] );
                        vertices.Add ( newV * scale );
                        uvs.Add ( new Vector2 ( newV.x / (float)mapSize, newV.z / (float)mapSize ) );
                        cornerHeights [ v ] = point.y;
                    }
                    else
                    {
                        tempVertsIndexes [ v ] = goodVertIndex;
                    }
                }
                //Add middle vertex:
                tempVertsIndexes [ 4 ] = vertNumber;
                points [ i ].VertexIndexes [ 4 ] = vertNumber;
                GetPointY ( noiseProviders, new Vector2 ( point.x + vertsCoords [ 4 ].x, point.z + vertsCoords [ 4 ].z ), out point.y );
                point.y = GetPointYMedian ( cornerHeights );
                newV = ( point + vertsCoords [ 4 ] );
                vertices.Add ( newV * scale );
                uvs.Add ( new Vector2 ( newV.x / ( float )mapSize, newV.z / ( float )mapSize ) );
                vertNumber++;

                // Now do tris:
                int l = 0;
                for ( int t = 0; t < 12; t += 3 )
                {
                    tempTris [ t ] = tempVertsIndexes [ trisFromVerts [ l ] [ 0 ] ];
                    tempTris [ t + 1 ] = tempVertsIndexes [ trisFromVerts [ l ] [ 1 ] ];
                    tempTris [ t + 2 ] = tempVertsIndexes [ trisFromVerts [ l ] [ 2 ] ];
                    l++;
                }
                triangles.AddRange ( new List<int> ( tempTris ) );
            }

            GameObject go = new GameObject ( "test procedural mountains" );
            MeshRenderer renderer = go.AddComponent<MeshRenderer> ();
            MeshFilter meshFiler = go.AddComponent<MeshFilter> ();
            Mesh mesh = new Mesh ();
            mesh.name = "testMesh";
            mesh.vertices = vertices.ToArray ();
            mesh.triangles = triangles.ToArray ();
            mesh.uv = uvs.ToArray ();
            mesh.RecalculateNormals ();
            meshFiler.mesh = mesh;
            //material.mainTextureScale = new Vector2 (mapSize, mapSize);
            renderer.material = material;
            //go.transform.localPosition = transform.localPosition;
            go.AddComponent<MeshCollider> ();
            renderer.sharedMaterial = materialProvider.GetMaterial ();
        }

        float GetPointYMedian( float [] cornerHeights )
        {
            float m = 0f;
            for(int i = 0; i < cornerHeights.Length; i++ )
            {
                m += cornerHeights [ i ];
            }
            return m / 4f;
        }

        float GetPointY( List<MonoBehaviour> noiseProviders, Vector2 position, out float newY )
        {
            newY = 0f;
            for ( int p = 0; p < noiseProviders.Count; p++ )
            {
                newY += ( noiseProviders [ p ] as INoise ).SampleNoiseData ( position.x, position.y, new IntVector3 () );
            }
            return newY;
        }

        Vector2 NewUVPoint ( IntVector3 point, int corner, float mapSize )
        {
            return new Vector2 ( ( ( point.x * 1.0f ) / mapSize ) + ( 1f / ( mapSize * 2f ) ), ( ( point.y * 1.0f ) / mapSize ) + ( 1f / ( mapSize * 2f ) ) );
        }

        int HasNeighbourAVertToUse ( int corner, int mapSize, Voxel [] points, IntVector2 pointPosition, out bool inactiveNeighbours )
        {
            inactiveNeighbours = false;
            int returnIndex = -1;
            IntVector2 tempPoint = new IntVector2 ();
            for ( int n = 0; n < 3; n++ )
            {

                int index = neighboursForVerts [ corner ] [ n ];
                tempPoint.x = neighbours [ index ].x + pointPosition.x;
                tempPoint.z = neighbours [ index ].z + pointPosition.z;

                if ( CheckIfOutSide ( tempPoint, mapSize ) )
                {
                    inactiveNeighbours = true;
                    //Debug.Log ( string.Format ( "Checking neighbour {0} for corner {1}, position: {2} : OUTSIDE", n, corner, tempPoint.ToString () ) );
                    continue;
                }

                // We know its inside. Check if neighbour active:
                int nIndex = Helper.Convert2dto1d ( tempPoint.x, tempPoint.z, mapSize );
                if ( !points [ nIndex ].Active )
                {
                    // This neighbour is not active, so it will not have any good verts. Skip.
                    //Debug.Log ( string.Format ( "Checking neighbour {0} for corner {1}, position: {2} : INSIDE BUT NOT ACTIVE", n, corner, tempPoint.ToString () ) );
                    inactiveNeighbours = true;
                    continue;
                }
                // Get this point vert that we want to use:
                int indexVertN = neighbourVertexes [ corner ] [ n ];
                // Check if it is set already( if it exists)

                if ( points [ nIndex ].VertexIndexes [ indexVertN ] != -1 )
                {
                    returnIndex = points [ nIndex ].VertexIndexes [ indexVertN ];
                }
                //Debug.Log ( string.Format ( "Checking neighbour {0} for corner {1}, position: {2} : INSIDE AND ACTIVE. vert index we want:{3}, it's value: [{4}] ", n, corner, tempPoint.ToString (), indexVertN, points [ nIndex ].VertexIndexes [ indexVertN ] ) );
            }
            return returnIndex;
        }

        bool CheckIfOutSide ( IntVector2 point, int mapSize )
        {
            return point.x < 0 || point.x >= mapSize || point.z < 0 || point.z >= mapSize;
        }
    }
}