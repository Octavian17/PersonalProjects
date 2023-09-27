using Platforma_Educationala.Helpers;
using Platforma_Educationala.MVVM.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Platforma_Educationala.MVVM.ViewModel
{
    class MainWindowVM:ObservableObject
    {      
        private ICommand openLoginCommand;
        public ICommand OpenLoginCommand
        {
            get
            {
                if (openLoginCommand == null)
                {
                    openLoginCommand = new RelayCommand<object>(OpenLogin);
                }
                return openLoginCommand;
            }
        }
      
        public void OpenLogin(object obj)
        {
            string nr = obj as string;
            LoginView login = new LoginView();
            (login.DataContext as LoginVM).ChosenMode = nr;
            login.ShowDialog();
        }
    }
}
