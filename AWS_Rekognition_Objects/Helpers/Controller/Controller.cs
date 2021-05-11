using Amazon.Rekognition.Model;
using AWS_Rekognition_Objects.Helpers.Model;
using AWS_Rekognition_Objects.Helpers.Model.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWS_Rekognition_Objects.Helpers.Controller
{
    class Controller
    {
        AnaliserLabelsAWS analizadorArquivo;
        FileImage fileImage;
        IViewAnalyzer formPrincipal;
        PostProcessingImages processingImages;
        public Controller(IViewAnalyzer formPrincipal) {
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

        public string SetFileImage(String nameFile) {
            fileImage = new FileImage(nameFile);
            this.analizadorArquivo = new AnaliserLabelsAWS(fileImage);
            return fileImage.nameFile;
        }
        public bool CheckArchive() {
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
        public string GetFileName() {
            return fileImage.nameFile;
        }
        public async void AnalyzeImages(int numberLabels, float minConfidence) {

            analizadorArquivo.listarNomesImagensDoBucket();

            bool inclusao = await analizadorArquivo.UploadImageFromS3();
            if (inclusao)
            {
                formPrincipal.releaseNumericsUpDown(false);
                bool b = await analizadorArquivo.DetectScenes(numberLabels, minConfidence);
                bool validate = await DrawAnalysis();
                formPrincipal.releaseNumericsUpDown(validate);
            }
            else
            {
                formPrincipal.MensagemErro("ERRO" , "Não foi possivei inserir o arquivo no Bucket!");
            }
        }
        public async Task<bool> DrawAnalysis()//DetectLabelsResponse detectLabelsResponse
        {
            List<Label> labelsResponse = analizadorArquivo.GetListlabelObjectsCategories();
            fileImage = processingImages.DrawAnalysis(labelsResponse, fileImage);
            bool constructTAG = formPrincipal.ConstructTAG(ConstructTAGLabels(labelsResponse));
            if (constructTAG)
            {
                bool drawAnalyzeVerific = formPrincipal.drawAnalyze(labelsResponse, fileImage);
                if (drawAnalyzeVerific)
                {
                    bool generateTree = formPrincipal.generateTreeView();
                    if (generateTree)
                    {
                        return true;
                    }                    
                }           
            }

            return false;
        }

        public List<Label> GetDetectLabelsResponse() {
            return analizadorArquivo.GetListlabelObjectsCategories();
        }

        public async Task<bool> ValidateOperation()
        {
            bool validador = await analizadorArquivo.GetCredentialsAWS();
            return validador;
        }
        [Obsolete("Metodos substituidos pela tag de TreeView")]
        public Label FilterViewByCategory(int IndexCategory)
        {
            List<Label> labelsDetecteds = analizadorArquivo.GetListlabelObjectsCategories();
            return labelsDetecteds.ElementAt(IndexCategory);
        }
        [Obsolete("Metodos substituidos pela tag de TreeView")]
        public FileImage FilterViewByCategorybyInstances(int IndexCategory)
        {
            fileImage = processingImages.Filterbycategory(FilterViewByCategory(IndexCategory).Instances, fileImage);
            return fileImage;
        }
        [Obsolete("Metodos substituidos pela tag de TreeView")]
        public FileImage FilterViewByCategoryItem(int IndexCategory,int IndexItem)
        {
            List<Instance> CategoryFilter = FilterViewByCategory(IndexCategory).Instances;
            fileImage = processingImages.Filterbycategory(CategoryFilter, fileImage);
            Instance instance = CategoryFilter.ElementAt(IndexItem);
            fileImage = processingImages.filtrarPorInstance(instance, fileImage);
            fileImage = processingImages.zoomImage(instance, fileImage);

            return fileImage;
        }
        public FileImage FilterViewByInstance(DTO_LabelInstance instanceLabel)
        {
            fileImage = processingImages.Filterbycategory(instanceLabel.CategoryInstances, fileImage);
            fileImage = processingImages.filtrarPorInstance(instanceLabel.Instance, fileImage);
            fileImage = processingImages.zoomImage(instanceLabel.Instance, fileImage);
            return fileImage;
        }
        public FileImage FilterViewByCategoryInstances(DTO_LabelInstance instanceLabel)
        {
            fileImage = processingImages.Filterbycategory(instanceLabel.CategoryInstances, fileImage);
            return fileImage;
        }
        public FileImage GetFileImage() {
            return fileImage;
        }
        public List<String> ConstructTAGLabels(List<Label> labels) {
            return processingImages.ConstructOfTag(labels);
        }
    }
}
