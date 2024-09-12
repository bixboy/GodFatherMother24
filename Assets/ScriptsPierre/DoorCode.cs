using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCode : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject _lockPuzzle;
    private bool _isActive = false;

    public void OnInteract(PlayerBehaviour behaviour)
    {
        if (_isActive) return;
        OpenDoor(true);
    }

    private void OpenDoor(bool on)
    {
        _isActive = on;
        _lockPuzzle.SetActive(true);
    }
}
