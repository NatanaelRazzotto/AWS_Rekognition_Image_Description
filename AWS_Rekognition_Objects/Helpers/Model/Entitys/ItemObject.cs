using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWS_Rekognition_Objects.Helpers.Model.Entitys
{
    [Obsolete ("Classe obsoleta não usar!")]
    public class ItemObject
    {
        public Pen penItem { get; set; }
        public RectangleF Rectangle { get; set; }
        public float Confidence { get; set; }
    }
}
