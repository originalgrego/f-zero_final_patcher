namespace DesktopApp1 {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.fzeroFileText = new System.Windows.Forms.TextBox();
            this.fzeroSelectButton = new System.Windows.Forms.Button();
            this.gp2FileText = new System.Windows.Forms.TextBox();
            this.gp2SelectButton = new System.Windows.Forms.Button();
            this.patchButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // fzeroFileText
            // 
            this.fzeroFileText.Location = new System.Drawing.Point(12, 12);
            this.fzeroFileText.Name = "fzeroFileText";
            this.fzeroFileText.Size = new System.Drawing.Size(359, 20);
            this.fzeroFileText.TabIndex = 0;
            // 
            // fzeroSelectButton
            // 
            this.fzeroSelectButton.Location = new System.Drawing.Point(12, 38);
            this.fzeroSelectButton.Name = "fzeroSelectButton";
            this.fzeroSelectButton.Size = new System.Drawing.Size(118, 23);
            this.fzeroSelectButton.TabIndex = 1;
            this.fzeroSelectButton.Text = "Choose F-Zero";
            this.fzeroSelectButton.UseVisualStyleBackColor = true;
            this.fzeroSelectButton.Click += new System.EventHandler(this.fzeroSelect_Click);
            // 
            // gp2FileText
            // 
            this.gp2FileText.Location = new System.Drawing.Point(12, 67);
            this.gp2FileText.Name = "gp2FileText";
            this.gp2FileText.Size = new System.Drawing.Size(359, 20);
            this.gp2FileText.TabIndex = 2;
            // 
            // gp2SelectButton
            // 
            this.gp2SelectButton.Location = new System.Drawing.Point(12, 93);
            this.gp2SelectButton.Name = "gp2SelectButton";
            this.gp2SelectButton.Size = new System.Drawing.Size(118, 23);
            this.gp2SelectButton.TabIndex = 3;
            this.gp2SelectButton.Text = "Choose GP2";
            this.gp2SelectButton.UseVisualStyleBackColor = true;
            this.gp2SelectButton.Click += new System.EventHandler(this.gp2Select_Click);
            // 
            // patchButton
            // 
            this.patchButton.Location = new System.Drawing.Point(296, 128);
            this.patchButton.Name = "patchButton";
            this.patchButton.Size = new System.Drawing.Size(75, 23);
            this.patchButton.TabIndex = 4;
            this.patchButton.Text = "Patch";
            this.patchButton.UseVisualStyleBackColor = true;
            this.patchButton.Click += new System.EventHandler(this.patch_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 163);
            this.Controls.Add(this.patchButton);
            this.Controls.Add(this.gp2SelectButton);
            this.Controls.Add(this.gp2FileText);
            this.Controls.Add(this.fzeroSelectButton);
            this.Controls.Add(this.fzeroFileText);
            this.Name = "Form1";
            this.Text = "F-Zero Final Patcher";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox fzeroFileText;
        private System.Windows.Forms.Button fzeroSelectButton;
        private System.Windows.Forms.TextBox gp2FileText;
        private System.Windows.Forms.Button gp2SelectButton;
        private System.Windows.Forms.Button patchButton;
    }
}

