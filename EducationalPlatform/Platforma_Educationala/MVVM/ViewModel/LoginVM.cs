using Platforma_Educationala.Helpers;
using Platforma_Educationala.MVVM.Model.BusinessLogicLayer;
using Platforma_Educationala.MVVM.Model.EntityLayer;
using Platforma_Educationala.MVVM.View;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace Platforma_Educationala.MVVM.ViewModel
{
    class LoginVM
    {

        public string ChosenMode { get; set; }

        LoginBLL loginBLL = new LoginBLL();

        private ICommand loginCommand;
        public ICommand LoginCommand
        {
            get
            {
                if (loginCommand == null)
                {
                    loginCommand = new RelayCommand<LoginView>(Logging);
                }
                return loginCommand;
            }
        }

        private void Logging(LoginView window)
        {
            string email = window.txtemail.Text;
            string password = window.txtpassword.Password;
            switch (ChosenMode)
            {
                case "1":
                    if (email == "Admin" && password == "123")
                    {         
                        window.Close();
                        AdminView adminView = new AdminView();
                        adminView.ShowDialog();
                    }
                    else MessageBox.Show("Email si/sau parola gresite!", "Avertizare", MessageBoxButton.OK, MessageBoxImage.Warning);
                    break;

                case "2":
                    Teacher classMaster = loginBLL.VerifyLoginClassMaster(email, password);
                    if (classMaster.TeacherID!=null)
                    {                        
                        window.Close();
                        ClassMasterView classMasterView = new ClassMasterView();
                        classMasterView.ShowDialog();
                    }
                    else MessageBox.Show("Email si/sau parola gresite!", "Avertizare", MessageBoxButton.OK, MessageBoxImage.Warning);
                    break;

                case "3":
                    Teacher teacher = loginBLL.VerifyLoginTeacher(email, password);
                    if (teacher.TeacherID!=null)
                    {                        
                        window.Close();
                        ProfessorView professorView = new ProfessorView();
                        (professorView.DataContext as ProfessorVM).Teacher = teacher;
                        professorView.ShowDialog();
                    }
                    else MessageBox.Show("Email si/sau parola gresite!", "Avertizare", MessageBoxButton.OK, MessageBoxImage.Warning);
                    break;

                case "4":
                    Student student = loginBLL.VerifyLoginStudent(email, password);
                    if (student.StudentID!=null)
                    {                        
                        window.Close();
                        StudentView studentView = new StudentView();
                        (studentView.DataContext as StudentVM).Student = student;
                        studentView.ShowDialog();
                    }
                    else MessageBox.Show("Email si/sau parola gresite!", "Avertizare", MessageBoxButton.OK, MessageBoxImage.Warning);
                    break;
            }
        }
    }
}
