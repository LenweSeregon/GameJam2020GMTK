using System;
using TMPro;

namespace Equilibrium
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class IntDisplayer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI m_text;
        [SerializeField] private IntVariable m_variable;

        private void Awake()
        {
            m_text.SetText(m_variable.Value.ToString());
        }

        public void UpdateDisplay(int value)
        {
            m_text.SetText(value.ToString());
        }
    }
}

