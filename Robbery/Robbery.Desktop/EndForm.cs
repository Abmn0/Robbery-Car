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
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Robbery.Desktop
{
    public partial class EndForm : Form
    {
        public EndForm()
        {
            InitializeComponent();
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


        private void buttonBack_Click_1(object sender, EventArgs e)
        {
            panelLeaderboard.Visible = false;
        }

        private void buttonLeaders_Click_1(object sender, EventArgs e)
        {
            panelLeaderboard.Visible = true;
            writeLeaders();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
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
        public string lname;
        public string lscore;


        List<string> gamers;
        private void ReadLeaders()
        {
            string filePath = @"C:\Users\ozabd\Desktop\Robbery Game\leaders.txt";

            // Dosyayı okuma işlemini using bloğu içine alarak kaynakları düzgün bir şekilde serbest bırakma
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
                    en_yuksek_puanlar += gamers[i] + "\n";  // gamers[i] şeklinde doğru oyuncuyu alma
                }

            } 
        }

        private void EndForm_Shown(object sender, EventArgs e)
        {
            labelName.Text = lname;
            labelScore.Text = lscore;
        }
    }
}
