using System;
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
using System.Windows.Shapes;

namespace Dictionar
{
    /// <summary>
    /// Interaction logic for Joc.xaml
    /// </summary>
    public partial class Joc : Window
    {
      
        Random random = new Random();
        int ApRandom()
        {
            return random.Next(0, 2);
        }

        private int nrCorecte = 0;
        public int NrCorecte
        {
            get
            {
                return nrCorecte;
            }
            set
            {
                nrCorecte = value;
            }
        }

        private int nrIncercari = 0;
        public int NrIncercari
        {
            get
            {
                return nrIncercari;
            }
            set
            {
                nrIncercari = value;
            }
        }
        private int pozitie;
        public int Pozitie
        {
            get
            {
                return pozitie;
            }
            set
            {
                pozitie = value;
            }
        }

        void Aparitie(int x)
        {

            if(x==0)
            {
                pozitie = random.Next((DataContext as Cuvant).Cuvinte.ListaDescrieri.Count);
                desc.Text = (DataContext as Cuvant).Cuvinte.ListaDescrieri[pozitie];
            }
            else
            {
                pozitie = random.Next((DataContext as Cuvant).Cuvinte.ListaImagini.Count);
                if ((DataContext as Cuvant).Cuvinte.ListaImagini[pozitie] == @"C:\Users\Octavian\Desktop\mvp\Dictionar\Dictionar\bin\Debug\NoImage.png")
                
                    desc.Text = (DataContext as Cuvant).Cuvinte.ListaDescrieri[pozitie];
                else
                    img.Source = new BitmapImage(new Uri((DataContext as Cuvant).Cuvinte.ListaImagini[pozitie], UriKind.Absolute));
            }
            if (nrIncercari == 4)
            {
                next.Visibility = Visibility.Collapsed;
                finish.Visibility = Visibility.Visible;
            }
        }
        public Joc()
        {
            InitializeComponent();
            Aparitie(ApRandom());
        }

        private void Next(object sender, RoutedEventArgs e)
        {
            nrIncercari++;
            if (rasp.Text == (DataContext as Cuvant).Cuvinte.ListaCuvinte[pozitie])
            {
                nrCorecte++;
                MessageBox.Show("Corect!");
            }
            else
                MessageBox.Show("Incorect! Varianta corecta este: "+ (DataContext as Cuvant).Cuvinte.ListaCuvinte[pozitie]);
            Aparitie(ApRandom());

        }

        private void Finish(object sender, RoutedEventArgs e)
        {
            nrCorecte++;
            if (nrCorecte == 5)
                MessageBox.Show("Ai ghicit toate cuvintele!");
            else
                MessageBox.Show("Ai ghicit " + nrCorecte + " cuvinte!");
            nrIncercari = 0;
            nrCorecte = 0;
        }
    }
}
