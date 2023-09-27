using Platforma_Educationala.Helpers;
using System;

namespace Platforma_Educationala.MVVM.Model.EntityLayer
{
    class Attendence : ObservableObject
    {
        private int? attendenceID;
        public int? AttendenceID
        {
            get
            {
                return attendenceID;
            }
            set
            {
                attendenceID = value;
                NotifyPropertyChanged("AttendenceID");
            }
        }

        private DateTime? dateTime;
        public DateTime? DateTime
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
                return dateTime.Value.Date.ToShortDateString();
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

        private bool motivated;
        public bool Motivated
        {
            get
            {
                return motivated;
            }
            set
            {
                motivated = value;
                NotifyPropertyChanged("Motivated");
            }
        }

        private bool motivable;
        public bool Motivable
        {
            get
            {
                return motivable;
            }
            set
            {
                motivable = value;
                NotifyPropertyChanged("Motivable");
            }
        }

        public string Status
        {
            get
            {
                switch (motivable)
                {
                    case false: return "Nemotivabila";

                    case true:
                        {
                            switch (motivated)
                            {
                                case false: return "Nemotivata";
                                case true: return "Motivata";
                                default:return "";
                            }
                        }
                    default:return "";
                }
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
       
    }
}
