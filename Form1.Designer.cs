namespace laife_arayuz_alternatif
{
    partial class mainwindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainwindow));
            this.sidebar = new System.Windows.Forms.Panel();
            this.btn_credits = new System.Windows.Forms.Button();
            this.btn_ayarlar = new System.Windows.Forms.Button();
            this.btn_newChat = new System.Windows.Forms.Button();
            this.pb_logo = new System.Windows.Forms.PictureBox();
            this.lbl_desc = new System.Windows.Forms.Label();
            this.btn_gonder = new System.Windows.Forms.Button();
            this.chat_panel = new System.Windows.Forms.Panel();
            this.panel_settings = new System.Windows.Forms.Panel();
            this.chat_ekran = new System.Windows.Forms.RichTextBox();
            this.text_mesaj = new System.Windows.Forms.RichTextBox();
            this.gb_gorunum = new System.Windows.Forms.GroupBox();
            this.cb_tema = new System.Windows.Forms.CheckBox();
            this.panel_credits = new System.Windows.Forms.Panel();
            this.gb_yapimcilar = new System.Windows.Forms.GroupBox();
            this.lbl_ardaeren = new System.Windows.Forms.Label();
            this.lbl_ea = new System.Windows.Forms.Label();
            this.lbl_fe = new System.Windows.Forms.Label();
            this.lbl_mbb = new System.Windows.Forms.Label();
            this.sidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_logo)).BeginInit();
            this.chat_panel.SuspendLayout();
            this.panel_settings.SuspendLayout();
            this.gb_gorunum.SuspendLayout();
            this.panel_credits.SuspendLayout();
            this.gb_yapimcilar.SuspendLayout();
            this.SuspendLayout();
            // 
            // sidebar
            // 
            this.sidebar.AutoSize = true;
            this.sidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(35)))));
            this.sidebar.Controls.Add(this.btn_credits);
            this.sidebar.Controls.Add(this.btn_ayarlar);
            this.sidebar.Controls.Add(this.btn_newChat);
            this.sidebar.Controls.Add(this.pb_logo);
            this.sidebar.Location = new System.Drawing.Point(0, -1);
            this.sidebar.Name = "sidebar";
            this.sidebar.Size = new System.Drawing.Size(212, 700);
            this.sidebar.TabIndex = 0;
            // 
            // btn_credits
            // 
            this.btn_credits.BackColor = System.Drawing.Color.Transparent;
            this.btn_credits.FlatAppearance.BorderSize = 0;
            this.btn_credits.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_credits.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_credits.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btn_credits.Location = new System.Drawing.Point(12, 566);
            this.btn_credits.Name = "btn_credits";
            this.btn_credits.Size = new System.Drawing.Size(185, 47);
            this.btn_credits.TabIndex = 3;
            this.btn_credits.Text = "Hakkında";
            this.btn_credits.UseVisualStyleBackColor = false;
            this.btn_credits.Click += new System.EventHandler(this.btn_credits_Click);
            this.btn_credits.MouseLeave += new System.EventHandler(this.btn_credits_MouseLeave);
            this.btn_credits.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btn_credits_MouseMove);
            // 
            // btn_ayarlar
            // 
            this.btn_ayarlar.BackColor = System.Drawing.Color.Transparent;
            this.btn_ayarlar.FlatAppearance.BorderSize = 0;
            this.btn_ayarlar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ayarlar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_ayarlar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btn_ayarlar.Location = new System.Drawing.Point(12, 504);
            this.btn_ayarlar.Name = "btn_ayarlar";
            this.btn_ayarlar.Size = new System.Drawing.Size(185, 47);
            this.btn_ayarlar.TabIndex = 2;
            this.btn_ayarlar.Text = "Ayarlar";
            this.btn_ayarlar.UseVisualStyleBackColor = false;
            this.btn_ayarlar.Click += new System.EventHandler(this.btn_ayarlar_Click);
            this.btn_ayarlar.MouseLeave += new System.EventHandler(this.btn_ayarlar_MouseLeave);
            this.btn_ayarlar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btn_ayarlar_MouseMove);
            // 
            // btn_newChat
            // 
            this.btn_newChat.BackColor = System.Drawing.Color.Transparent;
            this.btn_newChat.FlatAppearance.BorderSize = 0;
            this.btn_newChat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_newChat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_newChat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btn_newChat.Location = new System.Drawing.Point(12, 265);
            this.btn_newChat.Name = "btn_newChat";
            this.btn_newChat.Size = new System.Drawing.Size(185, 47);
            this.btn_newChat.TabIndex = 1;
            this.btn_newChat.Text = "Yeni Sohbet";
            this.btn_newChat.UseVisualStyleBackColor = false;
            this.btn_newChat.Click += new System.EventHandler(this.btn_newChat_Click);
            this.btn_newChat.MouseLeave += new System.EventHandler(this.btn_newChat_MouseLeave);
            this.btn_newChat.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btn_newChat_MouseMove);
            // 
            // pb_logo
            // 
            this.pb_logo.Image = ((System.Drawing.Image)(resources.GetObject("pb_logo.Image")));
            this.pb_logo.Location = new System.Drawing.Point(12, 12);
            this.pb_logo.Name = "pb_logo";
            this.pb_logo.Size = new System.Drawing.Size(185, 180);
            this.pb_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_logo.TabIndex = 0;
            this.pb_logo.TabStop = false;
            // 
            // lbl_desc
            // 
            this.lbl_desc.AutoSize = true;
            this.lbl_desc.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_desc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.lbl_desc.Location = new System.Drawing.Point(195, 204);
            this.lbl_desc.Name = "lbl_desc";
            this.lbl_desc.Size = new System.Drawing.Size(670, 84);
            this.lbl_desc.TabIndex = 4;
            this.lbl_desc.Text = "Merhaba\r\nBugün ne hakkında konuşmak istersin?";
            this.lbl_desc.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btn_gonder
            // 
            this.btn_gonder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(115)))));
            this.btn_gonder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_gonder.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_gonder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btn_gonder.Location = new System.Drawing.Point(1091, 573);
            this.btn_gonder.Name = "btn_gonder";
            this.btn_gonder.Size = new System.Drawing.Size(185, 68);
            this.btn_gonder.TabIndex = 4;
            this.btn_gonder.Text = "Gönder";
            this.btn_gonder.UseVisualStyleBackColor = false;
            this.btn_gonder.Click += new System.EventHandler(this.btn_gonder_Click);
            // 
            // chat_panel
            // 
            this.chat_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(20)))));
            this.chat_panel.Controls.Add(this.panel_settings);
            this.chat_panel.Controls.Add(this.chat_ekran);
            this.chat_panel.Controls.Add(this.lbl_desc);
            this.chat_panel.Location = new System.Drawing.Point(220, 12);
            this.chat_panel.Name = "chat_panel";
            this.chat_panel.Size = new System.Drawing.Size(1069, 543);
            this.chat_panel.TabIndex = 6;
            // 
            // panel_settings
            // 
            this.panel_settings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(115)))));
            this.panel_settings.Controls.Add(this.gb_gorunum);
            this.panel_settings.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.panel_settings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel_settings.Location = new System.Drawing.Point(0, 385);
            this.panel_settings.Name = "panel_settings";
            this.panel_settings.Size = new System.Drawing.Size(293, 153);
            this.panel_settings.TabIndex = 4;
            this.panel_settings.Visible = false;
            // 
            // chat_ekran
            // 
            this.chat_ekran.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(20)))));
            this.chat_ekran.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chat_ekran.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.chat_ekran.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.chat_ekran.Location = new System.Drawing.Point(0, 2);
            this.chat_ekran.Margin = new System.Windows.Forms.Padding(5);
            this.chat_ekran.Name = "chat_ekran";
            this.chat_ekran.ReadOnly = true;
            this.chat_ekran.Size = new System.Drawing.Size(1056, 536);
            this.chat_ekran.TabIndex = 7;
            this.chat_ekran.Text = "";
            this.chat_ekran.Visible = false;
            // 
            // text_mesaj
            // 
            this.text_mesaj.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(115)))));
            this.text_mesaj.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.text_mesaj.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.text_mesaj.Location = new System.Drawing.Point(220, 573);
            this.text_mesaj.Margin = new System.Windows.Forms.Padding(5);
            this.text_mesaj.Name = "text_mesaj";
            this.text_mesaj.Size = new System.Drawing.Size(865, 66);
            this.text_mesaj.TabIndex = 5;
            this.text_mesaj.Text = "";
            this.text_mesaj.KeyDown += new System.Windows.Forms.KeyEventHandler(this.text_mesaj_KeyDown);
            // 
            // gb_gorunum
            // 
            this.gb_gorunum.Controls.Add(this.cb_tema);
            this.gb_gorunum.Location = new System.Drawing.Point(13, 22);
            this.gb_gorunum.Name = "gb_gorunum";
            this.gb_gorunum.Size = new System.Drawing.Size(263, 100);
            this.gb_gorunum.TabIndex = 0;
            this.gb_gorunum.TabStop = false;
            this.gb_gorunum.Text = "Görünüm";
            // 
            // cb_tema
            // 
            this.cb_tema.AutoSize = true;
            this.cb_tema.Checked = true;
            this.cb_tema.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_tema.Location = new System.Drawing.Point(61, 41);
            this.cb_tema.Name = "cb_tema";
            this.cb_tema.Size = new System.Drawing.Size(145, 29);
            this.cb_tema.TabIndex = 0;
            this.cb_tema.Text = "Koyu Tema";
            this.cb_tema.UseVisualStyleBackColor = true;
            this.cb_tema.CheckedChanged += new System.EventHandler(this.cb_tema_CheckedChanged);
            // 
            // panel_credits
            // 
            this.panel_credits.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(115)))));
            this.panel_credits.Controls.Add(this.gb_yapimcilar);
            this.panel_credits.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.panel_credits.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel_credits.Location = new System.Drawing.Point(220, 205);
            this.panel_credits.Name = "panel_credits";
            this.panel_credits.Size = new System.Drawing.Size(293, 345);
            this.panel_credits.TabIndex = 5;
            this.panel_credits.Visible = false;
            // 
            // gb_yapimcilar
            // 
            this.gb_yapimcilar.Controls.Add(this.lbl_mbb);
            this.gb_yapimcilar.Controls.Add(this.lbl_fe);
            this.gb_yapimcilar.Controls.Add(this.lbl_ea);
            this.gb_yapimcilar.Controls.Add(this.lbl_ardaeren);
            this.gb_yapimcilar.Location = new System.Drawing.Point(13, 19);
            this.gb_yapimcilar.Name = "gb_yapimcilar";
            this.gb_yapimcilar.Size = new System.Drawing.Size(263, 299);
            this.gb_yapimcilar.TabIndex = 0;
            this.gb_yapimcilar.TabStop = false;
            this.gb_yapimcilar.Text = "Yapımcılar";
            // 
            // lbl_ardaeren
            // 
            this.lbl_ardaeren.AutoSize = true;
            this.lbl_ardaeren.Location = new System.Drawing.Point(41, 50);
            this.lbl_ardaeren.Name = "lbl_ardaeren";
            this.lbl_ardaeren.Size = new System.Drawing.Size(171, 25);
            this.lbl_ardaeren.TabIndex = 0;
            this.lbl_ardaeren.Text = "Arda Eren Şahin";
            // 
            // lbl_ea
            // 
            this.lbl_ea.AutoSize = true;
            this.lbl_ea.Location = new System.Drawing.Point(41, 112);
            this.lbl_ea.Name = "lbl_ea";
            this.lbl_ea.Size = new System.Drawing.Size(171, 25);
            this.lbl_ea.TabIndex = 1;
            this.lbl_ea.Text = "Efe Aydın Aksoy";
            // 
            // lbl_fe
            // 
            this.lbl_fe.AutoSize = true;
            this.lbl_fe.Location = new System.Drawing.Point(41, 171);
            this.lbl_fe.Name = "lbl_fe";
            this.lbl_fe.Size = new System.Drawing.Size(165, 25);
            this.lbl_fe.TabIndex = 2;
            this.lbl_fe.Text = "Furkan Erduvan";
            // 
            // lbl_mbb
            // 
            this.lbl_mbb.AutoSize = true;
            this.lbl_mbb.Location = new System.Drawing.Point(41, 229);
            this.lbl_mbb.Name = "lbl_mbb";
            this.lbl_mbb.Size = new System.Drawing.Size(182, 25);
            this.lbl_mbb.TabIndex = 3;
            this.lbl_mbb.Text = "Mustafa Berk Bay";
            // 
            // mainwindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(35)))));
            this.ClientSize = new System.Drawing.Size(1282, 653);
            this.Controls.Add(this.panel_credits);
            this.Controls.Add(this.text_mesaj);
            this.Controls.Add(this.chat_panel);
            this.Controls.Add(this.btn_gonder);
            this.Controls.Add(this.sidebar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1300, 700);
            this.MinimumSize = new System.Drawing.Size(1300, 700);
            this.Name = "mainwindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LAIfe";
            this.Load += new System.EventHandler(this.mainwindow_Load);
            this.sidebar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_logo)).EndInit();
            this.chat_panel.ResumeLayout(false);
            this.chat_panel.PerformLayout();
            this.panel_settings.ResumeLayout(false);
            this.gb_gorunum.ResumeLayout(false);
            this.gb_gorunum.PerformLayout();
            this.panel_credits.ResumeLayout(false);
            this.gb_yapimcilar.ResumeLayout(false);
            this.gb_yapimcilar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel sidebar;
        private System.Windows.Forms.PictureBox pb_logo;
        private System.Windows.Forms.Button btn_newChat;
        private System.Windows.Forms.Label lbl_desc;
        private System.Windows.Forms.Button btn_gonder;
        private System.Windows.Forms.Panel chat_panel;
        private System.Windows.Forms.RichTextBox text_mesaj;
        private System.Windows.Forms.Button btn_credits;
        private System.Windows.Forms.Button btn_ayarlar;
        public System.Windows.Forms.RichTextBox chat_ekran;
        private System.Windows.Forms.Panel panel_settings;
        private System.Windows.Forms.GroupBox gb_gorunum;
        private System.Windows.Forms.CheckBox cb_tema;
        private System.Windows.Forms.Panel panel_credits;
        private System.Windows.Forms.GroupBox gb_yapimcilar;
        private System.Windows.Forms.Label lbl_ardaeren;
        private System.Windows.Forms.Label lbl_mbb;
        private System.Windows.Forms.Label lbl_fe;
        private System.Windows.Forms.Label lbl_ea;
    }
}

