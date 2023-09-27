using Platforma_Educationala.Helpers;
using Platforma_Educationala.MVVM.Model.BusinessLogicLayer;
using Platforma_Educationala.MVVM.Model.EntityLayer;
using Platforma_Educationala.MVVM.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Platforma_Educationala.MVVM.ViewModel
{
    class StudentVM : ObservableObject
    {
        private Student student;
        public Student Student
        {
            get
            {
                return student;
            }
            set
            {
                student = value;
                NotifyPropertyChanged("Student");
            }
        }

        StudentMenuBLL studentMenu = new StudentMenuBLL();

        private ICommand marksCommand;
        public ICommand MarksCommand
        {
            get
            {
                if (marksCommand == null)
                {
                    marksCommand = new RelayCommand<object>(o =>
                    {
                        ShowMarksView marks = new ShowMarksView();
                        (marks.DataContext as ShowMarksVM).Marks = studentMenu.GetMarksforStudent(student);
                        marks.ShowDialog();
                    });
                }
                return marksCommand;
            }
        }

        private ICommand absencesCommand;
        public ICommand AbsencesCommand
        {
            get
            {
                if (absencesCommand == null)
                {
                    absencesCommand = new RelayCommand<object>(o =>
                    {
                        ShowAbsencesView absences = new ShowAbsencesView();
                        (absences.DataContext as ShowAbsencesVM).Absences = studentMenu.GetAbsencesforStudent(student);
                        absences.ShowDialog();
                    });
                }
                return absencesCommand;
            }
        }

        private ICommand averageMarksCommand;
        public ICommand AverageMarksCommand
        {
            get
            {
                if (averageMarksCommand == null)
                {
                    averageMarksCommand = new RelayCommand<object>(o =>
                    {
                        ShowAverageMarksView marks = new ShowAverageMarksView();
                        (marks.DataContext as ShowAverageMarksVM).AverageMarks = studentMenu.GetAverageMarks(student);
                        (marks.DataContext as ShowAverageMarksVM).AverageMarkSem1 = studentMenu.finalAverageSemOne;
                        (marks.DataContext as ShowAverageMarksVM).AverageMarkSem2 = studentMenu.finalAverageSemTwo;
                        marks.ShowDialog();
                    });
                }
                return averageMarksCommand;
            }
        }

        private ICommand materialsCommand;
        public ICommand MaterialsCommand
        {
            get
            {
                if (materialsCommand == null)
                {
                    materialsCommand = new RelayCommand<object>(o =>
                    {
                        ShowMaterialsView materials = new ShowMaterialsView();
                        (materials.DataContext as ShowMaterialsVM).Materials = studentMenu.GetMaterials(student);
                        materials.ShowDialog();
                    });
                }
                return materialsCommand;
            }
        }
    }
}
