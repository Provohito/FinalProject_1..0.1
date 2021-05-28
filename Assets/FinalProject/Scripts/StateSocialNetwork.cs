using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class StateSocialNetwork : MonoBehaviour
{
    [SerializeField]
    StateSocial SocialState;

    public void InteractionSocial()
    {
        if (SocialState == StateSocial.Facebook)
        {
            Debug.Log("Facebook");
        }
        else if (SocialState == StateSocial.Twitter)
        {
            Debug.Log("Twitter");
        }
        else if (SocialState == StateSocial.Other)
        {
            Debug.Log("Other");
        }
    }
}
