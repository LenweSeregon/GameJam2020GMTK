using System;

namespace Equilibrium
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class UIScoreMenu : MonoBehaviour
    {
        [SerializeField] private Transform m_container;
        [SerializeField] private UIScoreEntity m_prefabUIScoreEntity;
        [SerializeField] private ScoreDatabase m_scoreDatabase;
        
        private void Start()
        {
            ClearContainer();
            foreach (ScorePersistence score in m_scoreDatabase.Scores)
            {
                UIScoreEntity instantiated = Instantiate(m_prefabUIScoreEntity, m_container, false);
                instantiated.Init(score.m_playerName, score.m_playerCoin, score.m_playerKills, score.m_playerTime,
                    score.m_playerGlobalScore);
            }
        }

        private void ClearContainer()
        {
            foreach (Transform child in m_container)
            {
                Destroy(child.gameObject);
            }
        }
    }
}

