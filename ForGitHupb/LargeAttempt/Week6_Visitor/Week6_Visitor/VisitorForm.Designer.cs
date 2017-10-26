namespace Week6_Visitor
{
    partial class VisitorForm
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
            this.rbMessages = new System.Windows.Forms.RichTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.rbDutch = new System.Windows.Forms.RadioButton();
            this.rbBulgarian = new System.Windows.Forms.RadioButton();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.picHamburger = new System.Windows.Forms.PictureBox();
            this.picTobacco = new System.Windows.Forms.PictureBox();
            this.picLiqour = new System.Windows.Forms.PictureBox();
            this.lbBurger = new System.Windows.Forms.Label();
            this.lbLiquor = new System.Windows.Forms.Label();
            this.lbTobacco = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHamburger)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTobacco)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLiqour)).BeginInit();
            this.SuspendLayout();
            // 
            // rbMessages
            // 
            this.rbMessages.Location = new System.Drawing.Point(336, 12);
            this.rbMessages.Name = "rbMessages";
            this.rbMessages.Size = new System.Drawing.Size(348, 252);
            this.rbMessages.TabIndex = 0;
            this.rbMessages.Text = "";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = global::Week6_Visitor.Properties.Resources.dutch_flag;
            this.pictureBox1.InitialImage = global::Week6_Visitor.Properties.Resources.dutch_flag;
            this.pictureBox1.Location = new System.Drawing.Point(13, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(37, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // rbDutch
            // 
            this.rbDutch.AutoSize = true;
            this.rbDutch.Location = new System.Drawing.Point(55, 22);
            this.rbDutch.Name = "rbDutch";
            this.rbDutch.Size = new System.Drawing.Size(82, 17);
            this.rbDutch.TabIndex = 2;
            this.rbDutch.Text = "Dutch Shop";
            this.rbDutch.UseVisualStyleBackColor = true;
            this.rbDutch.MouseClick += new System.Windows.Forms.MouseEventHandler(this.rbDutch_MouseClick);
            // 
            // rbBulgarian
            // 
            this.rbBulgarian.AutoSize = true;
            this.rbBulgarian.Location = new System.Drawing.Point(193, 22);
            this.rbBulgarian.Name = "rbBulgarian";
            this.rbBulgarian.Size = new System.Drawing.Size(97, 17);
            this.rbBulgarian.TabIndex = 4;
            this.rbBulgarian.Text = "Bulgarian Shop";
            this.rbBulgarian.UseVisualStyleBackColor = true;
            this.rbBulgarian.MouseClick += new System.Windows.Forms.MouseEventHandler(this.rbBulgarian_MouseClick);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Image = global::Week6_Visitor.Properties.Resources.Bulgaria_Flag;
            this.pictureBox2.InitialImage = global::Week6_Visitor.Properties.Resources.dutch_flag;
            this.pictureBox2.Location = new System.Drawing.Point(293, 14);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(37, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // picHamburger
            // 
            this.picHamburger.Image = global::Week6_Visitor.Properties.Resources.hamburger;
            this.picHamburger.Location = new System.Drawing.Point(13, 100);
            this.picHamburger.Name = "picHamburger";
            this.picHamburger.Size = new System.Drawing.Size(85, 75);
            this.picHamburger.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picHamburger.TabIndex = 5;
            this.picHamburger.TabStop = false;
            this.picHamburger.Click += new System.EventHandler(this.picHamburger_Click);
            // 
            // picTobacco
            // 
            this.picTobacco.Image = global::Week6_Visitor.Properties.Resources.tobacco;
            this.picTobacco.Location = new System.Drawing.Point(245, 100);
            this.picTobacco.Name = "picTobacco";
            this.picTobacco.Size = new System.Drawing.Size(85, 75);
            this.picTobacco.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picTobacco.TabIndex = 6;
            this.picTobacco.TabStop = false;
            this.picTobacco.Click += new System.EventHandler(this.picTobacco_Click);
            // 
            // picLiqour
            // 
            this.picLiqour.Image = global::Week6_Visitor.Properties.Resources.liqour;
            this.picLiqour.Location = new System.Drawing.Point(129, 100);
            this.picLiqour.Name = "picLiqour";
            this.picLiqour.Size = new System.Drawing.Size(85, 75);
            this.picLiqour.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLiqour.TabIndex = 7;
            this.picLiqour.TabStop = false;
            this.picLiqour.Click += new System.EventHandler(this.picLiqour_Click);
            // 
            // lbBurger
            // 
            this.lbBurger.AutoSize = true;
            this.lbBurger.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBurger.Location = new System.Drawing.Point(10, 182);
            this.lbBurger.Name = "lbBurger";
            this.lbBurger.Size = new System.Drawing.Size(85, 48);
            this.lbBurger.TabIndex = 8;
            this.lbBurger.Text = "Buy\r\nHamburger\r\nBase: $";
            // 
            // lbLiquor
            // 
            this.lbLiquor.AutoSize = true;
            this.lbLiquor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLiquor.Location = new System.Drawing.Point(126, 182);
            this.lbLiquor.Name = "lbLiquor";
            this.lbLiquor.Size = new System.Drawing.Size(60, 48);
            this.lbLiquor.TabIndex = 9;
            this.lbLiquor.Text = "Buy\r\nLiquor\r\nBase: $";
            // 
            // lbTobacco
            // 
            this.lbTobacco.AutoSize = true;
            this.lbTobacco.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTobacco.Location = new System.Drawing.Point(242, 182);
            this.lbTobacco.Name = "lbTobacco";
            this.lbTobacco.Size = new System.Drawing.Size(70, 48);
            this.lbTobacco.TabIndex = 10;
            this.lbTobacco.Text = "Buy\r\nTobacco\r\nBase: $";
            // 
            // VisitorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 287);
            this.Controls.Add(this.lbTobacco);
            this.Controls.Add(this.lbLiquor);
            this.Controls.Add(this.lbBurger);
            this.Controls.Add(this.picLiqour);
            this.Controls.Add(this.picTobacco);
            this.Controls.Add(this.picHamburger);
            this.Controls.Add(this.rbBulgarian);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.rbDutch);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.rbMessages);
            this.Name = "VisitorForm";
            this.Text = "Visitor";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHamburger)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTobacco)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLiqour)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rbMessages;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RadioButton rbDutch;
        private System.Windows.Forms.RadioButton rbBulgarian;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox picHamburger;
        private System.Windows.Forms.PictureBox picTobacco;
        private System.Windows.Forms.PictureBox picLiqour;
        private System.Windows.Forms.Label lbBurger;
        private System.Windows.Forms.Label lbLiquor;
        private System.Windows.Forms.Label lbTobacco;
    }
}

