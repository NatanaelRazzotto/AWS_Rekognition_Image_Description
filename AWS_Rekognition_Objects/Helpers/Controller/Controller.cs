﻿using Amazon.Rekognition.Model;
using AWS_Rekognition_Objects.Helpers.Model;
using AWS_Rekognition_Objects.Helpers.Model.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWS_Rekognition_Objects.Helpers.Controller
{
    class Controller
    {
        AnaliserLabelsAWS analizadorArquivo;
        FileImage fileImage;
        Form1 formPrincipal;
        PostProcessingImages processingImages;
        public Controller(Form1 formPrincipal) {
            this.formPrincipal = formPrincipal;
            this.processingImages = new PostProcessingImages();
        }

        public FileImage ResetCategory()
        {
            fileImage.imagesBitmap = null;
            fileImage.imagesOfCategoryBitmap = null;
            fileImage.imageZoom = null;

            return fileImage;
        }

        public string setFileImage(String nameFile) {
            fileImage = new FileImage(nameFile);
            this.analizadorArquivo = new AnaliserLabelsAWS(fileImage);
            return fileImage.nameFile;
        }
        public bool checkArchive() {
            if (fileImage != null)
            {
                if (!String.IsNullOrEmpty(fileImage.nameFile))
                {
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
            return false;
        }
        public string getFileName() {
            return fileImage.nameFile;
        }
        public async void AnalyzeImages(int numberLabels, Single minConfidence) {
            bool inclusao = await analizadorArquivo.UploadImageFromS3();
            if (inclusao)
            {
                await analizadorArquivo.DetectScenes( numberLabels, minConfidence);
                await DrawAnalysis();

                formPrincipal.generateTreeView();
            }
        }
        private async Task DrawAnalysis()//DetectLabelsResponse detectLabelsResponse
        {
            fileImage = processingImages.desenharAnalise(analizadorArquivo.getListlabelObjectsCategories(), fileImage);
            formPrincipal.drawAnalyze(analizadorArquivo.getListlabelObjectsCategories(), fileImage);

        }

        public List<Label> getDetectLabelsResponse() {
            return analizadorArquivo.getListlabelObjectsCategories();
        }

        public async Task<bool> ValidateOperation()
        {
            bool validador = await analizadorArquivo.getCredentialsAWS();
            return validador;
        }
        [Obsolete("Metodos substituidos pela tag de TreeView")]
        public Label FilterViewByCategory(int IndexCategory)
        {
            List<Label> labelsDetecteds = analizadorArquivo.getListlabelObjectsCategories();
            return labelsDetecteds.ElementAt(IndexCategory);
        }
        [Obsolete("Metodos substituidos pela tag de TreeView")]
        public FileImage FilterViewByCategorybyInstances(int IndexCategory)
        {
            fileImage = processingImages.filtrarPorCategoria(FilterViewByCategory(IndexCategory).Instances, fileImage);
            return fileImage;
        }
        [Obsolete("Metodos substituidos pela tag de TreeView")]
        public FileImage FilterViewByCategoryItem(int IndexCategory,int IndexItem)
        {
            List<Instance> CategoryFilter = FilterViewByCategory(IndexCategory).Instances;
            fileImage = processingImages.filtrarPorCategoria(CategoryFilter, fileImage);
            Instance instance = CategoryFilter.ElementAt(IndexItem);
            fileImage = processingImages.filtrarPorInstance(instance, fileImage);
            fileImage = processingImages.zoomImage(instance, fileImage);

            return fileImage;
        }
        public FileImage FilterViewByInstance(DTO_LabelInstance instanceLabel)
        {
            fileImage = processingImages.filtrarPorCategoria(instanceLabel.CategoryInstances, fileImage);
            fileImage = processingImages.filtrarPorInstance(instanceLabel.Instance, fileImage);
            fileImage = processingImages.zoomImage(instanceLabel.Instance, fileImage);
            return fileImage;
        }
        public FileImage FilterViewByCategoryInstances(DTO_LabelInstance instanceLabel)
        {
            fileImage = processingImages.filtrarPorCategoria(instanceLabel.CategoryInstances, fileImage);
            return fileImage;
        }
        public FileImage GetFileImage() {
            return fileImage;
        }
    }
}
