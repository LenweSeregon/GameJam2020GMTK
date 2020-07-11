using System;
using System.IO;

namespace Equilibrium
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    [Serializable]
    public class ScorePersistence
    {
        public string m_playerName;
        public string m_playerCoin;
        public string m_playerKills;
        public string m_playerTime;
        public string m_playerGlobalScore;

        public ScorePersistence(string name, string coin, string kill, string time, string globalScore)
        {
            m_playerName = name;
            m_playerCoin = coin;
            m_playerKills = kill;
            m_playerTime = time;
            m_playerGlobalScore = globalScore;
        }
    }

    [Serializable]
    public class ScorePersistenceJSON
    {
        public List<ScorePersistence> m_scores;

        public ScorePersistenceJSON(List<ScorePersistence> scores)
        {
            m_scores = scores;
        }
    }

    [CreateAssetMenu(fileName = "ScoreDatabase", menuName = "Equilibrium/ScoreDatabase")]
    public class ScoreDatabase : ScriptableObject
    {
        [SerializeField] private string m_loadAt = "scores.json"; 
        
        [NonSerialized] private List<ScorePersistence> _scores;

        public List<ScorePersistence> Scores => _scores;

        private void OnEnable()
        {
            Load();
        }

        public void AddEntry(ScorePersistence score)
        {
            _scores.Add(score);
        }
        
        public void Load()
        {
            _scores = new List<ScorePersistence>();
            string path = Path.Combine(Application.persistentDataPath, m_loadAt);
            if (File.Exists(path))
            {
                string jsonContent = File.ReadAllText(path);
                if (string.IsNullOrEmpty(jsonContent) == false && jsonContent != "{}")
                {
                    ScorePersistenceJSON scoresJson = JsonUtility.FromJson<ScorePersistenceJSON>(jsonContent);
                    _scores = scoresJson.m_scores;
                }
            }
        }

        public void Save()
        {
            ScorePersistenceJSON json = new ScorePersistenceJSON(_scores);
            string path = Path.Combine(Application.persistentDataPath, m_loadAt);
            string jsonContent = JsonUtility.ToJson(json, true);
            File.WriteAllText(path, jsonContent);
        }
    }
}

