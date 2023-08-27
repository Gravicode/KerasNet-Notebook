namespace MnistApp
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
            this.DrawingBox = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnClear = new System.Windows.Forms.Button();
            this.BtnGuess = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtGuess = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DrawingBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DrawingBox
            // 
            this.DrawingBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DrawingBox.Location = new System.Drawing.Point(12, 12);
            this.DrawingBox.Name = "DrawingBox";
            this.DrawingBox.Size = new System.Drawing.Size(476, 476);
            this.DrawingBox.TabIndex = 0;
            this.DrawingBox.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnClear);
            this.groupBox1.Controls.Add(this.BtnGuess);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.TxtGuess);
            this.groupBox1.Location = new System.Drawing.Point(518, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(184, 101);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Guess Number";
            // 
            // BtnClear
            // 
            this.BtnClear.Location = new System.Drawing.Point(11, 47);
            this.BtnClear.Name = "BtnClear";
            this.BtnClear.Size = new System.Drawing.Size(75, 23);
            this.BtnClear.TabIndex = 3;
            this.BtnClear.Text = "&Clear";
            this.BtnClear.UseVisualStyleBackColor = true;
            // 
            // BtnGuess
            // 
            this.BtnGuess.Location = new System.Drawing.Point(92, 47);
            this.BtnGuess.Name = "BtnGuess";
            this.BtnGuess.Size = new System.Drawing.Size(75, 23);
            this.BtnGuess.TabIndex = 2;
            this.BtnGuess.Text = "&Guess";
            this.BtnGuess.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Number:";
            // 
            // TxtGuess
            // 
            this.TxtGuess.Location = new System.Drawing.Point(67, 18);
            this.TxtGuess.Name = "TxtGuess";
            this.TxtGuess.Size = new System.Drawing.Size(100, 23);
            this.TxtGuess.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 533);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.DrawingBox);
            this.Name = "Form1";
            this.Text = "MNIST ";
            ((System.ComponentModel.ISupportInitialize)(this.DrawingBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox DrawingBox;
        private GroupBox groupBox1;
        private Button BtnGuess;
        private Label label1;
        private TextBox TxtGuess;
        private Button BtnClear;
    }
}