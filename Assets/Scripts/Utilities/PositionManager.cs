using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Utilities
{
    public class PositionManager : MonoBehaviour
    {
        public GameObject player;
        private List<Position>  data;
        public bool dataSend = false;

        // Start is called before the first frame update
        void Start()
        {
            data = new List<Position>();
            StartCoroutine("TackerExecute");
            gameObject.tag = "Djigby";
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        IEnumerator TackerExecute()
        {
            while (!dataSend)
            {
                data.Add(new Position(player.transform.position.x, player.transform.position.z));
                yield return new WaitForSeconds(1.0f);
            }
        }

        public void StopSavingPosition()
        {
            dataSend = true;
        }

        public List<Position> SendData() 
        {
            dataSend = true;
            return data;
        }

    }
}
