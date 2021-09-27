
namespace Samuel_Gurara_COMP306_Lab1
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
            this.btnCreateBucket = new System.Windows.Forms.Button();
            this.btnObjectLevelOperation = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCreateBucket
            // 
            this.btnCreateBucket.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateBucket.Location = new System.Drawing.Point(53, 48);
            this.btnCreateBucket.Name = "btnCreateBucket";
            this.btnCreateBucket.Size = new System.Drawing.Size(194, 59);
            this.btnCreateBucket.TabIndex = 0;
            this.btnCreateBucket.Text = "Create Bucket";
            this.btnCreateBucket.UseVisualStyleBackColor = true;
            this.btnCreateBucket.Click += new System.EventHandler(this.btnCreateBucket_Click);
            // 
            // btnObjectLevelOperation
            // 
            this.btnObjectLevelOperation.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnObjectLevelOperation.Location = new System.Drawing.Point(309, 48);
            this.btnObjectLevelOperation.Name = "btnObjectLevelOperation";
            this.btnObjectLevelOperation.Size = new System.Drawing.Size(194, 59);
            this.btnObjectLevelOperation.TabIndex = 1;
            this.btnObjectLevelOperation.Text = "Object Level Operations";
            this.btnObjectLevelOperation.UseVisualStyleBackColor = true;
            this.btnObjectLevelOperation.Click += new System.EventHandler(this.btnObjectLevelOperation_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(551, 48);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(194, 59);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 154);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnObjectLevelOperation);
            this.Controls.Add(this.btnCreateBucket);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCreateBucket;
        private System.Windows.Forms.Button btnObjectLevelOperation;
        private System.Windows.Forms.Button btnExit;
    }
}

