using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockPuzzle : MonoBehaviour
{
    [SerializeField] private GameObject _passWordUi;
    private bool _win = false;

    void Start()
    {
        GameObject newInstance = Instantiate(_passWordUi, Vector3.zero, Quaternion.identity);
    }

    private void Win()
    {
        if (_win)
        {
            NightDay.instance.ChangeDay();
        }
    }
}
