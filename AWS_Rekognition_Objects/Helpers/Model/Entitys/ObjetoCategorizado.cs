using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWS_Rekognition_Objects.Helpers.Model.Entitys
{
    class ObjetoCategorizado
    {
        public List<RectangleF> Instances { get; set; }//Uma lista de Rentagulos por categoria
        public string Name { get; set; }
    }
}
