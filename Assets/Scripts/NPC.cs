using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NPC : MonoBehaviour, IInteractable
{
    [SerializeField] private List<string> listLines = new();
    bool _isTalking = false;

    public void OnInteract(PlayerBehaviour behaviour)
    {
        if(_isTalking == false)
        {
            behaviour.CanMove = false;
            //talk
        }
        else        
        {
            behaviour.CanMove = true;
            //remove talk (or skip line
        }
    }

}
