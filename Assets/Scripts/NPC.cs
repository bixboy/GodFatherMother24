using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NPC : MonoBehaviour, IInteractable
{
    [SerializeField] private List<string> listLines = new();
    bool _isTalking = false;
    [SerializeField] private Sprite _characterImg;

    public void OnInteract(PlayerBehaviour behaviour)
    {
        if(_isTalking == false)
        {
            //behaviour.CanMove = false;
            //talk
            dialogue.instance.SartDialogue("gfdgfdfgdfgdfgfd", _characterImg);
        }
        else        
        {
            behaviour.CanMove = true;
            //remove talk (or skip line
        }
    }

}
