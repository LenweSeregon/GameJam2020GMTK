using TMPro;

namespace Equilibrium
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class UIScoreEntity : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI m_playerNameText;
        [SerializeField] private TextMeshProUGUI m_playerCoinText;
        [SerializeField] private TextMeshProUGUI m_playerEnemyKilledText;
        [SerializeField] private TextMeshProUGUI m_playerTimeText;
        [SerializeField] private TextMeshProUGUI m_playerGlobalScoreText;

        public void Init(string name, string coin, string enemyKilled, string time, string globalScore)
        {
            m_playerNameText.SetText(name);
        }
    }
}