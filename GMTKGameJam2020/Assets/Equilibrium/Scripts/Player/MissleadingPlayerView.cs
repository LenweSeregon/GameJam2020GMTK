using System;

namespace Equilibrium
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class MissleadingPlayerView : MonoBehaviour
    {
        [SerializeField] protected IntVariable m_missleadingView;
        [SerializeField] protected GameObject m_goMissleading;
        [SerializeField] protected GameObject m_goNormal;

        private bool m_listen;
        
        private void Awake()
        {
            m_listen = true;
            UpdateMissleadingView();
        }

        public void ResetNormal()
        {
            m_listen = false;
            m_goMissleading.gameObject.SetActive(false);
            m_goNormal.gameObject.SetActive(true);
        }

        public void Listen()
        {
            m_listen = true;
        }
        
        public void UpdateMissleadingView()
        {
            if (m_listen)
            {
                if (m_missleadingView.Value > 0)
                {
                    m_goMissleading.gameObject.SetActive(true);
                    m_goNormal.gameObject.SetActive(false);
                }
                else
                {
                    m_goMissleading.gameObject.SetActive(false);
                    m_goNormal.gameObject.SetActive(true);
                }
            }

        }
    }
}

