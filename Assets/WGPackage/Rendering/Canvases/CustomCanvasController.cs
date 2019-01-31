using System;
using WGPackage.Data.Serialization;
using WGPackage.Rendering.Canvases;
using WGPackage.Rendering.Canvases.Models;

namespace WGPackage.Rendering.Canvases
{
    public class CustomCanvasController : ICustomCanvasController
    {
        public CustomCanvasModel customCanvasData { get; }

        public CustomCanvasController ()
        {
            customCanvasData = new CustomCanvasModel ()
            {
                Name = "Some canvas Data"
            };
            string soldierPath = BaseSerializer.SaveToJson<CustomCanvasModel> ( customCanvasData, customCanvasData.Name, "tests", overwrite: true );
        }

        public void ChangeState ()
        {
            throw new NotImplementedException ();
        }

        public void ChangeStatus ()
        {
            throw new NotImplementedException ();
        }

        public Action Close ()
        {
            throw new NotImplementedException ();
        }

        public Action Open ()
        {
            throw new NotImplementedException ();
        }
    }
}
