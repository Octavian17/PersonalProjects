using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Platforma_Educationala.Helpers;
using Platforma_Educationala.MVVM.Model.BusinessLogicLayer;
using Platforma_Educationala.MVVM.Model.EntityLayer;

namespace Platforma_Educationala.MVVM.ViewModel
{
    class ShowMarksVM:ObservableObject
    {

        private ObservableCollection<Tuple<Subject, Mark>> marks;
        public ObservableCollection<Tuple<Subject, Mark>> Marks
        {
            get
            {
                return marks;
            }

            set
            {
                marks = value;
                NotifyPropertyChanged("Marks");
            }
        }
    }
}
