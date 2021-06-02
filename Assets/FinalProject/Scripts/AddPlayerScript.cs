using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AddPlayerScript : MonoBehaviour
{
    [SerializeField]
    TMP_InputField namePlayer;
    [SerializeField]
    TMP_Text alertText;
    [SerializeField]
    GameObject alertWindow;
    [SerializeField]
    GameObject MainPanel;
    [SerializeField]
    UIControllerMenu uiController;




    private void Start()
    {

    }

    public void SetName()
    {
        string _namePlayer = namePlayer.text;
        Debug.Log(CheckCount(_namePlayer) + " " + CheckEnglish(_namePlayer) + " " + CheckFirstLetter(_namePlayer));
        if (CheckCount(_namePlayer) && CheckEnglish(_namePlayer) && CheckFirstLetter(_namePlayer))
        {

            PlayerPrefs.SetString("NamePlayer", _namePlayer);
            PlayerPrefs.SetInt("LevelCompleted", 1);
            uiController.GetNamePlayer();
            MainPanel.SetActive(true);
            this.gameObject.SetActive(false);
        }
        
    }
    bool CheckEnglish(string text)
    {
        int countTrues = 0;
        
        for (int i = 0; i < text.Length; i++)
        {

            if (text[i] >= 65 && text[i] <= 90 || text[i] >= 97 && text[i] <= 122 || (text[i] >= '0' && text[i] <=  '9'))
                countTrues += 1;
            Debug.Log("countTrues" + countTrues);
            
        }
        Debug.Log( " text.length" +text.Length );
        if (countTrues == text.Length)
            return true;
        StartCoroutine(OpenAlertWindow("Write your name in English"));
        return false;
    }
    bool CheckCount(string text)
    {
        if (text.Length > 8)
        {
            StartCoroutine(OpenAlertWindow("Check the number of characters in your Name"));
            return false;
        }

        return true;
    }

    bool CheckFirstLetter(string text)
    {
        if (text[0] == text.ToUpper()[0])
            return true;

        StartCoroutine(OpenAlertWindow("Capital letter must be capital or number"));
        return false;
    }

    IEnumerator OpenAlertWindow(string textMessage)
    {
        alertWindow.SetActive(true);
        alertText.text = textMessage;
        yield return new WaitForSeconds(2f);
        alertWindow.SetActive(false);

    }
}
