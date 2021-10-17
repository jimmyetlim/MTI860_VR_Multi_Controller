using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Movements;
using UnityEngine;

public class MovementGen : MonoBehaviour
{
    private Dictionary<ChoiceOfMovement, MonoBehaviour> components;
    private ChoiceOfMovement currentMovement;

    [SerializeField] private ChoiceOfMovement selectedMovement;


    // Start is called before the first frame update
    void Start()
    {
        components = new Dictionary<ChoiceOfMovement, MonoBehaviour>();
        components.Add(ChoiceOfMovement.wasd,       this.GetComponent<WasdMovement>());
        components.Add(ChoiceOfMovement.teleport,   this.GetComponent<TeleportMovement>());
        components.Add(ChoiceOfMovement.joystick,   this.GetComponent<JoystickMovement>());
        components.Add(ChoiceOfMovement.joycon,     this.GetComponent<JoyCon.JoyConMovement>());
        components.Add(ChoiceOfMovement.omni,       this.GetComponent<OmniMovement>());

        selectedMovement = ChoiceOfMovement.wasd;
        currentMovement = ChoiceOfMovement.wasd;
        components[currentMovement].enabled = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(selectedMovement != currentMovement)
        {
            if (components[currentMovement] is IScriptDeMovement)
            {

                ((IScriptDeMovement) components[currentMovement]).BeforeDisable();
            }

            components[currentMovement].enabled = false;
            components[selectedMovement].enabled = true;
            currentMovement = selectedMovement;
        }
    }

    public void ChangeMovement(ChoiceOfMovement newChoice)
    {
        selectedMovement = newChoice;
    }

    public enum ChoiceOfMovement
    {
        wasd = 0,
        teleport = 1,
        joystick = 2,
        joycon = 3,
        omni = 4
    }
}
