using Platforma_Educationala.Helpers;
using Platforma_Educationala.MVVM.Model.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platforma_Educationala.MVVM.ViewModel
{
    class ShowAverageMarksVM:ObservableObject
    {
        private ObservableCollection<Tuple<Subject, double>> averagemarks;
        public ObservableCollection<Tuple<Subject, double>> AverageMarks
        {
            get
            {
                return averagemarks;
            }

            set
            {
                averagemarks = value;
                NotifyPropertyChanged("AverageMarks");
            }
        }

        private double averagemarkSem1;
        public double AverageMarkSem1
        {
            get
            {
                return averagemarkSem1;
            }

            set
            {
                averagemarkSem1 = value;
                NotifyPropertyChanged("AverageMarkSem1");
            }
        }

        private double averagemarkSem2;
        public double AverageMarkSem2
        {
            get
            {
                return averagemarkSem2;
            }

            set
            {
                averagemarkSem2 = value;
                NotifyPropertyChanged("AverageMarkSem2");
            }
        }
    }
}
