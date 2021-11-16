using System.Collections;
using Assets.Scripts.Utilities;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Assets.Scripts.MovementGen;

namespace Assets.Scripts.HammerScript
{
    public class Executable : MonoBehaviour
    {
        public Timer timer;
        public string NextScene;
        public TextMesh text;
        public bool noMovementChange = true;
        public bool bloquer = false;
        public ChoiceOfMovement nextMouv;

        // Si on veut skipper/bypasser le 5-4-3-2-1
        public bool IsQuickTeleport = false;

        void Start()
        {
            //Set the tag of this GameObject to Player
            gameObject.tag = Constant.GT_TARGET;
            if(noMovementChange)
                text.text = "";
            else
                text.text = nextMouv.ToString();
        }

        public void Execute() 
        {
            if (!bloquer) {
                bloquer = true;
                if (timer)
                {
                    timer.Stop();
                }

                if (!noMovementChange)
                {
                    PlayerPrefs.SetInt(Constant.PPK_MOVEMENT_CHOICE, (int)nextMouv);
                }

                if (IsQuickTeleport)
                {
                    LoadScene();
                }
                else
                {
                    StartCoroutine("TimerExecute");
                }
            }
        
        }

        private int count = 0;
        private IEnumerator TimerExecute()
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


                yield return new WaitForSeconds(1.0f);
                DataSaver.SaveTime();
                if (count <= 0)
                {
                    LoadScene();
                }
            }

        }

        private void LoadScene()
        {
            PlayerPrefs.SetString(Constant.PPK_SCENE_NAME, NextScene);
            SceneManager.LoadScene(NextScene);
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("Demon detected the colision");
        }
    }
}
