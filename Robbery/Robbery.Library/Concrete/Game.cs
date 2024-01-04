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


using Robbery.Library.Enum;
using Robbery.Library.Interface;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;


namespace Robbery.Library.Concrete
{
    public class Game : IGame
    {
        //Car health kontrolleri
        #region CarHealth

        private short _carHealth = 10;

        public short CarHealth
        {
            get { return _carHealth; }

            set
            {
                _carHealth = value;
            }
        }


        public void HealthControl()
        {
            try
            {
                int trapCount = GetTrapCount(refPanel[index1, index2]);

                if (trapCount == 1)
                {
                    CarHealth -= 1;
                    trapsArray[index1, index2].Visible = true;

                }

                int HasGift = GetGiftCount(refPanel[index1, index2]);

                if (HasGift == 1)
                {
                    Random rnd = new Random();
                    int gift = rnd.Next() % 100;

                    if (gift < 80)
                    {
                        CarHealth += 1;
                    }
                    else
                        CarHealth -= 1;
                    refPanel[index1, index2].Controls.Clear();
                    refPanel[index1, index2].Controls.Add(carr);

                }
                int HasAirTrap = GetAirTrapCount(refPanel[index1, index2]);
                if (HasAirTrap == 1)
                {
                    CarHealth -= 1;
                }
                int HasTrafficCar = GetTrafficCarCount(refPanel[index1, index2]);
                if (HasTrafficCar == 1)
                {
                    CarHealth -= 1;
                }
            }
            catch
            {
                MessageBox.Show("iptal");
            }
        }


        FuelGauge fuelGauge = new FuelGauge(new Size());
        public PictureBox FuelGaugeControl(short health, Panel panelFuel) // panelFuelGauge ı parametre olarak alıp içine picturebox oluşturur.
        {

            //Araç sağlığına göre fuelgauge değişimi
            fuelGauge.SizeMode = PictureBoxSizeMode.AutoSize;
            panelFuel.Controls.Add(fuelGauge);
            fuelGauge.Image = Image.FromFile("C:\\Users\\ozabd\\Desktop\\Robbery Game\\Pictures\\8.png");
            switch (health)
            {
                case 0:
                    fuelGauge.Image = Image.FromFile("C:\\Users\\ozabd\\Desktop\\Robbery Game\\Pictures\\0.png");
                    break;
                case 1:
                    fuelGauge.Image = Image.FromFile("C:\\Users\\ozabd\\Desktop\\Robbery Game\\Pictures\\1.png");
                    break;
                case 2:
                    fuelGauge.Image = Image.FromFile("C:\\Users\\ozabd\\Desktop\\Robbery Game\\Pictures\\2.png");
                    break;
                case 3:
                    fuelGauge.Image = Image.FromFile("C:\\Users\\ozabd\\Desktop\\Robbery Game\\Pictures\\3.png");
                    break;
                case 4:
                    fuelGauge.Image = Image.FromFile("C:\\Users\\ozabd\\Desktop\\Robbery Game\\Pictures\\4.png");
                    break;
                case 5:
                    fuelGauge.Image = Image.FromFile("C:\\Users\\ozabd\\Desktop\\Robbery Game\\Pictures\\5.png");
                    break;
                case 6:
                    fuelGauge.Image = Image.FromFile("C:\\Users\\ozabd\\Desktop\\Robbery Game\\Pictures\\6.png");
                    break;
                case 7:
                    fuelGauge.Image = Image.FromFile("C:\\Users\\ozabd\\Desktop\\Robbery Game\\Pictures\\7.png");
                    break;
                case 8:
                    fuelGauge.Image = Image.FromFile("C:\\Users\\ozabd\\Desktop\\Robbery Game\\Pictures\\8.png");
                    break;
            }

            return fuelGauge;

        }
        #endregion


        // Panelin içinde picturebox var mı- trap var mı -car var mı -gift var mı- lightening var mı- trafficcar var mı kontrolleri
        #region HasControls-CountControls       

        public bool CheckCarExistence(Panel[,] panel, int row, int column)
        {
            foreach (Control control in panel[row, column].Controls)
            {
                if (control is Car) return true;
            }
            return false;
        }

        public int GetTrapCount(Panel panel)

