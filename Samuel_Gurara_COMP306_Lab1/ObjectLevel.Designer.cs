
namespace Samuel_Gurara_COMP306_Lab1
{
    partial class ObjectLevel
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
            this.cbxBucket = new System.Windows.Forms.ComboBox();
            this.txtObj = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnUpload = new System.Windows.Forms.Button();
            this.DataObjectGrid = new System.Windows.Forms.DataGridView();
            this.btnBackToMain = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DataObjectGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // cbxBucket
            // 
            this.cbxBucket.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxBucket.FormattingEnabled = true;
            this.cbxBucket.Location = new System.Drawing.Point(131, 81);
            this.cbxBucket.Name = "cbxBucket";
            this.cbxBucket.Size = new System.Drawing.Size(441, 26);
            this.cbxBucket.TabIndex = 2;
            this.cbxBucket.SelectedIndexChanged += new System.EventHandler(this.cbxBucket_SelectedIndexChanged);
            // 
            // txtObj
            // 
            this.txtObj.Location = new System.Drawing.Point(131, 135);
            this.txtObj.Name = "txtObj";
            this.txtObj.Size = new System.Drawing.Size(441, 20);
            this.txtObj.TabIndex = 3;
            this.txtObj.TextChanged += new System.EventHandler(this.txtObj_TextChanged);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.Location = new System.Drawing.Point(594, 81);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(189, 33);
            this.btnBrowse.TabIndex = 4;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnUpload
            // 
            this.btnUpload.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpload.Location = new System.Drawing.Point(594, 135);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(189, 32);
            this.btnUpload.TabIndex = 5;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // DataObjectGrid
            // 
            this.DataObjectGrid.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.DataObjectGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataObjectGrid.Location = new System.Drawing.Point(53, 192);
            this.DataObjectGrid.Name = "DataObjectGrid";
            this.DataObjectGrid.Size = new System.Drawing.Size(519, 235);
            this.DataObjectGrid.TabIndex = 6;
            // 
            // btnBackToMain
            // 
            this.btnBackToMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackToMain.Location = new System.Drawing.Point(594, 383);
            this.btnBackToMain.Name = "btnBackToMain";
            this.btnBackToMain.Size = new System.Drawing.Size(195, 44);
            this.btnBackToMain.TabIndex = 7;
            this.btnBackToMain.Text = "Back to Main Window";
            this.btnBackToMain.UseVisualStyleBackColor = true;
            this.btnBackToMain.Click += new System.EventHandler(this.btnBackToMain_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(50, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 18);
            this.label1.TabIndex = 8;
            this.label1.Text = "Bucket";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(53, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 18);
            this.label2.TabIndex = 9;
            this.label2.Text = "Object";
            // 
            // ObjectLevel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBackToMain);
            this.Controls.Add(this.DataObjectGrid);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtObj);
            this.Controls.Add(this.cbxBucket);
            this.Name = "ObjectLevel";
            this.Text = "ObjectLevel";
            ((System.ComponentModel.ISupportInitialize)(this.DataObjectGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cbxBucket;
        private System.Windows.Forms.TextBox txtObj;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.DataGridView DataObjectGrid;
        private System.Windows.Forms.Button btnBackToMain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}