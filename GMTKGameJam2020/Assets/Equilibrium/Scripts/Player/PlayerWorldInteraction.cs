namespace Equilibrium
{
    using System;
    using UnityEngine.InputSystem;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class PlayerWorldInteraction : MonoBehaviour
    {
        [SerializeField] private LayerMask m_layerMask;
        [SerializeField] private float m_distanceInteraction = 2f;
        [SerializeField] private float m_minAngle = -10;
        [SerializeField] private float m_maxAngle = 10;
        [SerializeField] private GameObject m_uiInteract;
        [SerializeField] private Vector3 m_offsetRaycast = new Vector3(0, 1, 0);

        private Interactable m_interactable;
        private Vector3 positionCenter;

        private void Update()
        {
            m_interactable = null;

            Debug.DrawRay(transform.position + m_offsetRaycast, transform.forward * m_distanceInteraction, Color.red, Time.deltaTime);
            if(Physics.Raycast(transform.position + m_offsetRaycast, transform.forward, out var hit, m_distanceInteraction, m_layerMask))
            {
                Interactable interactableHit = hit.transform.gameObject.GetComponent<Interactable>();
                if (interactableHit == null)
                    return;

                m_interactable = interactableHit;
            }
            else
            {
                m_interactable = null;
            }
            
            
            m_uiInteract.gameObject.SetActive(m_interactable != null);
        }
        
        public void Interact(InputAction.CallbackContext ctx)
        {
            if (ctx.started && m_interactable != null)
            {
                m_interactable.Interact();
                Destroy(m_interactable.gameObject);
                m_interactable = null;
            }
        }
    }
}

