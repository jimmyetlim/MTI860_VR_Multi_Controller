using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hello: " + other.name);
        if (other.gameObject.tag == "Target")
        {
            Executable ex = other.gameObject.GetComponent("Executable") as Executable;
            ex.Execute();
        }
    }
}
