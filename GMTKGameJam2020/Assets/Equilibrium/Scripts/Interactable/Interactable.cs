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

        public void Apply()
        {
            int random = UnityEngine.Random.Range(m_minFactor, m_maxFactor);
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

