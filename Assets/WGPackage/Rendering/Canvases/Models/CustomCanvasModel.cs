using WGPackage.Rendering.Canvases.Switches;

namespace WGPackage.Rendering.Canvases.Models
{
    public class CustomCanvasModel
    {
        public string Name { get; set; }
        public ECanvasState CanvasState { get; set; }
        public ECanvasStatus CanvasStatus { get; set; }
    }
}
