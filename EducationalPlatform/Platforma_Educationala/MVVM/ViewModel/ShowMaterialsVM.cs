using Platforma_Educationala.Helpers;
using Platforma_Educationala.MVVM.Model.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Platforma_Educationala.MVVM.ViewModel
{
    class ShowMaterialsVM : ObservableObject
    {
        private ObservableCollection<Tuple<Subject, ClassroomSubjectTeacher>> materials;
        public ObservableCollection<Tuple<Subject, ClassroomSubjectTeacher>> Materials
        {
            get
            {
                return materials;
            }

            set
            {
                materials = value;
                NotifyPropertyChanged("Materials");
            }
        }

        private ICommand openMaterial;
        public ICommand OpenMaterial
        {
            get
            {
                if (openMaterial == null)
                {
                    openMaterial = new RelayCommand<object>(Open);

                }
                return openMaterial;
            }
        }

        private void Open(object obj)
        {
            string path = obj as string;
            if (path != null)
                System.Diagnostics.Process.Start(path);
        }
    }
}
