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
    class AdminMenuBLL
    {
        StudentDAL studentDAL = new StudentDAL();
        ClassroomDAL classroomDAL = new ClassroomDAL();
        TeacherDAL teacherDAL = new TeacherDAL();
        SubjectDAL subjectDAL = new SubjectDAL();
        ClassroomSubjectTeacherDAL classroomSubjectTeacherDAL = new ClassroomSubjectTeacherDAL();

        public ObservableCollection<Tuple<ClassroomSubjectTeacher, string, string, string>> GetAllRelationsWithClassSubTeach()
        {
            return classroomSubjectTeacherDAL.GetAllRelationsWithClassSubTeach();
        }

        public void InsertClassroomSubjectTeacher(ClassroomSubjectTeacher classroomSubjectTeacher)
        {
            classroomSubjectTeacherDAL.InsertClassroomSubjectTeacher(classroomSubjectTeacher);
        }
        public void DeleteClassroomSubjectTeacher(ClassroomSubjectTeacher classroomSubjectTeacher)
        {
            classroomSubjectTeacherDAL.DeleteClassroomSubjectTeacher(classroomSubjectTeacher);
        }

        public void ModifyClassroomSubjectTeacher(ClassroomSubjectTeacher classroomSubjectTeacher)
        {
            classroomSubjectTeacherDAL.ModifyClassroomSubjectTeacher(classroomSubjectTeacher);
        }

        public ObservableCollection<Classroom> GetAllClassrooms()
        {
            return classroomDAL.GetAllClasses();
        }
        public ObservableCollection<Tuple<Classroom, string>> GetAllClassroomsAndClassmaster()
        {
            return classroomDAL.GetAllClassroomsAndClassmaster();
        }

        public void InsertClassroom(Classroom classroom)
        {
             classroomDAL.InsertClassroom(classroom);
        }

        public void DeleteClassroom(Classroom classroom)
        {
            classroomDAL.DeleteClassroom(classroom);
        }
        public void ModifyClassroom(Classroom classroom)
        {
            classroomDAL.ModifyClassroom(classroom);
        }

        public ObservableCollection<Tuple<Subject, string>> GetAllSubjectsExtended()
        {
            return subjectDAL.GetAllSubjectsExtended();
        }
        public ObservableCollection<Subject> GetAllSubjects()
        {
            return subjectDAL.GetAllSubjects();
        }
        public void InsertSubject(Subject subject)
        {
            subjectDAL.InsertSubject(subject);
        }
        public void DeleteSubject(Subject subject)
        {
            subjectDAL.DeleteSubject(subject);
        }
        public void ModifySubject(Subject subject)
        {
            subjectDAL.ModifySubject(subject);
        }

        public ObservableCollection<Tuple<Student, string>> GetAllStudentsAndClassroom()
        {
            return studentDAL.GetAllStudentsAndClassroom();
        }
        public void InsertStudent(Student student)
        {
            studentDAL.InsertStudent(student);
        }
        public void DeleteStudent(Student student)
        {
            studentDAL.DeleteStudent(student);
        }
        public void ModifyStudent(Student student)
        {
            studentDAL.ModifyStudent(student);
        }

        public ObservableCollection<Tuple<Teacher, string>> GetAllTeachersExtendedName()
        {
            return teacherDAL.GetAllTeachersExtendedName();
        }
        public ObservableCollection<Teacher> GetAllTeachers()
        {
            return teacherDAL.GetAllTeachers();
        }
        public ObservableCollection<Tuple<Teacher, string>> GetAllClassmastersExtendedName()
        {
            return teacherDAL.GetAllClassmastersExtendedName();
        }
        public ObservableCollection<Teacher> GetAllClassmasters()
        {
            return teacherDAL.GetAllClassmasters();
        }

        public void InsertTeacher(Teacher teacher)
        {
            teacherDAL.InsertTeacher(teacher);
        }
        public void DeleteTeacher(Teacher teacher)
        {
            teacherDAL.DeleteTeacher(teacher);
        }
        public void ModifyTeacher(Teacher teacher)
        {
            teacherDAL.ModifyTeacher(teacher);
        }


    }
}
