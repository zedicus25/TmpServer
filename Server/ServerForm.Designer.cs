namespace Server
{
    partial class ServerForm
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
            this.filesLB = new System.Windows.Forms.ListBox();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.hoursTB = new System.Windows.Forms.TextBox();
            this.minutesTB = new System.Windows.Forms.TextBox();
            this.secondsTB = new System.Windows.Forms.TextBox();
            this.hoursL = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.forAllCB = new System.Windows.Forms.CheckBox();
            this.setTimeBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // filesLB
            // 
            this.filesLB.FormattingEnabled = true;
            this.filesLB.Location = new System.Drawing.Point(12, 12);
            this.filesLB.Name = "filesLB";
            this.filesLB.Size = new System.Drawing.Size(535, 316);
            this.filesLB.TabIndex = 0;
            // 
            // deleteBtn
            // 
            this.deleteBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deleteBtn.Location = new System.Drawing.Point(553, 12);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(129, 70);
            this.deleteBtn.TabIndex = 1;
            this.deleteBtn.Text = "Delete";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // hoursTB
            // 
            this.hoursTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.hoursTB.Location = new System.Drawing.Point(553, 145);
            this.hoursTB.Name = "hoursTB";
            this.hoursTB.Size = new System.Drawing.Size(39, 30);
            this.hoursTB.TabIndex = 2;
            this.hoursTB.Text = "00";
            this.hoursTB.TextChanged += new System.EventHandler(this.TimeTB_TextChanged);
            this.hoursTB.Leave += new System.EventHandler(this.TimeTB_Leave);
            // 
            // minutesTB
            // 
            this.minutesTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.minutesTB.Location = new System.Drawing.Point(598, 145);
            this.minutesTB.Name = "minutesTB";
            this.minutesTB.Size = new System.Drawing.Size(39, 30);
            this.minutesTB.TabIndex = 3;
            this.minutesTB.Text = "00";
            this.minutesTB.TextChanged += new System.EventHandler(this.TimeTB_TextChanged);
            this.minutesTB.Leave += new System.EventHandler(this.TimeTB_Leave);
            // 
            // secondsTB
            // 
            this.secondsTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.secondsTB.Location = new System.Drawing.Point(643, 145);
            this.secondsTB.Name = "secondsTB";
            this.secondsTB.Size = new System.Drawing.Size(39, 30);
            this.secondsTB.TabIndex = 4;
            this.secondsTB.Text = "00";
            this.secondsTB.TextChanged += new System.EventHandler(this.TimeTB_TextChanged);
            this.secondsTB.Leave += new System.EventHandler(this.TimeTB_Leave);
            // 
            // hoursL
            // 
            this.hoursL.AutoSize = true;
            this.hoursL.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.hoursL.Location = new System.Drawing.Point(602, 117);
            this.hoursL.Name = "hoursL";
            this.hoursL.Size = new System.Drawing.Size(29, 25);
            this.hoursL.TabIndex = 5;
            this.hoursL.Text = "M";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(557, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "H";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(647, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "S";
            // 
            // forAllCB
            // 
            this.forAllCB.AutoSize = true;
            this.forAllCB.Location = new System.Drawing.Point(554, 182);
            this.forAllCB.Name = "forAllCB";
            this.forAllCB.Size = new System.Drawing.Size(54, 17);
            this.forAllCB.TabIndex = 7;
            this.forAllCB.Text = "For all";
            this.forAllCB.UseVisualStyleBackColor = true;
            // 
            // setTimeBtn
            // 
            this.setTimeBtn.Location = new System.Drawing.Point(553, 205);
            this.setTimeBtn.Name = "setTimeBtn";
            this.setTimeBtn.Size = new System.Drawing.Size(129, 45);
            this.setTimeBtn.TabIndex = 8;
            this.setTimeBtn.Text = "Set life time";
            this.setTimeBtn.UseVisualStyleBackColor = true;
            this.setTimeBtn.Click += new System.EventHandler(this.setTimeBtn_Click);
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 341);
            this.Controls.Add(this.setTimeBtn);
            this.Controls.Add(this.forAllCB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.hoursL);
            this.Controls.Add(this.secondsTB);
            this.Controls.Add(this.minutesTB);
            this.Controls.Add(this.hoursTB);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.filesLB);
            this.Name = "ServerForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox filesLB;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.TextBox hoursTB;
        private System.Windows.Forms.TextBox minutesTB;
        private System.Windows.Forms.TextBox secondsTB;
        private System.Windows.Forms.Label hoursL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox forAllCB;
        private System.Windows.Forms.Button setTimeBtn;
    }
}

