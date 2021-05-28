using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField]
    GameObject _playPanel;
    [SerializeField]
    GameObject _settingsPanel;
    [SerializeField]
    GameObject _mainPanel;

    [SerializeField]
    Slider _sliderVolume;
    [SerializeField]
    Toggle _toggleVolume;

    string _previousPanel;
    public void Start()
    {
        _previousPanel = _mainPanel.name.ToString();
    }
    public void ChoosePanel(string namePanel)
    {
        GameObject.Find(_previousPanel).SetActive(false);

        if (namePanel == "PlayPanel")
           _playPanel.SetActive(true);
        else if (namePanel == "SettingsPanel")
           _settingsPanel.SetActive(true);
        else if(namePanel == "MainPanel")
           _mainPanel.SetActive(true);

        _previousPanel = namePanel;
    }

    public void VolumeChanges()
    {
        if (_toggleVolume.isOn)
        {
            AudioListener.volume = _sliderVolume.value;
        }
        else
            AudioListener.volume = 0;
    }
    


    public void ExitGame()
    {
        Application.Quit();
    }
    
}
