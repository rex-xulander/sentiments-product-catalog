namespace WindowsApplication_cs
{
    partial class ModelNumberForm
    {
        /// Required designer variable.
        private System.ComponentModel.IContainer components = null;

        /// Clean up any resources being used.
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
            this.Label6 = new System.Windows.Forms.Label();
            this.cboBrandName = new System.Windows.Forms.ComboBox();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdAccept = new System.Windows.Forms.Button();
            this.Label4 = new System.Windows.Forms.Label();
            this.cboColorName = new System.Windows.Forms.ComboBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.cboPatternName = new System.Windows.Forms.ComboBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.cboProductName = new System.Windows.Forms.ComboBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.cboSize = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(39, 260);
            this.Label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(52, 20);
            this.Label6.TabIndex = 9;
            this.Label6.Text = "Brand";

            // 
            // cboBrandName
            // 
            this.cboBrandName.Location = new System.Drawing.Point(159, 252);
            this.cboBrandName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboBrandName.Name = "cboBrandName";
            this.cboBrandName.Size = new System.Drawing.Size(148, 28);
            this.cboBrandName.TabIndex = 10;
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(345, 375);
            this.cmdCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(130, 66);
            this.cmdCancel.TabIndex = 0;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdAccept
            // 
            this.cmdAccept.Location = new System.Drawing.Point(20, 375);
            this.cmdAccept.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmdAccept.Name = "cmdAccept";
            this.cmdAccept.Size = new System.Drawing.Size(130, 66);
            this.cmdAccept.TabIndex = 11;
            this.cmdAccept.Text = "Accept";
            this.cmdAccept.UseVisualStyleBackColor = true;
            this.cmdAccept.Click += new System.EventHandler(this.cmdAccept_Click);
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(40, 191);
            this.Label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(40, 20);
            this.Label4.TabIndex = 7;
            this.Label4.Text = "Size";

            // 
            // cboColorName
            // 
            this.cboColorName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboColorName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboColorName.Location = new System.Drawing.Point(159, 132);
            this.cboColorName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboColorName.Name = "cboColorName";
            this.cboColorName.Size = new System.Drawing.Size(294, 28);
            this.cboColorName.TabIndex = 6;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(40, 140);
            this.Label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(46, 20);
            this.Label3.TabIndex = 5;
            this.Label3.Text = "Color";
            // 
            // cboPatternName
            // 
            this.cboPatternName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboPatternName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboPatternName.Location = new System.Drawing.Point(159, 75);
            this.cboPatternName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboPatternName.Name = "cboPatternName";
            this.cboPatternName.Size = new System.Drawing.Size(294, 28);
            this.cboPatternName.TabIndex = 4;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(39, 80);
            this.Label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(61, 20);
            this.Label2.TabIndex = 3;
            this.Label2.Text = "Pattern";
            // 
            // cboProductName
            // 
            this.cboProductName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboProductName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboProductName.Location = new System.Drawing.Point(159, 18);
            this.cboProductName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboProductName.Name = "cboProductName";
            this.cboProductName.Size = new System.Drawing.Size(294, 28);
            this.cboProductName.TabIndex = 2;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(40, 23);
            this.Label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(110, 20);
            this.Label1.TabIndex = 1;
            this.Label1.Text = "Product Name";
            // 
            // cboSize
            // 
            this.cboSize.Location = new System.Drawing.Point(159, 188);
            this.cboSize.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboSize.Name = "cboSize";
            this.cboSize.Size = new System.Drawing.Size(294, 28);
            this.cboSize.TabIndex = 8;
            // 
            // ModelNumberForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 460);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.cboBrandName);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdAccept);
            this.Controls.Add(this.cboSize);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.cboColorName);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.cboPatternName);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.cboProductName);
            this.Controls.Add(this.Label1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ModelNumberForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ModelNumberForm";
            this.Load += new System.EventHandler(this.ModelNumberForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button cmdCancel;
        internal System.Windows.Forms.Button cmdAccept;

        internal System.Windows.Forms.Label Label6;
        public System.Windows.Forms.ComboBox cboBrandName;
        internal System.Windows.Forms.Label Label4;
        public System.Windows.Forms.ComboBox cboColorName;
        internal System.Windows.Forms.Label Label3;
        public System.Windows.Forms.ComboBox cboPatternName;
        internal System.Windows.Forms.Label Label2;
        public System.Windows.Forms.ComboBox cboProductName;
        internal System.Windows.Forms.Label Label1;
        public System.Windows.Forms.ComboBox cboSize;
    }
}