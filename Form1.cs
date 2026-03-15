using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices; //api icin gerekli library
using System.Windows.Controls;
using System.Drawing;


namespace laife_arayuz_alternatif
{
    public partial class mainwindow : Form
    {

        [DllImport("user32.dll")] // windows ui fonksiyonlarina erismek icin dllimport ile user32.dll cagiriyoruz (imlecin yanip sonmesini engellemek icin)
        static extern bool HideCaret(IntPtr hWnd); // belirli penceredeki imleci gizleyecek method

        private static readonly string apiKey = "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"; //groq apı ile değiştirdim
        private static readonly string apiUrl = "https://api.groq.com/openai/v1/chat/completions"; //groq ile değiştirildi için groq linki

        private List<object> gecmis = new List<object>
{
    new {
        role = "assistant", // "model" değil "assistant" oldu
        content = "Selam! Ben LAIfe. Yapay zeka olabilirim ama bu, sıcak ve eğlenceli olamayacağım anlamına gelmez! Kısa, öz ve samimi konuşurum. Bana her şeyi sorabilirsin, ama sıkıcı teknik cevaplar bekleme. Bazen espri yaparım, bazen ciddi olurum. Yani tıpkı senin gibi bir sohbet arkadaşıyım! Kısa cevaplar veririm lafı uzatmam. Hadi bakalım, ne hakkında konuşmak istersin?"
    }
};

        public mainwindow()
        {
            InitializeComponent();
            SetupChatScreen(); // chat ekrani ayarlamalarini formun baslangicinda yapmasini sagliyoruz
        }



        private void SetupChatScreen()
        {
            HideCaret(chat_ekran.Handle); // hangi ekranin imlecinin gizlenecegi belirlenir
            this.Load += (s, e) => HideCaret(chat_ekran.Handle); // 

            // += ile eventlere fonksiyon eklenir s = sender = durum, e = event = olay, durumun gerceklesmesi
            chat_ekran.Click += (s, e) => HideCaret(chat_ekran.Handle); // click durumunda 
            chat_ekran.MouseDown += (s, e) => HideCaret(chat_ekran.Handle); // mousedown durumunda
            chat_ekran.GotFocus += (s, e) => HideCaret(chat_ekran.Handle); // focus durumunda 
            chat_ekran.TextChanged += (s, e) => HideCaret(chat_ekran.Handle); // text degisme durumunda da imleci gizliyor


        }

        private void mainwindow_Load(object sender, EventArgs e)
        {



        }

        string mesaj;
        private async void btn_gonder_Click(object sender, EventArgs e)
        {

            mesaj = text_mesaj.Text.Trim(); //trim gereksiz bosluklari siliyor
            if (string.IsNullOrWhiteSpace(mesaj)) return; //mesaj bossa fonksiyon sonlaniyor

            text_mesaj.Clear();

            // chat ekrani gorunurluk ayarlari
            if (chat_ekran == null)
            {
                if (string.IsNullOrEmpty(mesaj) || text_mesaj.Text == " " || text_mesaj.Text == "\n")
                {
                    chat_ekran.Visible = false;
                }
                else
                {
                    chat_ekran.Visible = true;
                }
            }
            else
            {
                chat_ekran.Visible = true;
            }


            //kullanicinin mesajini listeye ekliyor ve ai in yanit vermesini sagliyor
            chat_ekran.Text = chat_ekran.Text + "Sen: " + mesaj + "\n";
            gecmis.Add(new { role = "user", content = mesaj }); // gecmise kullanicidan gelen mesaj ekleniyor

            //oto scroll down
            chat_ekran.SelectionStart = chat_ekran.Text.Length;
            chat_ekran.ScrollToCaret();

            //yanıtı alıp listeye ekliyor
            string yanit = await AIYanit(mesaj);
            chat_ekran.Text = chat_ekran.Text + "LAIfe: " + yanit + "\n";

            gecmis.Add(new { role = "assistant", content = yanit }); // ai dan gelen mesaj gecmise ekleniyor

            //oto scroll down
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
                    model = "llama-3.3-70b-versatile", // ücretsiz ve güçlü model
                    messages = gecmis,
                    temperature = 0.6,
                    max_tokens = 999
                };

                string json = JsonSerializer.Serialize(requestBody);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(apiUrl, content);
                string jsonResponse = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                    return $"Hata: {response.StatusCode}";

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
            //global mesaj degiskenine text_mesaj daki degeri yazdirip trim ile gereksiz bosluklari aliyoruz
            mesaj = text_mesaj.Text.Trim();

            //chat ekraninda ve mesaj textbox da icerik yoksa chat ekrani gorunmuyor
            if (chat_ekran.Text == "" && text_mesaj.Text == "")
            {
                chat_ekran.Visible = false;
            }
            else
            {
                chat_ekran.Visible = true;
                if (string.IsNullOrEmpty(mesaj) || mesaj == " " || mesaj == "\n")
                {

                }
                else
                {
                    chat_ekran.Visible = true;
                    //keydown dan e ile gelen deger enter ise btn_gonder calisiyor
                    if (e.KeyCode == Keys.Enter)
                    {
                        btn_gonder.PerformClick();
                        e.SuppressKeyPress = true;
                    }
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
                role = "assistant", content = "Selam! Ben LAIfe. Yapay zeka olabilirim ama bu, sıcak ve eğlenceli olamayacağım anlamına gelmez! Kısa, öz ve samimi konuşurum. Bana her şeyi sorabilirsin, ama sıkıcı teknik cevaplar bekleme. Bazen espri yaparım, bazen ciddi olurum. Yani tıpkı senin gibi bir sohbet arkadaşıyım! Kısa cevaplar veririm lafı uzatmam. Hadi bakalım, ne hakkında konuşmak istersin?"
              
            });
        }

