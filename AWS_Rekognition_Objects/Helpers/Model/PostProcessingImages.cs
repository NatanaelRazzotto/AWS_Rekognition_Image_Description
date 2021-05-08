﻿using Amazon.Rekognition.Model;
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
            // FileImage fileImage = (FileImage)file.Clone();
            // FileImage fileImage = new FileImage();
            Pen pen = new Pen(Color.Aqua, 2);

            Bitmap imageAnalizeBitmap = new Bitmap(file.imageAnalizeBitmap);

            foreach (Instance instancesCategory in ListInstancesCategory)
            {
                file.imagesOfCategoryBitmap =  definedRectangle(instancesCategory, imageAnalizeBitmap , pen);
            }
            return file;
        }
        public FileImage filtrarPorInstance(Instance instance, FileImage file)
        {
            Pen pen = new Pen(Color.BlueViolet, 3);
           // FileImage file = new FileImage();
            //file.imageAnalizeBitmap = fileImage.imageAnalizeBitmap;
            Bitmap imageAnalizeBitmap = new Bitmap(file.imagesOfCategoryBitmap);
            file.imagesBitmap = definedRectangle(instance, imageAnalizeBitmap, pen);
            
            return file;
        }
        public FileImage zoomImage(Instance instance, FileImage file)
        {
            Bitmap bitmap = new Bitmap(file.image);
            RectangleF rectangleF = new RectangleF(instance.BoundingBox.Left, instance.BoundingBox.Top,
                                       instance.BoundingBox.Width, instance.BoundingBox.Height);
            Bitmap btmClone = bitmap.Clone(rectangleF, System.Drawing.Imaging.PixelFormat.DontCare);
            file.imageZoom = btmClone;
            return file;
        }
        private Bitmap definedRectangle(Instance instancesCategory, Bitmap file , Pen pen) {

            Graphics graphics = Graphics.FromImage(file);
            graphics.DrawRectangle(pen, instancesCategory.BoundingBox.Left, instancesCategory.BoundingBox.Top,
                                       instancesCategory.BoundingBox.Width, instancesCategory.BoundingBox.Height);
            return file;
        }


    }
}