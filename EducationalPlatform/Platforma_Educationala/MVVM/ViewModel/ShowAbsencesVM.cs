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
    class ShowAbsencesVM:ObservableObject
    {
        private ObservableCollection<Tuple<Subject, Attendence>> absences;
        public ObservableCollection<Tuple<Subject, Attendence>> Absences
        {
            get
            {
                return absences;
            }

            set
            {
                absences = value;
                NotifyPropertyChanged("Absences");
            }
        }
    }
}
