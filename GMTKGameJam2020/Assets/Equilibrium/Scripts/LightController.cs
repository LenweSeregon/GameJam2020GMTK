namespace Equilibrium
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class LightController : MonoBehaviour
	{
		[SerializeField] private PropertyConsumer m_luminosityConsumer;
		[SerializeField] private int m_speed;

		private int m_enterValue;

		private void OnTriggerEnter(Collider other)
		{
			PlayerController pController = other.GetComponent<PlayerController>();
			if (pController != null)
			{
				m_enterValue = m_luminosityConsumer.ModifValue;
				m_luminosityConsumer.ModifValue = m_speed;
			}
		}

		private void OnTriggerExit(Collider other)
		{
			PlayerController pController = other.GetComponent<PlayerController>();
			if (pController != null)
			{
				m_luminosityConsumer.ModifValue = m_enterValue;
			}
		}

	}
}