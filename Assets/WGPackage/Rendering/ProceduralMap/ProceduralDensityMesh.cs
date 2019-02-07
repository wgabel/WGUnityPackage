using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using WG.CORE.Voxels;
using WGPackage.Maps.GridMap;
using WGPackage.Rendering.DynamicDensityMap.Helpers;
using WGPackage.Rendering.DynamicDensityMap.MaterialProviders;

namespace WGPackage.Rendering.ProceduralMap
{
    /// <summary>
    /// Step 1 : Build a procesural mesh based on cell dataPoints. Each point can have multiple quads.
    /// Step 2 : sSet ChunkMaxSize to divide mesh into chunks
    /// </summary>
    public class ProceduralDensityMesh
    {
        public static readonly string MESH_NAME = "procedural Mesh";
        IMaterialProvider _materialProvider;

        public ProceduralDensityMesh ( IMaterialProvider materialProvider )
        {
            _materialProvider = materialProvider;
        }

        public GameObject Create ( MeshInputData inputData ) =>
            new GameObject ( GetObjectName() )
                .AddComponent<MeshRenderer> ().SetSharedMaterial( _materialProvider.GetMaterial () )
                .gameObject.AddComponent<MeshFilter> ()
                    .ApplyMesh ( CreateMesh ( inputData ) )
                .gameObject;

        private string GetObjectName ( ) => MESH_NAME + Path.GetRandomFileName ();
        
        public Mesh CreateMesh ( MeshInputData inputData )
        {
            Mesh m = new Mesh ();
            MeshData md = new MeshData ();
            MeshWorker worker = new MeshWorker ();

            //Create mesh for every voxel
            foreach ( Voxel voxel in inputData.DataPoints )
            {
                if ( !voxel.Active ) continue;
                worker.Reset ().SetInitialPoint ( voxel );
            }
            return m;
        }

        private bool CheckIfVoxelIsOutSide ( IntVector2 point, int mapSize )
        {
            return point.x < 0 || point.x >= mapSize || point.z < 0 || point.z >= mapSize;
        }

        private int HasNeighbourAVertToUse()
        {
            return -1;
        }

        public void CreateMesh ( Voxel[] points, int mapSize, List<MonoBehaviour> noiseProviders, float scale, IMaterialProvider materialProvider )
        {
            throw new NotImplementedException ();
        }
    }

    public class MeshData
    {
        public List<Vector3> vertices { get; set; }
        public List<int> triangles { get; set; }
        public List<Vector2> uvs { get; set; }

        public MeshData()
        {
            vertices = new List<Vector3> ();
            triangles = new List<int> ();
            uvs = new List<Vector2> ();
        }
    }

    public class MeshWorker
    {
        public float[] CornerHeights { get; set; }
        public int[] TempVertsIndexes { get; set; }
        public int[] TempTris { get; set; }
        public Vector3 NewV { get; set; }
        public Vector3 Point { get; set; }
        public bool[] InactiveNeighbours { get; private set; }
        public int goodVertIndex = -1;
        public MeshWorker ( )
        {
            Reset ();
        }

        public MeshWorker Reset ()
        {
            CornerHeights = new float[4];
            TempVertsIndexes = new int[5];
            TempTris = new int[12];
            NewV = new Vector3 ();
            InactiveNeighbours = new bool[4];
            goodVertIndex = -1;
            return this;
        }

        public void SetInitialPoint ( Voxel voxel )
        {
            Point = voxel.Position.ToVector3;
        }

        public void SetNeighbourState ( int index, bool newState )
        {
            InactiveNeighbours [ index ] = newState;
        }

        internal bool SetNeighbourGoodVert ( int v )
        {
            goodVertIndex = v;
            return v != -1;
        }

        public void SetTempVertsIndexes ( int index )
        {
            TempVertsIndexes[index] = goodVertIndex;
        }
    }

    public class MeshInputData
    {
        public Voxel[] DataPoints { get; set; }
        public float QuadSize { get; set; }
        public int CellDivision { get; set; }
    }

    public static class MeshDataExtension
    {
        public static MeshData FillMeshData ( this MeshData meshData, MeshInputData inputData )
        {
            MeshData md = new MeshData ();
            return md;
        }

        public static Transform SetPosition ( Transform transform, Vector3 newPosition )
        {
            transform.position = newPosition;
            return transform;
        }
    }
}
