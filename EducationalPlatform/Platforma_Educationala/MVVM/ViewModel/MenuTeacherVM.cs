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
    class MenuTeacherVM:ObservableObject
    {
        public AdminMenuBLL Admin { get; set; }
        private ObservableCollection<Teacher> teachers;
        public ObservableCollection<Teacher> Teachers
        {
            get
            {
                return teachers;
            }

            set
            {
                teachers = value;
                NotifyPropertyChanged("Teachers");
            }
        }

        private ICommand addTeacher;
        public ICommand AddTeacher
        {
            get
            {
                if (addTeacher == null)
                {
                    addTeacher = new RelayCommand<MenuTeacherView>(window =>
                    {
                        if (!(VerifyInsert(window) && (window.grid.SelectedItem as Teacher) == null))
                            return;
                        Teacher teacher = new Teacher()
                        {
                            Email = window.email.Text,
                            Password = window.password.Text,
                            FirstName = window.firstName.Text,
                            LastName = window.lastName.Text,
                            Phone = window.phone.Text,                            
                        };
                        Admin.InsertTeacher(teacher);                      
                        Teachers = Admin.GetAllTeachers();

                    });
                }
                return addTeacher;
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

        private ICommand deleteTeacher;
        public ICommand DeleteTeacher
        {
            get
            {
                if (deleteTeacher == null)
                {
                    deleteTeacher = new RelayCommand<object>(grid =>
                    {
                        Admin.DeleteTeacher(((grid as DataGrid).SelectedItem as Teacher));
                        Teachers = Admin.GetAllTeachers();
                    });
                }
                return deleteTeacher;
            }

        }

        private ICommand modifyTeacher;
        public ICommand ModifyTeacher
        {
            get
            {
                if (modifyTeacher == null)
                {
                    modifyTeacher = new RelayCommand<MenuTeacherView>(window =>
                    {
                        if (window.grid.SelectedItem as Teacher == null)
                            return;
                        Teacher teacher = new Teacher()
                        {
                            TeacherID = (window.grid.SelectedItem as Teacher).TeacherID,
                            Email = window.email.Text,
                            Password = window.password.Text,
                            FirstName = window.firstName.Text,
                            LastName = window.lastName.Text,
                            Phone = window.phone.Text,                            
                        };
                        Admin.ModifyTeacher(teacher);
                        Teachers = Admin.GetAllTeachers();
                    });
                }
                return modifyTeacher;
            }

        }

        private bool VerifyInsert(MenuTeacherView window)
        {
            if (window.email.Text != "" &&
                window.password.Text != "" &&
                window.firstName.Text != "" &&
                window.lastName.Text != "" &&
                window.phone.Text != "")
                return true;
            return false;
        }
    }

}
