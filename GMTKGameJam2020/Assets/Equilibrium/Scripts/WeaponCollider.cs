using System;

namespace Equilibrium
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class WeaponCollider : MonoBehaviour
    {
        [SerializeField] private float m_pushForce = 40000;
        [SerializeField] private Transform m_playerTransform;
        [SerializeField] private IntVariable m_strengthPlayer;
        [SerializeField] private float m_damagePerStrength = 1;
        [SerializeField] private float m_baseDamage = 15;
        private bool m_canTrigger;
        
        public void CanTrigger(bool can)
        {
            m_canTrigger = true;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (m_canTrigger == true)
            {
                m_canTrigger = false;
                EnemyController controller = other.GetComponent<EnemyController>();
                if (controller != null)
                {
                    float dmg = m_baseDamage + (m_strengthPlayer.Value * m_damagePerStrength);
                    dmg = Mathf.Clamp(dmg, 10, int.MaxValue);
                    controller.GetHit((int) dmg, m_playerTransform.forward, m_pushForce);
                }
            }
        }
    }
}