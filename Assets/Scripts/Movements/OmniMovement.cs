using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Movements;
using UnityEngine;
using Valve.VR;

public class OmniMovement : MonoBehaviour, IScriptDeMovement
{
    [Header("References")]
    [SerializeField] private Rigidbody body;

    [SerializeField] private SteamVR_Action_Boolean movePress = null;
    [SerializeField] private SteamVR_Action_Vector2 moveVal = null;
    //[SerializeField] private PlayerController ctrl = null;

    [Header("Configuration")]

    [SerializeField] private float _speed;
    [SerializeField] private int constSpeed;
    [SerializeField] private int constRotation;
    [SerializeField] private int constUpForce;
    [SerializeField] private float sensitivity;


    void Start()
    {
        _speed = 0;
    }

    private void Update()
    {


        /*float moveHorizontal = Input.GetAxis("Horizontal");
        transform.Rotate(0.0f, moveHorizontal * constSpeed * 2, 0.0f);*/
    }

    private void FixedUpdate()
    {

        if (movePress.state) 
        {
            Debug.Log("(" + moveVal.axis.x + ", " + moveVal.axis.y + ")");
            float valY = getY();
            if (valY != 0) {

                transform.Translate(0, 0, valY * constSpeed / 20);
            }
            float valX = getX();
            if (valX != 0)
            {
                transform.Rotate(0.0f, valX * constRotation * 2, 0.0f);
            }

        }


    }

    float getX() 
    {
        return (moveVal.axis.x > sensitivity || moveVal.axis.x < -sensitivity) ? moveVal.axis.x:0;
    }
    float getY()
    {
        return (moveVal.axis.y > sensitivity || moveVal.axis.y < -sensitivity) ? moveVal.axis.y : 0;
    }

    public void BeforeDisable()
    {
        //TODO throw new System.NotImplementedException();
    }
}
