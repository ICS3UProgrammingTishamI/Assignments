namespace FallingObjectTishamI
{
    partial class frmFallingObjects
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
            this.txtTimeInput = new System.Windows.Forms.TextBox();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.lblCalculations = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.mnuFallingObjects = new System.Windows.Forms.MenuStrip();
            this.mniFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mniExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mniGravity = new System.Windows.Forms.ToolStripMenuItem();
            this.mniEarthGravity = new System.Windows.Forms.ToolStripMenuItem();
            this.mniMoonGravity = new System.Windows.Forms.ToolStripMenuItem();
            this.mniSunGravity = new System.Windows.Forms.ToolStripMenuItem();
            this.mniInitialHeight = new System.Windows.Forms.ToolStripMenuItem();
            this.mni100Height = new System.Windows.Forms.ToolStripMenuItem();
            this.mni1000Height = new System.Windows.Forms.ToolStripMenuItem();
            this.mni10000Height = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.mnuFallingObjects.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTimeInput
            // 
            this.txtTimeInput.Font = new System.Drawing.Font("Segoe Script", 36F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimeInput.Location = new System.Drawing.Point(94, 140);
            this.txtTimeInput.Name = "txtTimeInput";
            this.txtTimeInput.Size = new System.Drawing.Size(343, 84);
            this.txtTimeInput.TabIndex = 0;
            this.txtTimeInput.Text = "0";
            this.txtTimeInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTimeInput_KeyPress);
            // 
            // btnCalculate
            // 
            this.btnCalculate.Font = new System.Drawing.Font("Stencil Std", 71.99999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalculate.Location = new System.Drawing.Point(621, 113);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(761, 140);
            this.btnCalculate.TabIndex = 1;
            this.btnCalculate.Text = "Calculate!";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // lblCalculations
            // 
            this.lblCalculations.AutoSize = true;
            this.lblCalculations.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCalculations.Location = new System.Drawing.Point(25, 272);
            this.lblCalculations.Name = "lblCalculations";
            this.lblCalculations.Size = new System.Drawing.Size(440, 25);
            this.lblCalculations.TabIndex = 2;
            this.lblCalculations.Text = "The rock is currently 100m above the ground";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FallingObjectTishamI.Properties.Resources.FallingObject;
            this.pictureBox1.Location = new System.Drawing.Point(45, 326);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(366, 408);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(49, 83);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(564, 25);
            this.lblDescription.TabIndex = 4;
            this.lblDescription.Text = "Input the time elapsed after the rock has fallen in this box.";
            // 
            // mnuFallingObjects
            // 
            this.mnuFallingObjects.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniFile,
            this.mniGravity,
            this.mniInitialHeight});
            this.mnuFallingObjects.Location = new System.Drawing.Point(0, 0);
            this.mnuFallingObjects.Name = "mnuFallingObjects";
            this.mnuFallingObjects.Size = new System.Drawing.Size(1447, 24);
            this.mnuFallingObjects.TabIndex = 5;
            // 
            // mniFile
            // 
            this.mniFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniExit});
            this.mniFile.Name = "mniFile";
            this.mniFile.Size = new System.Drawing.Size(37, 20);
            this.mniFile.Text = "File";
            // 
            // mniExit
            // 
            this.mniExit.Name = "mniExit";
            this.mniExit.Size = new System.Drawing.Size(92, 22);
            this.mniExit.Text = "Exit";
            this.mniExit.Click += new System.EventHandler(this.mniExit_Click);
            // 
            // mniGravity
            // 
            this.mniGravity.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniEarthGravity,
            this.mniMoonGravity,
            this.mniSunGravity});
            this.mniGravity.Name = "mniGravity";
            this.mniGravity.Size = new System.Drawing.Size(56, 20);
            this.mniGravity.Text = "Gravity";
            // 
            // mniEarthGravity
            // 
            this.mniEarthGravity.Name = "mniEarthGravity";
            this.mniEarthGravity.Size = new System.Drawing.Size(106, 22);
            this.mniEarthGravity.Text = "Earth";
            this.mniEarthGravity.Click += new System.EventHandler(this.mniEarthGravity_Click);
            // 
            // mniMoonGravity
            // 
            this.mniMoonGravity.Name = "mniMoonGravity";
            this.mniMoonGravity.Size = new System.Drawing.Size(106, 22);
            this.mniMoonGravity.Text = "Moon";
            this.mniMoonGravity.Click += new System.EventHandler(this.mniMoonGravity_Click);
            // 
            // mniSunGravity
            // 
            this.mniSunGravity.Name = "mniSunGravity";
            this.mniSunGravity.Size = new System.Drawing.Size(106, 22);
            this.mniSunGravity.Text = "Sun";
            this.mniSunGravity.Click += new System.EventHandler(this.mniSunGravity_Click);
            // 
            // mniInitialHeight
            // 
            this.mniInitialHeight.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mni100Height,
            this.mni1000Height,
            this.mni10000Height});
            this.mniInitialHeight.Name = "mniInitialHeight";
            this.mniInitialHeight.Size = new System.Drawing.Size(87, 20);
            this.mniInitialHeight.Text = "Initial Height";
            // 
            // mni100Height
            // 
            this.mni100Height.Name = "mni100Height";
            this.mni100Height.Size = new System.Drawing.Size(104, 22);
            this.mni100Height.Text = "100";
            this.mni100Height.Click += new System.EventHandler(this.mni100Height_Click);
            // 
            // mni1000Height
            // 
            this.mni1000Height.Name = "mni1000Height";
            this.mni1000Height.Size = new System.Drawing.Size(104, 22);
            this.mni1000Height.Text = "1000";
            this.mni1000Height.Click += new System.EventHandler(this.mni1000Height_Click);
            // 
            // mni10000Height
            // 
            this.mni10000Height.Name = "mni10000Height";
            this.mni10000Height.Size = new System.Drawing.Size(104, 22);
            this.mni10000Height.Text = "10000";
            this.mni10000Height.Click += new System.EventHandler(this.mni10000Height_Click);
            // 
            // frmFallingObjects
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1447, 749);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblCalculations);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.txtTimeInput);
            this.Controls.Add(this.mnuFallingObjects);
            this.MainMenuStrip = this.mnuFallingObjects;
            this.Name = "frmFallingObjects";
            this.Text = "Falling Objects by Tisham Islam";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.mnuFallingObjects.ResumeLayout(false);
            this.mnuFallingObjects.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTimeInput;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Label lblCalculations;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.MenuStrip mnuFallingObjects;
        private System.Windows.Forms.ToolStripMenuItem mniFile;
        private System.Windows.Forms.ToolStripMenuItem mniExit;
        private System.Windows.Forms.ToolStripMenuItem mniGravity;
        private System.Windows.Forms.ToolStripMenuItem mniEarthGravity;
        private System.Windows.Forms.ToolStripMenuItem mniMoonGravity;
        private System.Windows.Forms.ToolStripMenuItem mniSunGravity;
        private System.Windows.Forms.ToolStripMenuItem mniInitialHeight;
        private System.Windows.Forms.ToolStripMenuItem mni100Height;
        private System.Windows.Forms.ToolStripMenuItem mni1000Height;
        private System.Windows.Forms.ToolStripMenuItem mni10000Height;
    }
}

