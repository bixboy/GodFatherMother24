using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehaviour : MonoBehaviour
{

    Vector2 _moveInputs;
    private Rigidbody2D _rb;
    [SerializeField]private float _moveSpeed = 5f;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Debug.Log("Move : " + _moveInputs);
        //Move here
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
            Debug.Log("Interact");
        }
    }

}
