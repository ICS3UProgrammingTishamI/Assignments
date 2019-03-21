namespace PizzaOrderTishamI
{
    partial class frmPizzaOrder
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
            this.grbPizzaSize = new System.Windows.Forms.GroupBox();
            this.radExtraLarge = new System.Windows.Forms.RadioButton();
            this.radLarge = new System.Windows.Forms.RadioButton();
            this.radMedium = new System.Windows.Forms.RadioButton();
            this.lblPizzaSize = new System.Windows.Forms.Label();
            this.nudToppings = new System.Windows.Forms.NumericUpDown();
            this.lblToppings = new System.Windows.Forms.Label();
            this.lblFries = new System.Windows.Forms.Label();
            this.lblDrinks = new System.Windows.Forms.Label();
            this.nudFries = new System.Windows.Forms.NumericUpDown();
            this.nudDrinks = new System.Windows.Forms.NumericUpDown();
            this.lblGetDrinks = new System.Windows.Forms.Label();
            this.lblGetFries = new System.Windows.Forms.Label();
            this.lblGetToppings = new System.Windows.Forms.Label();
            this.btnOrder = new System.Windows.Forms.Button();
            this.lstOrder = new System.Windows.Forms.ListBox();
            this.btnRedo = new System.Windows.Forms.Button();
            this.grbPizzaSize.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudToppings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFries)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDrinks)).BeginInit();
            this.SuspendLayout();
            // 
            // grbPizzaSize
            // 
            this.grbPizzaSize.Controls.Add(this.radExtraLarge);
            this.grbPizzaSize.Controls.Add(this.radLarge);
            this.grbPizzaSize.Controls.Add(this.radMedium);
            this.grbPizzaSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbPizzaSize.Location = new System.Drawing.Point(22, 27);
            this.grbPizzaSize.Name = "grbPizzaSize";
            this.grbPizzaSize.Size = new System.Drawing.Size(334, 66);
            this.grbPizzaSize.TabIndex = 0;
            this.grbPizzaSize.TabStop = false;
            this.grbPizzaSize.Text = "Pizza Size";
            // 
            // radExtraLarge
            // 
            this.radExtraLarge.AutoSize = true;
            this.radExtraLarge.Location = new System.Drawing.Point(202, 29);
            this.radExtraLarge.Name = "radExtraLarge";
            this.radExtraLarge.Size = new System.Drawing.Size(109, 24);
            this.radExtraLarge.TabIndex = 2;
            this.radExtraLarge.TabStop = true;
            this.radExtraLarge.Text = "Extra Large";
            this.radExtraLarge.UseVisualStyleBackColor = true;
            this.radExtraLarge.CheckedChanged += new System.EventHandler(this.radExtraLarge_CheckedChanged);
            // 
            // radLarge
            // 
            this.radLarge.AutoSize = true;
            this.radLarge.Location = new System.Drawing.Point(112, 29);
            this.radLarge.Name = "radLarge";
            this.radLarge.Size = new System.Drawing.Size(68, 24);
            this.radLarge.TabIndex = 1;
            this.radLarge.TabStop = true;
            this.radLarge.Text = "Large";
            this.radLarge.UseVisualStyleBackColor = true;
            this.radLarge.CheckedChanged += new System.EventHandler(this.radLarge_CheckedChanged);
            // 
            // radMedium
            // 
            this.radMedium.AutoSize = true;
            this.radMedium.Location = new System.Drawing.Point(7, 29);
            this.radMedium.Name = "radMedium";
            this.radMedium.Size = new System.Drawing.Size(83, 24);
            this.radMedium.TabIndex = 0;
            this.radMedium.TabStop = true;
            this.radMedium.Text = "Medium";
            this.radMedium.UseVisualStyleBackColor = true;
            this.radMedium.CheckedChanged += new System.EventHandler(this.radMedium_CheckedChanged);
            // 
            // lblPizzaSize
            // 
            this.lblPizzaSize.AutoSize = true;
            this.lblPizzaSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPizzaSize.Location = new System.Drawing.Point(389, 54);
            this.lblPizzaSize.Name = "lblPizzaSize";
            this.lblPizzaSize.Size = new System.Drawing.Size(261, 20);
            this.lblPizzaSize.TabIndex = 1;
            this.lblPizzaSize.Text = "Here is the cost for your pizza\'s size";
            // 
            // nudToppings
            // 
            this.nudToppings.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudToppings.Location = new System.Drawing.Point(43, 171);
            this.nudToppings.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nudToppings.Name = "nudToppings";
            this.nudToppings.Size = new System.Drawing.Size(120, 26);
            this.nudToppings.TabIndex = 2;
            this.nudToppings.ValueChanged += new System.EventHandler(this.nudToppings_ValueChanged);
            // 
            // lblToppings
            // 
            this.lblToppings.AutoSize = true;
            this.lblToppings.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToppings.Location = new System.Drawing.Point(183, 173);
            this.lblToppings.Name = "lblToppings";
            this.lblToppings.Size = new System.Drawing.Size(242, 20);
            this.lblToppings.TabIndex = 3;
            this.lblToppings.Text = "Here is the cost for your toppings";
            // 
            // lblFries
            // 
            this.lblFries.AutoSize = true;
            this.lblFries.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFries.Location = new System.Drawing.Point(204, 269);
            this.lblFries.Name = "lblFries";
            this.lblFries.Size = new System.Drawing.Size(211, 20);
            this.lblFries.TabIndex = 4;
            this.lblFries.Text = "Here is the cost for your fries";
            // 
            // lblDrinks
            // 
            this.lblDrinks.AutoSize = true;
            this.lblDrinks.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDrinks.Location = new System.Drawing.Point(204, 368);
            this.lblDrinks.Name = "lblDrinks";
            this.lblDrinks.Size = new System.Drawing.Size(223, 20);
            this.lblDrinks.TabIndex = 5;
            this.lblDrinks.Text = "Here is the cost for your drinks";
            // 
            // nudFries
            // 
            this.nudFries.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudFries.Location = new System.Drawing.Point(43, 261);
            this.nudFries.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudFries.Name = "nudFries";
            this.nudFries.Size = new System.Drawing.Size(120, 26);
            this.nudFries.TabIndex = 6;
            this.nudFries.ValueChanged += new System.EventHandler(this.nudFries_ValueChanged);
            // 
            // nudDrinks
            // 
            this.nudDrinks.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudDrinks.Location = new System.Drawing.Point(43, 366);
            this.nudDrinks.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudDrinks.Name = "nudDrinks";
            this.nudDrinks.Size = new System.Drawing.Size(120, 26);
            this.nudDrinks.TabIndex = 7;
            this.nudDrinks.ValueChanged += new System.EventHandler(this.nudDrinks_ValueChanged);
            // 
            // lblGetDrinks
            // 
            this.lblGetDrinks.AutoSize = true;
            this.lblGetDrinks.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGetDrinks.Location = new System.Drawing.Point(19, 334);
            this.lblGetDrinks.Name = "lblGetDrinks";
            this.lblGetDrinks.Size = new System.Drawing.Size(273, 20);
            this.lblGetDrinks.TabIndex = 8;
            this.lblGetDrinks.Text = "Get some drinks to quench your thirst";
            // 
            // lblGetFries
            // 
            this.lblGetFries.AutoSize = true;
            this.lblGetFries.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGetFries.Location = new System.Drawing.Point(19, 227);
            this.lblGetFries.Name = "lblGetFries";
            this.lblGetFries.Size = new System.Drawing.Size(288, 20);
            this.lblGetFries.TabIndex = 9;
            this.lblGetFries.Text = "Get some fries for a delicious side order";
            // 
            // lblGetToppings
            // 
            this.lblGetToppings.AutoSize = true;
            this.lblGetToppings.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGetToppings.Location = new System.Drawing.Point(19, 135);
            this.lblGetToppings.Name = "lblGetToppings";
            this.lblGetToppings.Size = new System.Drawing.Size(433, 20);
            this.lblGetToppings.TabIndex = 10;
            this.lblGetToppings.Text = "Top your pizza with an arrangement of scrumptious toppings";
            // 
            // btnOrder
            // 
            this.btnOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrder.Location = new System.Drawing.Point(930, 366);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(130, 58);
            this.btnOrder.TabIndex = 11;
            this.btnOrder.Text = "ORDER";
            this.btnOrder.UseVisualStyleBackColor = true;
            // 
            // lstOrder
            // 
            this.lstOrder.FormattingEnabled = true;
            this.lstOrder.Location = new System.Drawing.Point(930, 70);
            this.lstOrder.Name = "lstOrder";
            this.lstOrder.Size = new System.Drawing.Size(314, 277);
            this.lstOrder.TabIndex = 12;
            // 
            // btnRedo
            // 
            this.btnRedo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRedo.Location = new System.Drawing.Point(1113, 368);
            this.btnRedo.Name = "btnRedo";
            this.btnRedo.Size = new System.Drawing.Size(131, 56);
            this.btnRedo.TabIndex = 13;
            this.btnRedo.Text = "REDO";
            this.btnRedo.UseVisualStyleBackColor = true;
            this.btnRedo.Click += new System.EventHandler(this.btnRedo_Click);
            // 
            // frmPizzaOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1473, 769);
            this.Controls.Add(this.btnRedo);
            this.Controls.Add(this.lstOrder);
            this.Controls.Add(this.btnOrder);
            this.Controls.Add(this.lblGetToppings);
            this.Controls.Add(this.lblGetFries);
            this.Controls.Add(this.lblGetDrinks);
            this.Controls.Add(this.nudDrinks);
            this.Controls.Add(this.nudFries);
            this.Controls.Add(this.lblDrinks);
            this.Controls.Add(this.lblFries);
            this.Controls.Add(this.lblToppings);
            this.Controls.Add(this.nudToppings);
            this.Controls.Add(this.lblPizzaSize);
            this.Controls.Add(this.grbPizzaSize);
            this.Name = "frmPizzaOrder";
            this.Text = "Pizza Order by Tisham Islam";
            this.grbPizzaSize.ResumeLayout(false);
            this.grbPizzaSize.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudToppings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFries)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDrinks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grbPizzaSize;
        private System.Windows.Forms.Label lblPizzaSize;
        private System.Windows.Forms.NumericUpDown nudToppings;
        private System.Windows.Forms.Label lblToppings;
        private System.Windows.Forms.Label lblFries;
        private System.Windows.Forms.Label lblDrinks;
        private System.Windows.Forms.NumericUpDown nudFries;
        private System.Windows.Forms.NumericUpDown nudDrinks;
        private System.Windows.Forms.Label lblGetDrinks;
        private System.Windows.Forms.RadioButton radLarge;
        private System.Windows.Forms.RadioButton radMedium;
        private System.Windows.Forms.Label lblGetFries;
        private System.Windows.Forms.Label lblGetToppings;
        private System.Windows.Forms.RadioButton radExtraLarge;
        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.ListBox lstOrder;
        private System.Windows.Forms.Button btnRedo;
    }
}

