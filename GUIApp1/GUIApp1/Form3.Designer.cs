namespace GUIApp1
{
    partial class Form3
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
            button1 = new System.Windows.Forms.Button();
            progressBar1 = new System.Windows.Forms.ProgressBar();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(25, 16);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(112, 34);
            button1.TabIndex = 0;
            button1.Text = "Start";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // progressBar1
            // 
            progressBar1.Location = new System.Drawing.Point(52, 916);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new System.Drawing.Size(465, 51);
            progressBar1.TabIndex = 1;
            progressBar1.Visible = false;
            // 
            // Form3
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.ControlText;
            ClientSize = new System.Drawing.Size(1886, 1010);
            Controls.Add(progressBar1);
            Controls.Add(button1);
            Name = "Form3";
            Text = "Form3";
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}