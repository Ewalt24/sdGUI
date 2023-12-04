namespace GUIApp1
{
    partial class Form2
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
            label1 = new System.Windows.Forms.Label();
            textBox1 = new System.Windows.Forms.TextBox();
            button1 = new System.Windows.Forms.Button();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(23, 19);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(263, 25);
            label1.TabIndex = 0;
            label1.Text = "Insert Custom DNA String Here:";
            // 
            // textBox1
            // 
            textBox1.Location = new System.Drawing.Point(32, 58);
            textBox1.Name = "textBox1";
            textBox1.Size = new System.Drawing.Size(1092, 31);
            textBox1.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(524, 252);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(112, 34);
            button1.TabIndex = 2;
            button1.Text = "Save";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(35, 250);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(219, 25);
            label2.TabIndex = 3;
            label2.Text = "Recommended Array Size:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(265, 253);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(49, 25);
            label3.TabIndex = 4;
            label3.Text = "Here";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(33, 111);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(204, 25);
            label4.TabIndex = 5;
            label4.Text = "Max String Length: 8515";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(35, 145);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(191, 25);
            label5.TabIndex = 6;
            label5.Text = "Min String Length: 600";
            // 
            // Form2
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1155, 322);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Name = "Form2";
            Text = "Form2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}