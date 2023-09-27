using Platforma_Educationala.Helpers;
using Platforma_Educationala.MVVM.Model.BusinessLogicLayer;
using Platforma_Educationala.MVVM.Model.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Platforma_Educationala.MVVM.ViewModel
{
    class MenuAbsencesTeacherVM : ObservableObject
    {

        public TeacherMenuBLL teacherBLL { get; set; }
        private ObservableCollection<Tuple<Subject, string>> subjects;
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

        private ObservableCollection<Attendence> attendences;
        public ObservableCollection<Attendence> Attendences
        {
            get
            {
                return attendences;
            }
            set
            {
                attendences = value;
                NotifyPropertyChanged("Attendences");
            }
        }

        private Subject subjectSelected;
        public Subject SubjectSelected
        {
            get
            {
                return subjectSelected;
            }
            set
            {
                subjectSelected = value;
                NotifyPropertyChanged("SubjectSelected");
            }
        }

        private Student studentSelected;
        public Student StudentSelected
        {
            get
            {
                return studentSelected;
            }
            set
            {
                studentSelected = value;
                NotifyPropertyChanged("StudentSelected");
            }
        }

        private ICommand getStudentsCommand;
        public ICommand GetStudentsCommand
        {
            get
            {
                getStudentsCommand = new RelayCommand<Subject>(subject =>
                {
                    SubjectSelected = subject;
                    Students = teacherBLL.GetStudentsforSubject(SubjectSelected);
                });
                return getStudentsCommand;
            }
        }

        private ICommand getAttendenceCommand;
        public ICommand GetAttendenceCommand
        {
            get
            {
                getAttendenceCommand = new RelayCommand<Student>(student =>
                {
                    StudentSelected = student;
                    if (StudentSelected != null && SubjectSelected != null)
                        Attendences = teacherBLL.GetStudentAbsencesforSubject(StudentSelected, SubjectSelected);
                });
                return getAttendenceCommand;
            }
        }

        private ICommand addCommand;
        public ICommand AddCommand
        {
            get
            {
                addCommand = new RelayCommand<Attendence>(o =>
                {
                    if (o == null || o.DateTime == null || o.Status == null ||
                        o.StudentID == null || o.SubjectID == null)
                    {
                        MessageBox.Show("Campurile nu sunt completate", "Error", MessageBoxButton.OK);
                        return;
                    }
                    teacherBLL.InsertAttendence(o);
                    Attendences = teacherBLL.GetStudentAbsencesforSubject(StudentSelected, SubjectSelected);
                });
                return addCommand;
            }
        }

        private ICommand motivateCommand;
        public ICommand MotivateCommand
        {
            get
            {
                motivateCommand = new RelayCommand<Attendence>(o =>
                {
                    if (o == null)
                    {
                        MessageBox.Show("Nicio absenta selectata!", "Error", MessageBoxButton.OK);
                        return;
                    }
                    if (o.Status == "Nemotivabila")
                    {
                        MessageBox.Show("Absenta nemotivabila!", "Error", MessageBoxButton.OK);
                        return;
                    }
                    if (o.Status == "Motivata")
                    {
                        MessageBox.Show("Absenta deja motivata!", "Error", MessageBoxButton.OK);
                        return;
                    }
                    o.Motivated=true;
                    o.Motivable = true;
                    teacherBLL.ModifyAttendence(o);
                    Attendences = teacherBLL.GetStudentAbsencesforSubject(StudentSelected, SubjectSelected);
                });
                return motivateCommand;
            }
        }
    }



}
