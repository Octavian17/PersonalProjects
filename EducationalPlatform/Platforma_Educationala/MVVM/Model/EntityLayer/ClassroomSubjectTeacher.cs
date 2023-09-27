using Platforma_Educationala.Helpers;

namespace Platforma_Educationala.MVVM.Model.EntityLayer
{
    class ClassroomSubjectTeacher : ObservableObject
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

        private int? teacherID;
        public int? TeacherID
        {
            get
            {
                return teacherID;
            }
            set
            {
                teacherID = value;
                NotifyPropertyChanged("TeacherID");
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

        private string material;
        public string Material
        {
            get
            {
                return material;
            }
            set
            {
                material = value;
                NotifyPropertyChanged("Material");
            }
        }

        private string materialName;
        public string MaterialName
        {
            get
            {
                return materialName;
            }
            set
            {
                materialName = value;
                NotifyPropertyChanged("MaterialName");
            }
        }

    }
}
