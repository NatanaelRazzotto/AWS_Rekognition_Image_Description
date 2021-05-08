using Amazon.Rekognition.Model;
using AWS_Rekognition_Objects.Helpers.Model.Entitys;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Image = Amazon.Rekognition.Model.Image;
using Label = Amazon.Rekognition.Model.Label;
using Point = System.Drawing.Point;

namespace AWS_Rekognition_Objects.Helpers.Model
{
    class PostProcessingImages
    {
        public FileImage desenharAnalise(List<Label> detectLabels, FileImage file)
        {
         
            foreach (Label label in detectLabels)
            {
                Pen pen = new Pen(Color.Red);
                foreach (Instance instance in label.Instances)
                {
                    file.imageAnalizeBitmap = definedRectangle(instance, file.imageAnalizeBitmap, pen);
                }
            }
            return file;
        }
        public FileImage filtrarPorCategoria(List<Instance> ListInstancesCategory, FileImage file)
        {
            FileImage fileImage = (FileImage)file.Clone();
            Pen pen = new Pen(Color.Aqua, 2);
            foreach (Instance instancesCategory in ListInstancesCategory)
            {
                fileImage.imagesOfCategoryBitmap =  definedRectangle(instancesCategory, fileImage.imageAnalizeBitmap, pen);
            }
            return fileImage;
        }
        public FileImage filtrarPorInstance(Instance instance, FileImage fileImage)
        {
            Pen pen = new Pen(Color.BlueViolet, 3);

            fileImage.imagesBitmap = definedRectangle(instance, fileImage.imagesOfCategoryBitmap, pen);
            
            return fileImage;
        }
        private Bitmap definedRectangle(Instance instancesCategory, Bitmap file , Pen pen) {

            Graphics graphics = Graphics.FromImage(file);
            graphics.DrawRectangle(pen, instancesCategory.BoundingBox.Left, instancesCategory.BoundingBox.Top,
                                       instancesCategory.BoundingBox.Width, instancesCategory.BoundingBox.Height);
            return file;
        }


    }
}
