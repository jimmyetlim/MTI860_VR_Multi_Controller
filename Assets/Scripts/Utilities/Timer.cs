using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private float time { get; set; }
    private bool timerStop { get; set; }

    // TODO JIMMY : Rename this
    [SerializeField]
    private TextMesh text;
    // TODO JIMMY :   ^ Rename this

    private Coroutine timerRoutine;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        timerRoutine = StartCoroutine("TimerExecute");
    }

    private void FixedUpdate()
    {

    }

	public void Stop()
	{
        timerStop = true;
        PlayerPrefs.SetString(Constant.PPK_TIMER_TIME, text.text);
        StopCoroutine(timerRoutine);

    }

	IEnumerator TimerExecute()
	{
        while (true) 
        {
            if (!timerStop)
            {
                time += 0.1f;
                if (text != null)
                    text.text = ""+ (Mathf.Round(time * 10) * 0.1f).ToString("F1");
                yield return new WaitForSeconds(.1f);
            }
        }
       
	}
}
