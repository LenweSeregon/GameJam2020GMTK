namespace Equilibrium
{
    using System;
    using TMPro;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    public enum DisplayMode
    {
        Percentage,
        Value
    }
    
    public class IntDisplayer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI m_text;
        [SerializeField] private IntVariable m_variable;
        [SerializeField] private Image m_ui;
        [SerializeField] private Slider m_slider;
        [SerializeField] private DisplayMode m_displayMode;
        
        private void Awake()
        {
            UpdateDisplay(m_variable.Value);
            
        }

        public void UpdateDisplay(int value)
        {
            if (m_ui != null && m_displayMode == DisplayMode.Percentage)
            {
                if (m_variable.HasMaxValue == false || m_variable.HasMinValue == false)
                {
                    throw new Exception("Should have min and max for UI bar");
                }
                float percentage = ((float) m_variable.Value - m_variable.MinValue) / ((float) m_variable.MaxValue - m_variable.MinValue);
                m_ui.fillAmount = percentage;
            }

            if (m_slider != null && m_displayMode == DisplayMode.Percentage)
            {
                if (m_variable.HasMaxValue == false || m_variable.HasMinValue == false)
                {
                    throw new Exception("Should have min and max for UI bar");
                }
                float percentage = ((float) m_variable.Value - m_variable.MinValue) / ((float) m_variable.MaxValue - m_variable.MinValue);
                m_slider.value = percentage;
            }

            if (m_text != null)
            {
                if (m_displayMode == DisplayMode.Percentage)
                {
                    if (m_variable.HasMaxValue == false || m_variable.HasMinValue == false)
                    {
                        throw new Exception("Should have min and max for UI bar");
                    }
                    
                    float percentage = ((float) m_variable.Value - m_variable.MinValue) / ((float) m_variable.MaxValue - m_variable.MinValue);
                    int percentage100 = Mathf.FloorToInt(percentage * 100);
                    m_text.SetText($"{percentage100} %");
                }
                else if(m_displayMode == DisplayMode.Value)
                {
                    m_text.SetText(value.ToString()); 
                }
            }
        }
    }
}

