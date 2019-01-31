using System;
using WGPackage.Rendering.Canvases.Models;

namespace WGPackage.Rendering.Canvases
{
    public interface ICustomCanvasController
    {
        CustomCanvasModel customCanvasData { get; }
        Action Open ();
        Action Close ();
        void ChangeState ();
        void ChangeStatus ();
    }
}