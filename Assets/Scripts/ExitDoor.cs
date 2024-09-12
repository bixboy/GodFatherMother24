using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    private Animator _animator;

    [SerializeField] private GameObject _doorBlock;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    public void Open()
    {
        _animator.SetTrigger("Open");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            NightDay.instance.OpenChangeDay();
        }
    }
}
