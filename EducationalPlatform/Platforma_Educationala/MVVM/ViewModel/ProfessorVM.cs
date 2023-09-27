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
    class ProfessorVM:ObservableObject
    {
        TeacherMenuBLL teacherBLL = new TeacherMenuBLL();

        private Teacher teacher;
        public Teacher Teacher
        {
            get
            {
                return teacher;
            }
            set
            {
                teacher = value;
                NotifyPropertyChanged("Teacher");
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
                        MenuAbsencesTeacherView absences = new MenuAbsencesTeacherView();
                        (absences.DataContext as MenuAbsencesTeacherVM).Subjects = teacherBLL.GetSubjectsForTeacher(teacher);
                        (absences.DataContext as MenuAbsencesTeacherVM).teacherBLL = teacherBLL;
                        absences.ShowDialog();
                    });
                }
                return absencesCommand;
            }

        }
    }
}
