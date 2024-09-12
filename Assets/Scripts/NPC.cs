using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NPC : MonoBehaviour, IInteractable
{
    [SerializeField] private List<string> _listLines = new();
    bool _isTalking = false;
    [SerializeField] private Sprite _characterImg;
    private int _index = 0;
    public void OnInteract(PlayerBehaviour behaviour)
    {
        if (_isTalking == false)
        {
            //behaviour.CanMove = false;
            //talk
            Debug.Log("ouiii");
            string text = _listLines[_index];
            dialogue.instance.SartDialogue(text, _characterImg);
            _index++;
            if (_index == _listLines.Count) _index = 0;
        }
        else        
        {
            behaviour.CanMove = true;
            //remove talk (or skip line
        }
    }

}
