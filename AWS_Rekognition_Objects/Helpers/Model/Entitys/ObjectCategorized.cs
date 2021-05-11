using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWS_Rekognition_Objects.Helpers.Model.Entitys
{
    [Obsolete("Classe obsoleta não usar!")]
    class ObjectCategorized
    {
        public string Name { get; set; }
        public float Confidence { get; set; }
        public Pen penCategory { get; set; }
        public List<ItemObject> Instances { get; set; }//Uma lista de Rentagulos por categoria
        public List<String> Parents { get; set; }
    }
}
