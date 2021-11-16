using Assets.Scripts.Utilities;
using UnityEngine;

namespace Assets.Scripts.HammerScript
{
    public class HammerTrigger : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            gameObject.tag = Constant.GT_HAMMER;
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("Hammer detected the colision");
            if (other.gameObject.tag == Constant.GT_TARGET)
            {
                Executable ex = other.gameObject.GetComponent("Executable") as Executable;
                ex.Execute();
            }
        }
    }
}
