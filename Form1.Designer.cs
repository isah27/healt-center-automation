namespace FACCID
{
    partial class HOME
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HOME));
            this.label1 = new System.Windows.Forms.Label();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.AttendaceBtn = new System.Windows.Forms.Button();
            this.MANAGEMENTBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(575, 66);
            this.label1.TabIndex = 0;
            this.label1.Text = "WELCOME TO OFU LOCAL GOVERNMENT UGWOLAWO COMMUNITY HEALTH CENTRE";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ExitBtn
            // 
            this.ExitBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ExitBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ExitBtn.FlatAppearance.BorderSize = 0;
            this.ExitBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aqua;
            this.ExitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitBtn.Location = new System.Drawing.Point(214, 406);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(165, 39);
            this.ExitBtn.TabIndex = 3;
            this.ExitBtn.Text = "EXIT";
            this.ExitBtn.UseVisualStyleBackColor = true;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // AttendaceBtn
            // 
            this.AttendaceBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AttendaceBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AttendaceBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.AttendaceBtn.FlatAppearance.BorderSize = 0;
            this.AttendaceBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aqua;
            this.AttendaceBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AttendaceBtn.ForeColor = System.Drawing.Color.White;
            this.AttendaceBtn.Image = global::FACCID.Properties.Resources.symbol_of_man_icon_5933_Windows;
            this.AttendaceBtn.Location = new System.Drawing.Point(0, 307);
            this.AttendaceBtn.Name = "AttendaceBtn";
            this.AttendaceBtn.Size = new System.Drawing.Size(144, 138);
            this.AttendaceBtn.TabIndex = 2;
            this.AttendaceBtn.Text = "STAFF\'S";
            this.AttendaceBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.AttendaceBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.AttendaceBtn.UseVisualStyleBackColor = true;
            this.AttendaceBtn.Click += new System.EventHandler(this.AttendaceBtn_Click);
            // 
            // MANAGEMENTBtn
            // 
            this.MANAGEMENTBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.MANAGEMENTBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.MANAGEMENTBtn.FlatAppearance.BorderSize = 0;
            this.MANAGEMENTBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aqua;
            this.MANAGEMENTBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.MANAGEMENTBtn.Image = global::FACCID.Properties.Resources.agent_icon_png_2019_Windows;
            this.MANAGEMENTBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.MANAGEMENTBtn.Location = new System.Drawing.Point(425, 307);
            this.MANAGEMENTBtn.Name = "MANAGEMENTBtn";
            this.MANAGEMENTBtn.Size = new System.Drawing.Size(150, 138);
            this.MANAGEMENTBtn.TabIndex = 1;
            this.MANAGEMENTBtn.Text = "MANAGEMENT";
            this.MANAGEMENTBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.MANAGEMENTBtn.UseVisualStyleBackColor = true;
            this.MANAGEMENTBtn.Click += new System.EventHandler(this.MANAGEMENTBtn_Click);
            // 
            // HOME
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(575, 448);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.AttendaceBtn);
            this.Controls.Add(this.MANAGEMENTBtn);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "HOME";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.HOME_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button MANAGEMENTBtn;
        private System.Windows.Forms.Button AttendaceBtn;
        private System.Windows.Forms.Button ExitBtn;
    }
}

