using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementGen : MonoBehaviour
{

    [Header("DEBUG movement")]
    public bool isDebug;

    [Header("References")]
    [SerializeField] private Rigidbody body;

    [Header("Configuration")]
    [SerializeField] private int constSpeed;
    [SerializeField] private int constRotation;
    [SerializeField] private int constUpForce;

    private int _speed;

    private Vector3 _gyroMagnitude;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
