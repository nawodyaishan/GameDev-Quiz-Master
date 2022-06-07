using UnityEngine;

namespace Questions
{
    [CreateAssetMenu(menuName = "QuizQuestion", fileName = "New Question")]
    public class QuestionSO : ScriptableObject
    {
        string question = "Enter New Question Text Here";
    } // Class
}