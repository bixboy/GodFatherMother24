using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    private Animator _animator;

    [SerializeField] private GameObject _doorBlock;
    bool _isLocked = true;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    public void Open()
    {
        _animator.SetTrigger("Open");
        _isLocked = false;
        gameObject.transform.position += new Vector3(0, 0, -1);
        CameraManager.Instance.ScreenShake();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_isLocked)
            return;
        if (collision.gameObject.CompareTag("Player"))
        {
            NightDay.instance.OpenChangeDay();
            collision.GetComponent<PlayerBehaviour>().CanMove = false;
        }
    }
}
