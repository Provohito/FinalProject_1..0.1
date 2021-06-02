using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIControllerGame : MonoBehaviour
{
    string _isPlaySound;
    [SerializeField]
    Sprite[] soundSprites;
    [SerializeField]
    Button soundBtn;
    [SerializeField]
    GameObject infoPanel;


    private void Start()
    {
        ChangeVolume();
        _isPlaySound = PlayerPrefs.GetString("_isPlaySound");
    }


    

    public void ChangeVolume()
    {
        if (_isPlaySound == "true")
        {
            soundBtn.gameObject.GetComponent<Image>().sprite = soundSprites[0];
            AudioListener.volume = 1;
            _isPlaySound = "false";
        }
        else
        {
            soundBtn.gameObject.GetComponent<Image>().sprite = soundSprites[1];
            AudioListener.volume = 0;
            _isPlaySound = "true";
        }
    }


    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
    }

    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
    }

}
