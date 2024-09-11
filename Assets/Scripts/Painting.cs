using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;

public class Painting : MonoBehaviour, IInteractable
{
    [SerializeField] private SpriteRenderer _light;
                     private PaintingPuzzle _paintingPuzzle;
                     private bool _isActivated = false;
                     private int _paintingIndex;

    public bool IsActivated => _isActivated;
    public int PaintingIndex => _paintingIndex;

    private void Start()
    {
        _paintingPuzzle = transform.parent.GetComponent<PaintingPuzzle>();
        _paintingIndex = transform.GetSiblingIndex() + 1;
    }

    public void OnInteract(PlayerBehaviour behaviour)
    {
        if (_isActivated)
            return;
        SwitchLight(true);
        _paintingPuzzle.CheckPuzzle(_paintingIndex);
    }

    public void SwitchLight(bool on) 
    {
        _light.color = on ? Color.white : Color.black;
        _isActivated = on;
    }

}
