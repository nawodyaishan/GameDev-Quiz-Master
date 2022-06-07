using UnityEngine;

namespace Questions
{
    [CreateAssetMenu(menuName = "QuizQuestion", fileName = "Question")]
    public class QuestionSO : ScriptableObject
    {
        // for the question
        [TextArea(2, 6)] [SerializeField] string question = "Enter New Question Text Here";

        // for the answers
        [SerializeField] string[] answers = new string[4];

        // For the o=correct answer
        [SerializeField] int correctAnswer;

        public string GetQuestion()
        {
            return question;
        }
    } // Class
}