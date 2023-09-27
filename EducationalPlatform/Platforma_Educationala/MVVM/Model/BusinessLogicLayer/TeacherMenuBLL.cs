using Platforma_Educationala.MVVM.Model.DataAccessLAyer;
using Platforma_Educationala.MVVM.Model.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platforma_Educationala.MVVM.Model.BusinessLogicLayer
{
    class TeacherMenuBLL
    {
        StudentDAL studentDAL = new StudentDAL();
        ClassroomDAL classroomDAL = new ClassroomDAL();
        TeacherDAL teacherDAL = new TeacherDAL();
        SubjectDAL subjectDAL = new SubjectDAL();
        AbsencesDAL absencesDAL = new AbsencesDAL();
        ClassroomSubjectTeacherDAL classroomSubjectTeacherDAL = new ClassroomSubjectTeacherDAL();

        public ObservableCollection<Tuple<Subject, string>> GetSubjectsForTeacher(Teacher teacher)
        {
            return subjectDAL.GetSubjectsForTeacher(teacher);
        }

        public ObservableCollection<Tuple<Student, string>> GetStudentsforSubject(Subject subject)
        {
            return studentDAL.GetStudentsforSubject(subject);
        }

        public ObservableCollection<Attendence> GetStudentAbsencesforSubject(Student student, Subject subject)
        {
            return absencesDAL.GetStudentAbsencesforSubject(student, subject);
        }
        public void InsertAttendence(Attendence attendence)
        {
            absencesDAL.InsertAttendence(attendence);
        }
        public void ModifyAttendence(Attendence attendence)
        {
            absencesDAL.ModifyAttendence(attendence);
        }
    }
}
