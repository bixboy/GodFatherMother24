using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    private Animator _animator;

    //TEMP
    [SerializeField] private GameObject _doorBlock;
    public void Open()
    {
        _doorBlock.gameObject.SetActive(false);
        //anim
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //END DAY
            Debug.Log("NEXT DAY");
        }
    }



}
