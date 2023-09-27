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
    class StudentMenuBLL
    {
        MarksDAL marks = new MarksDAL();
        AbsencesDAL absences = new AbsencesDAL();
        MaterialsDAL materials = new MaterialsDAL();
        public double finalAverageSemOne { get; set; }
        public double finalAverageSemTwo { get; set; }
        public ObservableCollection<Tuple<Subject, Mark>> GetMarksforStudent(Student student)
        {
            return marks.GetMarksforStudent(student);
        }

        public ObservableCollection<Tuple<Subject, Attendence>> GetAbsencesforStudent(Student student)
        {
            return absences.GetAbsencesforStudent(student);
        }
        public ObservableCollection<Tuple<Subject, ClassroomSubjectTeacher>> GetMaterials(Student student)
        {
            return materials.GetMaterials(student);
        }
        public ObservableCollection<Tuple<Subject, double>> GetAverageMarks(Student student)
        {
            ObservableCollection<Tuple<Subject, Mark>> averageMarks = marks.GetMarksforStudent(student);
            var averageMarksSorted = averageMarks.GroupBy(x => x.Item1.Semester);
            ObservableCollection<Tuple<Subject, double>> result = new ObservableCollection<Tuple<Subject, double>>();
            ObservableCollection<Tuple<Subject, Mark>> semesterOneMarks = new ObservableCollection<Tuple<Subject, Mark>>();
            ObservableCollection<Tuple<Subject, Mark>> semesterTwoMarks = new ObservableCollection<Tuple<Subject, Mark>>();

            int nr = 1;
            foreach (var sortedMarks in averageMarksSorted)
            {
                foreach (var mark in sortedMarks)
                    if (nr == 1)
                        semesterOneMarks.Add(mark);
                    else
                        semesterTwoMarks.Add(mark);
                ++nr;
            }

            finalAverageSemOne = 0;
            finalAverageSemTwo = 0;
            int net1 = 0;
            int net2 = 0;
            var sem1 = GetAverageMarksSemester(semesterOneMarks);
            var sem2 = GetAverageMarksSemester(semesterTwoMarks);
            foreach (var averageMark in sem1)
            {
                result.Add(averageMark);
                if (averageMark.Item2 == 0)
                    ++net1;
                finalAverageSemOne += averageMark.Item2;
            }
            finalAverageSemOne /= (sem1.Count() - net1);

            foreach (var averageMark in sem2)
            {
                result.Add(averageMark);
                if (averageMark.Item2 == 0)
                    ++net2;
                finalAverageSemTwo += averageMark.Item2;
            }
            finalAverageSemTwo /= (sem2.Count() - net2);

            return result;
        }

        private ObservableCollection<Tuple<Subject, double>> GetAverageMarksSemester(ObservableCollection<Tuple<Subject, Mark>> semester)
        {
            ObservableCollection<Tuple<Subject, double>> result = new ObservableCollection<Tuple<Subject, double>>();
            var averageMarksSorted = semester.GroupBy(x => x.Item1.SubjectName);


            foreach (var subjectMarks in averageMarksSorted)
            {
                int sum = 0;
                int thesis = 0;
                double average = 0;
                string name = "";
                int sem = 0;
                foreach (var mark in subjectMarks)
                {
                    name = mark.Item1.SubjectName;
                    sem = mark.Item1.Semester;
                    if (mark.Item2.Thesis == true)
                        thesis = mark.Item2.Score;
                    else
                        sum += mark.Item2.Score;
                }
                Subject subject = new Subject();
                subject.SubjectName = name;
                subject.Semester = sem;
                if (subjectMarks.Count() >= 4)
                    if (thesis != 0)
                        average = (sum / (subjectMarks.Count() - 1) + thesis) / 2.0;
                    else
                        average = sum / (double)subjectMarks.Count();
                else
                    average = 0;

                result.Add(new Tuple<Subject, double>(subject, Math.Round(average)));
            }
            return result;
        }
    }


}
