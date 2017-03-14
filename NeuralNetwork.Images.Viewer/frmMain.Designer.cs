namespace NeuralNetwork.Images.Viewer
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnGetRandom = new System.Windows.Forms.Button();
            this.pcbMain = new System.Windows.Forms.PictureBox();
            this.lvImages = new System.Windows.Forms.ListView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.lblActual = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblExpected = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblLearningSuccess = new System.Windows.Forms.Label();
            this.lblTestSuccess = new System.Windows.Forms.Label();
            this.btnLoad = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pcbMain)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGetRandom
            // 
            this.btnGetRandom.Location = new System.Drawing.Point(12, 219);
            this.btnGetRandom.Name = "btnGetRandom";
            this.btnGetRandom.Size = new System.Drawing.Size(200, 59);
            this.btnGetRandom.TabIndex = 0;
            this.btnGetRandom.Text = "Random";
            this.btnGetRandom.UseVisualStyleBackColor = true;
            this.btnGetRandom.Click += new System.EventHandler(this.btnGetRandom_Click);
            // 
            // pcbMain
            // 
            this.pcbMain.Location = new System.Drawing.Point(12, 13);
            this.pcbMain.Name = "pcbMain";
            this.pcbMain.Size = new System.Drawing.Size(200, 200);
            this.pcbMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbMain.TabIndex = 2;
            this.pcbMain.TabStop = false;
            // 
            // lvImages
            // 
            this.lvImages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvImages.LargeImageList = this.imageList;
            this.lvImages.Location = new System.Drawing.Point(12, 284);
            this.lvImages.Name = "lvImages";
            this.lvImages.Size = new System.Drawing.Size(425, 265);
            this.lvImages.SmallImageList = this.imageList;
            this.lvImages.TabIndex = 4;
            this.lvImages.UseCompatibleStateImageBehavior = false;
            this.lvImages.Click += new System.EventHandler(this.lvImages_Click);
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList.ImageSize = new System.Drawing.Size(28, 28);
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(233, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 22);
            this.label1.TabIndex = 5;
            this.label1.Text = "Expected value:";
            // 
            // lblActual
            // 
            this.lblActual.AutoSize = true;
            this.lblActual.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblActual.Location = new System.Drawing.Point(377, 167);
            this.lblActual.Name = "lblActual";
            this.lblActual.Size = new System.Drawing.Size(20, 22);
            this.lblActual.TabIndex = 5;
            this.lblActual.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(233, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 22);
            this.label3.TabIndex = 5;
            this.label3.Text = "Network result:";
            // 
            // lblExpected
            // 
            this.lblExpected.AutoSize = true;
            this.lblExpected.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblExpected.Location = new System.Drawing.Point(377, 136);
            this.lblExpected.Name = "lblExpected";
            this.lblExpected.Size = new System.Drawing.Size(20, 22);
            this.lblExpected.TabIndex = 5;
            this.lblExpected.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(233, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(195, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "Learning dataset success:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(233, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(164, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "Test dataset success:";
            // 
            // lblLearningSuccess
            // 
            this.lblLearningSuccess.AutoSize = true;
            this.lblLearningSuccess.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblLearningSuccess.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblLearningSuccess.Location = new System.Drawing.Point(232, 33);
            this.lblLearningSuccess.Name = "lblLearningSuccess";
            this.lblLearningSuccess.Size = new System.Drawing.Size(101, 25);
            this.lblLearningSuccess.TabIndex = 6;
            this.lblLearningSuccess.Text = "99.9995%";
            // 
            // lblTestSuccess
            // 
            this.lblTestSuccess.AutoSize = true;
            this.lblTestSuccess.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblTestSuccess.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblTestSuccess.Location = new System.Drawing.Point(232, 91);
            this.lblTestSuccess.Name = "lblTestSuccess";
            this.lblTestSuccess.Size = new System.Drawing.Size(101, 25);
            this.lblTestSuccess.TabIndex = 6;
            this.lblTestSuccess.Text = "99.9995%";
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(237, 219);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(200, 59);
            this.btnLoad.TabIndex = 0;
            this.btnLoad.Text = "Load own image";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 561);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblTestSuccess);
            this.Controls.Add(this.lblLearningSuccess);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblExpected);
            this.Controls.Add(this.lblActual);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvImages);
            this.Controls.Add(this.pcbMain);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnGetRandom);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Name = "frmMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pcbMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGetRandom;
        private System.Windows.Forms.PictureBox pcbMain;
        private System.Windows.Forms.ListView lvImages;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblActual;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblExpected;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblLearningSuccess;
        private System.Windows.Forms.Label lblTestSuccess;
        private System.Windows.Forms.Button btnLoad;
    }
}

