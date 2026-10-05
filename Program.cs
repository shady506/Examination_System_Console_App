namespace Examination_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Exam exam = new Exam(1);
            SystemManager systemManager = new SystemManager(exam);

            systemManager.StartSystem();

        }
    }
}
