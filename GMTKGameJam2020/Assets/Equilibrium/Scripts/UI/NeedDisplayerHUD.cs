using System;

namespace Equilibrium
{
    using TMPro;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    public class NeedDisplayerHUD : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI m_percentageText;
        [SerializeField] private Image m_imageFill;
        [SerializeField] private IntVariable m_needVariable;

        private void Awake()
        {
            UpdateDisplay(m_needVariable.Value);
        }

        public void UpdateDisplay(int value)
        {
            if (m_needVariable.HasMaxValue == false || m_needVariable.HasMinValue == false)
            {
                throw new Exception("Should have min and max");
            }
            
            float percentage = ((float) m_needVariable.Value - m_needVariable.MinValue) / ((float) m_needVariable.MaxValue - m_needVariable.MinValue);
            int percentage100 = Mathf.FloorToInt(percentage * 100);
            m_imageFill.fillAmount = percentage;
            m_percentageText.SetText($"{percentage100} %");
        }
    }
}

