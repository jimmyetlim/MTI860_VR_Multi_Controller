using System;
using System.Collections.Generic;
using Assets.Scripts.Movements;
using Assets.Scripts.Utilities;
using UnityEngine;

public class PlayerNameManager : MonoBehaviour
{

    [SerializeField] private string nomDuJoueur = string.Empty;

    // Start is called before the first frame update
    void Start()
    {
        if (nomDuJoueur == string.Empty)
        {
            nomDuJoueur = DateTime.Now.ToString("YYYY-MM-dd_HH-mm");
        }
        PlayerPrefs.SetString(Constant.PPK_PLAYER_NAME, nomDuJoueur);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
