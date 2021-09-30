using UnityEngine;

namespace JoyCon
{
    // Blame Jimmy

    public class JoyConMovement : JoyConBehaviour
    {
        [Header("DEBUG movement")]
        public bool isDebug;

        [Header("References")]
        [SerializeField] private Rigidbody body;
    
        [Header("Configuration")]
        [SerializeField] private int constSpeed;
        [SerializeField] private int constRotation;
        [SerializeField] private int constUpForce;     

        private HistoricalData _gyroMagnitude;

        private int _speed;

        private Vector3 _playerDirection;

    
        protected override void Start()
        {
            if(!isDebug)
            {
                base.Start();
                _gyroMagnitude = new HistoricalData(5);
                _speed = 0;
            }            
        }

        private void Update()
        {
            if(!isDebug)
            {
                Joycon j = JoyConManager.GetJoycon(JcLegInd);
                _playerDirection = j.GetButton(Joycon.Button.SHOULDER_2) ? Vector3.back : Vector3.forward;
            }           
        }

        private void FixedUpdate()
        {
            if(!isDebug)
            {
                Joycon j = JoyConManager.GetJoycon(JcLegInd);
                Joycon jArm = JoyConManager.GetJoycon(JcArmInd);

                _gyroMagnitude.AddData(j.GetGyro().magnitude);

                _speed = IsWalking() ? 4 : 0;

                body.transform.Rotate(0, jArm.GetStick()[0] * constRotation * Time.fixedDeltaTime, 0);

                body.AddRelativeForce(_playerDirection * (_speed * _gyroMagnitude.Total * constSpeed));
                body.AddForce(Vector3.up * constUpForce);
            }

#if DEBUG
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            transform.Rotate(0.0f, moveHorizontal * constSpeed * 2, 0.0f);
            transform.Translate(0, 0,  moveVertical * constSpeed / 20);
#endif
        }

        public bool IsWalking() => Mathf.Abs(_gyroMagnitude.Total) > 1;
    }
}
