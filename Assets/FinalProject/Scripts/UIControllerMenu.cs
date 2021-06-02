using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIControllerMenu : MonoBehaviour
{
    [SerializeField]
    GameObject _addPlayerPanel;
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

    [SerializeField]
    TMP_Text namePlayerPanel;

    string _previousPanel;

    string _namePlayer;

    GameObject[] namePlayerObjects;

    public void Start()
    {
        namePlayerObjects = GameObject.FindGameObjectsWithTag("namePanel");
        NoActiveAllPanel();

        if (PlayerPrefs.HasKey("NamePlayer"))
        {
            GetNamePlayer();
            _mainPanel.SetActive(true);
        }
        else
        {
            _addPlayerPanel.SetActive(true);
        }
        _previousPanel = _mainPanel.name.ToString();
    }

    public void ChangeName()
    {
        _addPlayerPanel.SetActive(true);
        GameObject.Find(_previousPanel).SetActive(false);
    }

    public void NoActiveAllPanel()
    {
        _addPlayerPanel.SetActive(false);
        _playPanel.SetActive(false);
        _mainPanel.SetActive(false);
        _settingsPanel.SetActive(false);
    }

    public void GetNamePlayer()
    {
        _namePlayer = PlayerPrefs.GetString("NamePlayer");
        for (int i = 0; i < namePlayerObjects.Length; i++)
        {
            Debug.Log(_namePlayer);
            namePlayerObjects[i].GetComponentInChildren<TMP_Text>().text = _namePlayer;
        }
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
            PlayerPrefs.SetString("_isPlaySound", "true");
        }
        else
        {
            AudioListener.volume = 0;
            PlayerPrefs.SetString("_isPlaySound", "false");
        }
           
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
