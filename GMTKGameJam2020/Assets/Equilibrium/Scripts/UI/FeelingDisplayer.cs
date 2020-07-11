using System;
using TMPro;

namespace Equilibrium
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    public class FeelingDisplayer : MonoBehaviour
    {
        [SerializeField] private Slider m_progress;
        [SerializeField] private FeelingsSO m_feelingSO;
        [SerializeField] private IntVariable m_feelingValue;
        [SerializeField] private TextMeshProUGUI m_textProgress;
        [SerializeField] private Transform m_containerEffects;
        [SerializeField] private FeelingEffectDisplayer m_feelingEffectPrefab;

        private void Awake()
        {
            UpdateDisplayer(m_feelingValue.Value);
        }

        private void CleanContainer()
        {
            foreach (Transform child in m_containerEffects)
            {
                Destroy(child.gameObject);
            }
        }

        public void UpdateDisplayer(int value)
        {
            if (m_feelingValue.HasMinValue == false || m_feelingValue.HasMaxValue == false)
            {
                throw new Exception("Feeling value need min and max value");
            }
            
            float percentage = ((float) value - m_feelingValue.MinValue) / ((float) m_feelingValue.MaxValue - m_feelingValue.MinValue);
            int percentage100 = Mathf.FloorToInt(percentage * 100);
            m_progress.value = percentage;
            m_textProgress.SetText($"{percentage100} %");

            CleanContainer();
            
            // Retrieve effects
        }
    }
}

