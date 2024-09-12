using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DoorCode : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject _lockPuzzle;
    private bool _isActive = false;

    public void OnInteract(PlayerBehaviour behaviour)
    {
        if (_isActive) return;
        OpenPuzzle(true);
    }

    private void OpenPuzzle(bool on)
    {
        _isActive = on;
        _lockPuzzle.SetActive(true);
        Destroy(GetComponent<BoxCollider2D>());
    }
}
