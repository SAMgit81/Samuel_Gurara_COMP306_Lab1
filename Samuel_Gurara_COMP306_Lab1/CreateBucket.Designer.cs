
namespace Samuel_Gurara_COMP306_Lab1
{
    partial class CreateBucket
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtBucket = new System.Windows.Forms.TextBox();
            this.btnCreateBucket = new System.Windows.Forms.Button();
            this.btnBackToMain = new System.Windows.Forms.Button();
            this.dataCreateBucket = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataCreateBucket)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(38, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bucket Name";
            // 
            // txtBucket
            // 
            this.txtBucket.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBucket.Location = new System.Drawing.Point(142, 81);
            this.txtBucket.Multiline = true;
            this.txtBucket.Name = "txtBucket";
            this.txtBucket.Size = new System.Drawing.Size(266, 32);
            this.txtBucket.TabIndex = 1;
            // 
            // btnCreateBucket
            // 
            this.btnCreateBucket.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateBucket.Location = new System.Drawing.Point(436, 81);
            this.btnCreateBucket.Name = "btnCreateBucket";
            this.btnCreateBucket.Size = new System.Drawing.Size(146, 32);
            this.btnCreateBucket.TabIndex = 2;
            this.btnCreateBucket.Text = "Create Bucket";
            this.btnCreateBucket.UseVisualStyleBackColor = true;
            this.btnCreateBucket.Click += new System.EventHandler(this.btnCreateBucket_Click);
            // 
            // btnBackToMain
            // 
            this.btnBackToMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackToMain.Location = new System.Drawing.Point(180, 392);
            this.btnBackToMain.Name = "btnBackToMain";
            this.btnBackToMain.Size = new System.Drawing.Size(308, 46);
            this.btnBackToMain.TabIndex = 4;
            this.btnBackToMain.Text = "Back to Main Window";
            this.btnBackToMain.UseVisualStyleBackColor = true;
            this.btnBackToMain.Click += new System.EventHandler(this.btnBackToMain_Click);
            // 
            // dataCreateBucket
            // 
            this.dataCreateBucket.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataCreateBucket.Location = new System.Drawing.Point(41, 139);
            this.dataCreateBucket.Name = "dataCreateBucket";
            this.dataCreateBucket.Size = new System.Drawing.Size(541, 239);
            this.dataCreateBucket.TabIndex = 5;
            // 
            // CreateBucket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 450);
            this.Controls.Add(this.dataCreateBucket);
            this.Controls.Add(this.btnBackToMain);
            this.Controls.Add(this.btnCreateBucket);
            this.Controls.Add(this.txtBucket);
            this.Controls.Add(this.label1);
            this.Name = "CreateBucket";
            this.Text = "Create Bucket";
            ((System.ComponentModel.ISupportInitialize)(this.dataCreateBucket)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBucket;
        private System.Windows.Forms.Button btnCreateBucket;
        private System.Windows.Forms.Button btnBackToMain;
        private System.Windows.Forms.DataGridView dataCreateBucket;
    }
}