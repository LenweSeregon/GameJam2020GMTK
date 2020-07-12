namespace Equilibrium
{
    using System;
    using TMPro;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

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

        [SerializeField] private GameObject m_saveDoneText;
        [SerializeField] private GameObject m_saveErrorText;
        [SerializeField] private Button m_buttonSave;

        private void Awake()
        {
            m_saveErrorText.gameObject.SetActive(false);
            m_saveDoneText.gameObject.SetActive(false);
            
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
                m_saveErrorText.gameObject.SetActive(false);
                m_saveDoneText.gameObject.SetActive(true);
                m_buttonSave.interactable = false;
                
                string name = m_inputField.text;
                string coin = m_playerCoinScore.Value.ToString();
                string kill = m_playerKillScore.Value.ToString();
                string time = m_playerTimeScore.Value.ToString();
                string globalScore = m_playerGlobalScore.Value.ToString();
                m_scoreDatabase.AddEntry(new ScorePersistence(name, coin, kill, time, globalScore));
                m_scoreDatabase.Save();
            }
            else
            {
                m_saveErrorText.gameObject.SetActive(true);
                m_saveDoneText.gameObject.SetActive(false);
            }

        }
    }
}