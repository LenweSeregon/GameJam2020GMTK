using System;
using TMPro;

namespace Equilibrium
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class UIScoreEndGameMenu : MonoBehaviour
    {
        [SerializeField] private TMP_InputField m_inputField;
        [SerializeField] private ScoreDatabase m_scoreDatabase;

        [SerializeField] private TextMeshProUGUI m_playerGlobalScoreText;
        [SerializeField] private TextMeshProUGUI m_playerTimeScoreText;
        [SerializeField] private TextMeshProUGUI m_playerKillScoreText;
        [SerializeField] private TextMeshProUGUI m_playerCoinScoreText;
        
        [SerializeField] private IntVariable m_playerGlobalScore;
        [SerializeField] private IntVariable m_playerTimeScore;
        [SerializeField] private IntVariable m_playerKillScore;
        [SerializeField] private IntVariable m_playerCoinScore;

        private void Awake()
        {
            string minutes = Mathf.Floor(m_playerTimeScore.Value / 60.0f).ToString("00");
            string seconds = (m_playerTimeScore.Value % 60).ToString("00");
            
            m_playerGlobalScoreText.SetText(m_playerGlobalScore.Value.ToString());
            m_playerTimeScoreText.SetText(minutes + "'" + seconds);
            m_playerKillScoreText.SetText(m_playerKillScore.Value.ToString());
            m_playerCoinScoreText.SetText(m_playerCoinScore.Value.ToString());
        }

        public void Save()
        {
            if (string.IsNullOrEmpty(m_inputField.text) == false)
            {
                string name = m_inputField.text;
                string coin = m_playerCoinScore.Value.ToString();
                string kill = m_playerKillScore.Value.ToString();
                string time = m_playerTimeScore.Value.ToString();
                string globalScore = m_playerGlobalScore.Value.ToString();
                m_scoreDatabase.AddEntry(new ScorePersistence(name, coin, kill, time, globalScore));
                m_scoreDatabase.Save();
            }

        }
    }
}