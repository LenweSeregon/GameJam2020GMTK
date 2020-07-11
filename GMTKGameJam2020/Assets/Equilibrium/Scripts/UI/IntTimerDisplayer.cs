namespace Equilibrium
{
    using TMPro;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class IntTimerDisplayer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI m_text;
        [SerializeField] private IntVariable m_variable;
        
        private void Awake()
        {
            UpdateDisplay(m_variable.Value);
            
        }

        public void UpdateDisplay(int value)
        {
            if (m_text != null)
            {
                string minutes = Mathf.Floor(value / 60.0f).ToString("00");
                string seconds = (value % 60).ToString("00");

                m_text.SetText(minutes + "'" + seconds);
            }
        }
    }
}