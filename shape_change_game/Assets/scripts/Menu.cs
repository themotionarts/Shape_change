using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject settings_Canvas;
    public GameObject mainMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void play()
    {
        SceneManager.LoadScene(sceneName: "Level");
    }
    public void settings()
    {
        settings_Canvas.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void settings_off()
    {
        settings_Canvas.SetActive(false);
        mainMenu.SetActive(true);
    }
}
