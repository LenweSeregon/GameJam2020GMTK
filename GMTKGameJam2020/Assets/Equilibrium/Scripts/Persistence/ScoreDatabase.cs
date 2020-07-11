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
        public List<ScorePersistence> _scores;

        public ScorePersistenceJSON(List<ScorePersistence> scores)
        {
            _scores = scores;
        }
    }

    [CreateAssetMenu(fileName = "ScoreDatabase", menuName = "Equilibrium/ScoreDatabase")]
    public class ScoreDatabase : ScriptableObject
    {
        [SerializeField] private string _loadAt = "scores.json"; 
        
        [NonSerialized] private List<ScorePersistence> _scores;

        public List<ScorePersistence> Scores => _scores;

        private void OnEnable()
        {
            Load();
            Save();
        }

        public void Load()
        {
            _scores = new List<ScorePersistence>();
            string path = Path.Combine(Application.persistentDataPath, _loadAt);
            if (File.Exists(path))
            {
                string jsonContent = File.ReadAllText(path);
                ScorePersistenceJSON scoresJson = JsonUtility.FromJson<ScorePersistenceJSON>(path);
                _scores = scoresJson._scores;
            }

        }

        public void Save()
        {
            for (int i = 0; i < 10; i++)
            {
                _scores.Add(new ScorePersistence("Toto : " + i, "10", "20", "20'3", "1240"));
            }
            
            string path = Path.Combine(Application.persistentDataPath, _loadAt);
            string jsonContent = JsonUtility.ToJson(_scores);
            File.WriteAllText(path, jsonContent);
        }
    }
}

