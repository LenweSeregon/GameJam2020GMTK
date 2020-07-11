namespace Equilibrium
{
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	using System.Linq;

	public class NeedHandler : MonoBehaviour
	{
		[Serializable]
		public abstract class NeedItem
		{
			[SerializeField] protected IntVariable m_feeling;
			[SerializeField] protected int m_threshold;
			[SerializeField] protected int m_effectMaxValue;

			protected int m_LastEffectValue = 0;

			public abstract void CheckEffect(IntVariable needValue);
		}

		[Serializable]
		public class NeedItemPositive : NeedItem
		{
			public override void CheckEffect(IntVariable needValue)
			{
				if(needValue.Value >= m_threshold)
				{
					int oldValue = m_feeling.Value;

					float severity = (needValue.Value - m_threshold) / (100.0f - m_threshold);
					int applyValue = Mathf.FloorToInt(m_effectMaxValue * severity);

					m_feeling.Value = Mathf.Min(m_feeling.Value - m_LastEffectValue + applyValue, 100);
					m_LastEffectValue = Mathf.Abs(oldValue - m_feeling.Value);
				}
			}
		}

		[Serializable]
		public class NeedItemNegative : NeedItem
		{
			public override void CheckEffect(IntVariable needValue)
			{
				if (needValue.Value <= m_threshold)
				{
					int oldValue = m_feeling.Value;

					float severity = (m_threshold - needValue.Value) / (m_threshold);
					int applyValue = Mathf.FloorToInt(m_effectMaxValue * severity);

					m_feeling.Value = Mathf.Max(m_feeling.Value + m_LastEffectValue - applyValue, 0);
					m_LastEffectValue = Mathf.Abs(oldValue - m_feeling.Value);
				}
			}
		}


		[SerializeField] IntVariable m_needValue;
		[SerializeField] List<NeedItemPositive> m_bonus;
		[SerializeField] List<NeedItemNegative> m_malus;

		public void UpdateNeed(int value)
		{
			m_bonus.ForEach(needItem => needItem.CheckEffect(m_needValue));
			m_malus.ForEach(needItem => needItem.CheckEffect(m_needValue));
		}

		public void IncreaseValue()
		{
			m_needValue.Value += 10;
		}

		public void DecreaseValue()
		{
			m_needValue.Value -= 10;
		}
	}
}
