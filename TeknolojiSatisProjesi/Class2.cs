using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeknolojiSatisProjesi
{
    class Dugum2
    {
        public string veri;
        public Dugum2 onceki;
        public Dugum2 sonraki;
        public Dugum2 ozellikler;

        public Dugum2(string veri)
        {
            this.veri = veri;
            this.onceki = null;
            this.sonraki = null;
            this.ozellikler = null;
        }
    }

    class Liste2
    {
        public Dugum2 bas;
        public Dugum2 son;

        public Liste2()
        {
            this.bas = null;
            this.son = null;
        }

        public void DugumEkle(string veri, string ozellik_1, string ozellik_2, string ozellik_3, string ozellik_4, string ozellik_5, string ozellik_6, string ozellik_7, string ozellik_8, string ozellik_9, string ozellik_10)
        {
            Dugum2 yeniDugum2 = new Dugum2(veri);
            Dugum2 yeniOzelliklerDugum1 = new Dugum2(ozellik_1);
            Dugum2 yeniOzelliklerDugum2 = new Dugum2(ozellik_2);
            Dugum2 yeniOzelliklerDugum3 = new Dugum2(ozellik_3);
            Dugum2 yeniOzelliklerDugum4 = new Dugum2(ozellik_4);
            Dugum2 yeniOzelliklerDugum5 = new Dugum2(ozellik_5);
            Dugum2 yeniOzelliklerDugum6 = new Dugum2(ozellik_6);
            Dugum2 yeniOzelliklerDugum7 = new Dugum2(ozellik_7);
            Dugum2 yeniOzelliklerDugum8 = new Dugum2(ozellik_8);
            Dugum2 yeniOzelliklerDugum9 = new Dugum2(ozellik_9);
            Dugum2 yeniOzelliklerDugum10 = new Dugum2(ozellik_10);


            if (bas == null)
            {
                bas = yeniDugum2;
                son = yeniDugum2;
            }
            else
            {
                son.sonraki = yeniDugum2;
                yeniDugum2.onceki = son;
                son = yeniDugum2;
            }
            son.ozellikler = yeniOzelliklerDugum1;

            yeniOzelliklerDugum1.veri = ozellik_1;
            yeniOzelliklerDugum1.ozellikler = yeniOzelliklerDugum2;

            yeniOzelliklerDugum2.veri = ozellik_2;
            yeniOzelliklerDugum2.ozellikler = yeniOzelliklerDugum3;

            yeniOzelliklerDugum3.veri = ozellik_3;
            yeniOzelliklerDugum3.ozellikler = yeniOzelliklerDugum4;

            yeniOzelliklerDugum4.veri = ozellik_4;
            yeniOzelliklerDugum4.ozellikler = yeniOzelliklerDugum5;

            yeniOzelliklerDugum5.veri = ozellik_5;
            yeniOzelliklerDugum5.ozellikler = yeniOzelliklerDugum6;

            yeniOzelliklerDugum6.veri = ozellik_6;
            yeniOzelliklerDugum6.ozellikler = yeniOzelliklerDugum7;

            yeniOzelliklerDugum7.veri = ozellik_7;
            yeniOzelliklerDugum7.ozellikler = yeniOzelliklerDugum8;

            yeniOzelliklerDugum8.veri = ozellik_8;
            yeniOzelliklerDugum8.ozellikler = yeniOzelliklerDugum9;

            yeniOzelliklerDugum9.veri = ozellik_9;
            yeniOzelliklerDugum9.ozellikler = yeniOzelliklerDugum10;

            yeniOzelliklerDugum10.veri = ozellik_10;
            yeniOzelliklerDugum10.ozellikler = yeniDugum2;
        }

        public void DugumSil(string veri)
        {
            Dugum2 currentDugum = bas;

            while (currentDugum != null)
            {
                if (currentDugum.veri == veri)
                {
                    if (currentDugum == bas)
                    {
                        bas = currentDugum.sonraki;
                        if (bas != null)
                        {
                            bas.onceki = null;
                        }
                    }
                    else if (currentDugum == son)
                    {
                        son = currentDugum.onceki;
                        if (son != null)
                        {
                            son.sonraki = null;
                        }
                    }
                    else
                    {
                        currentDugum.onceki.sonraki = currentDugum.sonraki;
                        currentDugum.sonraki.onceki = currentDugum.onceki;
                    }
                    break;
                }
                currentDugum = currentDugum.sonraki;
            }
        }

        public void DugumSilByValue()
        {
            Console.WriteLine("Lütfen silmek istediğiniz düğümün değerini giriniz: ");
            //string deger = Console.ReadLine();
            //DugumSil(deger);
        }

        public string DugumleriGoster()
        {
            string dugumler = "";

            Dugum2 currentDugum = bas;
            Dugum2 currentDugum2 = currentDugum;

            while (currentDugum != null)
            {
                dugumler += currentDugum.veri;
                dugumler += " : ";
                for (int i = 1; i <= 10; i++)
                {
                    currentDugum = currentDugum.ozellikler;
                    dugumler += currentDugum.veri;
                    dugumler += " : ";
                }
                dugumler += "\n";
                currentDugum = currentDugum2.sonraki;
                currentDugum2 = currentDugum2.sonraki;
            }
            return dugumler;
        }
    }
}
