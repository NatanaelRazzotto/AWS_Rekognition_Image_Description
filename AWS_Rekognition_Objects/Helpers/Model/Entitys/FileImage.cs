using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWS_Rekognition_Objects.Helpers.Model.Entitys
{
    public class FileImage : ICloneable
    {
        private string _nameFile;
        private Image _image;
        private Bitmap _imagesOfCategoryBitmap;
        private Bitmap _imageAnalizeBitmap;
        private Bitmap _imagesBitmap;
        public string nameFile
        {
            get => _nameFile;
            set => _nameFile = value;
        }
        public Image image
        {
            get => _image;
            set => _image = value;
        }
        public Bitmap imageAnalizeBitmap
        {
            get => _imageAnalizeBitmap;
            set => _imageAnalizeBitmap = value;
        }
        public Bitmap imagesOfCategoryBitmap
        {
            get => _imagesOfCategoryBitmap;
            set => _imagesOfCategoryBitmap = value;
        }
        public Bitmap imagesBitmap
        {
            get => _imagesBitmap;
            set => _imagesBitmap = value;
        }

        public FileImage()
        { 
        }
        public FileImage(String _nameFile) {
            this._nameFile = _nameFile;
            this._image = Image.FromFile(_nameFile);
            this._imageAnalizeBitmap = new Bitmap(_nameFile);
            this._imagesOfCategoryBitmap = new Bitmap(_nameFile);
            this._imagesBitmap = new Bitmap(_nameFile);
        }

        public object Clone()
        {
            FileImage fileImage = (FileImage)this.MemberwiseClone();
            return fileImage;

        }
    }
}
