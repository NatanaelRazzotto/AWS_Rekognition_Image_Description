using Amazon.Rekognition.Model;
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

        public FileImage RestartCategory()
        {
            fileImage.imagesBitmap = null;
            fileImage.imagesOfCategoryBitmap = null;
            fileImage.imageZoom = null;

            return fileImage;
        }

        public string definirArquivoImage(String nameFile) {
            fileImage = new FileImage(nameFile);
            this.analizadorArquivo = new AnaliserLabelsAWS(fileImage);
            return fileImage.nameFile;
        }
        public bool verificarArquivo() {
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
        public string obtemNomeArquivo() {
            return fileImage.nameFile;
        }
        public async void analizarImagens(int numberLabels, Single minConfidence) {
            bool inclusao = await analizadorArquivo.UploadImageFromS3();
            if (inclusao)
            {
                await analizadorArquivo.DetectScenes( numberLabels, minConfidence);
               // detectLabelsResponse = analizadorArquivo.getListlabelObjectsCategories();
                await desenharAnalise();

                formPrincipal.gerarTreeView();
            }
        }
        private async Task desenharAnalise()//DetectLabelsResponse detectLabelsResponse
        {
            fileImage = processingImages.desenharAnalise(analizadorArquivo.getListlabelObjectsCategories(), fileImage);
            formPrincipal.desenharAnalise(analizadorArquivo.getListlabelObjectsCategories(), fileImage);
            //formPrincipal.convertResponseInObjectcategory(detectLabelsResponse.Labels);
        }
        //[Obsolete("Metodo de teste não incluido na versão final.")]
        public List<Label> getDetectLabelsResponse() {
            return analizadorArquivo.getListlabelObjectsCategories();
        }

        public async Task<bool> ValidarOperacao()
        {
            bool validador = await analizadorArquivo.getCredentialsAWS();
            return validador;
        }

        public Label FilterViewByCategory(int IndexCategory)
        {
            List<Label> labelsDetecteds = analizadorArquivo.getListlabelObjectsCategories();
            return labelsDetecteds.ElementAt(IndexCategory);
        }
        public FileImage FilterViewByCategorybyInstances(int IndexCategory)
        {
            fileImage = processingImages.filtrarPorCategoria(FilterViewByCategory(IndexCategory).Instances, fileImage);
            return fileImage;
        }
        public FileImage FilterViewByCategoryItem(int IndexCategory,int IndexItem)
        {
            List<Instance> CategoryFilter = FilterViewByCategory(IndexCategory).Instances;
            fileImage = processingImages.filtrarPorCategoria(CategoryFilter, fileImage);
            Instance instance = CategoryFilter.ElementAt(IndexItem);
            fileImage = processingImages.filtrarPorInstance(instance, fileImage);
            fileImage = processingImages.zoomImage(instance, fileImage);

            return fileImage;
        }
    }
}
