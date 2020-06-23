using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public bool vibration;
    public Slider volume;
    private float _volume;
    public Toggle vib;
    public GameObject _settings;
    public GameObject _menu;
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("volume"))
        {
            PlayerPrefs.SetFloat("volume", 1);
            PlayerPrefs.Save();
            volume.value = 1;
        }
        else
        {
            volume.value = PlayerPrefs.GetFloat("volume");
        }
        if (!PlayerPrefs.HasKey("vibration"))
        {
            PlayerPrefs.SetInt("vibration", 1);
            PlayerPrefs.Save();
            vibration = true;
            vib.isOn = true;
        }
        else
        {
            if(PlayerPrefs.GetInt("vibration") == 0)
            {
                vib.isOn = false;
                vibration = false;
            }
            else
            {
                vib.isOn = true;
                vibration = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
       _volume =  volume.value;
        vibration = vib.isOn;
    }
    public void back()
    {
        PlayerPrefs.SetFloat("volume", _volume);
        if (vibration)
        {
            PlayerPrefs.SetInt("vibration", 1);
        }
        else
        {
            PlayerPrefs.SetInt("vibration", 0);
        }
        _settings.SetActive(false);
        _menu.SetActive(true);
    }
    
}
