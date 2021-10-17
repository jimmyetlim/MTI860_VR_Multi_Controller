using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Movements;
using UnityEngine;

public class TeleportMovement : MonoBehaviour, IScriptDeMovement
{
    [Header("References")]
    [SerializeField] private Rigidbody body;

    private bool flag = true;
    private List<MonoBehaviour> scriptsList;

    // Start is called before the first frame update
    void Start()
    {
        flag = true;
        scriptsList = new List<MonoBehaviour>();
        GameObject teleportScript = GameObject.FindGameObjectsWithTag("TeleportationScriptsList").FirstOrDefault();
        if (teleportScript != null)
        {
            scriptsList.Add(teleportScript.GetComponent<LocomotionController>());
            scriptsList.Add(teleportScript.GetComponent<LocomotionTeleport>());
            scriptsList.Add(teleportScript.GetComponent<TeleportInputHandlerTouch>());
            scriptsList.Add(teleportScript.GetComponent<TeleportTargetHandlerPhysical>());
            scriptsList.Add(teleportScript.GetComponent<TeleportAimVisualLaser>());
            scriptsList.Add(teleportScript.GetComponent<TeleportAimHandlerParabolic>());
            scriptsList.Add(teleportScript.GetComponent<TeleportOrientationHandlerThumbstick>());
            scriptsList.Add(teleportScript.GetComponent<TeleportTransitionInstant>());
        }
        else
        {
            Debug.Log("Sheeeet, Cant find!");
        }
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    void FixedUpdate()
    {
        if (scriptsList.Count == 0)
        {
            Debug.Log("SHEEEET");
        }

        if (flag)
        {
            foreach (var script in scriptsList)
            {
                script.enabled = true;
            }

            flag = false;
        }

        //changer à false si on désactive le script
    }

    public void BeforeDisable()
    {
        if (scriptsList.Count != 0)
        {
            foreach (var script in scriptsList)
            {
                script.enabled = false;
            }
        }

        flag = true;
    }

        /*
    public Transform teleportTarget;
    //public GameObject thePlayer;

    void OnTriggerEnter(Collider other)
    {
        transform.position = teleportTarget.transform.position;
        //thePlayer.transform.position = teleportTarget.transform.position;
    }
    */
}