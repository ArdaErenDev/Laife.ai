using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;

namespace laife_arayuz_alternatif
{
    public partial class mainwindow : Form
    {
        [DllImport("user32.dll")]
        static extern bool HideCaret(IntPtr hWnd);

        private string apiKey => Properties.Settings.Default.GroqApiKey;
        private static readonly string apiUrl = "https://api.groq.com/openai/v1/chat/completions";

        // API key giriş ekranı için panel
        private Panel pnl_keyGiris;

        private List<object> gecmis = new List<object>
        {
            new {
                role = "assistant",
                content = "Selam! Ben LAIfe. Türk yapay zeka geliştiricileri olan Arda Eren Şahin, Furkan Erduvan, Efe Aydın Aksoy ve Mustafa Berk tarafından üretildim. Yapay zeka olabilirim ama bu, sıcak ve eğlenceli olamayacağım anlamına gelmez! Kısa, öz ve samimi konuşurum. Bana her şeyi sorabilirsin, ama sıkıcı teknik cevaplar bekleme. Bazen espri yaparım, bazen ciddi olurum. Yani tıpkı senin gibi bir sohbet arkadaşıyım! Kısa cevaplar veririm lafı uzatmam. Hadi bakalım, ne hakkında konuşmak istersin?"
            }
        };

        public mainwindow()
        {
            InitializeComponent();
            SetupChatScreen();
        }

        private void SetupChatScreen()
        {
            HideCaret(chat_ekran.Handle);
            this.Load += (s, e) => HideCaret(chat_ekran.Handle);
            chat_ekran.Click += (s, e) => HideCaret(chat_ekran.Handle);
            chat_ekran.MouseDown += (s, e) => HideCaret(chat_ekran.Handle);
            chat_ekran.GotFocus += (s, e) => HideCaret(chat_ekran.Handle);
            chat_ekran.TextChanged += (s, e) => HideCaret(chat_ekran.Handle);
        }

