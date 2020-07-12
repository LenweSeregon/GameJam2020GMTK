namespace Equilibrium
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

	[RequireComponent(typeof(AudioSource))]
    public class AudioController : MonoBehaviour
    {
        [SerializeField] private AudioClip m_audioClip;
		[SerializeField] bool m_positiveFeeling;
		[SerializeField] float m_attenuation;
        private AudioSource m_source;

		private void Awake()
		{
			if(m_attenuation == 0)
			{
				m_attenuation = 1;
			}
			m_source = GetComponent<AudioSource>();
			m_source.clip = m_audioClip;
			m_source.Play();
		}

		public void FeelingChanged(int value)
        {
			float percentage = Mathf.Abs(value) / 100.0f;
			if (m_positiveFeeling)
			{
				if(value >= 0)
				{
					m_source.volume = (percentage / m_attenuation);
				}
				else
				{
					m_source.volume = 0;
				}
			}
			else
			{
				if(value <= 0)
				{
					m_source.volume = (percentage / m_attenuation);
				}
				else
				{
					m_source.volume = 0;
				}
			}
        }
    }
}

