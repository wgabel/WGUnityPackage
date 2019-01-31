using UnityEngine;
using WGPackage.Rendering.Canvases;

public class CanvasesTest : MonoBehaviour
{
    /*
     Canvases:
     - Loading from assets.
     - Retrieveing from Manager
     - Showing
     - Hiding
     - Needs to have a queue
     - Status (open/closed)
     - Status (active/disabled)
     */
    [ContextMenu ( "reun test" )]
    void Test ()
    {
        ICustomCanvasController controller = new CustomCanvasController ();
    }
}