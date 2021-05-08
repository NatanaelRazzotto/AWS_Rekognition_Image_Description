
namespace AWS_Rekognition_Objects
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRestart = new System.Windows.Forms.Button();
            this.btnLimparCategorias = new System.Windows.Forms.Button();
            this.btnAnalizarImage = new System.Windows.Forms.Button();
            this.btnImageBrowse = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBoxImage = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnItemIndividual = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.btnSelection = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.treeViewLabels = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNomeArquivo = new System.Windows.Forms.Label();
            this.rtbRetornoProcesso = new System.Windows.Forms.RichTextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.panel1.Controls.Add(this.btnRestart);
            this.panel1.Controls.Add(this.btnLimparCategorias);
            this.panel1.Controls.Add(this.btnAnalizarImage);
            this.panel1.Controls.Add(this.btnImageBrowse);
            this.panel1.Controls.Add(this.lblTitulo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1305, 68);
            this.panel1.TabIndex = 1;
            // 
            // btnRestart
            // 
            this.btnRestart.BackColor = System.Drawing.Color.Black;
            this.btnRestart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnRestart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRestart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestart.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnRestart.Location = new System.Drawing.Point(709, 25);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(124, 23);
            this.btnRestart.TabIndex = 10;
            this.btnRestart.Text = "Restart";
            this.btnRestart.UseVisualStyleBackColor = false;
            this.btnRestart.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnLimparCategorias
            // 
            this.btnLimparCategorias.BackColor = System.Drawing.Color.Black;
            this.btnLimparCategorias.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnLimparCategorias.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimparCategorias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimparCategorias.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnLimparCategorias.Location = new System.Drawing.Point(839, 25);
            this.btnLimparCategorias.Name = "btnLimparCategorias";
            this.btnLimparCategorias.Size = new System.Drawing.Size(124, 23);
            this.btnLimparCategorias.TabIndex = 9;
            this.btnLimparCategorias.Text = "Limpar Categorias";
            this.btnLimparCategorias.UseVisualStyleBackColor = false;
            this.btnLimparCategorias.Click += new System.EventHandler(this.btnLimparCategorias_Click);
            // 
            // btnAnalizarImage
            // 
            this.btnAnalizarImage.BackColor = System.Drawing.Color.Black;
            this.btnAnalizarImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAnalizarImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAnalizarImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnalizarImage.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnAnalizarImage.Location = new System.Drawing.Point(975, 19);
            this.btnAnalizarImage.Name = "btnAnalizarImage";
            this.btnAnalizarImage.Size = new System.Drawing.Size(134, 34);
            this.btnAnalizarImage.TabIndex = 8;
            this.btnAnalizarImage.Text = "Analisar Imagem";
            this.btnAnalizarImage.UseVisualStyleBackColor = false;
            this.btnAnalizarImage.Click += new System.EventHandler(this.btnAnalizarImage_Click);
            // 
            // btnImageBrowse
            // 
            this.btnImageBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImageBrowse.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnImageBrowse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnImageBrowse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImageBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImageBrowse.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnImageBrowse.Location = new System.Drawing.Point(1115, 15);
            this.btnImageBrowse.Name = "btnImageBrowse";
            this.btnImageBrowse.Size = new System.Drawing.Size(178, 43);
            this.btnImageBrowse.TabIndex = 0;
            this.btnImageBrowse.Text = "Image Browse";
            this.btnImageBrowse.UseVisualStyleBackColor = false;
            this.btnImageBrowse.Click += new System.EventHandler(this.btnImageBrowse_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Swis721 Hv BT", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTitulo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTitulo.Location = new System.Drawing.Point(13, 17);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(210, 25);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Image Rekognition";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gray;
            this.panel2.Controls.Add(this.pictureBoxImage);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 68);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1305, 509);
            this.panel2.TabIndex = 2;
            // 
            // pictureBoxImage
            // 
            this.pictureBoxImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBoxImage.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxImage.Name = "pictureBoxImage";
            this.pictureBoxImage.Size = new System.Drawing.Size(811, 494);
            this.pictureBoxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxImage.TabIndex = 0;
            this.pictureBoxImage.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel3.Controls.Add(this.btnItemIndividual);
            this.panel3.Controls.Add(this.richTextBox1);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.numericUpDown3);
            this.panel3.Controls.Add(this.numericUpDown1);
            this.panel3.Controls.Add(this.btnSelection);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Controls.Add(this.treeViewLabels);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.lblNomeArquivo);
            this.panel3.Controls.Add(this.rtbRetornoProcesso);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(829, 68);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(476, 509);
            this.panel3.TabIndex = 3;
            // 
            // btnItemIndividual
            // 
            this.btnItemIndividual.Location = new System.Drawing.Point(132, 126);
            this.btnItemIndividual.Name = "btnItemIndividual";
            this.btnItemIndividual.Size = new System.Drawing.Size(101, 23);
            this.btnItemIndividual.TabIndex = 17;
            this.btnItemIndividual.Text = "SelecionarItem (test)";
            this.btnItemIndividual.UseVisualStyleBackColor = true;
            this.btnItemIndividual.Click += new System.EventHandler(this.btnItemIndividual_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(10, 460);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(454, 37);
            this.richTextBox1.TabIndex = 16;
            this.richTextBox1.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(10, 435);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 20);
            this.label4.TabIndex = 15;
            this.label4.Text = "Tag Gerada";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(88, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 15);
            this.label3.TabIndex = 14;
            this.label3.Text = "Numero de Labels";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(293, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 15);
            this.label5.TabIndex = 13;
            this.label5.Text = "Minimo de Confidence";
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Location = new System.Drawing.Point(286, 87);
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(136, 23);
            this.numericUpDown3.TabIndex = 12;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(71, 87);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(131, 23);
            this.numericUpDown1.TabIndex = 8;
            // 
            // btnSelection
            // 
            this.btnSelection.Location = new System.Drawing.Point(10, 126);
            this.btnSelection.Name = "btnSelection";
            this.btnSelection.Size = new System.Drawing.Size(107, 23);
            this.btnSelection.TabIndex = 7;
            this.btnSelection.Text = "SelecionarCateg";
            this.btnSelection.UseVisualStyleBackColor = true;
            this.btnSelection.Click += new System.EventHandler(this.btnSelection_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(239, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Lista de Labels \r\n";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Gray;
            this.pictureBox1.Location = new System.Drawing.Point(10, 165);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(223, 160);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // treeViewLabels
            // 
            this.treeViewLabels.BackColor = System.Drawing.Color.Gray;
            this.treeViewLabels.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeViewLabels.Location = new System.Drawing.Point(239, 165);
            this.treeViewLabels.Name = "treeViewLabels";
            this.treeViewLabels.Size = new System.Drawing.Size(225, 267);
            this.treeViewLabels.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(10, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nome do Arquivo: ";
            // 
            // lblNomeArquivo
            // 
            this.lblNomeArquivo.AutoSize = true;
            this.lblNomeArquivo.Font = new System.Drawing.Font("Square721 BT", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNomeArquivo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblNomeArquivo.Location = new System.Drawing.Point(10, 41);
            this.lblNomeArquivo.Name = "lblNomeArquivo";
            this.lblNomeArquivo.Size = new System.Drawing.Size(24, 19);
            this.lblNomeArquivo.TabIndex = 3;
            this.lblNomeArquivo.Text = "...";
            // 
            // rtbRetornoProcesso
            // 
            this.rtbRetornoProcesso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rtbRetornoProcesso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbRetornoProcesso.ForeColor = System.Drawing.SystemColors.Window;
            this.rtbRetornoProcesso.Location = new System.Drawing.Point(10, 331);
            this.rtbRetornoProcesso.Name = "rtbRetornoProcesso";
            this.rtbRetornoProcesso.Size = new System.Drawing.Size(223, 101);
            this.rtbRetornoProcesso.TabIndex = 2;
            this.rtbRetornoProcesso.Text = "";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1305, 577);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Image Objective Recognition";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.RichTextBox rtbRetornoProcesso;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNomeArquivo;
        private System.Windows.Forms.PictureBox pictureBoxImage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TreeView treeViewLabels;
        private System.Windows.Forms.Button btnImageBrowse;
        private System.Windows.Forms.Button btnAnalizarImage;
        private System.Windows.Forms.Button btnSelection;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Button btnLimparCategorias;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnItemIndividual;
    }
}

