using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8_2
{
    class FIT
    {
        public const int StudentCount = 10;
        public List<Abiturient> Students;

        public FIT()
        {
            Students = new List<Abiturient>();
        }

        public void AddStudent(Abiturient newStudent)
        {
            if (Students.Count + 1 <= StudentCount)
                Students.Add(newStudent);
            else 
            {
                var badStudent = FindBadStudent();
                int numberBad = badStudent[0] + badStudent[1] + badStudent[2] + badStudent[3];
                int numberCurrent = newStudent[0] + newStudent[1] + newStudent[2] + newStudent[3];
                if(numberCurrent > numberBad)
                {
                    DeleteStudent(badStudent);
                    Students.Add(newStudent);
                }
                else if(numberCurrent == numberBad)
                    throw new CollisionException("ffffffffffffff");
                else throw new Exception("Набор закрыт - набрано необходимое кол-во студентов...");
            }
        }

        public void DeleteStudent(Abiturient abtr)
        {
            bool flag = false;
            for(int i=0;i<Students.Count;i++)
            {
                if (Students[i].Name == abtr.Name)
                {
                    Students.RemoveAt(i);
                    flag = true;
                    break;
                }
            }
            if (!flag) throw new Exception("Студент подлежащий отчислению не найден, видимо забрал доки...");
        }

        private Abiturient FindBadStudent()
        {
            int minSum = Students[0][0] + Students[0][1] + Students[0][2] + Students[0][3];
            int findIdx = 0;
            for(int i=1;i<Students.Count;++i)
            {
                int currentSum  = Students[i][0] + Students[i][1] + Students[i][2] + Students[i][3];
                if (currentSum < minSum)
                {
                    minSum = currentSum;
                    findIdx = i;
                }
            }
            return Students[findIdx];
        }

        public static FIT operator--(FIT fit)
        {
           fit.DeleteStudent(fit.FindBadStudent());
           return fit;
        }
    }
}
