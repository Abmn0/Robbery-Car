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

using Robbery.Library.Abbstact;
using System.Drawing;

namespace Robbery.Library.Concrete
{
    internal class Traps : Shape
    {
        public Traps(Size PanelSizes)
        {
            Left = PanelSizes.Width / 2 - Width / 2;
            Top = PanelSizes.Height / 2 - Height / 2;
        }

    }
}

