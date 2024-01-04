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

using Robbery.Library.Concrete;
using Robbery.Library.Enum;
using System;
using System.IO;
using System.Windows.Forms;

namespace Robbery.Desktop
{
    public partial class MainForm : Form
    {
        private readonly Game _game;  //burada değer ataması yapamıyoruz çünkü daha oluşturulmayan bir elemana değer ataması yapamayız , initializecomponent çalıştıktan sonra değer ataması yapabiliriz

        public MainForm() //Burası çok önemli, bu mainform'un cunstructor'ıdır.Burada ilk değerler atanır.
        {
            InitializeComponent(); // Elemanların oluşturulması ilk değerlerlerinin atanması gibi işlevleri gerçekleştirir.


            Panel[,] roads = new Panel[,]
            {
                { road0, road1, road2 , road3, road4, road5, road6, road7, road8 , road9 },
                { road10, road11, road12, road13, road14, road15, road16, road17, road18, road19 },
                { road20, road21, road22, road23,road24, road25, road26,road27, road28, road29 }

            };
            _game = new Game(roads);  //library projesindeki Game.cs ye buradan panelin referansı gönderilerek o taraftan panele erişim sağlanır

            _game.ElapsedTimeChanged += Game_ElapsedTimeChanged;
            
        }

        public string fileCar;

        int stopGame=0;
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.P)
            {
                _game.Pause();
                stopGame++;
            }

            if(stopGame%2==0)
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    _game.fileCar = fileCar;
                    _game.Start();      
                    break;
                case Keys.Left:
                    _game.MoveCar(Directions.toLeft);
                    break;
                case Keys.Right:
                    _game.MoveCar(Directions.toRight);
                    break;
                case Keys.Up:
                    _game.MoveCar(Directions.toUp);
                    break;
                case Keys.Down:
                    _game.MoveCar(Directions.toDown);
                    break;
            }
            labelLevel.Text = _game.GameLevel.ToString();


            _game.HealthControl();
            labelHealth.Text = _game.CarHealth.ToString();
            _game.FuelGaugeControl(short.Parse(labelHealth.Text), panelFuelGauge);



            if (Int32.Parse(labelHealth.Text)<=0)
            {
                WriteGamer(gamerName, _game.Puan());

                ShowEndForm();

            }


        }
        public void ShowEndForm()
        {
            EndForm endform = new EndForm();
            endform.Show();
            endform.lname = gamerName;
            endform.lscore=_game.Puan();

            this.Hide();
            endform.FormClosed += (s, args) => this.Close();
        }

        public string gamerName;

        private void Game_ElapsedTimeChanged(object sender, EventArgs e)
        {
            labelTime.Text = _game.ElapsedTime.ToString("m\\:ss");

            int time = (int)(_game.ElapsedTime.TotalSeconds);

            _game.LevelControl();
            labelPuan.Text = _game.Puan();
        }



        private void WriteGamer(string Name, string puan)
        {
            string name = Name;
            int score = int.Parse(puan);
            string filePath = @"C:\Users\ozabd\Desktop\Robbery Game\leaders.txt";
            FileStream fs = new FileStream(filePath, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            sw.WriteLine(name + " - " + score);

            sw.Flush();
            sw.Close();
            fs.Close();

        }

    }
}




