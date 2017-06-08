namespace Product_Catalog_User_Interface
{
    partial class CategoryAdder
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
            this.catNameLabel = new System.Windows.Forms.Label();
            this.catAbrLabel = new System.Windows.Forms.Label();
            this.txtCatName = new System.Windows.Forms.TextBox();
            this.txtCatAbr = new System.Windows.Forms.TextBox();
            this.cmdAccept = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // catNameLabel
            // 
            this.catNameLabel.AutoSize = true;
            this.catNameLabel.Location = new System.Drawing.Point(26, 95);
            this.catNameLabel.Name = "catNameLabel";
            this.catNameLabel.Size = new System.Drawing.Size(80, 13);
            this.catNameLabel.TabIndex = 2;
            this.catNameLabel.Text = "Category Name";
            // 
            // catAbrLabel
            // 
            this.catAbrLabel.AutoSize = true;
            this.catAbrLabel.Location = new System.Drawing.Point(4, 139);
            this.catAbrLabel.Name = "catAbrLabel";
            this.catAbrLabel.Size = new System.Drawing.Size(111, 13);
            this.catAbrLabel.TabIndex = 3;
            this.catAbrLabel.Text = "Category Abbreviation";
            // 
            // txtCatName
            // 
            this.txtCatName.Location = new System.Drawing.Point(162, 95);
            this.txtCatName.Name = "txtCatName";
            this.txtCatName.Size = new System.Drawing.Size(100, 20);
            this.txtCatName.TabIndex = 4;
            // 
            // txtCatAbr
            // 
            this.txtCatAbr.Location = new System.Drawing.Point(162, 139);
            this.txtCatAbr.Name = "txtCatAbr";
            this.txtCatAbr.Size = new System.Drawing.Size(100, 20);
            this.txtCatAbr.TabIndex = 5;
            // 
            // cmdAccept
            // 
            this.cmdAccept.Location = new System.Drawing.Point(12, 206);
            this.cmdAccept.Name = "cmdAccept";
            this.cmdAccept.Size = new System.Drawing.Size(87, 43);
            this.cmdAccept.TabIndex = 12;
            this.cmdAccept.Text = "Accept";
            this.cmdAccept.UseVisualStyleBackColor = true;
            this.cmdAccept.Click += new System.EventHandler(this.cmdAccept_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(175, 206);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(87, 43);
            this.cmdCancel.TabIndex = 13;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // CategoryAdder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdAccept);
            this.Controls.Add(this.txtCatAbr);
            this.Controls.Add(this.txtCatName);
            this.Controls.Add(this.catAbrLabel);
            this.Controls.Add(this.catNameLabel);
            this.Name = "CategoryAdder";
            this.Text = "CategoryAdder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label catNameLabel;
        private System.Windows.Forms.Label catAbrLabel;
        private System.Windows.Forms.TextBox txtCatName;
        private System.Windows.Forms.TextBox txtCatAbr;
        internal System.Windows.Forms.Button cmdAccept;
        internal System.Windows.Forms.Button cmdCancel;
    }
}