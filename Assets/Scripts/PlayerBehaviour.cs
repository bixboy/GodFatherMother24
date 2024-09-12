using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.U2D;
using static Unity.VisualScripting.Member;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    Vector2 _moveInputs;
    private Rigidbody2D _rb;
    IInteractable _closestInteractable;
    bool _canMove = true;

    public bool CanMove
    {
        get => _canMove; set => _canMove = value;
    }

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if(_canMove)
            MovePlayer();
    }

    #region Movements
    public void OnMove(InputAction.CallbackContext context)
    {
        _moveInputs = context.ReadValue<Vector2>();
        //Debug.Log(_moveInputs);

    }

    private void MovePlayer()
    {
        Vector2 movement = _moveInputs * _moveSpeed * Time.fixedDeltaTime;
        _rb.MovePosition(_rb.position + movement);
        _animator.SetBool("IsWalking", _moveInputs.magnitude != 0);
        if(_moveInputs.magnitude != 0)
            _spriteRenderer.flipX = _moveInputs.x >= 0;
    }

    #endregion

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _closestInteractable?.OnInteract(this);
        }
    }    
    
    public void OnClick(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (NightDay.instance.WaitingForInput)
            {
                NightDay.instance.NextDay();
                return;
            }

            TellerActions.Instance?.NextTellerAction();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        var tempMonoArray = col.gameObject.GetComponents<MonoBehaviour>();

        foreach (var monoBehaviour in tempMonoArray)
        {
            IInteractable tempInteractable = monoBehaviour as IInteractable;

            if (tempInteractable != null)
            {
                _closestInteractable = tempInteractable;
                break;
            }
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        _closestInteractable = null;
    }
}
