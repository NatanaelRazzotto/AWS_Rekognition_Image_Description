using Amazon;
using Amazon.Rekognition;
using Amazon.Rekognition.Model;
using Amazon.Runtime;
using Amazon.Runtime.CredentialManagement;
using Amazon.S3;
using Amazon.S3.Transfer;
using AWS_Rekognition_Objects.Helpers.Controller;
using AWS_Rekognition_Objects.Helpers.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Image = Amazon.Rekognition.Model.Image;
using Label = Amazon.Rekognition.Model.Label;

namespace AWS_Rekognition_Objects
{
    public partial class Form1 : Form
    {
       // ViewForm viewForm;
        Controller controller;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnAnalizarImage.Enabled = false;
        }

      

        private void btnImageBrowse_Click(object sender, EventArgs e)
        {
            btnAnalizarImage.Enabled = false;
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
            openFileDialog1.Title = "Selecione uma Imagem a Ser Analizada";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                controller = new Controller(this);
               // string fileName = controller.definirArquivoImage(openFileDialog1.FileName);
                pictureBoxImage.Load(controller.definirArquivoImage(openFileDialog1.FileName));
                btnAnalizarImage.Enabled = true;
            }
            
        }

        private async void btnAnalizarImage_Click(object sender, EventArgs e)
        {
            if (controller.verificarArquivo())
            {
                bool getCrendentials = await controller.ValidarOperacao();
                if (getCrendentials)
                {
                    controller.analizarImagens();
                    rtbRetornoProcesso.Clear();
                    rtbRetornoProcesso.AppendText("Crecenciais Obtidas com Sucesso");
                }
                else
                {
                    rtbRetornoProcesso.Clear();
                    rtbRetornoProcesso.AppendText("Crecenciais NÃO obtidas com sucesso");
                }

                // await DetectScenes(controller.obtemNomeArquivo());
            }
            else
            {
                rtbRetornoProcesso.Clear();
                rtbRetornoProcesso.AppendText("ERRO, não foi possivel obter o arquivo");
            }
        }

        public void desenharAnalise(List<Label> detectLabels)
        {
            foreach (Label label in detectLabels)
            {
                foreach (Instance instance in label.Instances)
                {
                    rtbRetornoProcesso.AppendText($"{label.Name} : {label.Confidence}");
                    Pen pen = new Pen(Color.Red);
                    Graphics graphics = pictureBoxImage.CreateGraphics();
                    graphics.DrawRectangle(pen,
                                           instance.BoundingBox.Left * pictureBoxImage.Image.Width,
                                           instance.BoundingBox.Top * pictureBoxImage.Image.Height,
                                           instance.BoundingBox.Width * pictureBoxImage.Image.Width,
                                           instance.BoundingBox.Height * pictureBoxImage.Image.Height
                           );
                }
            }
        }
        /// <summary>
        /// Metodo esperimental estuadando o armazenamento da posição de um item com base nas coordenadas convertidas
        /// Verificar o uso de uma estrutura desse modo ao invez de usar um objeto de forma crua
        /// </summary>
        /// <param name="labelObjects"></param>
        public void convertResponseInObjectcategory(List<Label> labelObjects)
        {
            foreach (Label item in labelObjects)
            {
                Graphics graphics = pictureBoxImage.CreateGraphics();
                Pen pen = new Pen(Color.Red);
                RectangleF[] listRectangleF = new RectangleF[labelObjects.Count];
                for (int i = 0; i < item.Instances.Count; i++)
                {
                    Instance itemLabel = item.Instances[i];
                    RectangleF rectangle = new RectangleF(itemLabel.BoundingBox.Left * pictureBoxImage.Image.Width,
                                                          itemLabel.BoundingBox.Top * pictureBoxImage.Image.Height,
                                                          itemLabel.BoundingBox.Width * pictureBoxImage.Image.Width,
                                                          itemLabel.BoundingBox.Height * pictureBoxImage.Image.Height);
                    listRectangleF[i] = rectangle;
                }
                graphics.DrawRectangles(pen, listRectangleF);
                     //graphics.DrawRectangle(pen, rectangle);                

            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBoxImage_MouseUp(object sender, MouseEventArgs e)
        {
            double coordinateX = e.X ;
            int coordinateY = e.Y;
            List<Label> detectLabels = controller.getDetectLabelsResponse().Labels;
            foreach (Label itemLabel in detectLabels)
            {
                foreach (Instance item in itemLabel.Instances)
                {
                    double coordenadaHorizI = item.BoundingBox.Left * pictureBoxImage.Image.Width;
                    double coordenadaHorizF = item.BoundingBox.Width * pictureBoxImage.Image.Width;
                    double coordenadaVertiF = item.BoundingBox.Height * pictureBoxImage.Image.Height;
                    double coordenadaVertiI = item.BoundingBox.Top * pictureBoxImage.Image.Height;

                    if ((coordinateX <= coordenadaHorizI) && (coordinateX >= coordenadaHorizF) &&
                        (coordinateY <= coordenadaVertiI) && (coordinateY >= coordenadaVertiF)) {
                        rtbRetornoProcesso.AppendText($" x = {itemLabel.Name}");
                        rtbRetornoProcesso.AppendText($" x = {coordinateX} : y = {coordinateY}");
                    }
                }
            }
           // rtbRetornoProcesso.AppendText($" x = {coordinateX} : y = {coordinateY}");
        }


        
    }
}
