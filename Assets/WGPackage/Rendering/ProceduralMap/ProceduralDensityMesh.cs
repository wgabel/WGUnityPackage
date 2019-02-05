using System.Collections.Generic;
using System.IO;
using UnityEngine;
using WG.CORE.Voxels;

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



            return m;
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

    public class MeshInputData
    {
        public Voxel DataPoint { get; set; }
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

        public static MeshFilter ApplyMesh ( this MeshFilter meshFilter, Mesh mesh )
        {
            meshFilter.mesh = mesh;
            return meshFilter;
        }

        public static MeshRenderer SetSharedMaterial ( this MeshRenderer renderer, Material material )
        {
            renderer.sharedMaterial = material;
            return renderer;
        }
    }
}
