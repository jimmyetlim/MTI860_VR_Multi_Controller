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
        public TextMesh text;

        public string NextScene;
        public ChoiceOfMovement nextMouv;

        public MovementGen target;
        public PositionManager positionManager;

        public bool noMovementChange = true;
        public bool changeMouvementForPractice = false;

        // Si on veut skipper/bypasser le 5-4-3-2-1
        public bool IsQuickTeleport = false;

        private bool prevent_hit_twice = false;

        void Start()
        {
            positionManager = GameObject.FindGameObjectsWithTag("Djigby")[0].GetComponent<PositionManager>();

            //Set the tag of this GameObject to Player
            gameObject.tag = Constant.GT_TARGET;
            if(noMovementChange)
                text.text = "";
            else
                text.text = nextMouv.ToString();
        }

        public void Execute() 
        {
            if (!prevent_hit_twice) {
                prevent_hit_twice = true;
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
                else if (changeMouvementForPractice)
                {
                    StartCoroutine("Practice");
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
            count = 4;
            positionManager.StopSavingPosition();

            while (true)
            {
                count--;
                if (text != null) {
                    if (count > 0)
                        text.text = "" + count;
                    else
                        text.text = "Done";
                }

                yield return new WaitForSeconds(1.0f);
                if (count <= 0)
                {
                    DataSaver.SaveTime();
                    DataSaver.SavePosition(positionManager.SendData());
                    LoadScene();
                }
            }
        }

        private IEnumerator Practice()
        {
            yield return new WaitForSeconds(2);
            PlayerPrefs.SetInt(Constant.PPK_MOVEMENT_CHOICE, (int)nextMouv);
            target.ChangeMovement(nextMouv);
        }

        private void LoadChangeMouvement()
        {
            PlayerPrefs.SetInt(Constant.PPK_MOVEMENT_CHOICE, (int)nextMouv);
            target.ChangeMovement(nextMouv);
        }

        private void LoadScene()
        {
            PlayerPrefs.SetString(Constant.PPK_SCENE_NAME, NextScene);
            SceneManager.LoadScene(NextScene);
        }

        private void OnTriggerEnter(Collider other)
        {
            //Debug.Log("Demon detected the colision");
        }
    }
}
