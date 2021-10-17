using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Movements;
using UnityEngine;

public class WasdMovement : MonoBehaviour, IScriptDeMovement
{
    /*
        Si version non-vr, utilise WASD.
        Si utilise la version VR, utilise les joysticks
     */
    
    [Header("References")]
    [SerializeField] private Rigidbody body;

    [Header("Configuration")]
    [SerializeField] private int constSpeed;
    [SerializeField] private int constRotation;
    [SerializeField] private int constUpForce;

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        transform.Rotate(0.0f, moveHorizontal * constSpeed * 2, 0.0f);
        transform.Translate(0, 0, moveVertical * constSpeed / 20);
    }

    public void BeforeDisable()
    {
        //TODO throw new System.NotImplementedException();
    }
}
