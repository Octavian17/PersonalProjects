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
    class MenuRelationsVM:ObservableObject
    {
        public AdminMenuBLL Admin { get; set; }
        private ObservableCollection<Tuple<ClassroomSubjectTeacher, string, string, string>> relations;
        public ObservableCollection<Tuple<ClassroomSubjectTeacher, string, string, string>> Relations
        {
            get
            {
                return relations;
            }

            set
            {
                relations = value;
                NotifyPropertyChanged("Relations");
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

        private ObservableCollection<Tuple<Subject,string>> subjects;
        public ObservableCollection<Tuple<Subject, string>> Subjects
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

        private ObservableCollection<Tuple<Teacher, string>> teachers;
        public ObservableCollection<Tuple<Teacher, string>> Teachers
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

        


        private ICommand addClassroomSubjectTeacher;
        public ICommand AddClassroomSubjectTeacher
        {
            get
            {
                if (addClassroomSubjectTeacher == null)
                {
                    addClassroomSubjectTeacher = new RelayCommand<MenuRelationsView>(window =>
                    {
                        if (!(VerifyInsert(window) && (window.grid.SelectedItem as Tuple<ClassroomSubjectTeacher, string, string, string>) == null))
                            return;
                        ClassroomSubjectTeacher classroomSubjectTeacher = new ClassroomSubjectTeacher()
                        {
                           ClassroomID = (window.classroom.SelectedItem as Classroom).ClassroomID,
                           SubjectID=(window.subject.SelectedItem as Tuple<Subject,string>).Item1.SubjectID,
                           TeacherID=(window.teacher.SelectedItem as Tuple<Teacher,string>).Item1.TeacherID,
                           Material=window.material.Text,
                           MaterialName=window.materialName.Text,
                           Thesis=(bool)window.thesis.IsChecked
                        };
                        Admin.InsertClassroomSubjectTeacher(classroomSubjectTeacher);
                        Relations = Admin.GetAllRelationsWithClassSubTeach();                       
                    });
                }
                return addClassroomSubjectTeacher;
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

        private ICommand deleteClassroomSubjectTeacher;
        public ICommand DeleteClassroomSubjectTeacher
        {
            get
            {
                if (deleteClassroomSubjectTeacher == null)
                {
                    deleteClassroomSubjectTeacher = new RelayCommand<object>(grid =>
                    {
                        Admin.DeleteClassroomSubjectTeacher(((grid as DataGrid).SelectedItem as Tuple<ClassroomSubjectTeacher, string, string, string>).Item1);
                        Relations = Admin.GetAllRelationsWithClassSubTeach();
                    });
                }
                return deleteClassroomSubjectTeacher;
            }

        }

        private ICommand modifyClassroomSubjectTeacher;
        public ICommand ModifyClassroomSubjectTeacher
        {
            get
            {
                if (modifyClassroomSubjectTeacher == null)
                {
                    modifyClassroomSubjectTeacher = new RelayCommand<MenuRelationsView>(window =>
                    {
                        if (window.grid.SelectedItem as Tuple<ClassroomSubjectTeacher, string, string, string> == null)
                            return;
                        ClassroomSubjectTeacher classroomSubjectTeacher = new ClassroomSubjectTeacher()
                        {
                            ClassroomID = (window.classroom.SelectedItem as Classroom).ClassroomID,
                            SubjectID = (window.subject.SelectedItem as Tuple<Subject, string>).Item1.SubjectID,
                            TeacherID = (window.teacher.SelectedItem as Tuple<Teacher, string>).Item1.TeacherID,
                            Material = window.material.Text,
                            MaterialName = window.materialName.Text,
                            Thesis = (bool)window.thesis.IsChecked
                        };
                        Admin.ModifyClassroomSubjectTeacher(classroomSubjectTeacher);
                        Relations = Admin.GetAllRelationsWithClassSubTeach();
                    });
                }
                return modifyClassroomSubjectTeacher;
            }

        }

        private bool VerifyInsert(MenuRelationsView window)
        {
            if (window.classroom.Text != "" &&
                window.subject.Text != "" &&
                window.teacher.Text != "")
                return true;
            return false;
        }
                
    }
}
