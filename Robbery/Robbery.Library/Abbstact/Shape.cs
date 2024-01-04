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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Robbery.Library.Abbstact
{
    internal abstract class Shape : PictureBox
    {
        protected Shape()  // soyut sınıf olduğu için zaten oluşturulamaz, public yapmaya gerek yok
        {
            SizeMode = PictureBoxSizeMode.AutoSize;   //Bazı resim dosyaları oluşturulan picturebox'ın tamamını kaplamayabiliyor. Bu kod sayesinde picturebox boyutu tam olarak resmin boyutu kadar ayarlanıyor.
        }

        
    }
}
