using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Dictionar
{
    /// <summary>
    /// Interaction logic for Cautare.xaml
    /// </summary>
    public partial class Cautare : Window
    {
        private List<string> autoSuggestionList = new List<string>();
        public List<string> AutoSuggestionList
        {
            get { return this.autoSuggestionList; }
            set { this.autoSuggestionList = value; }
        }
        private List<string> cuvinteCautare = new List<string>();
        public List<string> CuvinteCautare
        {
            get { return this.cuvinteCautare; }
            set { this.cuvinteCautare= value; }
        }
        private List<string> categoriiCautare = new List<string>();
        public List<string> CategoriiCautare
        {
            get { return this.categoriiCautare; }
            set { this.categoriiCautare = value; }
        }
        private List<string> descrieriCautare = new List<string>();
        public List<string> DescrieriCautare
        {
            get { return this.descrieriCautare; }
            set { this.descrieriCautare = value; }
        }
        public Cautare()
        {
            InitializeComponent();
            AutoSuggestionList = (DataContext as Cuvant).Cuvinte.ListaCuvinte.ToList();
        }

        private void OpenAutoSuggestionBox()
        {
              this.autoListPopup.Visibility = Visibility.Visible;
              this.autoListPopup.IsOpen = true;
              this.autoList.Visibility = Visibility.Visible;
        }
        private void CloseAutoSuggestionBox()
        {              
              this.autoListPopup.Visibility = Visibility.Collapsed;
              this.autoListPopup.IsOpen = false;
              this.autoList.Visibility = Visibility.Collapsed;
        }
        private void AutoTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.autoTextBox.Text))
            {
           
                this.CloseAutoSuggestionBox(); 
                return;
            }

             
            this.OpenAutoSuggestionBox();

         
            this.autoList.ItemsSource = 
                this.AutoSuggestionList.Where(p => p.ToLower().Contains(this.autoTextBox.Text.ToLower())).ToList();
        }
        private void AutoList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        
             
                if (this.autoList.SelectedIndex <= -1)
                {
                    
                    this.CloseAutoSuggestionBox();

                    return;
                }

                 
                this.CloseAutoSuggestionBox();

               
                this.autoTextBox.Text = this.autoList.SelectedItem.ToString();
                this.autoList.SelectedIndex = -1;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            if(SelectCat.Text!=null)
            {
                
                for(int i=0;i<(DataContext as Cuvant).Cuvinte.ListaToateCategoriile.Count;i++)
                {
                    if((DataContext as Cuvant).Cuvinte.ListaToateCategoriile[i]== SelectCat.Text)
                    {
                        CategoriiCautare.Add((DataContext as Cuvant).Cuvinte.ListaToateCategoriile[i]);
                        CuvinteCautare.Add((DataContext as Cuvant).Cuvinte.ListaCuvinte[i]);
                        DescrieriCautare.Add((DataContext as Cuvant).Cuvinte.ListaToateCategoriile[i]);
                    }
                }

            }
            else
            {
                for (int i = 0; i < (DataContext as Cuvant).Cuvinte.ListaToateCategoriile.Count; i++)
                {
                        CategoriiCautare.Add((DataContext as Cuvant).Cuvinte.ListaToateCategoriile[i]);
                        CuvinteCautare.Add((DataContext as Cuvant).Cuvinte.ListaCuvinte[i]);
                        DescrieriCautare.Add((DataContext as Cuvant).Cuvinte.ListaToateCategoriile[i]);
                }
            }
            AutoSuggestionList = CuvinteCautare;
        }

        private void Cauta(object sender, RoutedEventArgs e)
        {
            int pozitie = (DataContext as Cuvant).Cuvinte.ListaCuvinte.IndexOf(autoTextBox.Text);
            cuv.Text = (DataContext as Cuvant).Cuvinte.ListaCuvinte[pozitie];
            cat.Text = (DataContext as Cuvant).Cuvinte.ListaToateCategoriile[pozitie];
            desc.Text = (DataContext as Cuvant).Cuvinte.ListaDescrieri[pozitie];
            Img.Source= new BitmapImage(new Uri((DataContext as Cuvant).Cuvinte.ListaImagini[pozitie], UriKind.Absolute));
        }
    }
}
