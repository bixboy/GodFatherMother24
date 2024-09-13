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

    private int correctAnswerIndex;
    private string[] questions = {
        "Quelle est la capitale de la France?",
        "Quel est l'élément chimique avec le symbole 'O'?",
        "Quelle planète est la plus proche du soleil?",
        "Combien de continents y a-t-il sur Terre?"
    };
    private string[,] answers = {
        { "Paris", "Londres", "Rome", "Berlin" },
        { "Hydrogène", "Oxygène", "Carbone", "Azote" },
        { "Mars", "Mercure", "Venus", "Jupiter" },
        { "4", "6", "7", "5" }
    };
    private int[] _correctAnswers = { 0, 1, 1, 2 }; // Index des bonnes réponses

    private int _currentQuestion = 0;
    private PlayerBehaviour _player;

    private void Start()
    {
        DisplayQuestion();
        _player = GameObject.FindWithTag("Player").GetComponent<PlayerBehaviour>();
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
        if (index == correctAnswerIndex)
        {
            Debug.Log("Bonne réponse!");
            NextQuestion();
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
        else
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
