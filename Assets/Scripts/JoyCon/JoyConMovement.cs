 using Assets.Scripts.Movements;
using UnityEngine;

namespace JoyCon
{
    // Blame Jimmy

    public class JoyConMovement : JoyConBehaviour, IScriptDeMovement
    {
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
            base.Start();
            _gyroMagnitude = new HistoricalData(5);
            _speed = 0;
        }

        private void Update()
        {

            Joycon j = JoyConManager.GetJoycon(JcLegInd);
            _playerDirection = j.GetButton(Joycon.Button.SHOULDER_2) ? Vector3.back : Vector3.forward;

            float moveHorizontal = Input.GetAxis("Horizontal");
            transform.Rotate(0.0f, moveHorizontal * constSpeed * 2, 0.0f);
        }

        private void FixedUpdate()
        {
            Joycon j = JoyConManager.GetJoycon(JcLegInd);

            _gyroMagnitude.AddData(j.GetGyro().magnitude);

            _speed = IsWalking() ? 4 : 0;

            body.AddRelativeForce(_playerDirection * (_speed * _gyroMagnitude.Total * constSpeed));
            body.AddForce(Vector3.up * constUpForce);
        }

        public bool IsWalking() => Mathf.Abs(_gyroMagnitude.Total) > 1;
        public void BeforeDisable()
        {
            // TODO throw new System.NotImplementedException();
        }
    }
}
