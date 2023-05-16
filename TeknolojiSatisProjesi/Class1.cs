using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeknolojiSatisProjesi
{
    class Dugum
    {
        public string veri;
        public Dugum onceki;
        public Dugum sonraki;
        public Dugum ozellikler;

        public Dugum(string veri)
        {
            this.veri = veri;
            this.onceki = null;
            this.sonraki = null;
            this.ozellikler = null;
        }
    }

    class Liste
    {
        public Dugum bas;
        public Dugum son;

        public Liste()
        {
            this.bas = null;
            this.son = null;
        }

        public void DugumEkle(string veri, string ozellik_1, string ozellik_2, string ozellik_3, string ozellik_4, string ozellik_5, string ozellik_6, string ozellik_7, string ozellik_8, string ozellik_9, string ozellik_10)
        {
            Dugum yeniDugum = new Dugum(veri);
            Dugum yeniOzelliklerDugum1 = new Dugum(ozellik_1);
            Dugum yeniOzelliklerDugum2 = new Dugum(ozellik_2);
            Dugum yeniOzelliklerDugum3 = new Dugum(ozellik_3);
            Dugum yeniOzelliklerDugum4 = new Dugum(ozellik_4);
            Dugum yeniOzelliklerDugum5 = new Dugum(ozellik_5);
            Dugum yeniOzelliklerDugum6 = new Dugum(ozellik_6);
            Dugum yeniOzelliklerDugum7 = new Dugum(ozellik_7);
            Dugum yeniOzelliklerDugum8 = new Dugum(ozellik_8);
            Dugum yeniOzelliklerDugum9 = new Dugum(ozellik_9);
            Dugum yeniOzelliklerDugum10 = new Dugum(ozellik_10);


            if (bas == null)
            {
                bas = yeniDugum;
                son = yeniDugum;
            }
            else
            {
                son.sonraki = yeniDugum;
                yeniDugum.onceki = son;
                son = yeniDugum;
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
            yeniOzelliklerDugum10.ozellikler = yeniDugum;
        }

        public void DugumSil(string veri)
        {
            Dugum currentDugum = bas;

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

            Dugum currentDugum = bas;
            Dugum currentDugum2 = currentDugum;

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
