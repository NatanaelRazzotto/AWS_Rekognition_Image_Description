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
        public Controller(Form1 formPrincipal) {
            this.formPrincipal = formPrincipal;
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
        public async void analizarImagens(int pictureWidth, int pictureHeight) {
           analizadorArquivo.DefinirDimensoesPicture(pictureWidth, pictureHeight);
           bool inclusao = await analizadorArquivo.UploadImageFromS3();
            if (inclusao)
            {
                await analizadorArquivo.DetectScenes();
               // detectLabelsResponse = analizadorArquivo.getListlabelObjectsCategories();
                await desenharAnalise();
            }
        }
        private async Task desenharAnalise()//DetectLabelsResponse detectLabelsResponse
        {
            formPrincipal.desenharAnalise(analizadorArquivo.getListlabelObjectsCategories());
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
            return labelsDetecteds[IndexCategory];
        }
        public List<Instance> FilterViewByCategorybyInstances(int IndexCategory)
        {
            List<Instance> labelsDetecteds = FilterViewByCategory(IndexCategory).Instances;
            return labelsDetecteds;
        }
    }
}
