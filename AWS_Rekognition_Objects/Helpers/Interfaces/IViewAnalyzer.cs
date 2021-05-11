using Amazon.Rekognition.Model;
using AWS_Rekognition_Objects.Helpers.Model.Entitys;
using System.Collections.Generic;
namespace AWS_Rekognition_Objects.Helpers
{
    interface IViewAnalyzer
    {
        bool drawAnalyze(List<Label> detectLabels, FileImage file);
        bool ConstructTAG(List<string> labelsResponse);
        bool generateTreeView();
        void MensagemErro(string cabecalhoErro, string mensageErro);
        void releaseNumericsUpDown(bool defined);
    }
}
