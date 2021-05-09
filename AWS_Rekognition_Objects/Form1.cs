using Amazon;
using Amazon.Rekognition;
using Amazon.Rekognition.Model;
using Amazon.Runtime;
using Amazon.Runtime.CredentialManagement;
using Amazon.S3;
using Amazon.S3.Transfer;
using AWS_Rekognition_Objects.Helpers.Controller;
using AWS_Rekognition_Objects.Helpers.Model;
using AWS_Rekognition_Objects.Helpers.Model.Entitys;
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
using Point = System.Drawing.Point;

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
            btnLimparCategorias.Enabled = false;
            btnRestart.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            btnAnalizarImage.Enabled = false;
            btnLimparCategorias.Enabled = false;
            btnRestart.Enabled = false;
            Application.Restart();
        }
        private void btnLimparCategorias_Click(object sender, EventArgs e)
        {
            btnAnalizarImage.Enabled = false;
            // btnLimparCategorias.Enabled = false;
            // btnRestart.Enabled = false;
            pictureBoxImage.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBoxImage.Location = new Point(0, 0);
            pictureBoxImage.Image = controller.RestartCategory().imageAnalizeBitmap;
            pictureBox1.Image = null;
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
                pictureBoxImage.Load(controller.definirArquivoImage(openFileDialog1.FileName));
                lblNomeArquivo.Text = openFileDialog1.FileName;
                btnAnalizarImage.Enabled = true;

                LogRegister logRegister = new LogRegister();
                logRegister.Log(String.Format($"{"Log criado em "} : {DateTime.Now}"), "ArquivoLog");
                logRegister.Log("Teste de execução");

                /*  Bitmap imageAnalizeBitmap = new Bitmap(openFileDialog1.FileName);
                  Bitmap b = new Bitmap(imageAnalizeBitmap);
                  Graphics graphics = Graphics.FromImage(b);
                  Pen pen = new Pen(Color.Aqua, 2);
                  graphics.DrawRectangle(pen, pictureBoxImage.Image.Width - 50, pictureBoxImage.Image.Height - 50,
                                             pictureBoxImage.Image.Width - 50, pictureBoxImage.Image.Height - 50);

                  pictureBoxImage.Image = imageAnalizeBitmap;*/
            }

        }

        private async void btnAnalizarImage_Click(object sender, EventArgs e)
        {
            if (controller.verificarArquivo())
            {
                bool getCrendentials = await controller.ValidarOperacao();
                if (getCrendentials)
                {
                    int numbLabels = Convert.ToInt32(nudNumLabels.Value);
                    Single confidence = Convert.ToSingle(nudConfidence.Value);
                    if ((numbLabels == 0) && (confidence == 0))
                    {
                        DialogResult dr = MessageBox.Show("Você não informou os Paremetros", "Deseja trabalhar com os valores Padrões?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                        if (dr == DialogResult.Yes)
                        {
                            controller.analizarImagens(20, 75);
                            rtbRetornoProcesso.Clear();
                            rtbRetornoProcesso.AppendText("Analise Realizada com Sucesso");
                            btnLimparCategorias.Enabled = true;
                            btnRestart.Enabled = true;

                        }
                    }
                    else
                    {
                        controller.analizarImagens(numbLabels, confidence);
                        rtbRetornoProcesso.Clear();
                        rtbRetornoProcesso.AppendText("Analise Realizada com Sucesso");
                        btnLimparCategorias.Enabled = true;
                        btnRestart.Enabled = true;

                    }
                }
                else
                {
                    rtbRetornoProcesso.Clear();
                    rtbRetornoProcesso.AppendText("Dados NÃO obtidas com sucesso");
                }

                // await DetectScenes(controller.obtemNomeArquivo());
            }
            else
            {
                rtbRetornoProcesso.Clear();
                rtbRetornoProcesso.AppendText("ERRO, não foi possivel obter o arquivo");
            }
        }

        public void desenharAnalise(List<Label> detectLabels, FileImage file)
        {
            pictureBoxImage.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBoxImage.Location = new Point(0, 0);
            foreach (Label label in detectLabels)
            {
                foreach (Instance instance in label.Instances)
                {
                    rtbRetornoProcesso.AppendText($"{label.Name} : {label.Confidence}");
                }
            }
            pictureBoxImage.Image = file.imageAnalizeBitmap;

        }
        [Obsolete("Metodo esperimental estuadando o armazenamento da posição de um item com base nas coordenadas convertidas" +
                   "Verificar o uso de uma estrutura desse modo ao invez de usar um objeto de forma crua")]
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
            double coordinateX = e.X;
            int coordinateY = e.Y;
            List<Label> detectLabels = controller.getDetectLabelsResponse();
            foreach (Label itemLabel in detectLabels)
            {
                foreach (Instance item in itemLabel.Instances)
                {
                    double coordenadaHorizI = item.BoundingBox.Left * pictureBoxImage.Image.Width;
                    double coordenadaHorizF = item.BoundingBox.Width * pictureBoxImage.Image.Width;
                    double coordenadaVertiF = item.BoundingBox.Height * pictureBoxImage.Image.Height;
                    double coordenadaVertiI = item.BoundingBox.Top * pictureBoxImage.Image.Height;

                    if ((coordinateX <= coordenadaHorizI) && (coordinateX >= coordenadaHorizF) &&
                        (coordinateY <= coordenadaVertiI) && (coordinateY >= coordenadaVertiF))
                    {
                        rtbRetornoProcesso.AppendText($" x = {itemLabel.Name}");
                        rtbRetornoProcesso.AppendText($" x = {coordinateX} : y = {coordinateY}");
                    }
                }
            }
            // rtbRetornoProcesso.AppendText($" x = {coordinateX} : y = {coordinateY}");
        }

        private void btnSelection_Click(object sender, EventArgs e)
        {
            pictureBoxImage.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBoxImage.Location = new Point(0, 0);
            //Passa o valor do Index da lista
            FileImage InstancesCategory = controller.FilterViewByCategorybyInstances(2);
            pictureBoxImage.Image = InstancesCategory.imagesOfCategoryBitmap;

        }

        private void btnItemIndividual_Click(object sender, EventArgs e)
        {
            pictureBoxImage.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBoxImage.Location = new Point(0, 0);
            //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            //pictureBox1.Location = new Point(0, 0);
            //Passa o valor do Index da lista
            FileImage InstancesCategory = controller.FilterViewByCategoryItem(2, 2);
            pictureBoxImage.Image = InstancesCategory.imagesBitmap;
            pictureBox1.Image = InstancesCategory.imageZoom;
        }

        public void gerarTreeView()
        {
            List<Label> labelsCarregadas = controller.getDetectLabelsResponse();

            for (int i = 0; i < labelsCarregadas.Count - 1; i++)
            {
                var label = labelsCarregadas[i];
                var nome = label.Name;
                var confidence = label.Confidence.ToString();
                //var categorias = label.Parents;
                var categorias = label.Instances; 

                TreeNode nodeNome = treeViewLabels.Nodes.Add(nome);
                nodeNome.Nodes.Add($" Confidence : {confidence}%");

                if (categorias.Count != 0)
                {

                    for (int j = 0; j < categorias.Count - 1; j++)
                    {
                        //var categoria = categorias[j].Name;
                        var categoria = categorias[j];
                        TreeNode treeNodeChild1 = nodeNome.Nodes.Add($"{nome} - {j}");
                        treeNodeChild1.Tag = categoria;

                        var cat = (Instance)treeNodeChild1.Tag;
                        //nodeNome.Nodes.Add($"Car{j} : {categoria.BoundingBox.Top} - Confidence {categoria.Confidence}");
                    }
                }
            }
        }
    }
}
