using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WGPackage.Maps.GridMap;

namespace WG.CORE.Voxels
{
    [System.Serializable]
    public struct Voxel
    {
        [SerializeField]
        private bool active;
        [SerializeField]
        private IntVector2 position;
        [SerializeField]
        private int [] vertexIndexes;

        public Voxel (  IntVector2 newPosition, bool isActive = true )
        {
            this.active = isActive;
            this.position = newPosition;
            vertexIndexes = new int [ 5 ] { -1, -1, -1, -1, -1 };
        }

        public bool Active
        {
            get
            {
                return active;
            }

            set
            {
                active = value;
            }
        }

        public IntVector2 Position
        {
            get
            {
                return position;
            }

            set
            {
                position = value;
            }
        }

        public int [] VertexIndexes
        {
            get
            {
                return vertexIndexes;
            }

            set
            {
                vertexIndexes = value;
            }
        }
    }
}