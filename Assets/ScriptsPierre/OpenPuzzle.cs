using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPuzzle : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject _puzzle;
    private bool _isActive = false;
    private PlayerBehaviour _player;

    private void Start()
    {
        _player = GameObject.FindWithTag("Player").GetComponent<PlayerBehaviour>();
    }


    public void OnInteract(PlayerBehaviour behaviour)
    {
        if (_isActive) return;
        Open(true);
    }

    private void Open(bool on)
    {
        _isActive = on;
        _puzzle.SetActive(true);
        Destroy(GetComponent<BoxCollider2D>());
        _player.CanMove = false;
    }
}
