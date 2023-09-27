using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;



namespace Dictionar
{
    class Cuvant: INotifyPropertyChanged
    {
        public Cuvinte Cuvinte { get; set; }
        public Cuvant()
        {
            Cuvinte = new Cuvinte();
        }
        private string cuv;
        public string Cuv{
            get
            {
                return cuv;
            }
            set
            {
                cuv = value;
                NotifyPropertyChanged("Cuv");
            }
        }

        private string categorie;
        
        public string Categorie {
            get
            {
                return categorie;
            }
            set
            {
                categorie = value;
                NotifyPropertyChanged("Categorie");
            }
        }
        private string descriere;
        public string Descriere{
            get
            {
                return descriere;
            }
            set
            {
                descriere = value;
                NotifyPropertyChanged("Descriere");
            }
        }

        private string imagine;
        public string Imagine
        {
            get
            {
                return imagine;
            }
            set
            {
                imagine = value;
                NotifyPropertyChanged("Imagine");
            }
        }

        private string cuvExistent = null;
        public string CuvExistent
        {
            get
            {
                return cuvExistent;
            }
            set
            {
                cuvExistent = value;
                NotifyPropertyChanged("CuvExistent");
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
