using System;
using System.Collections.Generic;
using System.Text;

namespace Examination_System
{
     enum eQType
    {
        QTrueOrFalse = 1,
        QChooseOne = 2,
        QMultipleChoice = 3
    }
    enum eQLevel
    {
        Easy =1,
        Medium = 2,
        Hard = 3
    }
    internal class Question
    {
        public Question() { }
        public Question(int id, eQType eQType, eQLevel eQLevel, string questionText, int questionMark, string answer)
        {
            Id = id;
            this.eQType = eQType;
            this.eQLevel = eQLevel;
            QuestionText = questionText;
            QuestionMark = questionMark;
            Answer = answer;
        }

        public int Id { get; set; }
        public eQType eQType { get; set; }
        public eQLevel eQLevel { get; set; }
        public string QuestionText { get; set; } = null!;

        public int QuestionMark { get; set; }
        public string Answer { get; set; } = null!;


        public virtual void DisplayQuestion()
        {
            Console.WriteLine(QuestionText);
        }



    }
}
