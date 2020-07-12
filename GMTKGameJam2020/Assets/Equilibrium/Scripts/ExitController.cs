using System;

namespace Equilibrium
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class ExitController : MonoBehaviour
    {
        [SerializeField] private GameController m_gameController;
        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<PlayerController>() != null)
            {
                m_gameController.GameWon();
            }
        }
    }
}

