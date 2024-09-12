using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenQuiz : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject _QuizPuzzle;
    private bool _isActive = false;

    public void OnInteract(PlayerBehaviour behaviour)
    {
        if (_isActive) return;
        OpenPuzzle(true);
    }

    private void OpenPuzzle(bool on)
    {
        _isActive = on;
        _QuizPuzzle.SetActive(true);
        Destroy(GetComponent<BoxCollider2D>());
    }
}
