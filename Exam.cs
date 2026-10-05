using System;
using System.Collections.Generic;
using System.Text;

namespace Examination_System
{
    internal class Exam
    {
        public Exam(int id)
        {
            Id = id;
            Questions = new List<Question>();
        }

        public int Id { get; set; }

        public List<Question> Questions { get; set; } 



        
    }
}
