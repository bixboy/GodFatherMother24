using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;

public class Painting : MonoBehaviour, IInteractable
{
    [SerializeField] private Animator _lightAnim;
                     private PaintingPuzzle _paintingPuzzle;
                     private bool _isActivated = false;
                     private int _paintingIndex;

    public bool IsActivated => _isActivated;
    public int PaintingIndex => _paintingIndex;
    public enum LightAnimState
    {
        ON,
        OFF,
        FAIL
    }

    private void Start()
    {
        _paintingPuzzle = transform.parent.GetComponent<PaintingPuzzle>();
        _paintingIndex = transform.GetSiblingIndex() + 1;
    }

    public void OnInteract(PlayerBehaviour behaviour)
    {
        if (_isActivated)
            return;
        SwitchLight(_paintingPuzzle.CheckPuzzle(_paintingIndex)? LightAnimState.ON : LightAnimState.FAIL);
    }

    public void SwitchLight(LightAnimState state) 
    {
        switch (state)
        {
            case LightAnimState.ON:
                _lightAnim.SetBool("ON", true);
                return;
            case LightAnimState.OFF:
                _lightAnim.SetBool("ON", false);
                return;
            case LightAnimState.FAIL:
                _lightAnim.SetTrigger("Fail");
                return;
        }
    }

}