        private void mainwindow_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Properties.Settings.Default.GroqApiKey))
            {
                // Her şeyi gizle
                sidebar.Visible = false;
                chat_panel.Visible = false;
                panel_settings.Visible = false;
                panel_credits.Visible = false;
                text_mesaj.Visible = false;
                btn_gonder.Visible = false;
                chat_ekran.Visible = false;

                // Formun üzerine yeni bir panel oluştur
                AnaEkranaKeyPaneliEkle();
            }
            else
            {
                // Key kayıtlı — giriş kontrollerini gizle kral ;)
            }
        }

        private void AnaEkranaKeyPaneliEkle()
        {
            int ortaX = this.ClientSize.Width / 2;
            int ortaY = this.ClientSize.Height / 2;

            // Ana panel
            pnl_keyGiris = new Panel();
            pnl_keyGiris.Size = new Size(360, 160);
            pnl_keyGiris.Location = new Point(ortaX - 180, ortaY - 80);
            pnl_keyGiris.BackColor = Color.FromArgb(20, 20, 60);
            this.Controls.Add(pnl_keyGiris);
            pnl_keyGiris.BringToFront();

            // Başlık
            Label lbl_baslik = new Label();
            lbl_baslik.Text = "Groq API Key'inizi Girin";
            lbl_baslik.ForeColor = Color.White;
            lbl_baslik.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lbl_baslik.AutoSize = true;
            lbl_baslik.Location = new Point(20, 15);
            pnl_keyGiris.Controls.Add(lbl_baslik);

            // TextBox
            TextBox txt_key = new TextBox();
            txt_key.Width = 320;
            txt_key.Height = 30;
            txt_key.Location = new Point(20, 50);
            txt_key.BackColor = Color.FromArgb(42, 42, 115);
            txt_key.ForeColor = Color.White;
            txt_key.Font = new Font("Segoe UI", 10);
            txt_key.BorderStyle = BorderStyle.FixedSingle;
            txt_key.PasswordChar = '*';
            pnl_keyGiris.Controls.Add(txt_key);

            // Kaydet butonu
            Button btn_key_kaydet = new Button();
            btn_key_kaydet.Text = "Kaydet ve Başla";
            btn_key_kaydet.Size = new Size(130, 32);
            btn_key_kaydet.Location = new Point(20, 90);
            btn_key_kaydet.BackColor = Color.FromArgb(80, 120, 180);
            btn_key_kaydet.ForeColor = Color.White;
            btn_key_kaydet.FlatStyle = FlatStyle.Flat;
            btn_key_kaydet.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            btn_key_kaydet.Cursor = Cursors.Hand;
            pnl_keyGiris.Controls.Add(btn_key_kaydet);

            // Bilgi notu
            Label lbl_not = new Label();
            lbl_not.Text = "console.groq.com adresinden ücretsiz alabilirsiniz.";
            lbl_not.ForeColor = Color.Gray;
            lbl_not.AutoSize = true;
            lbl_not.Location = new Point(20, 132);
            lbl_not.Font = new Font("Segoe UI", 8);
            pnl_keyGiris.Controls.Add(lbl_not);

            // Enter ile de kaydet
            txt_key.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    btn_key_kaydet.PerformClick();
                }
            };

            // Kaydet butonuna tıklanınca
            btn_key_kaydet.Click += (s, e) =>
            {
                string key = txt_key.Text.Trim();
                if (string.IsNullOrEmpty(key))
                {
                    MessageBox.Show("Lütfen bir API key girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Properties.Settings.Default.GroqApiKey = key;
                Properties.Settings.Default.Save();

                // Giriş panelini kaldır, chat'i aç
                pnl_keyGiris.Visible = false;
                this.Controls.Remove(pnl_keyGiris);

                sidebar.Visible = true;
                chat_panel.Visible = true;
                text_mesaj.Visible = true;
                btn_gonder.Visible = true;
            };
        }

        string mesaj;
        private async void btn_gonder_Click(object sender, EventArgs e)
        {
            mesaj = text_mesaj.Text.Trim();
            if (string.IsNullOrWhiteSpace(mesaj)) return;

            text_mesaj.Clear();
            chat_ekran.Visible = true;

            chat_ekran.Text = chat_ekran.Text + "Sen: " + mesaj + "\n";
            gecmis.Add(new { role = "user", content = mesaj });

            chat_ekran.SelectionStart = chat_ekran.Text.Length;
            chat_ekran.ScrollToCaret();

            string yanit = await AIYanit(mesaj);
            chat_ekran.Text = chat_ekran.Text + "LAIfe: " + yanit + "\n";

            gecmis.Add(new { role = "assistant", content = yanit });

            chat_ekran.SelectionStart = chat_ekran.Text.Length;
            chat_ekran.ScrollToCaret();
        }

        private async Task<string> AIYanit(string prompt)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

                var requestBody = new
                {
                    model = "llama-3.3-70b-versatile",
                    messages = gecmis,
                    temperature = 0.5,
                    max_tokens = 999
                };

                string json = JsonSerializer.Serialize(requestBody);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(apiUrl, content);
                string jsonResponse = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                        return "❌ API key geçersiz! Lütfen programı yeniden başlatıp doğru key'i girin.";
                    return $"Hata: {response.StatusCode}";
                }

                var jsonDoc = JsonDocument.Parse(jsonResponse);
                return jsonDoc.RootElement
                    .GetProperty("choices")[0]
                    .GetProperty("message")
                    .GetProperty("content")
                    .GetString() ?? "Yanıt alınamadı.";
            }
        }

        private void text_mesaj_KeyDown(object sender, KeyEventArgs e)
        {
            mesaj = text_mesaj.Text.Trim();

            if (chat_ekran.Text == "" && text_mesaj.Text == "")
                chat_ekran.Visible = false;
            else
            {
                chat_ekran.Visible = true;
                if (!string.IsNullOrEmpty(mesaj) && e.KeyCode == Keys.Enter)
                {
                    btn_gonder.PerformClick();
                    e.SuppressKeyPress = true;
                }
            }
        }

        private void btn_newChat_Click(object sender, EventArgs e)
        {
            chat_ekran.Text = "";
            chat_ekran.Visible = false;
            gecmis.Clear();
            gecmis.Add(new
            {
                role = "assistant",
                content = "Selam! Ben LAIfe. Türk yapay zeka geliştiricileri olan Arda Eren Şahin, Furkan Erduvan, Efe Aydın Aksoy ve Mustafa Berk tarafından üretildim. Yapay zeka olabilirim ama bu, sıcak ve eğlenceli olamayacağım anlamına gelmez! Kısa, öz ve samimi konuşurum. Bana her şeyi sorabilirsin, ama sıkıcı teknik cevaplar bekleme. Bazen espri yaparım, bazen ciddi olurum. Yani tıpkı senin gibi bir sohbet arkadaşıyım! Kısa cevaplar veririm lafı uzatmam. Hadi bakalım, ne hakkında konuşmak istersin?"
            });
        }

        // ===================== AYARLAR PANELİ =====================

        private void btn_ayarlar_Click(object sender, EventArgs e)
        {
            if (panel_credits.Visible == true)
                panel_credits.Visible = false;

            panel_settings.Visible = !panel_settings.Visible;
        }

        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            // Bu buton artık sidebar'daki eski buton — kullanılmıyor
        }

        private void btn_keySil_Click(object sender, EventArgs e)
        {
            var sonuc = MessageBox.Show("API key'i silmek istediğinize emin misiniz?", "Emin misiniz?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (sonuc == DialogResult.Yes)
            {
                Properties.Settings.Default.GroqApiKey = "";
                Properties.Settings.Default.Save();
                MessageBox.Show("Key silindi. Programı yeniden başlatın.");
            }
        }

        // ===================== HOVER EFEKTLERİ =====================

        private void btn_newChat_MouseMove(object sender, MouseEventArgs e)
        {
            btn_newChat.BackColor = cb_tema.Checked ? Color.DarkSlateBlue : Color.FromArgb(80, 120, 180);
        }
        private void btn_newChat_MouseLeave(object sender, EventArgs e)
        {
            btn_newChat.BackColor = Color.Transparent;
        }

        private void btn_ayarlar_MouseMove(object sender, MouseEventArgs e)
        {
            btn_ayarlar.BackColor = cb_tema.Checked ? Color.DarkSlateBlue : Color.FromArgb(80, 120, 180);
        }
        private void btn_ayarlar_MouseLeave(object sender, EventArgs e)
        {
            btn_ayarlar.BackColor = Color.Transparent;
        }

        private void btn_credits_MouseMove(object sender, MouseEventArgs e)
        {
            btn_credits.BackColor = cb_tema.Checked ? Color.DarkSlateBlue : Color.FromArgb(80, 120, 180);
        }
        private void btn_credits_MouseLeave(object sender, EventArgs e)
        {
            btn_credits.BackColor = Color.Transparent;
        }

        private void btn_credits_Click(object sender, EventArgs e)
        {
            if (panel_settings.Visible == true)
                panel_settings.Visible = false;

            panel_credits.Visible = !panel_credits.Visible;
        }

        // ===================== TEMA =====================

        private void cb_tema_CheckedChanged(object sender, EventArgs e)
        {
            if (!cb_tema.Checked)
            {
                Color yazi = Color.FromArgb(0, 0, 64);
                btn_ayarlar.ForeColor = yazi; btn_credits.ForeColor = yazi;
                btn_newChat.ForeColor = yazi; btn_gonder.ForeColor = yazi;
                chat_ekran.ForeColor = yazi; chat_panel.ForeColor = yazi;
                gb_gorunum.ForeColor = yazi; panel_credits.ForeColor = yazi;
                panel_settings.ForeColor = yazi; text_mesaj.ForeColor = yazi;
                lbl_desc.ForeColor = yazi;

                this.BackColor = Color.Silver;
                chat_ekran.BackColor = Color.FromArgb(120, 170, 240);
                chat_panel.BackColor = Color.FromArgb(120, 170, 240);
                panel_credits.BackColor = Color.FromArgb(100, 140, 200);
                panel_settings.BackColor = Color.FromArgb(100, 140, 200);
                sidebar.BackColor = Color.FromArgb(100, 140, 200);
                text_mesaj.BackColor = Color.FromArgb(100, 140, 200);
                btn_gonder.BackColor = Color.FromArgb(100, 140, 200);
            }
            else
            {
                Color yazi = Color.FromArgb(192, 192, 255);
                btn_ayarlar.ForeColor = yazi; btn_credits.ForeColor = yazi;
                btn_newChat.ForeColor = yazi; btn_gonder.ForeColor = yazi;
                chat_ekran.ForeColor = yazi; chat_panel.ForeColor = yazi;
                gb_gorunum.ForeColor = yazi; panel_credits.ForeColor = yazi;
                panel_settings.ForeColor = yazi; text_mesaj.ForeColor = yazi;
                lbl_desc.ForeColor = yazi;

                this.BackColor = Color.FromArgb(0, 0, 35);
                chat_ekran.BackColor = Color.FromArgb(0, 0, 20);
                chat_panel.BackColor = Color.FromArgb(0, 0, 20);
                panel_credits.BackColor = Color.FromArgb(42, 42, 115);
                panel_settings.BackColor = Color.FromArgb(42, 42, 115);
                sidebar.BackColor = Color.FromArgb(0, 0, 35);
                text_mesaj.BackColor = Color.FromArgb(42, 42, 115);
                btn_gonder.BackColor = Color.FromArgb(42, 42, 115);
            }
        }
    }
}
