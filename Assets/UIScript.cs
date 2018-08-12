using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public GameObject PausePanel;
    CanvasGroup Settings;
    static bool paused;


    void Start()
    {
        if (PausePanel != null)
        {
            Settings = PausePanel.GetComponent<CanvasGroup>();
        }
        if (Settings != null)
        {
            DisAppear();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void UnPauseGame()
    {
        Time.timeScale = 1;
    }

    public void Appear()
    {
        PauseGame();
        Settings.alpha = 1;
        Settings.blocksRaycasts = true;
    }

    public void DisAppear()
    {
        UnPauseGame();
        Settings.alpha = 0;
        Settings.blocksRaycasts = false;
    }

    static readonly bool Paused;

    public static bool IsPaused()
    {
        return Paused;
    }

    // This needs to be public so it can be seen by the UI, itwill be the code that runs
    public void StartGame()
    {
        // tell the scenemanager which scene to run
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void reStartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
    
        public void Quit()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit ();
#endif
        }
    

}