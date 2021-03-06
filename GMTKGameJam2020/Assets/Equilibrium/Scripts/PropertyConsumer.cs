﻿namespace Equilibrium
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class PropertyConsumer : MonoBehaviour
	{
		[SerializeField] IntVariable m_property;
		[SerializeField] FloatVariable m_modificationDelay;
		[SerializeField] int m_modificationValue;

		public int ModifValue
		{
			get { return m_modificationValue; }
			set { m_modificationValue = value; }
		}

		private float m_timer = 0;

		private void Update()
		{
			if(m_timer >= m_modificationDelay.Value)
			{
				if (m_property.Value < m_property.MaxValue && m_modificationValue > 0)
				{
					m_property.Value = Mathf.Min(m_property.Value + m_modificationValue, m_property.MaxValue);
				}
				else if(m_property.Value > m_property.MinValue && m_modificationValue < 0)
				{
					m_property.Value = Mathf.Max(m_property.Value + m_modificationValue, m_property.MinValue);
				}
				m_timer = 0;
			}
			else
			{
				m_timer += Time.deltaTime;
			}
		}
	}
}