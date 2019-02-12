using System.Collections.Generic;
using UnityEngine;
using WGPackage.Maps.GridMap;

namespace WGPackage.Rendering.DynamicDensityMap.MeshCreators
{
    public class DefaultMeshCreator : IMeshCreator
    {
        private IntVector2[] neighbours = new IntVector2[]
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

        private class MeshData
        {
            public List<Vector3> Vertices { get; set; }
            public List<int> Triangles { get; set; }
            public List<Vector2> Uvs { get; set; }

            public MeshData ()
            {
                Vertices = new List<Vector3> ();
                Triangles = new List<int> ();
                Uvs = new List<Vector2> ();
            }
        }

        public Mesh Create ( IMapDefinition mapDefinition, IPoxel[] allPoxels, int index, string newMeshName = "" )
        {
            
            return new Mesh ();
        }

        bool IsNeighbourValid ( IPoxel poxel, IPoxel[] allpoxels, int neighbourIndex, IMapDefinition mapDefinition, out IPoxel goodPoxel )
        {
            goodPoxel = new Poxel ();
            if ( IsPoxelOutOfMapBounds ( poxel, mapDefinition ) )
                return false;
            
            return true;
        }

        bool IsNeighbourInSameChunk()
        {
            return true;
        }

        private Poxel GetNeighbour ( IPoxel current, IPoxel[] allPoxels, int neighbourIndex, IMapDefinition mapDefinition )
        {
            throw new System.NotImplementedException ();
            //int currentPoxelIndex = Helper.Convert2dto1d ( current.PostionInMap.x, current.PostionInMap.z, mapDefinition.Height );
        }

        private bool IsPoxelOutOfMapBounds ( IPoxel poxel, IMapDefinition mapDefinition ) =>
            poxel.PostionInMap.x < 0 || 
            poxel.PostionInMap.x >= mapDefinition.Width || 
            poxel.PostionInMap.z < 0 || 
            poxel.PostionInMap.z >= mapDefinition.Height;

        private bool IsNeghbourDone()
        {
            return false;
        }
    }

    //public class Triangle
    //{
    //    private TrianglePoint[] _points = new TrianglePoint[3];
    //    public int[] trianlges = new int[0];
    //    public Vector2 MiddlePointPosition { get; private set; }
    //    public int CornerPoint { get; private set; }

    //    public Triangle( TrianglePoint point1, TrianglePoint point2, TrianglePoint point3 )
    //    {
    //        _points = new TrianglePoint[3]
    //        {
    //            point1,
    //            point2,
    //            point3
    //        };
            
    //    }

    //    public Triangle FindDivision ( int avaliableIndex )
    //    {
    //        float d0 = Distance ( _points[0].Position2D, _points[1].Position2D );
    //        float d1 = Distance ( _points[0].Position2D, _points[2].Position2D );
    //        float d2 = Distance ( _points[1].Position2D, _points[2].Position2D );

    //        if ( d0 >= d1 && d0 >= d2 )
    //        {
    //            CornerPoint = 2;
    //            MiddlePointPosition = Vector2.Lerp ( _points[0].Position2D, _points[1].Position2D, 0.5f );
    //        }
    //        else if ( d1 >= d2 )
    //        {
    //            CornerPoint = 1;
    //            MiddlePointPosition = Vector2.Lerp ( _points[0].Position2D, _points[2].Position2D, 0.5f );
    //        }
    //        else
    //        {
    //            CornerPoint = 0;
    //            MiddlePointPosition = Vector2.Lerp ( _points[1].Position2D, _points[1].Position2D, 0.5f );
    //        }
    //        Divide ( avaliableIndex, CornerPoint );
    //        return this;
    //    }

    //    private int GetNext ( int current ) => _points[current % 3].Index;

    //    private void Divide ( int avaliableIndex, int current )
    //    {
    //        trianlges = new int[6] 
    //        {
    //            CornerPoint, GetNext ( current++ ),avaliableIndex,
    //            CornerPoint, avaliableIndex, GetNext ( current++ )
    //        };
    //    }

    //    public Triangle Draw ()
    //    {

    //        return this;
    //    }

    //    public float Distance ( Vector2 p1, Vector2 p2 ) =>
    //        Mathf.Pow ( p1.x - p2.x, 2f ) + Mathf.Pow ( p1.y - p2.y, 2f );
    //}

    //public struct TrianglePoint
    //{
    //    public Vector3 Position { get; private set; }
    //    public Vector2 Position2D { get { return new Vector2 ( Position.x, Position.z ); } }
    //    public int Index { get; private set; }

    //    public TrianglePoint ( Vector3 position, int index )
    //    {
    //        Position = position;
    //        Index = index;
    //    }
    //}

}
