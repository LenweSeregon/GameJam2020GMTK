namespace Equilibrium
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class GameController : MonoBehaviour
	{
		[SerializeField] IntVariable m_Timer;
		[SerializeField] float m_GameOverTimer = 5.0f;
		[SerializeField] GameObject m_GameOverUI;
		[SerializeField] private GameObject m_GameWinUI;
		[SerializeField] IntVariable m_GameOverVariable;

		private float m_Delay = 0;

		float m_LifeTimer = 0;
		float m_HungryTimer = 0;
		float m_ThirstTimer = 0;
		float m_TirednessTimer = 0;


		private void GameOver()
		{
			Time.timeScale = 0;
			m_GameOverUI.SetActive(true);
			m_GameOverVariable.Value = 1;
		}

		public void GameWon()
		{
			Time.timeScale = 0;
			m_GameWinUI.SetActive(true);
			m_GameOverVariable.Value = 1;
		}

		private void Update()
		{
			m_Delay += Time.deltaTime;
			if (m_Delay >= 1.0f)
			{
				m_Timer.Value++;
				m_Delay = 0;
			}

			if(m_LifeTimer > 0)
			{
				GameOver();
			}
			if (m_HungryTimer > 0)
			{
				Debug.Log(m_HungryTimer);
				m_HungryTimer += Time.deltaTime;
				if (m_HungryTimer > m_GameOverTimer)
				{
					GameOver();
				}
			}
			if (m_ThirstTimer > 0)
			{
				m_ThirstTimer += Time.deltaTime;
				if (m_ThirstTimer > m_GameOverTimer)
				{
					GameOver();
				}
			}
			if (m_TirednessTimer > 0)
			{
				m_TirednessTimer += Time.deltaTime;
				if (m_TirednessTimer > m_GameOverTimer)
				{
					GameOver();
				}
			}

		}

		public void CheckGameOverHunger(int value)
		{
			Debug.Log(value);
			if(m_HungryTimer == 0 && value <= 0)
			{
				m_HungryTimer += Time.deltaTime;
			}
			else if(m_HungryTimer > 0 && value > 0)
			{
				m_HungryTimer += 0;
			}
		}

		public void CheckGameOverThirst(int value)
		{
			if (m_ThirstTimer == 0 && value <= 0)
			{
				m_ThirstTimer += Time.deltaTime;
			}
			else if (m_ThirstTimer > 0 && value > 0)
			{
				m_ThirstTimer += 0;
			}
		}

		public void CheckGameOverTiredness(int value)
		{
			if (m_TirednessTimer == 0 && value <= 0)
			{
				m_TirednessTimer += Time.deltaTime;
			}
			else if (m_TirednessTimer > 0 && value > 0)
			{
				m_TirednessTimer += 0;
			}
		}

		public void CheckGameOverLife(int value)
		{
			if (m_LifeTimer == 0 && value <= 0)
			{
				m_LifeTimer += Time.deltaTime;
			}
			else if (m_LifeTimer > 0 && value > 0)
			{
				m_LifeTimer += 0;
			}
		}
	}
}
