using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class MainMenu : MonoBehaviour
{
    public void QuitGame() => Quit();
    public void PauseGame(InputAction.CallbackContext context) => Pause(context);

    private bool _isPaused = false;

    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }
    

    private void Quit()
    {
        Application.Quit();
    }

    private void Pause(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (_animator != null)
            {
                if (_isPaused != true)
                {
                    _isPaused = true;
                    _animator.SetBool("IsPaused", _isPaused);
                    Time.timeScale = 0;
                }
                else
                {
                    Resum();
                }
            }
        }
    }

    private void Resum()
    {
        Time.timeScale = 1;
        _isPaused = false;
        _animator.SetBool("IsPaused", _isPaused);
    }
}
