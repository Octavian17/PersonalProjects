using Platforma_Educationala.MVVM.Model.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Platforma_Educationala.Converters
{
    class AttendenceConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool motivated = false; 
            bool motivable = false;
            switch (values[2].ToString())
            {
                case "Motivata":
                    motivated = true;
                    motivable = true;
                    break;
                case "Nemotivata":
                    motivated = false;
                    motivable = true;
                    break;
                case "Nemotivabila":
                    motivable = false;
                    motivated = false;
                    break;
            }
            return new Attendence()
            {
                
                SubjectID = values[0] as int?,
                StudentID = values[1] as int?,
                Motivated = motivated,
                Motivable = motivable,
                DateTime = values[3] as DateTime?
            };
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            Attendence attendence = value as Attendence;
            object[] result = new object[6]
            {
               attendence.AttendenceID,
               attendence.DateTime,
               attendence.StudentID,
               attendence.Motivated,
               attendence.Motivable,
               attendence.SubjectID
            };
            return result;
        }
    }
}
