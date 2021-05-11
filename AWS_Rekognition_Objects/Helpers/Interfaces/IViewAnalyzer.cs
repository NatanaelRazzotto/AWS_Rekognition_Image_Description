using Amazon.Rekognition.Model;
using AWS_Rekognition_Objects.Helpers.Model.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWS_Rekognition_Objects.Helpers
{
    interface IViewAnalyzer
    {
        void drawAnalyze(List<Label> detectLabels, FileImage file);
        void ConstructTAG(List<string> labelsResponse);
        void generateTreeView();
        void MensagemErro(string cabecalhoErro, string mensageErro);
        void releaseNumericsUpDown(bool defined);
    }
}
