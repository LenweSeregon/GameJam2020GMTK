namespace Equilibrium
{
    using TMPro;
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
            int secondsAsInt = int.Parse(time);
            string minutes = Mathf.Floor(secondsAsInt / 60.0f).ToString("00");
            string seconds = (secondsAsInt % 60).ToString("00");
            
            m_playerNameText.SetText(name);
            m_playerCoinText.SetText(coin);
            m_playerEnemyKilledText.SetText(enemyKilled);
            m_playerTimeText.SetText(minutes + "'" + seconds);
            m_playerGlobalScoreText.SetText(globalScore);
        }
    }
}