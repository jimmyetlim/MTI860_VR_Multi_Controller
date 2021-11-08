using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static MovementGen;
using UnityEngine.SceneManagement;

public class Executable : MonoBehaviour
{
    public Timer timer;
    public string NextScene;
    public TextMesh text;
    public bool IsQuickTeleport = false;
    public bool noMovementChange = true;
    public ChoiceOfMovement nextMouv;
    
    void Start()
    {
        //Set the tag of this GameObject to Player
        gameObject.tag = "Target";
    }

    public void Execute() 
    {
        if (timer) 
        {
            timer.Stop();
        }
        if (!noMovementChange) 
        {
            PlayerPrefs.SetInt("mouvement", (int)nextMouv);
        }
        if (IsQuickTeleport)
        {
            SceneManager.LoadScene(NextScene);
        }
        else 
        {
             StartCoroutine("TimerExecute");
        }
    }
    private int count = 0;
    IEnumerator TimerExecute()
    {
        count = 3;
        while (true)
        {
            count--;
            yield return new WaitForSeconds(1f);
            if (count <= 0) 
            {
                SceneManager.LoadScene(NextScene);
            }
        }

    }
}
