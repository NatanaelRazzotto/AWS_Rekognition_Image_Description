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
        Analizer analizadorArquivo;
        FileImage fileImage;
        Form1 formPrincipal;
        DetectLabelsResponse detectLabelsResponse;
        public Controller(Form1 formPrincipal) {
            this.formPrincipal = formPrincipal;
        }

        public string definirArquivoImage(String nameFile) {
            fileImage = new FileImage(nameFile);
            this.analizadorArquivo = new Analizer(fileImage);
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
        public async void analizarImagens() {
           bool inclusao = await analizadorArquivo.UploadImageFromS3();
            if (inclusao)
            {
                detectLabelsResponse = await analizadorArquivo.DetectScenes();
                await desenharAnalise();
            }
        }
        private async Task desenharAnalise()//DetectLabelsResponse detectLabelsResponse
        {
            formPrincipal.desenharAnalise(detectLabelsResponse.Labels);
        }

        public DetectLabelsResponse getDetectLabelsResponse() {
            return detectLabelsResponse;
        }

        public async Task<bool> ValidarOperacao()
        {
            bool validador = await analizadorArquivo.getCredentialsAWS();
            return validador;
        }
    }
}
