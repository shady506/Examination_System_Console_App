using System;
using System.Collections.Generic;
using System.Text;

namespace Examination_System
{
    internal class MultipleChoiceQuestion : Question
    {
        public List<string> Options { get; set; } = new List<string>();

        public List<string> CorrectAnswers { get; set; } = new List<string>();
    }
}
