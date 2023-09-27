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
    class MenuStudentVM : ObservableObject
    {
        public AdminMenuBLL Admin { get; set; }
        private ObservableCollection<Tuple<Student, string>> students;
        public ObservableCollection<Tuple<Student, string>> Students
        {
            get
            {
                return students;
            }

            set
            {
                students = value;
                NotifyPropertyChanged("Students");
            }
        }

        private ObservableCollection<Classroom> classes;
        public ObservableCollection<Classroom> Classes
        {
            get
            {
                return classes;
            }
            set
            {
                classes = value;
                NotifyPropertyChanged("Classes");
            }
        }

        private ICommand addStudent;
        public ICommand AddStudent
        {
            get
            {
                if (addStudent == null)
                {
                    addStudent = new RelayCommand<MenuStudentView>(window =>
                    {
                        if (!(VerifyInsert(window) && (window.grid.SelectedItem as Tuple<Student, string>) == null))
                            return;
                        Student student = new Student()
                        {
                            Email = window.email.Text,
                            Password = window.password.Text,
                            FirstName = window.firstName.Text,
                            LastName = window.lastName.Text,
                            Phone = window.phone.Text,
                            ClassroomID = (window.classroom.SelectedItem as Classroom).ClassroomID
                        };
                        Admin.InsertStudent(student);                      
                        Students = Admin.GetAllStudentsAndClassroom();

                    });
                }
                return addStudent;
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

        private ICommand deleteStudent;
        public ICommand DeleteStudent
        {
            get
            {
                if (deleteStudent == null)
                {
                    deleteStudent = new RelayCommand<object>(grid =>
                    {
                        Admin.DeleteStudent(((grid as DataGrid).SelectedItem as Tuple<Student, string>).Item1);
                        Students = Admin.GetAllStudentsAndClassroom();
                    });
                }
                return deleteStudent;
            }

        }

        private ICommand modifyStudent;
        public ICommand ModifyStudent
        {
            get
            {
                if (modifyStudent == null)
                {
                    modifyStudent = new RelayCommand<MenuStudentView>(window =>
                    {
                        if (window.grid.SelectedItem as Tuple<Student, string> == null)
                            return;
                        Student student = new Student()
                        {
                            StudentID = (window.grid.SelectedItem as Tuple<Student, string>).Item1.StudentID,
                            Email = window.email.Text,
                            Password = window.password.Text,
                            FirstName = window.firstName.Text,
                            LastName = window.lastName.Text,
                            Phone = window.phone.Text,
                            ClassroomID = (window.classroom.SelectedItem as Classroom).ClassroomID
                        };
                        Admin.ModifyStudent(student);
                        Students = Admin.GetAllStudentsAndClassroom();
                    });
                }
                return modifyStudent;
            }

        }

        private bool VerifyInsert(MenuStudentView window)
        {
            if (window.email.Text != "" &&
                window.password.Text != "" &&
                window.firstName.Text != "" &&
                window.lastName.Text != "" &&
                window.phone.Text != "" &&
                window.classroom.Text != "")
                return true;
            return false;
        }
    }
}
