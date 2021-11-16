using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Utilities
{
    public class PositionManager : MonoBehaviour
    {
        public GameObject player;
        private List<Position>  data;
        public bool notSended = true;

        // Start is called before the first frame update
        void Start()
        {
            data = new List<Position>();
            StartCoroutine("TackerExecute");
        }

        // Update is called once per frame
        void Update()
        {
        
        }


        IEnumerator TackerExecute()
        {
            while (notSended)
            {
                data.Add(new Position(player.transform.position.x, player.transform.position.y));
                yield return new WaitForSeconds(1.0f);
            }
        }
        public void sendData() 
        {
            notSended = false;
            DataSaver.SavePosition(data);
        }

    }
}
