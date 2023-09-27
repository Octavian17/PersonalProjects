using Platforma_Educationala.Helpers;
using System;

namespace Platforma_Educationala.MVVM.Model.EntityLayer
{
    class Mark:ObservableObject
    {
        private int? markID;
        public int? MarkID
        {
            get
            {
                return markID;
            }
            set
            {
                markID = value;
                NotifyPropertyChanged("MarkID");
            }
        }

        private int score;
        public int Score
        {
            get
            {
                return score;
            }
            set
            {
                score = value;
                NotifyPropertyChanged("Score");
            }
        }

        private bool thesis;
        public bool Thesis
        {
            get
            {
                return thesis;
            }
            set
            {
                thesis = value;
                NotifyPropertyChanged("Thesis");
            }
        }

        public string ThesisStatus
        {
            get
            {
                if (thesis)
                    return "Da";
                return "Nu";
            }
        }

        private DateTime dateTime;
        public DateTime DateTime
        {
            get
            {
                return dateTime;
            }
            set
            {
                dateTime = value;
                NotifyPropertyChanged("DateTime");
            }
        }
        public string Date
        {
            get
            {                
                int year = dateTime.Year;
                int month = dateTime.Month;
                int day = dateTime.Day;

                return string.Format("{0}/{1}/{2}", month, day, year);                
            }
        }    

        private int? subjectID;
        public int? SubjectID
        {
            get
            {
                return subjectID;
            }
            set
            {
                subjectID = value;
                NotifyPropertyChanged("SubjectID");
            }
        }

        private int? studentID;
        public int? StudentID
        {
            get
            {
                return studentID;
            }
            set
            {
                studentID = value;
                NotifyPropertyChanged("StudentID");
            }
        }
    }
}
