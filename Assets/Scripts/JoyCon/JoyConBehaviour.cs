using UnityEngine;

namespace JoyCon
{
    public class JoyConBehaviour : MonoBehaviour
    {
        protected JoyconManager JoyConManager;
        protected const int JcLegInd = 0;
        protected const int JcArmInd = 1;

        protected virtual void Start()
        {
            JoyConManager = JoyconManager.Instance;
        }
    }
}
