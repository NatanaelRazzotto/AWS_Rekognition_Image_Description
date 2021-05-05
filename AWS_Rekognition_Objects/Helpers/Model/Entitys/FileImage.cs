using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWS_Rekognition_Objects.Helpers.Model.Entitys
{
    public class FileImage
    {
        private string _nameFile;
        public string nameFile  
        {
            get => _nameFile;
            set => _nameFile = value;
        }

        public FileImage(String _nameFile) {
            this._nameFile = _nameFile;
        }
    }
}
