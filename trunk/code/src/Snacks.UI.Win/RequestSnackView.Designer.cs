namespace Snacks.UI.Win
{
    partial class RequestSnackView
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
            this.lblUserId = new System.Windows.Forms.Label();
            this.txtUserId = new System.Windows.Forms.TextBox();
            this.btnRequestSnack = new System.Windows.Forms.Button();
            this.txtSnack = new System.Windows.Forms.TextBox();
            this.lblSnack = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblUserId
            // 
            this.lblUserId.AutoSize = true;
            this.lblUserId.Location = new System.Drawing.Point(7, 15);
            this.lblUserId.Name = "lblUserId";
            this.lblUserId.Size = new System.Drawing.Size(29, 13);
            this.lblUserId.TabIndex = 0;
            this.lblUserId.Text = "User";
            // 
            // txtUserId
            // 
            this.txtUserId.Location = new System.Drawing.Point(48, 12);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Size = new System.Drawing.Size(100, 20);
            this.txtUserId.TabIndex = 1;
            this.txtUserId.Text = "1";
            // 
            // btnRequestSnack
            // 
            this.btnRequestSnack.Location = new System.Drawing.Point(177, 238);
            this.btnRequestSnack.Name = "btnRequestSnack";
            this.btnRequestSnack.Size = new System.Drawing.Size(103, 23);
            this.btnRequestSnack.TabIndex = 4;
            this.btnRequestSnack.Text = "Request Snack";
            this.btnRequestSnack.UseVisualStyleBackColor = true;
            // 
            // txtSnack
            // 
            this.txtSnack.Location = new System.Drawing.Point(48, 56);
            this.txtSnack.Name = "txtSnack";
            this.txtSnack.Size = new System.Drawing.Size(100, 20);
            this.txtSnack.TabIndex = 3;
            this.txtSnack.Text = "Club Sandwich";
            // 
            // lblSnack
            // 
            this.lblSnack.AutoSize = true;
            this.lblSnack.Location = new System.Drawing.Point(7, 59);
            this.lblSnack.Name = "lblSnack";
            this.lblSnack.Size = new System.Drawing.Size(38, 13);
            this.lblSnack.TabIndex = 2;
            this.lblSnack.Text = "Snack";
            // 
            // RequestSnackView
            // 
            this.AcceptButton = this.btnRequestSnack;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.txtSnack);
            this.Controls.Add(this.lblSnack);
            this.Controls.Add(this.btnRequestSnack);
            this.Controls.Add(this.txtUserId);
            this.Controls.Add(this.lblUserId);
            this.Name = "RequestSnackView";
            this.Text = "Snack Request";
            this.Load += new System.EventHandler(this.RequestSnackView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUserId;
        private System.Windows.Forms.TextBox txtUserId;
        private System.Windows.Forms.Button btnRequestSnack;
        private System.Windows.Forms.TextBox txtSnack;
        private System.Windows.Forms.Label lblSnack;
    }
}

