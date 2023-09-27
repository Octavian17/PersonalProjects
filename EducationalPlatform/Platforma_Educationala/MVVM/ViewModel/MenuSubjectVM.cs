using Platforma_Educationala.Helpers;
using Platforma_Educationala.MVVM.Model.BusinessLogicLayer;
using Platforma_Educationala.MVVM.Model.EntityLayer;
using Platforma_Educationala.MVVM.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Platforma_Educationala.MVVM.ViewModel
{
    class MenuSubjectVM:ObservableObject
    {
        public AdminMenuBLL Admin { get; set; }
        private ObservableCollection<Subject> subjects;
        public ObservableCollection<Subject> Subjects
        {
            get
            {
                return subjects;
            }

            set
            {
                subjects = value;
                NotifyPropertyChanged("Subjects");
            }
        }

        private ICommand addSubject;
        public ICommand AddSubject
        {
            get
            {
                if (addSubject == null)
                {
                    addSubject = new RelayCommand<MenuSubjectView>(window =>
                    {
                        if (!(VerifyInsert(window) && (window.grid.SelectedItem as Subject) == null))
                            return;
                        Subject subject = new Subject()
                        {
                            SubjectName = window.name.Text,
                            Semester=int.Parse(window.semester.Text)                     
                        };
                        Admin.InsertSubject(subject);                        
                        Subjects = Admin.GetAllSubjects();

                    });
                }
                return addSubject;
            }
        }
       

        private ICommand deselect;
        public ICommand Deselect
        {
            get
            {
                if (deselect == null)
                {
                    deselect = new RelayCommand<object>(grid =>
                    {
                        (grid as DataGrid).UnselectAll();
                    });
                }
                return deselect;
            }

        }

        private ICommand deleteSubject;
        public ICommand DeleteSubject
        {
            get
            {
                if (deleteSubject == null)
                {
                    deleteSubject = new RelayCommand<object>(grid =>
                    {
                        Admin.DeleteSubject(((grid as DataGrid).SelectedItem as Subject));
                        Subjects = Admin.GetAllSubjects();
                    });
                }
                return deleteSubject;
            }

        }

        private ICommand modifySubject;
        public ICommand ModifySubject
        {
            get
            {
                if (modifySubject == null)
                {
                    modifySubject = new RelayCommand<MenuSubjectView>(window =>
                    {
                        if (window.grid.SelectedItem as Subject == null)
                            return;
                        Subject subject = new Subject()
                        {
                            SubjectID = (window.grid.SelectedItem as Subject).SubjectID,
                            SubjectName = window.name.Text,
                            Semester = int.Parse(window.semester.Text)
                            
                        };
                        Admin.ModifySubject(subject);
                        Subjects = Admin.GetAllSubjects();
                    });
                }
                return modifySubject;
            }

        }

        private bool VerifyInsert(MenuSubjectView window)
        {
            if (window.name.Text != "" &&
                window.semester.Text != "")                
                return true;
            return false;
        }
    }
}