        {
            int trapCount = panel.Controls.OfType<Traps>().Count();
            if (trapCount == 2) { trapsArray[index1, index2].Visible = true; }

            return trapCount;
        }

        public int GetGiftCount(Panel panel)

        {
            int giftCount = panel.Controls.OfType<Gift>().Count();
            return giftCount;

        }

        public int GetAirTrapCount(Panel panel)

        {
            int airTrapCount = panel.Controls.OfType<Lightening>().Count();
            return airTrapCount;

        }

        public int GetTrafficCarCount(Panel panel)

        {
            int trafficCarCount = panel.Controls.OfType<TrafficCar>().Count();
            return trafficCarCount;

        }


        public int GetPictureBoxCount(Panel panel)
        {
            int pictureBoxCount = panel.Controls.OfType<PictureBox>().Count();
            if (pictureBoxCount == 0) { }//trapsArray[index1, index2].Visible = true; }

            return pictureBoxCount;
        }

        public bool CheckLighteningExistence(Panel[,] panel, int row, int column)
        {
            foreach (Control control in panel[row, column].Controls)
            {
                if (control is Lightening) return true;
            }
            return false;
        }
        public bool CheckPictureBoxExistence(Panel[,] panel, int row, int column)
        {
            foreach (Control control in panel[row, column].Controls)
            {
                if (control is PictureBox) return true;
            }
            return false;
        }

        #endregion


        // Level controlleri
        #region Level

        private short _gameLevel = 1;

        public short GameLevel
        {
            get { return _gameLevel; }

            set
            {

                //if (value >= 0)
                _gameLevel = value;

            }
        }

