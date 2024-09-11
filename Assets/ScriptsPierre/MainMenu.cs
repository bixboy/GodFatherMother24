using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public void PlayGame() => Play();
    public void QuitGame() => Quit();
    public void PauseGame() => Pause();

    private bool _isPaused = false;

    private Animator _animator;

    private void start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Play()
    {
        SceneManager.LoadScene("EmaScene");
    }

    private void Quit()
    {
        Application.Quit();
    }

    private void Pause()
    {
        if (_animator != null)
        {
            if (_isPaused == true)
            {

                _isPaused = true;
                Time.timeScale = 0;
            }
            else
            {
                Resum();
            }
        }
    }

    private void Resum()
    {
        Time.timeScale = 1;
        _isPaused = false;
    }
}
