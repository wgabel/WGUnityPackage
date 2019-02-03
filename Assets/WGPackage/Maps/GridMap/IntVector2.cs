using UnityEngine;
using System.Collections;

namespace WGPackage.Maps.GridMap
{
	[System.Serializable]
	public struct IntVector2
	{
		public int x;
		public int z;
		public IntVector2 (int x, int z)
		{
			this.x = x;
			this.z = z;
		}

		public override string ToString ()
		{
			return string.Format ("[IntVector2: x={0}, z={1}]", x, z);
		}

        public Vector2 ToVector2
        {
            get
            {
                return new Vector2 ( x, z );
            }
        }

        public Vector3 ToVector3
        {
            get
            {
                return new Vector3 ( x, 0, z );
            }
        }

        public Vector2 ToVector2Scaled ( float scale )
        {
            return new Vector2 ( x * scale, z * scale );
        }

        public Vector3 ToVector3Scaled ( float scale )
        {
            return new Vector3 ( x * scale, 0f, z * scale );
        }

		public static bool operator ==(IntVector2 one, IntVector2 two)
		{
			if ( one.x == two.x && one.z == two.z )
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public static bool operator !=(IntVector2 one, IntVector2 two)
		{
			if ( one.x == two.x && one.z == two.z )
			{
				return false;
			}
			else
			{
				return true;
			}
		}

		public override bool Equals ( object obj )
		{
			if ( obj == null )
				return false;
			if ( ReferenceEquals ( this, obj ) )
				return true;
			if ( obj.GetType () != typeof( IntVector2 ) )
				return false;
			IntVector2 other = ( IntVector2 ) obj;
			return x == other.x && z == other.z;
		}

		public bool Equals(IntVector2 other)
		{
			if ((object)other == null)
				return false;
			return x == other.x && z == other.z;
		}

		public override int GetHashCode ()
		{
			return base.GetHashCode ();
		}
	}


}