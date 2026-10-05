using System;
using System.Collections.Generic;
using System.Text;

namespace Examination_System
{
    internal class ChooseOneQuestion : Question
    {
        public List<string> Options { get; set; } = new List<string>();

        public string CorrectAnswer { get; set; } = "";
    }
}
