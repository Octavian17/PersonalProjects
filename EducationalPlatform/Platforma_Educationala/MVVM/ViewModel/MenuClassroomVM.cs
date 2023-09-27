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
    class MenuClassroomVM : ObservableObject
    {
        public AdminMenuBLL Admin { get; set; }
        private ObservableCollection<Tuple<Classroom, string>> classrooms;
        public ObservableCollection<Tuple<Classroom, string>> Classrooms
        {
            get
            {
                return classrooms;
            }

            set
            {
                classrooms = value;
                NotifyPropertyChanged("Classrooms");
            }
        }

        private ObservableCollection<Tuple<Teacher, string>> classmasters;
        public ObservableCollection<Tuple<Teacher, string>> Classmasters
        {
            get
            {
                return classmasters;
            }

            set
            {
                classmasters = value;
                NotifyPropertyChanged("Classmasters");
            }
        }

        private ICommand addClassroom;
        public ICommand AddClassroom
        {
            get
            {
                if (addClassroom == null)
                {
                    addClassroom = new RelayCommand<MenuClassroomView>(window =>
                    {
                        if (!(VerifyInsert(window) && (window.grid.SelectedItem as Tuple<Classroom,string>) == null))
                            return;
                        Classroom classroom = new Classroom()
                        {
                            Grade = window.grade.Text,
                            Specialization = window.specialization.Text,
                            Classmaster = (window.classMaster.SelectedItem as Tuple<Teacher, string>).Item1.TeacherID
                        };
                        Admin.InsertClassroom(classroom);
                        Classrooms = Admin.GetAllClassroomsAndClassmaster();

                    });
                }
                return addClassroom;
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

        private ICommand deleteClassroom;
        public ICommand DeleteClassroom
        {
            get
            {
                if (deleteClassroom == null)
                {
                    deleteClassroom = new RelayCommand<object>(grid =>
                    {
                        Admin.DeleteClassroom(((grid as DataGrid).SelectedItem as Tuple<Classroom,string>).Item1);
                        Classrooms = Admin.GetAllClassroomsAndClassmaster();
                    });
                }
                return deleteClassroom;
            }

        }

        private ICommand modifyClassroom;
        public ICommand ModifyClassroom
        {
            get
            {
                if (modifyClassroom == null)
                {
                    modifyClassroom = new RelayCommand<MenuClassroomView>(window =>
                    {
                        if (window.grid.SelectedItem as Tuple<Classroom, string> == null)
                            return;
                        Classroom classroom = new Classroom()
                        {
                            ClassroomID = (window.grid.SelectedItem as Tuple<Classroom, string>).Item1.ClassroomID,
                            Grade = window.grade.Text,
                            Specialization = window.specialization.Text,
                            Classmaster = (window.classMaster.SelectedItem as Tuple<Teacher, string>).Item1.TeacherID
                        };
                        Admin.ModifyClassroom(classroom);
                        Classrooms = Admin.GetAllClassroomsAndClassmaster();
                    });
                }
                return modifyClassroom;
            }

        }

        private bool VerifyInsert(MenuClassroomView window)
        {
            if (window.grade.Text != "" &&
                window.classMaster.Text != "" &&
                window.specialization.Text != "")
                return true;
            return false;
        }

    }
}
