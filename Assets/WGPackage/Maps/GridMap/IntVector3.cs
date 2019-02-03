using UnityEngine;
using System.Collections;

namespace WG.CORE
{
	[System.Serializable]
	public class IntVector3
	{
		public int x;
		public int y;
		public int z;

		public IntVector3(){}
		public IntVector3 (int x, int y, int z)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}

        public IntVector3 ( Vector3 position )
        {
            this.x = Mathf.RoundToInt ( position.x );
            this.y = Mathf.RoundToInt ( position.y );
            this.z = Mathf.RoundToInt ( position.z );
        }

        public Vector3 ToVector3
        {
            get
            {
                return new Vector3 ( x, y, z );
            }
        }
    }
}