using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuizPuzzle : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _questionText;
    [SerializeField] private Button[] _answerButtons;
    [SerializeField] private TextMeshProUGUI[] _answerTexts;
    [SerializeField] private ExitDoor _exitDoor;
    private bool _king = false;

    private int correctAnswerIndex;
    private string[] questions = {
        "Quelle est la capitale de la France?",
        "Quel est l'élément chimique avec le symbole 'O'?",
        "Quelle planète est la plus proche du soleil?",
        "Combien de continents y a-t-il sur Terre?"
    };
    private string[,] answers = {
        { "Thomas", "Nicolet", "Nicola", "Thomet" },
        { "5", "12", "6", "4" },
        { "Le mensonge n'est pas la vérité", "la beauté est éphémère", "Ouf Ouf", "Que la lumiere te benisse" },
        { "Deus machina", "Deus ex", "Dieu vult", "Deus vult" }
    };

    private int[] _correctAnswers = { 3, 0, 2, 3}; // Index des bonnes réponses



    private string[] questions2 = {
        "Quelle est la capitale de la France?",
        "Quel est l'élément chimique avec le symbole 'O'?",
    };
    private string[,] answers2 = {
        { "3π/2 + e^(i/4)", " √(2 + i) - ln(φ)", " ζ(3) + arctan(√2)", "  " },
        { "3π/2 + e^(i/4)", " √(2 + i) - ln(φ)", " ζ(3) + arctan(√2)", " D " },
    };

    private int[] _correctAnswers2 = { 3, 3}; // Index des bonnes réponses


    private int _currentQuestion = 0;
    private PlayerBehaviour _player;

    private void Start()
    {
        _player = GameObject.FindWithTag("Player").GetComponent<PlayerBehaviour>();
        if (GameManager.sceneIndex == 4) {
            questions = questions2; ;
            answers = answers2;
            _correctAnswers = _correctAnswers2;
            _king = true;
        }
        DisplayQuestion();
    }

    // Affiche la question et les réponses
    private void DisplayQuestion()
    {
        _questionText.text = questions[_currentQuestion];
        correctAnswerIndex = _correctAnswers[_currentQuestion];

        for (int i = 0; i < _answerButtons.Length; i++)
        {
            _answerTexts[i].text = answers[_currentQuestion, i];
            int index = i;
            _answerButtons[i].onClick.RemoveAllListeners();
            _answerButtons[i].onClick.AddListener(() => CheckAnswer(index));
        }
    }

    private void CheckAnswer(int index)
    {
        if (GameManager.sceneIndex == 4 && index == 1)
        {
            NextQuestion();
            return;
        }

        if (index == correctAnswerIndex)
        {
            Debug.Log("Bonne réponse!");
            NextQuestion();
            if (GameManager.sceneIndex == 4)
            {
                LoadScreen.instance.FadeA();
                Destroy(gameObject);
            }
        }
        else
        {
            Debug.Log("Mauvaise réponse!");
        }

    }

    private void NextQuestion()
    {
        _currentQuestion++;

        if (_currentQuestion < questions.Length)
        {
            DisplayQuestion();
        }
        else if (!_king)
        {
            Win();
            Debug.Log("Quiz terminé !");
        }
    }

    private void Win()
    {
        _exitDoor.Open();
        _player.CanMove = true;
        Destroy(gameObject);
    }
}
