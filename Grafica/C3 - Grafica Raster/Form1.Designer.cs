namespace C3___Grafica_Raster
{
    partial class Form1
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
            this.sourcePictureBox = new System.Windows.Forms.PictureBox();
            this.destinationPictureBox = new System.Windows.Forms.PictureBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.medianButton = new System.Windows.Forms.Button();
            this.standardiseButton = new System.Windows.Forms.Button();
            this.contourButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.sourcePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.destinationPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // sourcePictureBox
            // 
            this.sourcePictureBox.Location = new System.Drawing.Point(12, 12);
            this.sourcePictureBox.Name = "sourcePictureBox";
            this.sourcePictureBox.Size = new System.Drawing.Size(455, 455);
            this.sourcePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.sourcePictureBox.TabIndex = 0;
            this.sourcePictureBox.TabStop = false;
            // 
            // destinationPictureBox
            // 
            this.destinationPictureBox.Location = new System.Drawing.Point(510, 12);
            this.destinationPictureBox.Name = "destinationPictureBox";
            this.destinationPictureBox.Size = new System.Drawing.Size(449, 455);
            this.destinationPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.destinationPictureBox.TabIndex = 1;
            this.destinationPictureBox.TabStop = false;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(989, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(208, 24);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedValueChanged += new System.EventHandler(this.comboBox1_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(187, 470);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Original";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(698, 470);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Edited";
            // 
            // medianButton
            // 
            this.medianButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.medianButton.Location = new System.Drawing.Point(989, 84);
            this.medianButton.Name = "medianButton";
            this.medianButton.Size = new System.Drawing.Size(208, 48);
            this.medianButton.TabIndex = 5;
            this.medianButton.Text = "Median Filter";
            this.medianButton.UseVisualStyleBackColor = true;
            this.medianButton.Click += new System.EventHandler(this.medianButton_Click);
            // 
            // standardiseButton
            // 
            this.standardiseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.standardiseButton.Location = new System.Drawing.Point(989, 138);
            this.standardiseButton.Name = "standardiseButton";
            this.standardiseButton.Size = new System.Drawing.Size(208, 48);
            this.standardiseButton.TabIndex = 6;
            this.standardiseButton.Text = "Standardise";
            this.standardiseButton.UseVisualStyleBackColor = true;
            this.standardiseButton.Click += new System.EventHandler(this.standardiseButton_Click);
            // 
            // contourButton
            // 
            this.contourButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.contourButton.Location = new System.Drawing.Point(989, 192);
            this.contourButton.Name = "contourButton";
            this.contourButton.Size = new System.Drawing.Size(208, 48);
            this.contourButton.TabIndex = 7;
            this.contourButton.Text = "Contour";
            this.contourButton.UseVisualStyleBackColor = true;
            this.contourButton.Click += new System.EventHandler(this.contourButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1209, 504);
            this.Controls.Add(this.contourButton);
            this.Controls.Add(this.standardiseButton);
            this.Controls.Add(this.medianButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.destinationPictureBox);
            this.Controls.Add(this.sourcePictureBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sourcePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.destinationPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox sourcePictureBox;
        private System.Windows.Forms.PictureBox destinationPictureBox;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button medianButton;
        private System.Windows.Forms.Button standardiseButton;
        private System.Windows.Forms.Button contourButton;
    }
}

