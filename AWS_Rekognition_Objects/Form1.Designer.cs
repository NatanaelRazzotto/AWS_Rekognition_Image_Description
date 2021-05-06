
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
            this.btnImageBrowse = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBoxImage = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pbImageZoom = new System.Windows.Forms.PictureBox();
            this.treeViewLabels = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNomeArquivo = new System.Windows.Forms.Label();
            this.rtbRetornoProcesso = new System.Windows.Forms.RichTextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnAnalizarImage = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImageZoom)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.panel1.Controls.Add(this.btnAnalizarImage);
            this.panel1.Controls.Add(this.btnImageBrowse);
            this.panel1.Controls.Add(this.lblTitulo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1305, 68);
            this.panel1.TabIndex = 1;
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
            this.panel2.Size = new System.Drawing.Size(1305, 382);
            this.panel2.TabIndex = 2;
            // 
            // pictureBoxImage
            // 
            this.pictureBoxImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBoxImage.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxImage.Name = "pictureBoxImage";
            this.pictureBoxImage.Size = new System.Drawing.Size(811, 367);
            this.pictureBoxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxImage.TabIndex = 0;
            this.pictureBoxImage.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.pbImageZoom);
            this.panel3.Controls.Add(this.treeViewLabels);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.lblNomeArquivo);
            this.panel3.Controls.Add(this.rtbRetornoProcesso);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(829, 68);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(476, 382);
            this.panel3.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(239, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Lista de Labels \r\n";
            // 
            // pbImageZoom
            // 
            this.pbImageZoom.BackColor = System.Drawing.Color.Gray;
            this.pbImageZoom.Location = new System.Drawing.Point(10, 112);
            this.pbImageZoom.Name = "pbImageZoom";
            this.pbImageZoom.Size = new System.Drawing.Size(223, 160);
            this.pbImageZoom.TabIndex = 5;
            this.pbImageZoom.TabStop = false;
            // 
            // treeViewLabels
            // 
            this.treeViewLabels.BackColor = System.Drawing.Color.Gray;
            this.treeViewLabels.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeViewLabels.Location = new System.Drawing.Point(239, 112);
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
            this.rtbRetornoProcesso.Location = new System.Drawing.Point(10, 278);
            this.rtbRetornoProcesso.Name = "rtbRetornoProcesso";
            this.rtbRetornoProcesso.Size = new System.Drawing.Size(223, 101);
            this.rtbRetornoProcesso.TabIndex = 2;
            this.rtbRetornoProcesso.Text = "";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1305, 450);
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
            ((System.ComponentModel.ISupportInitialize)(this.pbImageZoom)).EndInit();
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
        private System.Windows.Forms.PictureBox pbImageZoom;
        private System.Windows.Forms.TreeView treeViewLabels;
        private System.Windows.Forms.Button btnImageBrowse;
        private System.Windows.Forms.Button btnAnalizarImage;
    }
}

