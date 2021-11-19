using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Utilities
{
    public class Timer : MonoBehaviour
    {
        private float time { get; set; }
        private bool timerStop { get; set; }

        // TODO JIMMY : Rename this
        [SerializeField]
        private TextMesh textmesh;
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
            PlayerPrefs.SetString(Constant.PPK_TIMER_TIME, textmesh.text);
            StopCoroutine(timerRoutine);

        }

        IEnumerator TimerExecute()
        {
            while (true) 
            {
                if (!timerStop)
                {
                    time += 0.1f;
                    if (textmesh != null)
                        textmesh.text = ""+ (Mathf.Round(time * 10) * 0.1f).ToString("F1");
                    yield return new WaitForSeconds(.1f);
                }
            }
       
        }
    }
}
