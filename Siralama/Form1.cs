using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Siralama
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Alfabetik sıralama methodu zaten microsoft bizim için yapmış tek yapmamız gerek özelliği açmak.
            listBox1.Sorted = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Listeye textboxtaki yazıyı ekleme
            // Yazılan cümleyi kelimelere ayırma(kelimeler arası boşluk ile ' ') 
            string[] kelimeler = textBox1.Text.Split(' ');
            listBox1.Items.AddRange(kelimeler); //Dizi olduğu için addRange metodu
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //listboxu temizledik.
            listBox1.Items.Clear();

            // Dosyamızı okuyacak.
            StreamReader oku;
            //OpenfileDialog dosya seçme nesnemiz 
            OpenFileDialog file = new OpenFileDialog();
            //Sadece .txt uzantılı dosyaların seçilmesini sağladık.
            file.Filter = "Text Dosyası |*.txt";
            file.Title=("Txt Dosyası Seçme Ekranı");
           //İf ile eğer dosya seçme ekranında kullanıcı iptal ederse hatanın önüne geçmek için
            if (file.ShowDialog() == DialogResult.OK)
            {
                //filename ile dosya yolunu streamreadera gösterdik.
                oku = File.OpenText(file.FileName);
                string yazi;
                // Satır boş olana kadar okumaya devam eder.
                //Döngü ile satıt okuma
                while ((yazi = oku.ReadLine()) != null)
                {
                    // Listbox'ı .txt içeriği ile doldur.
                    listBox1.Items.Add(yazi.ToString());
                }

                // Okumayı kapat.
                oku.Close();
            }

         
      
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //savefiledialog tanımladık böylece kaydetme penceresi açılacak.
            SaveFileDialog savefile = new SaveFileDialog();
            //sadece .txt olarak kaydedilsin.
            savefile.Filter = "Text Dosyası |*.txt";
            if (savefile.ShowDialog() == DialogResult.OK)
            {
               
                StreamWriter yaz = new StreamWriter(savefile.FileName);
                //döngü ile tek tek yazma.
                for(int i=0;i<listBox1.Items.Count;i++)
                {
                    yaz.WriteLine(listBox1.Items[i].ToString());
                }
                //ve kaydedip kapatma.
                yaz.Close();
              
            }
          
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear(); //Listboxu temizle
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listBox1.Items.RemoveAt(listBox1.SelectedIndex); //Seçili olan elemanı sil
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblsay.Text = listBox1.Items.Count.ToString(); //Toplam Kayıt
        }
    }
}
