using System;
using System.Collections;
using UnityEngine;

namespace JoyCon
{
    public enum RumbleType
    {
        ConstantRumble,
        LinearRumble,
        PulseRumble,
    }

    public class JoyConRumble : JoyConBehaviour
    {
        [SerializeField] private RumbleType RumbleType;
        [SerializeField] private int RumbleLocation;
        [SerializeField] private int _rumbleDuration = 250;
        [SerializeField] private int Rep = 10;
        private IEnumerator _coroutine;
        private const float MaxRumbleFrequency = 100f;

        public void Set(RumbleType rumbleType, int rumbleLocation, int rumbleDuration, int rep =10) 
        {
            RumbleType = rumbleType;
            RumbleLocation = rumbleLocation;
            _rumbleDuration = rumbleDuration;
            Rep = rep;
        }

        protected override void Start()
        {
            base.Start();
            switch (RumbleType)
            {
                case RumbleType.ConstantRumble:
                    _coroutine = ConstantRumble();
                    break;
                case RumbleType.LinearRumble:
                    _coroutine = LinearRumble();
                    break;
                case RumbleType.PulseRumble:
                    _coroutine = PulseRumble();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            StartCoroutine(_coroutine);
        }
    
        private IEnumerator ConstantRumble()
        {
            yield return new WaitForSeconds(0.1f);
            Joycon j = JoyConManager.GetJoycon(RumbleLocation);
            j.SetRumble(150, 150, 0.6f, _rumbleDuration);
            yield return new WaitForSeconds(0.1f);
            Destroy(this);
        }
    
        private IEnumerator LinearRumble()
        {
            const float i = 1.05f;
            int time = 0;
            float maxFrequency = 30f;
            yield return new WaitForSeconds(0.1f);
            Joycon j = JoyConManager.GetJoycon(RumbleLocation);
            while(time < Rep)
            {
                j.SetRumble(25, maxFrequency, 0.6f, _rumbleDuration);
                time++;
                maxFrequency = Mathf.Min(maxFrequency * i, MaxRumbleFrequency);
                yield return new WaitForSeconds(0.1f);
            }
            Destroy(this);
        }

        private IEnumerator PulseRumble() {
            yield return new WaitForSeconds(0.1f);
            int time = 0;
            Joycon j = JoyConManager.GetJoycon(RumbleLocation);
            while (time < Rep)
            {
                j.SetRumble(50, 150, 0.6f, 500);
                time++;
                yield return new WaitForSeconds(1f);
            }
            Destroy(this);
        }
    }
}