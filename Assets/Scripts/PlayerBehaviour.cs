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
    }

    private void MovePlayer()
    {
        Vector2 movement = _moveInputs * _moveSpeed * Time.fixedDeltaTime;
        _rb.MovePosition(_rb.position + movement);
    }

    #endregion

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _closestInteractable?.OnInteract(this);
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
}
