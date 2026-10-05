using System;

namespace Examination_System
{
    internal class SystemManager
    {
        enum eSystemMode
        {
            TeacherMode = 1,
            StudentMode = 2
        }

        public SystemManager(Exam exam)
        {
            Exam = exam;
        }

        public Exam Exam { get; set; }

        #region Student Mode

        public void StartStudentMode()
        {
            Console.Clear();

            Console.WriteLine("=================================");
            Console.WriteLine("          Student Mode");
            Console.WriteLine("=================================");

            Console.WriteLine("\nChoose Exam Level:");
            Console.WriteLine("1. Easy");
            Console.WriteLine("2. Medium");
            Console.WriteLine("3. Hard");

            int LevelNumber = ReadNumber();

            eQLevel selectedLevel;

            switch (LevelNumber)
            {
                case 1:
                    selectedLevel = eQLevel.Easy;
                    break;

                case 2:
                    selectedLevel = eQLevel.Medium;
                    break;

                case 3:
                    selectedLevel = eQLevel.Hard;
                    break;

                default:
                    Console.WriteLine("Invalid Exam Level!");
                    return;
            }

            Console.WriteLine("\n=================================");
            Console.WriteLine("Are you sure you want to");
            Console.WriteLine("start the exam now?");
            Console.WriteLine("=================================");

            Console.WriteLine("1. OK");
            Console.WriteLine("2. Cancel");

            int confirmation = ReadNumber();

            if (confirmation != 1)
            {
                Console.WriteLine("\nExam Cancelled.");
                return;
            }

            
            List<Question> ExamQuestions = new List<Question>();

            foreach (var question in Exam.Questions)
            {
                if (question.eQLevel == selectedLevel)
                {
                    ExamQuestions.Add(question);
                }
            }

            if (ExamQuestions.Count == 0)
            {
                Console.WriteLine("\nThere are no questions for this level.");
                return;
            }

            Console.Clear();

            DateTime ExamStartTime = DateTime.Now;

            Console.WriteLine("==============================================");
            Console.WriteLine("              EXAMINATION");
            Console.WriteLine("==============================================");

            Console.WriteLine($"Exam Level : {selectedLevel}");
            Console.WriteLine($"Date       : {ExamStartTime:dd/MM/yyyy}");
            Console.WriteLine($"Time       : {ExamStartTime:hh:mm:ss tt}");

            Console.WriteLine("==============================================");

            int TotalMark = 0;
            int StudentMark = 0;

            List<string> StudentAnswers = new List<string>();

            for (int i = 0; i < ExamQuestions.Count; i++)
            {
                Question question = ExamQuestions[i];

                TotalMark += question.QuestionMark;

                Console.WriteLine($"\nQuestion {i + 1}");
                Console.WriteLine("----------------------------------------------");

                Console.WriteLine(question.QuestionText);
                Console.WriteLine($"Mark: {question.QuestionMark}");

                if (question is ChooseOneQuestion chooseOneQuestion)
                {
                    Console.WriteLine();

                    for (int j = 0; j < chooseOneQuestion.Options.Count; j++)
                    {
                        Console.WriteLine(
                            $"{j + 1}. {chooseOneQuestion.Options[j]}");
                    }

                    Console.Write("\nYour Answer: ");

                    int AnswerNumber = ReadNumber();

                    if (AnswerNumber >= 1 &&
                        AnswerNumber <= chooseOneQuestion.Options.Count)
                    {
                        string StudentAnswer =
                            chooseOneQuestion.Options[AnswerNumber - 1];

                        StudentAnswers.Add(StudentAnswer);

                        if (StudentAnswer == chooseOneQuestion.CorrectAnswer)
                        {
                            StudentMark += question.QuestionMark;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Answer!");
                        StudentAnswers.Add("Invalid Answer");
                    }
                }

                
                else if (question is TrueOrFalseQuestion trueFalseQuestion)
                {
                    Console.WriteLine();
                    Console.WriteLine("1. True");
                    Console.WriteLine("2. False");

                    Console.Write("\nYour Answer: ");

                    int AnswerNumber = ReadNumber();

                    bool StudentAnswer;

                    if (AnswerNumber == 1)
                    {
                        StudentAnswer = true;
                        StudentAnswers.Add("True");

                        if (StudentAnswer == trueFalseQuestion.CorrectAnswer)
                        {
                            StudentMark += question.QuestionMark;
                        }
                    }
                    else if (AnswerNumber == 2)
                    {
                        StudentAnswer = false;
                        StudentAnswers.Add("False");

                        if (StudentAnswer == trueFalseQuestion.CorrectAnswer)
                        {
                            StudentMark += question.QuestionMark;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Answer!");
                        StudentAnswers.Add("Invalid Answer");
                    }
                }

                
                else if (question is MultipleChoiceQuestion multipleChoiceQuestion)
                {
                    Console.WriteLine();

                    for (int j = 0; j < multipleChoiceQuestion.Options.Count; j++)
                    {
                        Console.WriteLine(
                            $"{j + 1}. {multipleChoiceQuestion.Options[j]}");
                    }

                    Console.WriteLine(
                        "\nEnter the number of each correct answer separated by comma.");

                    Console.Write("Your Answers: ");

                    string Input = Console.ReadLine() ?? "";

                    string[] Answers = Input.Split(',');

                    List<string> StudentCorrectAnswers =
                        new List<string>();

                    foreach (string answer in Answers)
                    {
                        if (int.TryParse(answer.Trim(), out int AnswerNumber))
                        {
                            if (AnswerNumber >= 1 &&
                                AnswerNumber <= multipleChoiceQuestion.Options.Count)
                            {
                                StudentCorrectAnswers.Add(
                                    multipleChoiceQuestion.Options[AnswerNumber - 1]);
                            }
                        }
                    }

                    StudentAnswers.Add(
                        string.Join(", ", StudentCorrectAnswers));

                    bool IsCorrect = true;

                    if (StudentCorrectAnswers.Count !=
                        multipleChoiceQuestion.CorrectAnswers.Count)
                    {
                        IsCorrect = false;
                    }
                    else
                    {
                        foreach (string correctAnswer
                            in multipleChoiceQuestion.CorrectAnswers)
                        {
                            if (!StudentCorrectAnswers.Contains(correctAnswer))
                            {
                                IsCorrect = false;
                                break;
                            }
                        }
                    }

                    if (IsCorrect)
                    {
                        StudentMark += question.QuestionMark;
                    }
                }

                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
            }

            
            Console.Clear();

            Console.WriteLine("==============================================");
            Console.WriteLine("                EXAM RESULT");
            Console.WriteLine("==============================================");

            for (int i = 0; i < ExamQuestions.Count; i++)
            {
                Question question = ExamQuestions[i];

                Console.WriteLine($"\nQuestion {i + 1}:");
                Console.WriteLine(question.QuestionText);

                Console.WriteLine(
                    $"Your Answer: {StudentAnswers[i]}");

                if (question is ChooseOneQuestion chooseOneQuestion)
                {
                    Console.WriteLine(
                        $"Correct Answer: {chooseOneQuestion.CorrectAnswer}");
                }

                else if (question is TrueOrFalseQuestion trueFalseQuestion)
                {
                    Console.WriteLine(
                        $"Correct Answer: {trueFalseQuestion.CorrectAnswer}");
                }

                else if (question is MultipleChoiceQuestion multipleChoiceQuestion)
                {
                    Console.WriteLine("Correct Answers:");

                    foreach (string answer
                        in multipleChoiceQuestion.CorrectAnswers)
                    {
                        Console.WriteLine($"- {answer}");
                    }
                }

                Console.WriteLine("----------------------------------------------");
            }

            Console.WriteLine("\n==============================================");
            Console.WriteLine("              FINAL RESULT");
            Console.WriteLine("==============================================");

            Console.WriteLine($"Your Mark : {StudentMark}");
            Console.WriteLine($"Total Mark: {TotalMark}");

            Console.WriteLine("==============================================");
        }

        #endregion

        #region Teacher Mode

        public void StartTeacherMode()
        {
            #region Questions Number

            Console.WriteLine("How Many Questions You Want");
            int NumberOfQuestion = ReadNumber();

            for (int i = 1; i <= NumberOfQuestion; i++)
            {
                Question question ;

                Console.WriteLine($"\nQuestion Number : {i}");

                Console.WriteLine("Type Of Question You Want?");
                Console.WriteLine("1. True Or False");
                Console.WriteLine("2. Choose One");
                Console.WriteLine("3. Multiple Choice");

                int TypeNumber = ReadNumber();

                eQType questionType;

                switch (TypeNumber)
                {
                    case 1:
                        question =new TrueOrFalseQuestion();
                        questionType = eQType.QTrueOrFalse;
                        break;

                    case 2:
                        question = new ChooseOneQuestion();
                        questionType = eQType.QChooseOne;
                        break;

                    case 3:
                        question = new MultipleChoiceQuestion();
                        questionType = eQType.QMultipleChoice;
                        break;

                    default:
                        Console.WriteLine("Invalid Question Type!");
                        i--;
                        continue;
                }

                question.eQType = questionType;

                #endregion

                #region Question Level

                Console.WriteLine("Level Of Question You Want?");
                Console.WriteLine("1. Easy");
                Console.WriteLine("2. Medium");
                Console.WriteLine("3. Hard");

                int LevelNumber = ReadNumber();

                eQLevel questionLevel;

                switch (LevelNumber)
                {
                    case 1:
                        questionLevel = eQLevel.Easy;
                        break;

                    case 2:
                        questionLevel = eQLevel.Medium;
                        break;

                    case 3:
                        questionLevel = eQLevel.Hard;
                        break;

                    default:
                        Console.WriteLine("Invalid Question Level!");
                        i--;
                        continue;
                }

                question.eQLevel = questionLevel;

                #endregion

                #region Question Body
                Console.WriteLine($"Selected Type : {questionType}");
                Console.WriteLine($"Selected Level : {questionLevel}");

                Console.WriteLine("Enter The Question Body ");
                string QuestionBody = Console.ReadLine() ?? "";
                question.QuestionText = QuestionBody;
                #endregion

                
                #region Question Mark

                Console.WriteLine("Enter Question Mark");
                int QMark = ReadNumber();
                question.QuestionMark = QMark;
                #endregion


                #region Question Options

                if (question is ChooseOneQuestion chooseOneQuestion)
                {
                    Console.WriteLine("\nHow Many Choices You Want?");
                    int NumberOfChoices = ReadNumber();

                    for (int j = 1; j <= NumberOfChoices; j++)
                    {
                        Console.Write($"Enter Choice {j}: ");
                        string choice = Console.ReadLine() ?? "";

                        chooseOneQuestion.Options.Add(choice);
                    }

                    Console.WriteLine("\nEnter Correct Answer:");

                    for (int j = 0; j < chooseOneQuestion.Options.Count; j++)
                    {
                        Console.WriteLine($"{j + 1}. {chooseOneQuestion.Options[j]}");
                    }

                    int CorrectAnswerNumber = ReadNumber();

                    if (CorrectAnswerNumber >= 1 &&
                        CorrectAnswerNumber <= chooseOneQuestion.Options.Count)
                    {
                        chooseOneQuestion.CorrectAnswer =
                            chooseOneQuestion.Options[CorrectAnswerNumber - 1];
                    }
                    else
                    {
                        Console.WriteLine("Invalid Answer!");
                    }
                }

                if (question is TrueOrFalseQuestion trueFalseQuestion)
                {
                    Console.WriteLine("\nEnter Correct Answer:");
                    Console.WriteLine("1. True");
                    Console.WriteLine("2. False");

                    int AnswerNumber = ReadNumber();

                    switch (AnswerNumber)
                    {
                        case 1:
                            trueFalseQuestion.CorrectAnswer = true;
                            break;

                        case 2:
                            trueFalseQuestion.CorrectAnswer = false;
                            break;

                        default:
                            Console.WriteLine("Invalid Answer!");
                            i--;
                            continue;
                    }
                }

                if (question is MultipleChoiceQuestion multipleChoiceQuestion)
                {
                    Console.WriteLine("\nHow Many Choices You Want?");
                    int NumberOfChoices = ReadNumber();

                    for (int j = 1; j <= NumberOfChoices; j++)
                    {
                        Console.Write($"Enter Choice {j}: ");
                        string choice = Console.ReadLine() ?? "";

                        multipleChoiceQuestion.Options.Add(choice);
                    }

                    Console.WriteLine("\nHow Many Correct Answers?");
                    int NumberOfCorrectAnswers = ReadNumber();

                    for (int j = 1; j <= NumberOfCorrectAnswers; j++)
                    {
                        Console.WriteLine("\nAvailable Choices:");

                        for (int k = 0; k < multipleChoiceQuestion.Options.Count; k++)
                        {
                            Console.WriteLine(
                                $"{k + 1}. {multipleChoiceQuestion.Options[k]}");
                        }

                        Console.Write($"Enter Correct Choice Number {j}: ");
                        int CorrectAnswerNumber = ReadNumber();

                        if (CorrectAnswerNumber >= 1 &&
                            CorrectAnswerNumber <= multipleChoiceQuestion.Options.Count)
                        {
                            string correctAnswer =
                                multipleChoiceQuestion.Options[CorrectAnswerNumber - 1];

                            if (!multipleChoiceQuestion.CorrectAnswers.Contains(correctAnswer))
                            {
                                multipleChoiceQuestion.CorrectAnswers.Add(correctAnswer);
                            }
                            else
                            {
                                Console.WriteLine("This Answer Was Already Selected!");
                                j--;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid Choice Number!");
                            j--;
                        }
                    }
                }
                #endregion

                Exam.Questions.Add(question);

               
            }
            Console.WriteLine($"\nNumber Of Questions In Exam : {Exam.Questions.Count}");

            int questionNumber = 1;

            foreach (var item in Exam.Questions)
            {
                Console.WriteLine("\n========================================");
                Console.WriteLine($"             QUESTION {questionNumber}");
                Console.WriteLine("========================================");

                Console.WriteLine($"Question Type   : {item.eQType}");
                Console.WriteLine($"Question Level  : {item.eQLevel}");
                Console.WriteLine($"Question Text   : {item.QuestionText}");
                Console.WriteLine($"Question Mark   : {item.QuestionMark}");

                // Choose One
                if (item is ChooseOneQuestion chooseOneQuestion)
                {
                    Console.WriteLine("\nChoices:");

                    for (int i = 0; i < chooseOneQuestion.Options.Count; i++)
                    {
                        Console.WriteLine(
                            $"{i + 1}. {chooseOneQuestion.Options[i]}");
                    }

                    Console.WriteLine(
                        $"Correct Answer : {chooseOneQuestion.CorrectAnswer}");
                }

                // True Or False
                if (item is TrueOrFalseQuestion trueFalseQuestion)
                {
                    Console.WriteLine("\nChoices:");
                    Console.WriteLine("1. True");
                    Console.WriteLine("2. False");

                    Console.WriteLine(
                        $"Correct Answer : {trueFalseQuestion.CorrectAnswer}");
                }

                // Multiple Choice
                if (item is MultipleChoiceQuestion multipleChoiceQuestion)
                {
                    Console.WriteLine("\nChoices:");

                    for (int i = 0; i < multipleChoiceQuestion.Options.Count; i++)
                    {
                        Console.WriteLine(
                            $"{i + 1}. {multipleChoiceQuestion.Options[i]}");
                    }

                    Console.WriteLine("\nCorrect Answers:");

                    foreach (var answer in multipleChoiceQuestion.CorrectAnswers)
                    {
                        Console.WriteLine($"- {answer}");
                    }
                }

                Console.WriteLine("========================================");

                questionNumber++;
            }
        }

        #endregion

        #region Start

        static int ReadNumber()
        {
            int Number = 0;

            try
            {
                Number = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error : {ex.Message}");
            }

            return Number;
        }

        static eSystemMode SystemMode(int Number)
        {
            return (eSystemMode)Number;
        }

        public void StartSystem()
        {
            while (true)
            {
                Console.WriteLine("=================================");
                Console.WriteLine("       Examination System");
                Console.WriteLine("=================================");

                Console.WriteLine("1. Teacher Mode");
                Console.WriteLine("2. Student Mode");

                Console.Write("\nEnter Your Mode: ");

                int number = ReadNumber();

                eSystemMode mode = SystemMode(number);

                switch (mode)
                {
                    case eSystemMode.TeacherMode:
                        StartTeacherMode();
                        break;

                    case eSystemMode.StudentMode:
                        StartStudentMode();
                        break;

                    default:
                        Console.WriteLine("Invalid Mode!");
                        break;
                }
            }
        }

        #endregion
    }
}