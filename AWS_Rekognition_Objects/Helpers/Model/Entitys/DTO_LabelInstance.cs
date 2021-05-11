using Amazon.Rekognition.Model;
using System.Collections.Generic;

namespace AWS_Rekognition_Objects.Helpers.Model.Entitys
{
    public class DTO_LabelInstance
    {
        public string NameCategoria{ get; set; }
        public int idCategoria { get; set; }
        public float confidence { get; set; }
        public List<Parent> parents { get; set; }
        public List<Instance> CategoryInstances { get; set; }
        public string nameItem { get; set; }
        public int idItem { get; set; }
        public Instance Instance { get; set; }
    }
}