        private void Remove()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    refPanel[i, j].Controls.Clear();
                }

            }
        }

        public void LevelUp()
        {
            GameLevel++;
            Remove();

        }


        public void LevelControl()
        {

            int time = (int)(TrapTime.TotalSeconds);

            int time2 = (int)(TrapTime.TotalSeconds);
            StartTrapTimer();
            if (time % 5 == 0)
                CreateRandomGift();

            if (GameLevel == 2)
            {
                if (time2 % 2 == 0)
                {
                    RemoveAirTrap();
                    CreateRandomAirTrap();
                    TrapTime = TimeSpan.Zero;
                }
            }

            if (GameLevel == 3)
            {
                if (time2 % 2 == 0)
                {
                    CreateRandomTrafficCar();

                    if (time2 % 1 == 0)
                    {
                        CreateRandomTrafficCar2();
                        MoveTrafficCar();
                        if (time2 % 1 == 0)
                            MoveTrafficCar2();
                    }


                }
            }
        }


        #endregion



        //Car oluşumu ve hareket kontrolleri
        #region Car

        public int index1 = 1, index2 = 0;//arabanın doğum konumu 1,0
        public void MoveCar(Directions direction)
        {
            //1,0


            if (direction == Directions.toLeft)
            {
                try
                {
                    index2 -= 1;
                    refPanel[index1, index2].Controls.Add(carr);
                }
                catch
                {
                    MessageBox.Show("İlk sütundan daha geriye gidemezsin!!");
                }

            }
            if (direction == Directions.toRight)
            {
                try
                {
                    index2 += 1;
                    if (index2 == 10)
                    {
                        index1 = 1; index2 = 0;
                        LevelUp();
                        refPanel[index1, index2].Controls.Add(carr);
                    }
                    refPanel[index1, index2].Controls.Add(carr);

                }
                catch
                {
                    MessageBox.Show("tamamdır");
                }

            }
            if (direction == Directions.toUp)
            {
                if (index1 > 0)
                    index1 -= 1;

                refPanel[index1, index2].Controls.Add(carr);

            }

            if (direction == Directions.toDown)
            {
                if (index1 < 2)
                {
                    index1 += 1;
                }
                refPanel[index1, index2].Controls.Add(carr);
            }


        }

        private Car carr;

        public string fileCar = "C:\\Users\\ozabd\\Desktop\\Robbery Game\\Pictures\\cars\\blackcar.png";
        public void CreateCar()
        {

            var car = new Car(refPanel[1, 2].Size); // oluştururken herhangi bir panelin sizeını getimesi lazım ben de 5.yi getir demişim zaten hepsi 128e128

            car.Image = Image.FromFile(fileCar);
            refPanel[1, 0].Controls.Add(car);
            car.BackColor = Color.Transparent; //picturebax car'ın arka plan rengini transparent yani görünmez yapar.
            car.Width = 115;
            car.Height = 40;
            car.SizeMode = PictureBoxSizeMode.StretchImage;

            carr = car;//carrı burada oluşturulan car nesnesini diğer panellere taşımak amaçlı kullanıyoruz. oyun başladığında 1 adet car nesnesi oluşuyor ve bu nesneyi daha sonra kontrol etmek için bu işlemi yapmak gerekiyor

        }
        #endregion


        //Rasgele trap lightening ve gift oluşumları
        #region Random_Trap_AirTrap_Gift

        Gift gift;

        public void CreateRandomGift()
        {
            Random rnd = new Random();
            gift = new Gift(refPanel[1, 2].Size);
            int index1gift = rnd.Next() % 3;
            int index2gift = rnd.Next() % 10;

            int pictureboxCount = GetPictureBoxCount(refPanel[index1gift, index2gift]);
            if (pictureboxCount != 0)
            {
                return;
            }
            else
            {
                gift.SizeMode = PictureBoxSizeMode.StretchImage;

                refPanel[index1gift, index2gift].Controls.Add(gift);
                gift.Height = 88;
                gift.Width = 108;
                gift.Image = Image.FromFile("C:\\Users\\ozabd\\Desktop\\Robbery Game\\Pictures\\gift2.gif");
                gift.BackColor = Color.Transparent;

            }

        }

        public void RemoveAirTrap()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    bool HasAirTrap = CheckLighteningExistence(refPanel, i, j);
                    if (HasAirTrap) { refPanel[i, j].Controls.Clear(); }
                }

            }
        }

        Lightening[,] lighteningArray = new Lightening[3, 10];
        public void CreateRandomAirTrap()
        {
            Random rnd = new Random();
            for (int i = 0; i < lighteningArray.GetLength(1); i++)
            {
                int index_trap1 = rnd.Next() % 3;
                int index_trap2 = rnd.Next() % 10;

                if (index_trap1 == 1 && index_trap2 == 0) //arabanın olduğu kutuda trap oluşturma
                {
                    i -= 1;
                    continue;
                }

                lighteningArray[index_trap1, index_trap2] = new Lightening(refPanel[1, 2].Size);
                lighteningArray[index_trap1, index_trap2].Visible = true;

                bool HasPictureBox = CheckPictureBoxExistence(refPanel, index_trap1, index_trap2);
                //MessageBox.Show("pictue var mı" + HasPictureBox.ToString());// picture box varsa true yoksa false döndürüyor

                if (HasPictureBox) // eğer picturebox varsa
                {
                    if (CheckCarExistence(refPanel, index_trap1, index_trap2)) //alicengizlik
                        CarHealth -= 1;

                    refPanel[index_trap1, index_trap2].Controls.Clear();
                    i -= 1;

                    refPanel[index1, index2].Controls.Add(carr);

                }

                refPanel[index_trap1, index_trap2].Controls.Add(lighteningArray[index_trap1, index_trap2]);

                lighteningArray[index_trap1, index_trap2].BackColor = Color.Transparent;
                lighteningArray[index_trap1, index_trap2].Height = 128;
                lighteningArray[index_trap1, index_trap2].SizeMode = PictureBoxSizeMode.StretchImage;
                lighteningArray[index_trap1, index_trap2].Image = Image.FromFile("C:\\Users\\ozabd\\Desktop\\Robbery Game\\Pictures\\lightening2.gif");
                lighteningArray[index_trap1, index_trap2].SendToBack();
            }
        }




        Traps[,] trapsArray = new Traps[3, 10]; //10 adet trap nesnesi elemanını tutan dizi oluşturuluyor
        public void CreateRandomTrap()
        {
            Random rnd = new Random();

            for (int i = 0; i < trapsArray.GetLength(1); i++) // 10 adet tuzak oluşumu //sadece length dersek 3*10 kadar döner, sadece GetLength(0) dersek 3 döner Getlength(1) dersek 10 döner
            {


                int index_trap1 = rnd.Next() % 3;
                int index_trap2 = rnd.Next() % 10;
                if (index_trap1 == 1 && index_trap2 == 0) //arabanın olduğu kutuda trap oluşturma
                {
                    i -= 1;
                    continue;
                }

                trapsArray[index_trap1, index_trap2] = new Traps(refPanel[1, 2].Size); // bu referanstaki panel sadece herhangi bir panelin size değerlerini getirmek için kullanılıyor resimler buna göre yerleşiyor oranlanıyor
                trapsArray[index_trap1, index_trap2].Visible = false;

                bool HasPictureBox = CheckPictureBoxExistence(refPanel, index_trap1, index_trap2);
                //MessageBox.Show("pictue var mı" + HasPictureBox.ToString());// picture box varsa true yoksa false döndürüyor

                if (HasPictureBox) // eğer picturebox varsa
                {
                    refPanel[index_trap1, index_trap2].Controls.Clear();
                    i -= 1;
                }

                refPanel[index_trap1, index_trap2].Controls.Add(trapsArray[index_trap1, index_trap2]);
                // MessageBox.Show(i.ToString());  i nin değerini döndürüyor i sayısı+1 kadar trap oluşmalı bunun kontrolünde i nin değerine bakmak için araç

                trapsArray[index_trap1, index_trap2].BackColor = Color.Transparent;
                trapsArray[index_trap1, index_trap2].Width = 128;
                trapsArray[index_trap1, index_trap2].Height = 128;


                // Bu if bloklarında oluşturulan trapsArray elemanlarına değer ataması yapılıyor
                if (i < 3)
                {
                    trapsArray[index_trap1, index_trap2].Image = Image.FromFile("C:\\Users\\ozabd\\Desktop\\Robbery Game\\Pictures\\spilledoiltrap.png");
                }
                else if (2 < i && i < 6)
                {
                    trapsArray[index_trap1, index_trap2].Image = Image.FromFile("C:\\Users\\ozabd\\Desktop\\Robbery Game\\Pictures\\barriertrap.png");
                }
                else if (i > 5)
                {
                    trapsArray[index_trap1, index_trap2].Image = Image.FromFile("C:\\Users\\ozabd\\Desktop\\Robbery Game\\Pictures\\roadtrap.png");
                }

                trapsArray[index_trap1, index_trap2].SendToBack();

            }

        }




        #endregion


        //Trafficcar oluşumu ve hareketi
        #region Trafficcar

        int index1_trafficcar = 2;
        int index2_trafficcar = 9;

        public void MoveTrafficCar()
        {
            refPanel[index1_trafficcar, index2_trafficcar].Controls.Clear();

            if (index2_trafficcar > 0)
            {
                index2_trafficcar -= 1;
                refPanel[index1_trafficcar, index2_trafficcar].Controls.Add(trafficCar);
            }
            else
            {
                Random rnd = new Random();
                index1_trafficcar = rnd.Next(0, 3);
                index2_trafficcar = 9;
                CreateRandomTrafficCar();
            }
        }
        TrafficCar trafficCar;

        public void CreateRandomTrafficCar()
        {
            trafficCar = new TrafficCar(refPanel[1, 2].Size);

            Random rnd = new Random();


            int whichtcar = rnd.Next() % 5;


            trafficCar.SizeMode = PictureBoxSizeMode.StretchImage;
            trafficCar.Height = 84;
            trafficCar.Width = 127;
            trafficCar.Image = Image.FromFile("C:\\Users\\ozabd\\Desktop\\Robbery Game\\Pictures\\police.png");

            trafficCar.BackColor = Color.Transparent;


            trafficCar.SizeMode = PictureBoxSizeMode.StretchImage;

            refPanel[index1_trafficcar, index2_trafficcar].Controls.Add(trafficCar);
        }

        int index1_trafficcar2 = 1;
        int index2_trafficcar2 = 9;

        public void MoveTrafficCar2()
        {
            refPanel[index1_trafficcar2, index2_trafficcar2].Controls.Clear();

            if (index2_trafficcar2 > 0)
            {
                index2_trafficcar2 -= 1;
                refPanel[index1_trafficcar2, index2_trafficcar2].Controls.Add(trafficCar2);
            }
            else
            {
                Random rnd = new Random();
                index1_trafficcar2 = rnd.Next(0, 3);
                index2_trafficcar2 = 9;
                CreateRandomTrafficCar2();
            }
        }
        TrafficCar trafficCar2;

        public void CreateRandomTrafficCar2()
        {
            trafficCar2 = new TrafficCar(refPanel[1, 2].Size);

            Random rnd = new Random();


            int whichtcar = rnd.Next() % 5;


            trafficCar2.SizeMode = PictureBoxSizeMode.StretchImage;
            trafficCar2.Height = 84;
            trafficCar2.Width = 127;
            trafficCar2.Image = Image.FromFile("C:\\Users\\ozabd\\Desktop\\Robbery Game\\Pictures\\police.png");

            trafficCar2.BackColor = Color.Transparent;


            trafficCar2.SizeMode = PictureBoxSizeMode.StretchImage;

            refPanel[index1_trafficcar2, index2_trafficcar2].Controls.Add(trafficCar2);
        }



        #endregion


        //Game zaman kontrolleri
        #region Time


        //Game
        private TimeSpan _elapsedTime;

        public TimeSpan ElapsedTime
        {
            get
            {
                return _elapsedTime;
            }

            internal set
            {
                _elapsedTime = value;
                ElapsedTimeChanged?.Invoke(this, EventArgs.Empty);
            }

        }


        private Timer _elapsedTimeTimer = new Timer { Interval = 1000 }; //her 1000 ms de bir timer tick olayı tetiklensin şeklinde bir field tanımlaması

        public event EventHandler ElapsedTimeChanged;

        private void ElapsedTimeTimer_Tick(object sender, EventArgs e) //her 1 s de tick olayı gerçekleşsin olayı için bir metod
        {
            ElapsedTime += TimeSpan.FromSeconds(1);   // bu metot ElapsedTime field ına +=1 yapıyor.

        }


        //Tuzak
        private TimeSpan _trapTime;
        public TimeSpan TrapTime
        {
            get
            {
                return _trapTime;
            }
            set
            {
                _trapTime = value;
                TrapTimeChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        private Timer _trapTimeTimer = new Timer { Interval = 1000 };
        public event EventHandler TrapTimeChanged;

        private void TrapTimeTimer_Tick(object sender, EventArgs e)
        {
            TrapTime += TimeSpan.FromSeconds(1);
        }

        private void StartTrapTimer()
        {

            _trapTimeTimer.Start();
        }
        private void StopTrapTimer()
        {

            _trapTimeTimer.Stop();
        }

        #endregion


        //Game start pause end devamediyor ve puan kontrolleri
        #region KeepGoing_Start_End_Pause

        public string Puan()
        {
            return ((GameLevel * (CarHealth + 1) * 500 + (1000 - ElapsedTime.TotalSeconds)).ToString());
        }
        public bool KeepGoing { get; private set; }

        public void Start()
        {
            if (KeepGoing) return; //oyun devam ediyorsa bu metottan çık

            KeepGoing = true;   //oyun devam etmiyor durumunda bunu true yap
            _elapsedTimeTimer.Start();
            MessageBox.Show("oyun basladi");

            CreateCar();
            CreateRandomTrap();
        }

        private bool key = true;
        public void Pause()
        {
            if (key)
            {
                _elapsedTimeTimer.Stop();
                key = false;
                return;
            }
            _elapsedTimeTimer.Start();
            key = true;
            return;
        }

        public void End()
        {
            if (!KeepGoing) return; //oyuna devam etmiyorsa metottan çık
            KeepGoing = false;      //oyuna devam ediyorsa bunu false yap
            MessageBox.Show("oyun bitti");
            _elapsedTimeTimer.Stop();
        }

        #endregion


        //Game sınıfının kurucu fonksiyonu
        #region Constructor
        public Panel[,] refPanel; //gelen panel dizisi referansını tutmak için field
        public Game(Panel[,] carPanel) //constructor Panel olarak bir dizi refernası alıyor çünkü bu taraftan o tarafa araba oluşturmak için kullanılıyor
        {
            refPanel = carPanel; //gelen panel dizisi referansını field'a aktarma işlemi yapılıyor, burada her yerde kullanabileceğiz

            _elapsedTimeTimer.Tick += ElapsedTimeTimer_Tick; //ilk elemanın tick olayına 2. metodu tanımladık

            _trapTimeTimer.Tick += TrapTimeTimer_Tick;
        }
        #endregion
    }
}
