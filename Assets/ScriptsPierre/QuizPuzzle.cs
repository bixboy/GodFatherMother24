using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizPuzzle : MonoBehaviour
{
    [SerializeField] private Text _questionText;
    [SerializeField] private Button[] _answerButtons;
    [SerializeField] private Text[] _answerTexts;

    private int correctAnswerIndex;
    private string[] questions = {
        "Quelle est la capitale de la France?",
        "Quel est l'�l�ment chimique avec le symbole 'O'?",
        "Quelle plan�te est la plus proche du soleil?",
        "Combien de continents y a-t-il sur Terre?"
    };
    private string[,] answers = {
        { "Paris", "Londres", "Rome", "Berlin" },
        { "Hydrog�ne", "Oxyg�ne", "Carbone", "Azote" },
        { "Mars", "Mercure", "Venus", "Jupiter" },
        { "4", "6", "7", "5" }
    };
    private int[] _correctAnswers = { 0, 1, 1, 2 }; // Index des bonnes r�ponses

    private int _currentQuestion = 0;

    private void Start()
    {
        DisplayQuestion();
    }

    // Affiche la question et les r�ponses
    private void DisplayQuestion()
    {
        _questionText.text = questions[_currentQuestion];
        correctAnswerIndex = _correctAnswers[_currentQuestion];

        for (int i = 0; i < _answerButtons.Length; i++)
        {
            _answerButtons[i].text = answers[_currentQuestion, i];
            int index = i;
            _answerButtons[i].onClick.RemoveAllListeners();
            _answerButtons[i].onClick.AddListener(() => CheckAnswer(index));
        }
    }

    private void CheckAnswer(int index)
    {
        if (index == correctAnswerIndex)
        {
            Debug.Log("Bonne r�ponse!");
        }
        else
        {
            Debug.Log("Mauvaise r�ponse!");
        }

        NextQuestion();
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
            Debug.Log("Quiz termin� !");
        }
    }
}
