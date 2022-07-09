namespace Client
{
    partial class ClientForm
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
            this.sendBtn = new System.Windows.Forms.Button();
            this.getFileBtn = new System.Windows.Forms.Button();
            this.fileIdTB = new System.Windows.Forms.TextBox();
            this.fileIdL = new System.Windows.Forms.Label();
            this.enablePremBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // sendBtn
            // 
            this.sendBtn.BackColor = System.Drawing.Color.SeaGreen;
            this.sendBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sendBtn.Location = new System.Drawing.Point(38, 97);
            this.sendBtn.Name = "sendBtn";
            this.sendBtn.Size = new System.Drawing.Size(234, 101);
            this.sendBtn.TabIndex = 0;
            this.sendBtn.Text = "SEND FILE";
            this.sendBtn.UseVisualStyleBackColor = false;
            this.sendBtn.Click += new System.EventHandler(this.sendBtn_Click);
            // 
            // getFileBtn
            // 
            this.getFileBtn.BackColor = System.Drawing.Color.DarkGreen;
            this.getFileBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.getFileBtn.Location = new System.Drawing.Point(278, 14);
            this.getFileBtn.Name = "getFileBtn";
            this.getFileBtn.Size = new System.Drawing.Size(147, 66);
            this.getFileBtn.TabIndex = 3;
            this.getFileBtn.Text = "GET FILE";
            this.getFileBtn.UseVisualStyleBackColor = false;
            this.getFileBtn.Click += new System.EventHandler(this.getFileBtn_Click);
            // 
            // fileIdTB
            // 
            this.fileIdTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fileIdTB.Location = new System.Drawing.Point(12, 32);
            this.fileIdTB.Name = "fileIdTB";
            this.fileIdTB.Size = new System.Drawing.Size(260, 30);
            this.fileIdTB.TabIndex = 4;
            // 
            // fileIdL
            // 
            this.fileIdL.AutoSize = true;
            this.fileIdL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fileIdL.Location = new System.Drawing.Point(12, 9);
            this.fileIdL.Name = "fileIdL";
            this.fileIdL.Size = new System.Drawing.Size(88, 20);
            this.fileIdL.TabIndex = 5;
            this.fileIdL.Text = "Enter file id";
            // 
            // enablePremBtn
            // 
            this.enablePremBtn.BackColor = System.Drawing.Color.LemonChiffon;
            this.enablePremBtn.Location = new System.Drawing.Point(375, 168);
            this.enablePremBtn.Name = "enablePremBtn";
            this.enablePremBtn.Size = new System.Drawing.Size(55, 55);
            this.enablePremBtn.TabIndex = 6;
            this.enablePremBtn.Text = "PREMIUM";
            this.enablePremBtn.UseVisualStyleBackColor = false;
            this.enablePremBtn.Click += new System.EventHandler(this.enablePremBtn_Click);
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 235);
            this.Controls.Add(this.enablePremBtn);
            this.Controls.Add(this.fileIdL);
            this.Controls.Add(this.fileIdTB);
            this.Controls.Add(this.getFileBtn);
            this.Controls.Add(this.sendBtn);
            this.Name = "ClientForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button sendBtn;
        private System.Windows.Forms.Button getFileBtn;
        private System.Windows.Forms.TextBox fileIdTB;
        private System.Windows.Forms.Label fileIdL;
        private System.Windows.Forms.Button enablePremBtn;
    }
}

