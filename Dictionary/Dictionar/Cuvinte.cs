using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace Dictionar
{
    class Cuvinte : INotifyPropertyChanged
    {
        private ObservableCollection<string> listaCuvinte = new ObservableCollection<string>();
        public ObservableCollection<string> ListaCuvinte
        {
            get
            {
                return listaCuvinte;
            }
            set
            {
                listaCuvinte = value;
                NotifyPropertyChanged("ListaCuvinte");
            }
        }
        private ObservableCollection<string> listaCategorii = new ObservableCollection<string>();
        public ObservableCollection<string> ListaCategorii
        {
            get
            {
                return listaCategorii;
            }
            set
            {
                listaCategorii = value;
                NotifyPropertyChanged("ListaCategorii");
            }
        }
        private ObservableCollection<string> listaDescrieri = new ObservableCollection<string>();
        public ObservableCollection<string> ListaDescrieri
        {
            get
            {
                return listaDescrieri;
            }
            set
            {
                listaDescrieri = value;
                NotifyPropertyChanged("ListaDescrieri");
            }
        }
        private ObservableCollection<string> listaToateCategoriile = new ObservableCollection<string>();
        public ObservableCollection<string> ListaToateCategoriile
        {
            get
            {
                return listaToateCategoriile;
            }
            set
            {
                listaToateCategoriile = value;
                NotifyPropertyChanged("ListaToateCategoriile");
            }
        }
        private ObservableCollection<string> listaImagini = new ObservableCollection<string>();
        public ObservableCollection<string> ListaImagini
        {
            get
            {
                return listaImagini;
            }
            set
            {
                listaImagini = value;
                NotifyPropertyChanged("ListaImagini");
            }
        }
        public Cuvinte()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:/Users/Octavian/Desktop/mvp/Dictionar/Dictionar/bin/Debug/cuvinte.txt");

            foreach (string line in lines)
            {
                string[] words = line.Split(' ');
                ListaCuvinte.Add(words[0]);
                if(!ListaCategorii.Contains(words[1]))
                    ListaCategorii.Add(words[1]);
                ListaToateCategoriile.Add(words[1]);
                ListaDescrieri.Add(words[2]);
                ListaImagini.Add(words[3]);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
