using Platforma_Educationala.Helpers;

namespace Platforma_Educationala.MVVM.Model.EntityLayer
{
    class Classroom : ObservableObject
    {
        private int? classroomID;
        public int? ClassroomID
        {
            get
            {
                return classroomID;
            }
            set
            {
                classroomID = value;
                NotifyPropertyChanged("ClassroomID");
            }
        }

        private string grade;
        public string Grade
        {
            get
            {
                return grade;
            }
            set
            {
                grade = value;
                NotifyPropertyChanged("Grade");
            }
        }

        private string specialization;
        public string Specialization
        {
            get
            {
                return specialization;
            }
            set
            {
                specialization = value;
                NotifyPropertyChanged("Specialization");
            }
        }

        private int? classmaster;
        public int? Classmaster
        {
            get
            {
                return classmaster;
            }
            set
            {
                classmaster = value;
            }
        }
    }
}