        private void btn_newChat_MouseMove(object sender, MouseEventArgs e)
        {
            //koyu tema acikken hover efekti
            if (cb_tema.Checked)
            {
                btn_newChat.BackColor = System.Drawing.Color.DarkSlateBlue;
            }
            //acik tema acikken hover efekti
            else
            {
                btn_newChat.BackColor = Color.FromArgb(80, 120, 180);
            }
        }
        private void btn_newChat_MouseLeave(object sender, EventArgs e)
        {
            btn_newChat.BackColor = System.Drawing.Color.Transparent;
        }

        private void btn_ayarlar_MouseMove(object sender, MouseEventArgs e)
        {
            //koyu tema acikken hover efekti
            if (cb_tema.Checked)
            {
                btn_ayarlar.BackColor = System.Drawing.Color.DarkSlateBlue;
            }
            //acik tema acikken hover efekti
            else
            {
                btn_ayarlar.BackColor = Color.FromArgb(80, 120, 180);
            }
        }

        private void btn_ayarlar_MouseLeave(object sender, EventArgs e)
        {
            btn_ayarlar.BackColor = System.Drawing.Color.Transparent;
        }

        private void btn_credits_MouseMove(object sender, MouseEventArgs e)
        {
            //koyu tema acikken hover efekti 
            if (cb_tema.Checked)
            {
                btn_credits.BackColor = System.Drawing.Color.DarkSlateBlue;
            }
            //acik tema acikken hover efekti 
            else
            {
                btn_credits.BackColor = Color.FromArgb(80, 120, 180);
            }
        }

        private void btn_credits_MouseLeave(object sender, EventArgs e)
        {
            btn_credits.BackColor = System.Drawing.Color.Transparent;
        }

        private void btn_credits_Click(object sender, EventArgs e)
        {
            // ayarlar penceresi aciksa kapanmasi icin
            if (panel_settings.Visible == true)
            {
                panel_settings.Visible = false;
            }

            // butona tiklandiginda hakkinda penceresinin acilip kapanmasi icin
            if (panel_credits.Visible == false)
            {
                panel_credits.Visible = true;
            }
            else
            {
                panel_credits.Visible = false;
            }
        }

        private void btn_ayarlar_Click(object sender, EventArgs e)
        {
            // hakkinda penceresi aciksa kapanmasi icin
            if (panel_credits.Visible == true)
            {
                panel_credits.Visible = false;
            }

            // butona tiklandiginda ayarlar penceresinin acilip kapanmasi icin
            if (panel_settings.Visible == false)
            {
                panel_settings.Visible = true;
            }
            else
            {
                panel_settings.Visible = false;
            }
        }

        private void cb_tema_CheckedChanged(object sender, EventArgs e)
        {
            if (!cb_tema.Checked)
            {
                //acik tema yazi renkleri
                btn_ayarlar.ForeColor = Color.FromArgb(0, 0, 64);
                btn_credits.ForeColor = Color.FromArgb(0, 0, 64);
                btn_newChat.ForeColor = Color.FromArgb(0, 0, 64);
                btn_gonder.ForeColor = Color.FromArgb(0, 0, 64);
                chat_ekran.ForeColor = Color.FromArgb(0, 0, 64);
                chat_panel.ForeColor = Color.FromArgb(0, 0, 64);
                gb_gorunum.ForeColor = Color.FromArgb(0, 0, 64);
                panel_credits.ForeColor = Color.FromArgb(0, 0, 64);
                panel_settings.ForeColor = Color.FromArgb(0, 0, 64);
                text_mesaj.ForeColor = Color.FromArgb(0, 0, 64);
                lbl_desc.ForeColor = Color.FromArgb(0, 0, 64);

                // acik tema arkaplan renkleri
                this.BackColor = System.Drawing.Color.Silver;
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
                // koyu tema yazi renkleri
                btn_ayarlar.ForeColor = Color.FromArgb(192, 192, 255);
                btn_credits.ForeColor = Color.FromArgb(192, 192, 255);
                btn_newChat.ForeColor = Color.FromArgb(192, 192, 255);
                btn_gonder.ForeColor = Color.FromArgb(192, 192, 255);
                chat_ekran.ForeColor = Color.FromArgb(192, 192, 255);
                chat_panel.ForeColor = Color.FromArgb(192, 192, 255);
                gb_gorunum.ForeColor = Color.FromArgb(192, 192, 255);
                panel_credits.ForeColor = Color.FromArgb(192, 192, 255);
                panel_settings.ForeColor = Color.FromArgb(192, 192, 255);
                text_mesaj.ForeColor = Color.FromArgb(192, 192, 255);
                lbl_desc.ForeColor = Color.FromArgb(192, 192, 255);

                // koyu tema arkaplan renkleri
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
