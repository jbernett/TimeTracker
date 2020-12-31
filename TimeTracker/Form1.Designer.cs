
namespace TimeTracker
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
            this.btnGo = new System.Windows.Forms.Button();
            this.lblhours = new System.Windows.Forms.Label();
            this.txtStroyNumber = new System.Windows.Forms.TextBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblMintutes = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblSeconds = new System.Windows.Forms.Label();
            this.btnAddTime = new System.Windows.Forms.Button();
            this.btnMinus = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGo
            // 
            this.btnGo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnGo.BackgroundImage = global::TimeTracker.Properties.Resources.go;
            this.btnGo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnGo.Location = new System.Drawing.Point(163, 157);
            this.btnGo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(104, 90);
            this.btnGo.TabIndex = 0;
            this.btnGo.TabStop = false;
            this.btnGo.UseVisualStyleBackColor = false;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // lblhours
            // 
            this.lblhours.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblhours.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblhours.Location = new System.Drawing.Point(22, 329);
            this.lblhours.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblhours.Name = "lblhours";
            this.lblhours.Size = new System.Drawing.Size(175, 112);
            this.lblhours.TabIndex = 1;
            this.lblhours.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtStroyNumber
            // 
            this.txtStroyNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStroyNumber.Location = new System.Drawing.Point(208, 86);
            this.txtStroyNumber.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtStroyNumber.Name = "txtStroyNumber";
            this.txtStroyNumber.Size = new System.Drawing.Size(166, 56);
            this.txtStroyNumber.TabIndex = 2;
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.Red;
            this.btnStop.BackgroundImage = global::TimeTracker.Properties.Resources.stop;
            this.btnStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnStop.Location = new System.Drawing.Point(324, 157);
            this.btnStop.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(104, 90);
            this.btnStop.TabIndex = 3;
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(161, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(268, 36);
            this.label1.TabIndex = 4;
            this.label1.Text = "Stroy/Bug Number";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(50, 271);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 36);
            this.label2.TabIndex = 5;
            this.label2.Text = "Hours";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(230, 271);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 36);
            this.label3.TabIndex = 7;
            this.label3.Text = "Minutes";
            // 
            // lblMintutes
            // 
            this.lblMintutes.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblMintutes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMintutes.Location = new System.Drawing.Point(218, 329);
            this.lblMintutes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMintutes.Name = "lblMintutes";
            this.lblMintutes.Size = new System.Drawing.Size(175, 112);
            this.lblMintutes.TabIndex = 6;
            this.lblMintutes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.Location = new System.Drawing.Point(420, 271);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 36);
            this.label5.TabIndex = 9;
            this.label5.Text = "Seconds";
            // 
            // lblSeconds
            // 
            this.lblSeconds.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblSeconds.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSeconds.Location = new System.Drawing.Point(410, 329);
            this.lblSeconds.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSeconds.Name = "lblSeconds";
            this.lblSeconds.Size = new System.Drawing.Size(175, 112);
            this.lblSeconds.TabIndex = 8;
            this.lblSeconds.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAddTime
            // 
            this.btnAddTime.Location = new System.Drawing.Point(198, 469);
            this.btnAddTime.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddTime.Name = "btnAddTime";
            this.btnAddTime.Size = new System.Drawing.Size(104, 59);
            this.btnAddTime.TabIndex = 10;
            this.btnAddTime.Text = "+30";
            this.btnAddTime.UseVisualStyleBackColor = true;
            this.btnAddTime.Click += new System.EventHandler(this.btnAddTime_Click);
            // 
            // btnMinus
            // 
            this.btnMinus.Location = new System.Drawing.Point(310, 469);
            this.btnMinus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnMinus.Name = "btnMinus";
            this.btnMinus.Size = new System.Drawing.Size(104, 59);
            this.btnMinus.TabIndex = 11;
            this.btnMinus.Text = "-30";
            this.btnMinus.UseVisualStyleBackColor = true;
            this.btnMinus.Click += new System.EventHandler(this.btnMinus_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(18F, 36F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(605, 595);
            this.Controls.Add(this.btnMinus);
            this.Controls.Add(this.btnAddTime);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblSeconds);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblMintutes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.txtStroyNumber);
            this.Controls.Add(this.lblhours);
            this.Controls.Add(this.btnGo);
            this.Font = new System.Drawing.Font("Poor Richard", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Label lblhours;
        private System.Windows.Forms.TextBox txtStroyNumber;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblMintutes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblSeconds;
        private System.Windows.Forms.Button btnAddTime;
        private System.Windows.Forms.Button btnMinus;
    }
}

