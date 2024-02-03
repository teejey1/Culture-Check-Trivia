using Firebase.Firestore;
using Firebase.Extensions;
using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Linq;

public class TriviaManager : MonoBehaviour
{
    public TMP_Text questionText;
    public List<TMP_Text> answerTexts;
    private List<Question> questions = new List<Question>();
    private Question currentQuestion;
    private string[] shuffledOptions; // Stores the shuffled options
    private int currentQuestionIndex = 0;

    FirebaseFirestore db;

    void Start()
    {
        db = FirebaseFirestore.DefaultInstance;
        FetchQuestionsForSubcategory(SessionManager.Instance.SelectedCategory,
                                     SessionManager.Instance.SelectedSubcategory);
        SessionManager.Instance.ResetScore();
    }

    void FetchQuestionsForSubcategory(string category, string subcategory)
    {
        Debug.Log($"Fetching questions for Category: {category}, Subcategory: {subcategory}");
        CollectionReference questionsRef = db.Collection("categories")
                                             .Document(category)
                                             .Collection("subcategories")
                                             .Document(subcategory)
                                             .Collection("questions");

        questionsRef.GetSnapshotAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsFaulted || task.IsCanceled)
            {
                Debug.LogError("Error fetching questions: " + task.Exception);
                return;
            }

            QuerySnapshot questionsSnapshot = task.Result;
            foreach (DocumentSnapshot documentSnapshot in questionsSnapshot.Documents)
            {
                Question newQuestion = new Question(
                    documentSnapshot.GetValue<string>("questionText"),
                    documentSnapshot.GetValue<List<string>>("options").ToArray(),
                    documentSnapshot.GetValue<string>("correctAnswer")
                );
                questions.Add(newQuestion);
            }

            if (questions.Count > 0)
            {
                currentQuestionIndex = 0;
                currentQuestion = questions[currentQuestionIndex];
                DisplayQuestion(currentQuestion);
            }
            else
            {
                Debug.LogError("No questions found.");
            }
        });
    }

    void DisplayQuestion(Question question)
    {
        questionText.text = question.QuestionText;
        shuffledOptions = question.Options.OrderBy(x => Random.value).ToArray();

        for (int i = 0; i < answerTexts.Count; i++)
        {
            if (i < shuffledOptions.Length)
            {
                answerTexts[i].text = shuffledOptions[i];
                answerTexts[i].gameObject.SetActive(true);
            }
            else
            {
                answerTexts[i].gameObject.SetActive(false);
            }
        }
    }

    public void OnAnswerSelected(int buttonIndex)
    {
        AudioManager.Instance?.PlayClickSound();

        if (currentQuestion != null && buttonIndex >= 0 && buttonIndex < shuffledOptions.Length)
        {
            bool isCorrect = shuffledOptions[buttonIndex] == currentQuestion.CorrectAnswer;

            if (isCorrect)
            {
                SessionManager.Instance.AddScore(1);
                Debug.Log("Correct! Score: " + SessionManager.Instance.Score);
            }
            else
            {
                Debug.Log("Incorrect. Score: " + SessionManager.Instance.Score);
            }

            LoadNextQuestion();
        }
    }

    void LoadNextQuestion()
    {
        if (++currentQuestionIndex < questions.Count)
        {
            currentQuestion = questions[currentQuestionIndex];
            DisplayQuestion(currentQuestion);
        }
        else
        {
            Debug.Log("End of questions. Final score: " + SessionManager.Instance.Score);
            SceneManager.LoadScene("ScoreScene");
        }
    }
}

[System.Serializable]
public class Question
{
    public string QuestionText { get; private set; }
    public string[] Options { get; private set; }
    public string CorrectAnswer { get; private set; }

    public Question(string questionText, string[] options, string correctAnswer)
    {
        QuestionText = questionText;
        Options = options;
        CorrectAnswer = correctAnswer;
    }
}
