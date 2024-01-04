//*******************************************************************************************
//**************SAKARYA ÜNİVERSİTESİ BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ***************
//****************************BİLİŞİM SİSTEMLERİ MÜHENDİSLİĞİ********************************
//****                                                                                   ****
//***                   Nesneye Dayalı Programlama Dersi                                  ***
//***                   Ödev No:1                                                         ***
//***                   Ödev: Windows Form Uygulamaları İle Kaçış Oyunu                   ***
//***                   Geliştirici: Abdurrahman ÖZ                                       ***
//***                   Öğrenci No:  B221200060                                           ***
//***                   Dersi Veren Öğretim Üyesi: Muhammed KOTAN                         ***
//****                                                                                   ****
//******                                                                               ******
//*******************************************************************************************

using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Media;
using System.IO;

namespace Robbery.Desktop
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
            sound.Play();
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            // Fare imleci üzerine gelindiğinde pointer olarak değiştirilir.
            Cursor = Cursors.Hand;

        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            // Fare imleci kontrolün üzerinden çıkınca varsayılan imleç olarak değiştirilir.
            Cursor = Cursors.Default;
        }

        private void buttonInfo_Click(object sender, EventArgs e)
        {
            panelInfo.Visible = true;
        }


        private void buttonBack_Click(object sender, EventArgs e)
        {
            panelInfo.Visible = false;
        }

        private void buttonLeaders_Click(object sender, EventArgs e)
        {
            writeLeaders();
            panelLeaderboard.Visible = true;
        }


        private void buttonBack2_Click(object sender, EventArgs e)
        {
            panelLeaderboard.Visible = false;
        }

        MainForm mainForm = new MainForm();
        private void buttonStart_Click(object sender, EventArgs e)
        {
            mainForm.fileCar = file;
            mainForm.Show();
            this.Hide();
            sound.Stop();
            mainForm.gamerName=textBoxName.Text;
            

            mainForm.FormClosed += (s, args) => this.Close();
        }

        private void FormMainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private string file= "C:\\Users\\ozabd\\Desktop\\Robbery Game\\Pictures\\cars\\bluecar.png";
        int i = 0;
        private void selectCarType()
        {
            switch (i)
            {
                case 0:
                    file="C:\\Users\\ozabd\\Desktop\\Robbery Game\\Pictures\\cars\\redcar.png";
                    break;
                case 1:
                    file = "C:\\Users\\ozabd\\Desktop\\Robbery Game\\Pictures\\cars\\beigecar.png";
                    break;
                case 2:
                    file = "C:\\Users\\ozabd\\Desktop\\Robbery Game\\Pictures\\cars\\blackcar.png";
                    break;
                case 3:
                    file = "C:\\Users\\ozabd\\Desktop\\Robbery Game\\Pictures\\cars\\greencar.png";
                    break;
                case 4:
                    file = "C:\\Users\\ozabd\\Desktop\\Robbery Game\\Pictures\\cars\\bluecar.png";
                    i = -1;
                    break;
            }
            pictureBoxCarType.Image = Image.FromFile(file);
            i++;
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            selectCarType();
        }
        private void writeLeaders()
        {
            ReadLeaders();
            labelG1.Text = gamers[0];
            labelG2.Text = gamers[1];
            labelG3.Text = gamers[2];
            labelG4.Text = gamers[3];
            labelG5.Text = gamers[4];

        }

        List<string> gamers;
        private void ReadLeaders()
        {
            string filePath = @"C:\Users\ozabd\Desktop\Robbery Game\leaders.txt";

            // Dosyayı okuma işlemini using bloğu içine alarak kaynakları düzgün bir şekilde serbest bırakmak
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            using (StreamReader sr = new StreamReader(fs))
            {
                gamers = new List<string>();

                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    gamers.Add(line);
                }

                // Puanlara göre sıralama işlemi
                gamers = gamers.OrderByDescending(o => int.Parse(o.Split(new string[] { " - " }, StringSplitOptions.None)[1])).ToList();

                string en_yuksek_puanlar = "";

                // En yüksek puan alan ilk 5 oyuncuyu al
                for (int i = 0; i < 5 && i < gamers.Count; i++)
                {
                    en_yuksek_puanlar += gamers[i] + "\n";  // gamers[i] şeklinde doğru oyuncuyu alma.
                }

            } 
        }


        SoundPlayer sound = new SoundPlayer("C:\\Users\\ozabd\\Desktop\\Robbery Game\\Music\\startmenu.wav");
        int timer=0;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (timer % 2 == 0)
            {
                pictureBox1.Image = Image.FromFile("C:\\Users\\ozabd\\Desktop\\Robbery Game\\Pictures\\volume3.png");
                sound.Stop();
            }

            else
            {
                pictureBox1.Image = Image.FromFile("C:\\Users\\ozabd\\Desktop\\Robbery Game\\Pictures\\mute.png");
                sound.Play();
            }
               
            timer++;
        }
    }
}

