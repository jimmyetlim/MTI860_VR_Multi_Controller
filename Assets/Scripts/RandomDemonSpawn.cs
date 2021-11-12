using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class RandomDemonSpawn : MonoBehaviour
{
    public GameObject[] listeCommeTuVeux;

    // Start is called before the first frame update
    void Start()
    {
        Random rnd = new Random();
        int card = rnd.Next(1, 3);

        listeCommeTuVeux[0].SetActive(card == 1);
        listeCommeTuVeux[1].SetActive(card != 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
