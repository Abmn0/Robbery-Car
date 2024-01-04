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
using System;

namespace Robbery.Library.Interface

{
    internal interface IGame
    {

        #region Methods
        void Start(); //başlat
        void End(); // bitir
        void Pause(); //durdur ve pause ekranını göster
        void CreateCar(); //araç oluştur
        void MoveCar(Directions direction); //araç hareketlerinin yönetimi
        void CreateRandomTrap(); //rastgele 10 tuzak
        void CreateRandomAirTrap(); //rastgele hava saldırısı
        void CreateRandomGift(); // rastgele hediye
        void LevelControl(); //seviye kontrol


        #endregion

        event EventHandler ElapsedTimeChanged;


        


        #region Properties

        bool KeepGoing //oyunun devam edip etmediğini tutmak için property
        {  
            get;
        }

        TimeSpan ElapsedTime //geçen süreyi tutmak için property
        {
            get; 
        }


        #endregion


    }
}
