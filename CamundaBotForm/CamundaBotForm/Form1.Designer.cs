namespace CamundaBotForm
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
            this.DefinitionIDTxtBox = new System.Windows.Forms.TextBox();
            this.JSONTxtBox = new System.Windows.Forms.TextBox();
            this.FileNameTxtBox = new System.Windows.Forms.TextBox();
            this.DefinitionKeyTxtBox = new System.Windows.Forms.TextBox();
            this.DefinitionIdLbl = new System.Windows.Forms.Label();
            this.DefinitionKeyLbl = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.StartProcessCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TimesTxtBox = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.FilePathLbl = new System.Windows.Forms.Label();
            this.RunProgramBtn = new System.Windows.Forms.Button();
            this.SuccessLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.TimesTxtBox)).BeginInit();
            this.SuspendLayout();
            // 
            // DefinitionIDTxtBox
            // 
            this.DefinitionIDTxtBox.Location = new System.Drawing.Point(84, 93);
            this.DefinitionIDTxtBox.Name = "DefinitionIDTxtBox";
            this.DefinitionIDTxtBox.Size = new System.Drawing.Size(246, 20);
            this.DefinitionIDTxtBox.TabIndex = 0;
            // 
            // JSONTxtBox
            // 
            this.JSONTxtBox.Location = new System.Drawing.Point(84, 154);
            this.JSONTxtBox.Name = "JSONTxtBox";
            this.JSONTxtBox.Size = new System.Drawing.Size(246, 20);
            this.JSONTxtBox.TabIndex = 1;
            // 
            // FileNameTxtBox
            // 
            this.FileNameTxtBox.Location = new System.Drawing.Point(84, 233);
            this.FileNameTxtBox.Name = "FileNameTxtBox";
            this.FileNameTxtBox.Size = new System.Drawing.Size(246, 20);
            this.FileNameTxtBox.TabIndex = 6;
            // 
            // DefinitionKeyTxtBox
            // 
            this.DefinitionKeyTxtBox.Location = new System.Drawing.Point(417, 93);
            this.DefinitionKeyTxtBox.Name = "DefinitionKeyTxtBox";
            this.DefinitionKeyTxtBox.Size = new System.Drawing.Size(246, 20);
            this.DefinitionKeyTxtBox.TabIndex = 4;
            // 
            // DefinitionIdLbl
            // 
            this.DefinitionIdLbl.AutoSize = true;
            this.DefinitionIdLbl.Location = new System.Drawing.Point(81, 77);
            this.DefinitionIdLbl.Name = "DefinitionIdLbl";
            this.DefinitionIdLbl.Size = new System.Drawing.Size(65, 13);
            this.DefinitionIdLbl.TabIndex = 7;
            this.DefinitionIdLbl.Text = "Definition ID";
            // 
            // DefinitionKeyLbl
            // 
            this.DefinitionKeyLbl.AutoSize = true;
            this.DefinitionKeyLbl.Location = new System.Drawing.Point(414, 77);
            this.DefinitionKeyLbl.Name = "DefinitionKeyLbl";
            this.DefinitionKeyLbl.Size = new System.Drawing.Size(72, 13);
            this.DefinitionKeyLbl.TabIndex = 8;
            this.DefinitionKeyLbl.Text = "Definition Key";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(81, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(198, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "JSON String (Leave blank if not needed)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(414, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Times Started";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(81, 217);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "File Name";
            // 
            // StartProcessCheckBox
            // 
            this.StartProcessCheckBox.AutoSize = true;
            this.StartProcessCheckBox.Checked = true;
            this.StartProcessCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.StartProcessCheckBox.Location = new System.Drawing.Point(84, 276);
            this.StartProcessCheckBox.Name = "StartProcessCheckBox";
            this.StartProcessCheckBox.Size = new System.Drawing.Size(95, 17);
            this.StartProcessCheckBox.TabIndex = 12;
            this.StartProcessCheckBox.Text = "Start Process?";
            this.StartProcessCheckBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(414, 217);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Save File Path";
            // 
            // TimesTxtBox
            // 
            this.TimesTxtBox.Location = new System.Drawing.Point(417, 155);
            this.TimesTxtBox.Name = "TimesTxtBox";
            this.TimesTxtBox.Size = new System.Drawing.Size(246, 20);
            this.TimesTxtBox.TabIndex = 15;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(417, 233);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 23);
            this.button1.TabIndex = 16;
            this.button1.Text = "Select Folder";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FilePathLbl
            // 
            this.FilePathLbl.AutoSize = true;
            this.FilePathLbl.Location = new System.Drawing.Point(509, 238);
            this.FilePathLbl.Name = "FilePathLbl";
            this.FilePathLbl.Size = new System.Drawing.Size(57, 13);
            this.FilePathLbl.TabIndex = 17;
            this.FilePathLbl.Text = "File Path...";
            // 
            // RunProgramBtn
            // 
            this.RunProgramBtn.Location = new System.Drawing.Point(288, 347);
            this.RunProgramBtn.Name = "RunProgramBtn";
            this.RunProgramBtn.Size = new System.Drawing.Size(182, 29);
            this.RunProgramBtn.TabIndex = 18;
            this.RunProgramBtn.Text = "Run Camunda Test";
            this.RunProgramBtn.UseVisualStyleBackColor = true;
            this.RunProgramBtn.Click += new System.EventHandler(this.RunProgramBtn_Click);
            // 
            // SuccessLbl
            // 
            this.SuccessLbl.AutoSize = true;
            this.SuccessLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SuccessLbl.ForeColor = System.Drawing.Color.DarkGreen;
            this.SuccessLbl.Location = new System.Drawing.Point(487, 347);
            this.SuccessLbl.Name = "SuccessLbl";
            this.SuccessLbl.Size = new System.Drawing.Size(130, 24);
            this.SuccessLbl.TabIndex = 19;
            this.SuccessLbl.Text = "File Created!";
            this.SuccessLbl.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 388);
            this.Controls.Add(this.SuccessLbl);
            this.Controls.Add(this.RunProgramBtn);
            this.Controls.Add(this.FilePathLbl);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TimesTxtBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StartProcessCheckBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DefinitionKeyLbl);
            this.Controls.Add(this.DefinitionIdLbl);
            this.Controls.Add(this.FileNameTxtBox);
            this.Controls.Add(this.DefinitionKeyTxtBox);
            this.Controls.Add(this.JSONTxtBox);
            this.Controls.Add(this.DefinitionIDTxtBox);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TimesTxtBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox DefinitionIDTxtBox;
        private System.Windows.Forms.TextBox JSONTxtBox;
        private System.Windows.Forms.TextBox FileNameTxtBox;
        private System.Windows.Forms.TextBox DefinitionKeyTxtBox;
        private System.Windows.Forms.Label DefinitionIdLbl;
        private System.Windows.Forms.Label DefinitionKeyLbl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox StartProcessCheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown TimesTxtBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label FilePathLbl;
        private System.Windows.Forms.Button RunProgramBtn;
        private System.Windows.Forms.Label SuccessLbl;
    }
}

