using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelChooseScript : MonoBehaviour
{
    [SerializeField]
    Button Stage_2;
    [SerializeField]
    Button Stage_3;
    [SerializeField]
    Button Stage_4;
    [SerializeField]
    Button Stage_5;



    int _levelCompleted;
    void Start()
    {
        _levelCompleted = PlayerPrefs.GetInt("LevelCompleted");
        Stage_2.interactable = false;
        Stage_3.interactable = false;
        Stage_4.interactable = false;
        Stage_5.interactable = false;

        switch (_levelCompleted)
        {
            case 2:
                Stage_2.interactable = true;
                break;
            case 3:
                Stage_2.interactable = true;
                Stage_3.interactable = true;
                break;
            case 4:
                Stage_2.interactable = true;
                Stage_3.interactable = true;
                Stage_4.interactable = true;
                break;
            case 5:
                Stage_2.interactable = true;
                Stage_3.interactable = true;
                Stage_4.interactable = true;
                Stage_5.interactable = true;
                break;
            default:
                break;
        }
    }

    public void LoadStage(int stage)
    {
        SceneManager.LoadScene(stage);
    }

    public void ResetLevels()
    {
        Stage_2.interactable = false;
        Stage_3.interactable = false;
        Stage_4.interactable = false;
        Stage_5.interactable = false;
        PlayerPrefs.DeleteAll();
    }
    void Update()
    {
        
    }
}
