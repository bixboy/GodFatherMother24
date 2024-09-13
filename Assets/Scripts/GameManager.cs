using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    public static GameManager Instance => instance;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public static int sceneIndex=0;

    public void NextScene()
    {
        ++sceneIndex;
        sceneIndex = sceneIndex % 5;
        Debug.Log(sceneIndex);
        SceneManager.LoadScene(sceneIndex);
    }

}
