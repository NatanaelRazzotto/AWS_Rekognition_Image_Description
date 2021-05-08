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
        private Bitmap _imageZoom;
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
        public Bitmap imageZoom
        {
            get => _imageZoom;
            set => _imageZoom = value;
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
        [Obsolete]
        public object Clone()
        {
            FileImage fileImage = (FileImage)this.MemberwiseClone();
            fileImage.imageAnalizeBitmap = (Bitmap)this.imageAnalizeBitmap.Clone();
            fileImage._imagesOfCategoryBitmap = (Bitmap)this._imagesOfCategoryBitmap.Clone();
            fileImage._imagesBitmap = (Bitmap)this._imagesBitmap.Clone();
            return fileImage;

        }
    }
}
