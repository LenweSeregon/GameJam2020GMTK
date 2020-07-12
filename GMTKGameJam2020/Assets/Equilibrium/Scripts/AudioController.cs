namespace Equilibrium
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class AudioController : MonoBehaviour
    {
        [SerializeField] private AudioClip m_clipJoy;
        [SerializeField] private AudioClip m_clipSadness;
        [SerializeField] private AudioClip m_clipConfident;
        [SerializeField] private AudioClip m_clipFear;
        [SerializeField] private AudioClip m_clipSooth;
        [SerializeField] private AudioClip m_clipAnger;
        [SerializeField] private AudioClip m_clipVigilant;
        [SerializeField] private AudioClip m_clipStone;
        [SerializeField] private AudioSource m_source;

        public void JoySadnessChanged(int value)
        {
            
        }

        public void ConfidentFearChanged(int value)
        {
            
        }

        public void SoothAngerChanged(int value)
        {
            
        }

        public void VigilantStoneChanged(int value)
        {
            
        }
    }
}

