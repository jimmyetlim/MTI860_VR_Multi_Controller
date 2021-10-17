using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Movements;
using UnityEngine;

public class OmniMovement : MonoBehaviour, IScriptDeMovement
{
    [Header("References")]
    [SerializeField] private Rigidbody body;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BeforeDisable()
    {
        //TODO throw new System.NotImplementedException();
    }
}
