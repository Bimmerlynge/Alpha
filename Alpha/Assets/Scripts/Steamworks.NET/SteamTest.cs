using System.Collections;
using System.Collections.Generic;
using Steamworks;
using TMPro;
using UnityEngine;

public class SteamTest : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        if (SteamManager.Initialized)
        {
            string name = SteamFriends.GetPersonaName();
            text.text = name;
        }
        
    }

   
}
