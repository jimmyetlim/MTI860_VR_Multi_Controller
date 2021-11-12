using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionManager : MonoBehaviour
{
    public GameObject player;
    public List<Position>  data;
    public bool notSended = true;

    // Start is called before the first frame update
    void Start()
    {
        data = "";
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
    public sendData() 
    {
        notSended = false;
        DataSaver.SavePosition(data);
    }

}
