using Platforma_Educationala.Helpers;
using Platforma_Educationala.MVVM.Model.BusinessLogicLayer;
using Platforma_Educationala.MVVM.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Platforma_Educationala.MVVM.ViewModel
{
    class AdminVM
    {
        AdminMenuBLL admin = new AdminMenuBLL();
        private ICommand menuStudentCommand;
        public ICommand MenuStudentCommand
        {
            get
            {
                if (menuStudentCommand == null)
                {
                    menuStudentCommand = new RelayCommand<object>(o =>
                    {
                        MenuStudentView student = new MenuStudentView();
                        (student.DataContext as MenuStudentVM).Students = admin.GetAllStudentsAndClassroom();
                        (student.DataContext as MenuStudentVM).Classes = admin.GetAllClassrooms();
                        (student.DataContext as MenuStudentVM).Admin = admin;
                        student.ShowDialog();
                    });
                }
                return menuStudentCommand;
            }
        }

        private ICommand menuTeacherCommand;
        public ICommand MenuTeacherCommand
        {
            get
            {
                if (menuTeacherCommand == null)
                {
                    menuTeacherCommand = new RelayCommand<object>(o =>
                    {
                        MenuTeacherView teacher = new MenuTeacherView();
                        (teacher.DataContext as MenuTeacherVM).Teachers = admin.GetAllTeachers();                        
                        (teacher.DataContext as MenuTeacherVM).Admin = admin;
                        teacher.ShowDialog();
                    });
                }
                return menuTeacherCommand;
            }
        }

        private ICommand menuSubjectCommand;
        public ICommand MenuSubjectCommand
        {
            get
            {
                if (menuSubjectCommand == null)
                {
                    menuSubjectCommand = new RelayCommand<object>(o =>
                    {
                        MenuSubjectView subject = new MenuSubjectView();
                        (subject.DataContext as MenuSubjectVM).Subjects = admin.GetAllSubjects();
                        (subject.DataContext as MenuSubjectVM).Admin = admin;
                        subject.ShowDialog();
                    });
                }
                return menuSubjectCommand;
            }
        }

        private ICommand menuClassroomCommand;
        public ICommand MenuClassroomCommand
        {
            get
            {
                if (menuClassroomCommand == null)
                {
                    menuClassroomCommand = new RelayCommand<object>(o =>
                    {
                        MenuClassroomView subject = new MenuClassroomView();
                        (subject.DataContext as MenuClassroomVM).Classrooms = admin.GetAllClassroomsAndClassmaster();
                        (subject.DataContext as MenuClassroomVM).Classmasters = admin.GetAllClassmastersExtendedName();
                        (subject.DataContext as MenuClassroomVM).Admin = admin;
                        subject.ShowDialog();
                    });
                }
                return menuClassroomCommand;
            }
        }

        private ICommand menuRelationsCommand;
        public ICommand MenuRelationsCommand
        {
            get
            {
                if (menuRelationsCommand == null)
                {
                    menuRelationsCommand = new RelayCommand<object>(o =>
                    {
                        MenuRelationsView relations  = new MenuRelationsView();
                        (relations.DataContext as MenuRelationsVM).Relations = admin.GetAllRelationsWithClassSubTeach();
                        (relations.DataContext as MenuRelationsVM).Classes = admin.GetAllClassrooms();
                        (relations.DataContext as MenuRelationsVM).Subjects = admin.GetAllSubjectsExtended();
                        (relations.DataContext as MenuRelationsVM).Teachers = admin.GetAllTeachersExtendedName();                     
                        (relations.DataContext as MenuRelationsVM).Admin = admin;
                        relations.ShowDialog();
                    });
                }
                return menuRelationsCommand;
            }
        }
    }
}
