using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace Dictionar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Adauga(object sender, RoutedEventArgs e)
        {
            if ((DataContext as Cuvant).Cuvinte.ListaCuvinte.Contains(text1.Text))
            {
                (DataContext as Cuvant).CuvExistent = "!!!";
                return;
            }
            else
                (DataContext as Cuvant).Cuvinte.ListaCuvinte.Add(text1.Text);
            string c;
            if ((DataContext as Cuvant).Cuvinte.ListaCategorii != null && (DataContext as Cuvant).Cuvinte.ListaCategorii.Contains(text2.Text))
            {
                c = (DataContext as Cuvant).Cuvinte.ListaCategorii.ElementAt((DataContext as Cuvant).Cuvinte.ListaCategorii.IndexOf(text2.Text));
            }
            else
            {
                (DataContext as Cuvant).Cuvinte.ListaCategorii.Add(text2.Text);
                c = text2.Text;
            }

            (DataContext as Cuvant).Cuvinte.ListaToateCategoriile.Add(c);
            (DataContext as Cuvant).Cuvinte.ListaDescrieri.Add(text3.Text);
            if (img.Text != null)
                (DataContext as Cuvant).Cuvinte.ListaImagini.Add(img.Text);
            


            using (StreamWriter w = new StreamWriter(@"cuvinte.txt", true))
            {
                    string test = text1.Text+" "+c+" "+text3.Text+" "+img.Text;
                    w.WriteLine(test);
            }
            
        }

        private void Sterge(object sender, RoutedEventArgs e)
        {
            (DataContext as Cuvant).Cuvinte.ListaCuvinte.Remove(Sterg.Text);

            List<string> lines = System.IO.File.ReadAllLines(@"C:/Users/Octavian/Desktop/mvp/Dictionar/Dictionar/bin/Debug/cuvinte.txt").ToList();
            int x=0;
            for(int i=0;i<lines.Count;i++)
            {
                string[] words = lines[i].Split(' ');
                if(words[0]==Sterg.Text)
                {
                    x = i;
                    break;
                }   
            }
            lines.RemoveAt(x);
            File.WriteAllLines(@"C:/Users/Octavian/Desktop/mvp/Dictionar/Dictionar/bin/Debug/cuvinte.txt", lines);

            string[] line = System.IO.File.ReadAllLines(@"C:/Users/Octavian/Desktop/mvp/Dictionar/Dictionar/bin/Debug/cuvinte.txt");
            (DataContext as Cuvant).Cuvinte.ListaCuvinte.Clear();
            (DataContext as Cuvant).Cuvinte.ListaCategorii.Clear();
            (DataContext as Cuvant).Cuvinte.ListaDescrieri.Clear();
            (DataContext as Cuvant).Cuvinte.ListaImagini.Clear();
            (DataContext as Cuvant).Cuvinte.ListaToateCategoriile.Clear();
            foreach (string l in line)
            {
                string[] words = l.Split(' ');
                (DataContext as Cuvant).Cuvinte.ListaCuvinte.Add(words[0]);
                if(!(DataContext as Cuvant).Cuvinte.ListaCategorii.Contains(words[1]))
                    (DataContext as Cuvant).Cuvinte.ListaCategorii.Add(words[1]);
                (DataContext as Cuvant).Cuvinte.ListaToateCategoriile.Add(words[1]);
                (DataContext as Cuvant).Cuvinte.ListaDescrieri.Add(words[2]);
                (DataContext as Cuvant).Cuvinte.ListaImagini.Add(words[3]);
            }
        }
        private void Modifica(object sender, RoutedEventArgs e)
        {
            int pozitie = (DataContext as Cuvant).Cuvinte.ListaCuvinte.IndexOf(Modific.Text);
            (DataContext as Cuvant).Cuvinte.ListaDescrieri[pozitie]= DescriereNoua.Text;
            (DataContext as Cuvant).Cuvinte.ListaToateCategoriile[pozitie] = CategorieNoua.Text;
            if(!(DataContext as Cuvant).Cuvinte.ListaCategorii.Contains(CategorieNoua.Text))
            {
                (DataContext as Cuvant).Cuvinte.ListaCategorii.Add(CategorieNoua.Text);
            }

            string[] lines=new string[(DataContext as Cuvant).Cuvinte.ListaCuvinte.Count];
            for (int i = 0; i < (DataContext as Cuvant).Cuvinte.ListaCuvinte.Count; i++)
            {
                lines[i] += (DataContext as Cuvant).Cuvinte.ListaCuvinte[i] + " " + (DataContext as Cuvant).Cuvinte.ListaToateCategoriile[i] + " "
                    + (DataContext as Cuvant).Cuvinte.ListaDescrieri[i]+" "+ (DataContext as Cuvant).Cuvinte.ListaImagini[i];
            }
            File.WriteAllLines(@"C:/Users/Octavian/Desktop/mvp/Dictionar/Dictionar/bin/Debug/cuvinte.txt", lines);
        }

        private void Cauta(object sender, RoutedEventArgs e)
        {
            Cautare cauta = new Cautare();
            cauta.Show();
        }

        private void SelectareImagine(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "(*.png)|*.png|(*.jpg)|*.jpg";
            if (openFileDialog.ShowDialog() == true)
                img.Text = System.IO.Path.GetFullPath(openFileDialog.FileName);
            
        }

        private void Joc(object sender, RoutedEventArgs e)
        {
            Joc joc = new Joc();
            joc.Show();
        }
    }
}
