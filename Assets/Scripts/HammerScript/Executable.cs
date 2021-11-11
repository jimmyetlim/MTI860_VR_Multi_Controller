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
        count = 6;
        while (true)
        {
            count--;
            if (text != null) {
                if (count >= 0)
                    text.text = "" + count;
                else
                    text.text = "Done";
            }
 

            yield return new WaitForSeconds(1f);
            if (count <= 0) 
            {
                SceneManager.LoadScene(NextScene);
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Demon detected the colision");
    }
}
