using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pause_game : MonoBehaviour
{
    public GameObject pause;
    public GameObject _pauseButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void pause_button()
    {
        pause.SetActive(true);
        _pauseButton.SetActive(false);
        Time.timeScale = 0f;
    }
    public void resume()
    {
        pause.SetActive(false);
        _pauseButton.SetActive(true);
        Time.timeScale = 1f;
    }
    public void quit()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName: "Main Menu");
    }
}
