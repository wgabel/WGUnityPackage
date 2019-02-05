using UnityEngine;

namespace WGPackage.Maps.GridMap.MapRenderers
{
    public struct RenderData
    {
        public float MapCellSize { get; internal set; }
        public Vector3 MapStartPosition { get; internal set; }
        public int MapCellDivision { get; internal set; }
        public RenderData ( float CellSize, Vector3 startPosition, int mapCellDivision )
        {
            this.MapCellSize = CellSize;
            this.MapStartPosition = startPosition;
            this.MapCellDivision = Mathf.Clamp( mapCellDivision, 1, int.MaxValue );
        }
    }
}
