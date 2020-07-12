namespace Equilibrium
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class WeaponColliderEnemy : MonoBehaviour
    {
        [SerializeField] private EnemyController m_enemyController;
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
                PlayerController controller = other.GetComponent<PlayerController>();
                if (controller != null)
                {
                    controller.GetHit(m_enemyController.Damage);
                }
            }
        }
    }
}
