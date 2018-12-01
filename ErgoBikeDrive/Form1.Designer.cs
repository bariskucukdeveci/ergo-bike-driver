namespace ErgoBikeDrive
{
    partial class myForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(myForm));
            this.lblPower = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtPower = new System.Windows.Forms.TextBox();
            this.lblBikeImg = new System.Windows.Forms.Label();
            this.onOffSwitch = new System.Windows.Forms.Button();
            this.lblPorts = new System.Windows.Forms.Label();
            this.comboPorts = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblPower
            // 
            this.lblPower.AutoSize = true;
            this.lblPower.Font = new System.Drawing.Font("Cambria", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblPower.Location = new System.Drawing.Point(413, 226);
            this.lblPower.Name = "lblPower";
            this.lblPower.Size = new System.Drawing.Size(95, 33);
            this.lblPower.TabIndex = 0;
            this.lblPower.Text = "Power";
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.Color.IndianRed;
            this.btnSend.Enabled = false;
            this.btnSend.Font = new System.Drawing.Font("Impact", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend.ForeColor = System.Drawing.Color.White;
            this.btnSend.Location = new System.Drawing.Point(415, 295);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(234, 59);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "SEND";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtPower
            // 
            this.txtPower.Font = new System.Drawing.Font("Cambria", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtPower.Location = new System.Drawing.Point(521, 218);
            this.txtPower.Name = "txtPower";
            this.txtPower.Size = new System.Drawing.Size(128, 46);
            this.txtPower.TabIndex = 2;
            this.txtPower.TextChanged += new System.EventHandler(this.txtPower_TextChanged);
            // 
            // lblBikeImg
            // 
            this.lblBikeImg.Image = ((System.Drawing.Image)(resources.GetObject("lblBikeImg.Image")));
            this.lblBikeImg.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBikeImg.Location = new System.Drawing.Point(-5, -7);
            this.lblBikeImg.Name = "lblBikeImg";
            this.lblBikeImg.Size = new System.Drawing.Size(747, 466);
            this.lblBikeImg.TabIndex = 3;
            // 
            // onOffSwitch
            // 
            this.onOffSwitch.BackColor = System.Drawing.Color.Lime;
            this.onOffSwitch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.onOffSwitch.Font = new System.Drawing.Font("Cambria", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.onOffSwitch.Location = new System.Drawing.Point(292, 25);
            this.onOffSwitch.Name = "onOffSwitch";
            this.onOffSwitch.Size = new System.Drawing.Size(89, 36);
            this.onOffSwitch.TabIndex = 4;
            this.onOffSwitch.Text = "Start";
            this.onOffSwitch.UseVisualStyleBackColor = false;
            this.onOffSwitch.Click += new System.EventHandler(this.onOffSwitch_Click);
            // 
            // lblPorts
            // 
            this.lblPorts.AutoSize = true;
            this.lblPorts.Font = new System.Drawing.Font("Cambria", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblPorts.Location = new System.Drawing.Point(413, 25);
            this.lblPorts.Name = "lblPorts";
            this.lblPorts.Size = new System.Drawing.Size(83, 33);
            this.lblPorts.TabIndex = 6;
            this.lblPorts.Text = "Ports";
            // 
            // comboPorts
            // 
            this.comboPorts.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.comboPorts.FormattingEnabled = true;
            this.comboPorts.Location = new System.Drawing.Point(521, 27);
            this.comboPorts.Name = "comboPorts";
            this.comboPorts.Size = new System.Drawing.Size(128, 31);
            this.comboPorts.TabIndex = 7;
            this.comboPorts.SelectedIndexChanged += new System.EventHandler(this.comboPorts_SelectedIndexChanged);
            // 
            // myForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(737, 452);
            this.Controls.Add(this.comboPorts);
            this.Controls.Add(this.lblPorts);
            this.Controls.Add(this.onOffSwitch);
            this.Controls.Add(this.txtPower);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.lblPower);
            this.Controls.Add(this.lblBikeImg);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "myForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ergo Bike Driver";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPower;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtPower;
        private System.Windows.Forms.Label lblBikeImg;
        private System.Windows.Forms.Button onOffSwitch;
        private System.Windows.Forms.Label lblPorts;
        private System.Windows.Forms.ComboBox comboPorts;
    }
}

