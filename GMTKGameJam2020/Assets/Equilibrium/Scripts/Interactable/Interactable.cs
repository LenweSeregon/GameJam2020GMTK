namespace Equilibrium
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    [Serializable]
    public class InteractableInteraction
    {
        [SerializeField] private IntVariable m_variableToModify;
        [SerializeField] private int m_maxFactor;
        [SerializeField] private int m_minFactor;

        [SerializeField] private bool m_useChances = false;
        [SerializeField] private IntVariable m_chance;

        public void Apply()
        {
            int random = 0;
            if (m_useChances)
            {
                random = UnityEngine.Random.Range(m_minFactor, m_maxFactor + m_chance.Value);
            }
            else
            {
                random = UnityEngine.Random.Range(m_minFactor, m_maxFactor);
            }
            
            int newValue = m_variableToModify.Value + random;
            
            if (m_variableToModify.HasMaxValue && m_variableToModify.HasMinValue)
            {
                newValue = Mathf.Clamp(newValue, m_variableToModify.MinValue, m_variableToModify.MaxValue);
                m_variableToModify.Value = newValue;
            }
            else
            {
                m_variableToModify.Value = newValue;
            }
        }
    }
    
    public class Interactable : MonoBehaviour
    {
        [SerializeField] private InteractableInteraction[] m_interactions;
        
        public void Interact()
        {
            foreach (var interaction in m_interactions)
            {
                interaction.Apply();
            }
        }
    } 
}

