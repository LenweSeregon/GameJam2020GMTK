namespace Equilibrium
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Events;

    public class SwitchOnOff : MonoBehaviour
    {
        [SerializeField] private UnityEvent _eventSwitchOn;
        [SerializeField] private UnityEvent _eventSwitchOff;
		[SerializeField] private bool m_baseValue = false;

        private bool _on = false;

		private void Awake()
		{
			_on = m_baseValue;
		}

		public void Switch()
        {
            if (_on)
            {
                _eventSwitchOff?.Invoke();
                _on = false;
            }
            else
            {
                _eventSwitchOn?.Invoke();
                _on = true;
            }
        }

        public void Reset()
        {
            _on = false;
        }
    }
}