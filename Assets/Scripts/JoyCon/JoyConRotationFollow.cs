using UnityEngine;

namespace JoyCon
{
    public class JoyConRotationFollow : JoyConBehaviour
    {
        [SerializeField] private Transform ObjectParent;
        [SerializeField] private Transform ObjectToRotate;

        private void Update()
        {
            Joycon j = JoyConManager.GetJoycon(JcArmInd);
            if (j.GetButtonDown(Joycon.Button.SHOULDER_2))
            {
                j.Recenter();
            }
            ObjectToRotate.eulerAngles = ObjectParent.eulerAngles + j.GetVector().eulerAngles;
        }
    }
}