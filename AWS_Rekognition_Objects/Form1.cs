using Amazon.Rekognition.Model;
using AWS_Rekognition_Objects.Helpers;
using AWS_Rekognition_Objects.Helpers.Controller;
using AWS_Rekognition_Objects.Helpers.Model;
using AWS_Rekognition_Objects.Helpers.Model.Entitys;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Label = Amazon.Rekognition.Model.Label;
using Point = System.Drawing.Point;

namespace AWS_Rekognition_Objects
{
    public partial class Form1 : Form , IViewAnalyzer
    {
        Controller controller;
        LogRegister logRegister;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnAnalizarImage.Enabled = false;
            btnLimparCategorias.Enabled = false;
            btnRestart.Enabled = false;
            logRegister = new LogRegister();
        }
        #region Reset
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
            pictureBoxImage.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBoxImage.Location = new Point(0, 0);
            pictureBoxImage.Image = controller.ResetCategory().imageAnalizeBitmap;
            pictureBox1.Image = null;
            rtbRetornoProcesso.Clear();
        }
        public void releaseNumericsUpDown(bool defined) {
            nudConfidence.Enabled = true;
            nudNumLabels.Enabled = true;
        }
        #endregion
        #region Events
        private void btnImageBrowse_Click(object sender, EventArgs e)
        {
            btnAnalizarImage.Enabled = false;
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
            openFileDialog1.Title = "Selecione uma Imagem a Ser Analizada";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                controller = new Controller(this);
                pictureBoxImage.Load(controller.SetFileImage(openFileDialog1.FileName));
                lblNomeArquivo.Text = openFileDialog1.FileName;
                btnAnalizarImage.Enabled = true;
                nudConfidence.Enabled = true;
                nudNumLabels.Enabled = true;
                treeViewLabels.Nodes.Clear();
                rtbTAG.Clear();
                rtbRetornoProcesso.Clear();
                rtbRetornoProcesso.ForeColor = Color.White;

                logRegister.Log(String.Format($"{"Log criado em "} : {DateTime.Now}"), "ArquivoLog");
                logRegister.Log("Inclusao de Arquivo");

            }

        } 

        private async void btnAnalizarImage_Click(object sender, EventArgs e)
        {
            try
            {
                if (controller.CheckArchive())
                {
                    bool getCrendentials = await controller.ValidateOperation();
                    if (getCrendentials)
                    {
                        int numbLabels = Convert.ToInt32(nudNumLabels.Value);
                        float confidence = (float) Convert.ToDouble(nudConfidence.Value);
                        if ((numbLabels == 0) && (confidence == 0))
                        {
                            DialogResult dr = MessageBox.Show("Você não informou os Paremetros", "Deseja MANTER os valores Padrões?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                            if (dr == DialogResult.Yes)
                            {
                                logRegister.Log("Inclusao de arquivo para analise com valor padrao");
                                int numL = 20;
                                float conf = 75F;
                                controller.AnalyzeImages(numL, conf);
                                rtbRetornoProcesso.Clear();
                                rtbRetornoProcesso.AppendText("Iniciando Análise");
                                rtbRetornoProcesso.AppendText(Environment.NewLine + "Aquarde.....");
                                btnLimparCategorias.Enabled = true;
                                btnRestart.Enabled = true;
                                btnAnalizarImage.Enabled = false;

                            }
                        }
                        else
                        {
                            logRegister.Log("Inclusao de arquivo para analise com valor padrao");
                            controller.AnalyzeImages(numbLabels, confidence);
                            rtbRetornoProcesso.Clear();
                            rtbRetornoProcesso.AppendText("Iniciando Análise");
                            rtbRetornoProcesso.AppendText(Environment.NewLine +"Aquarde.....");
                            btnLimparCategorias.Enabled = true;
                            btnRestart.Enabled = true;
                            btnAnalizarImage.Enabled = false;

                        }
                    }
                    else
                    {

                        MensagemErro("Credenciais NÃO ACEITAS!", " Verifique se seu token expirou.");

                    }

                }
                else
                {
                    MensagemErro("ERRO", " não foi possivel obter o arquivo!");
                }
            }
            catch (Exception ex)
            {                
                logRegister.Log(String.Format($"{"Log criado em "} : {DateTime.Now}"), "ArquivoLog");
                logRegister.Log(ex.Message);
                MensagemErro("ERRO", ex.Message);
            }
        }

        private void treeViewLabels_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            pictureBoxImage.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBoxImage.Location = new Point(0, 0);

            TreeNode treeNode = e.Node;
            if (treeNode.Tag != null)
            {
                DTO_LabelInstance instanceLabel = (DTO_LabelInstance)treeNode.Tag;

                if ((instanceLabel.Instance == null) && (instanceLabel.CategoryInstances.Count != 0))
                {
                    FileImage InstancesCategory = controller.FilterViewByCategoryInstances(instanceLabel);
                    pictureBoxImage.Image = InstancesCategory.imagesOfCategoryBitmap;
                    pictureBox1.Image = null;
                    rtbRetornoProcesso.Clear();
                    rtbRetornoProcesso.SelectionAlignment = HorizontalAlignment.Center;
                    rtbRetornoProcesso.ForeColor = Color.Yellow;
                    rtbRetornoProcesso.AppendText("*******Descrição Imagem(s)*******");
                    rtbRetornoProcesso.AppendText($"{Environment.NewLine}****Categoria(s) do objeto*****");
                    rtbRetornoProcesso.AppendText($"{Environment.NewLine}---Categoria: {instanceLabel.NameCategoria}---");
                    rtbRetornoProcesso.AppendText($"{Environment.NewLine}****Confidence: {instanceLabel.confidence}%*****");
                    if (instanceLabel.parents.Count != 0)
                    {
                        rtbRetornoProcesso.AppendText(Environment.NewLine + "***Categorias Associadas***" + Environment.NewLine);
                        foreach (Parent categoria in instanceLabel.parents)
                        {
                            rtbRetornoProcesso.AppendText($"--{categoria.Name}--{Environment.NewLine}");
                        }
                    }
                    int contador = 0;
                    foreach (Instance item in instanceLabel.CategoryInstances)
                    {
                        PrintOfInstance(item, $"{instanceLabel.NameCategoria}_{contador}");
                        contador++;
                    }
                }
                else if ((instanceLabel.Instance == null) && (instanceLabel.CategoryInstances.Count == 0))
                {
                    FileImage InstancesCategory = controller.GetFileImage();
                    pictureBoxImage.Image = InstancesCategory.imageAnalizeBitmap;
                    pictureBox1.Image = null;
                    rtbRetornoProcesso.Clear();
                    rtbRetornoProcesso.SelectionAlignment = HorizontalAlignment.Center;
                    rtbRetornoProcesso.ForeColor = Color.Yellow;
                    rtbRetornoProcesso.AppendText("*******Descrição Imagem(s)*******");
                    rtbRetornoProcesso.AppendText($"{Environment.NewLine}****Categoria(s) do objeto*****");
                    rtbRetornoProcesso.AppendText($"{Environment.NewLine}---Categoria: {instanceLabel.NameCategoria}---");
                    rtbRetornoProcesso.AppendText($"{Environment.NewLine}****Confidence: {instanceLabel.confidence}%*****");
                    if (instanceLabel.parents.Count != 0)
                    {
                        rtbRetornoProcesso.AppendText(Environment.NewLine + "***Categorias Associadas***" + Environment.NewLine);
                        foreach (Parent categoria in instanceLabel.parents)
                        {
                            rtbRetornoProcesso.AppendText($"--{categoria.Name}--{Environment.NewLine}");
                        }
                    }

                }
                else if (instanceLabel.Instance != null)
                {
                    FileImage InstancesCategory = controller.FilterViewByInstance(instanceLabel);
                    pictureBoxImage.Image = InstancesCategory.imagesBitmap;
                    pictureBox1.Image = InstancesCategory.imageZoom;
                    rtbRetornoProcesso.Clear();
                    rtbRetornoProcesso.SelectionAlignment = HorizontalAlignment.Center;
                    rtbRetornoProcesso.ForeColor = Color.Orange;
                    rtbRetornoProcesso.AppendText("*******Descrição Imagem(s)*******");
                    rtbRetornoProcesso.AppendText($"{Environment.NewLine}****Categoria(s) do objeto*****");
                    rtbRetornoProcesso.AppendText($"{Environment.NewLine}---Categoria: {instanceLabel.NameCategoria}---");
                    rtbRetornoProcesso.AppendText($"{Environment.NewLine}****Confidence: {instanceLabel.confidence}%*****");
                    if (instanceLabel.parents.Count != 0)
                    {
                        rtbRetornoProcesso.AppendText(Environment.NewLine + "***Categorias Associadas***" + Environment.NewLine);
                        foreach (Parent categoria in instanceLabel.parents)
                        {
                            rtbRetornoProcesso.AppendText($"--{categoria.Name}--{Environment.NewLine}");
                        }
                    }
                    PrintOfInstance(instanceLabel.Instance, instanceLabel.nameItem);
                }
            }
        }
        #endregion
        #region Methods
        public bool ConstructTAG(List<string> labelsResponse)
        {
            rtbTAG.Clear();
            rtbTAG.SelectionAlignment = HorizontalAlignment.Center;
            rtbTAG.ForeColor = Color.Black;

            String Tag = "";
            foreach (string label in labelsResponse)
            {
                if (String.IsNullOrEmpty(Tag))
                {
                    Tag = label;
                }
                else
                {
                    Tag = ($"{Tag} , {label} ");
                }
            }

            rtbTAG.AppendText(Tag + ",");
            logRegister.Log("Geração da TAG concluida");
            return true;
        }

        public bool drawAnalyze(List<Label> detectLabels, FileImage file)
        {
            pictureBoxImage.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBoxImage.Location = new Point(0, 0);
            rtbRetornoProcesso.AppendText(Environment.NewLine);
            foreach (Label label in detectLabels)
            {
                if (label.Instances.Count > 0)
                {
                    rtbRetornoProcesso.AppendText($" -Foram encontrados {label.Instances.Count} objetos da categoria {label.Name}; {Environment.NewLine} ");
                }

            }
            rtbRetornoProcesso.AppendText("Análise Concluida");
            pictureBoxImage.Image = file.imageAnalizeBitmap;
            logRegister.Log("Desenho das labels concluida");
            return true;

        }
        public bool generateTreeView()
        {
            List<Label> labelsCarregadas = controller.GetDetectLabelsResponse();

            foreach (Label item in labelsCarregadas)
            {
                DTO_LabelInstance dto_LabelInstance = new DTO_LabelInstance();
                //dto_LabelInstance.idCategoria = item
                dto_LabelInstance.NameCategoria = item.Name;
                dto_LabelInstance.CategoryInstances = item.Instances;
                dto_LabelInstance.confidence = item.Confidence;
                dto_LabelInstance.parents = item.Parents;

                TreeNode nodeNome = treeViewLabels.Nodes.Add(item.Name);
                nodeNome.Tag = dto_LabelInstance;
                TreeNode nodeNomeCategory = nodeNome.Nodes.Add($" Confidence : {item.Confidence}%");


                for (int j = 0; j < item.Instances.Count; j++)
                {
                    DTO_LabelInstance dto_Instance = new DTO_LabelInstance();
                    dto_Instance.NameCategoria = item.Name;
                    dto_Instance.CategoryInstances = item.Instances;
                    dto_Instance.confidence = item.Confidence;
                    dto_Instance.parents = item.Parents;
                    dto_Instance.nameItem = ($"{item.Name}_{j}");
                    dto_Instance.Instance = item.Instances.ElementAt(j);

                    TreeNode treeNodeChild = nodeNomeCategory.Nodes.Add($"{dto_Instance.nameItem} / Confidence : {dto_Instance.Instance.Confidence}%");
                    treeNodeChild.Tag = dto_Instance;
                }
                
            }
            logRegister.Log("Geração de TreeView Concluida");
            return true;

        }     

        public void PrintOfInstance(Instance instanceLabel, string nameItem) {
            rtbRetornoProcesso.AppendText(Environment.NewLine + "*******Imagem******");
            rtbRetornoProcesso.AppendText($"{Environment.NewLine}-- Identificador : {nameItem} -- Confidence: {instanceLabel.Confidence}%--");
            rtbRetornoProcesso.AppendText(Environment.NewLine);
            rtbRetornoProcesso.AppendText("--Coordenadas--");
            rtbRetornoProcesso.AppendText($"{Environment.NewLine}--Eixo_X(left): {instanceLabel.BoundingBox.Left}");
            rtbRetornoProcesso.AppendText($"{Environment.NewLine}--Eixo_Y(top): {instanceLabel.BoundingBox.Top}");
            rtbRetornoProcesso.AppendText($"{Environment.NewLine}--Width: {instanceLabel.BoundingBox.Width}");
            rtbRetornoProcesso.AppendText($"{Environment.NewLine}--Height: {instanceLabel.BoundingBox.Height}");

        }

        public void MensagemErro(string cabecalhoErro, string mensageErro)
        {
            MessageBox.Show($"{cabecalhoErro}, {mensageErro}");
            rtbRetornoProcesso.Clear();
            rtbRetornoProcesso.SelectionAlignment = HorizontalAlignment.Center;
            rtbRetornoProcesso.ForeColor = Color.Orange;
            rtbRetornoProcesso.AppendText($"!! {cabecalhoErro} !!" + Environment.NewLine);
            rtbRetornoProcesso.AppendText(mensageErro);
        }
        #endregion
    }
}
