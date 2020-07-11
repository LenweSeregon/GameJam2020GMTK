namespace Equilibrium
{
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using System.Linq;
    using static Equilibrium.FeelingsSO;

    public class FeelingHandler : MonoBehaviour
	{
		[Serializable]
		public abstract class FeelingItem
		{
			[SerializeField] protected IntVariable m_property;
			[SerializeField] protected int m_effectMaxValue;

			protected int m_LastEffectValue = 0;

			public FeelingItem(FeelingSOItem item)
			{
				m_property = item.Property;
			}

			public abstract void CheckEffect(IntVariable feelingValue, int threshold);
		}

		[Serializable]
		public class FeelingItemPositive : FeelingItem
		{
			public FeelingItemPositive(FeelingSOItem item) :
				base(item)
			{
			}

			public override void CheckEffect(IntVariable feelingValue, int threshold)
			{
				/*if(feelingValue.Value >= threshold)
				{
					int oldValue = m_property.Value;

					float severity = (feelingValue.Value - threshold) / (((float)feelingValue.MaxValue) - threshold);
					int applyValue = Mathf.FloorToInt(m_effectMaxValue * severity);

					m_property.Value = Mathf.Min((m_property.Value - m_LastEffectValue) + applyValue, feelingValue.MaxValue);
					m_LastEffectValue = Mathf.Abs(oldValue - m_property.Value);
				}*/

				if(feelingValue.Value >= threshold)
				{
					// Compute the value we need to assign
					float severity = (feelingValue.Value - threshold) / (((float)feelingValue.MaxValue) - threshold);
					int applyValue = Mathf.RoundToInt(m_effectMaxValue * severity);

					// Assign the value
					if (m_effectMaxValue < 0)
					{
						m_property.Value = Mathf.Max(m_property.Value - m_LastEffectValue + applyValue, feelingValue.MinValue);
					}
					else
					{
						m_property.Value = Mathf.Min(m_property.Value - m_LastEffectValue + applyValue, feelingValue.MaxValue);
					}
					
					m_LastEffectValue = applyValue;
				}
				
				
				
				
				
				
				/*if (feelingValue.Value >= threshold)
				{
					int oldValue = m_property.Value;

					float severity = (feelingValue.Value - threshold) / (((float)feelingValue.MaxValue) - threshold);
					int applyValue = (m_effectMaxValue < 0) ? Mathf.CeilToInt(m_effectMaxValue * severity) : Mathf.FloorToInt(m_effectMaxValue * severity);


					string s = m_property.Value + " - " + m_LastEffectValue + " + " + applyValue;
					m_property.Value = Mathf.Min((m_property.Value - m_LastEffectValue) + applyValue, m_property.MaxValue);
					s += " = " + m_property.Value + "(" + severity + ")";
					Debug.Log(s);
					if (oldValue != m_property.Value)
					{
						m_LastEffectValue += m_property.Value - oldValue;
					}
				}*/
			}
		}

		[Serializable]
		public class FeelingItemNegative : FeelingItem
		{
			public FeelingItemNegative(FeelingSOItem item) :
				base(item)
			{
			}

			public override void CheckEffect(IntVariable feelingValue, int threshold)
			{
				if(feelingValue.Value <= threshold)
				{
					// Compute the value we need to assign
					float severity = (feelingValue.Value - threshold) / (((float)feelingValue.MinValue) - threshold);
					int applyValue = Mathf.RoundToInt(m_effectMaxValue * severity);

					// Assign the value
					if (m_effectMaxValue < 0)
					{
						m_property.Value = Mathf.Max(m_property.Value - m_LastEffectValue + applyValue, feelingValue.MinValue);
					}
					else
					{
						m_property.Value = Mathf.Min(m_property.Value - m_LastEffectValue + applyValue, feelingValue.MaxValue);
					}
					
					m_LastEffectValue = applyValue;
				}
				
				
				/*if (feelingValue.Value <= threshold)
				{
					int oldValue = m_property.Value;

					float severity = (feelingValue.Value - threshold) / (((float)feelingValue.MinValue) - threshold);
					int applyValue = (m_effectMaxValue < 0) ? Mathf.CeilToInt(m_effectMaxValue * severity) : Mathf.FloorToInt(m_effectMaxValue * severity);


					string s = m_property.Value + " - " + m_LastEffectValue + " + " + applyValue;
					m_property.Value = Mathf.Max((m_property.Value + m_LastEffectValue) + applyValue, m_property.MinValue);
					s += " = " + m_property.Value + "(" + severity + ")";
					Debug.Log(s);
					if(oldValue != m_property.Value)
					{
						m_LastEffectValue += oldValue - m_property.Value;
					}
				}*/
			}
		}

		[SerializeField] FeelingsSO m_feelingsSO;

		private IntVariable m_feelingValue;
		private List<FeelingItemNegative> m_malusNegative;
		private List<FeelingItemPositive> m_malusPositive;
		private List<FeelingItemNegative> m_bonusNegative;
		private List<FeelingItemPositive> m_bonusPositive;

		private int m_negativeThreshold;
		private int m_positiveThreshold;

		private void Awake()
		{
			m_feelingValue = m_feelingsSO.Value;
			m_malusNegative = new List<FeelingItemNegative>();
			m_feelingsSO.NegativeMalusEffects.ForEach(x => m_malusNegative.Add(new FeelingItemNegative(x)));
			m_malusPositive = new List<FeelingItemPositive>();
			m_feelingsSO.PositiveMalusEffects.ForEach(x => m_malusPositive.Add(new FeelingItemPositive(x)));
			m_bonusNegative = new List<FeelingItemNegative>();
			m_feelingsSO.NegativeMalusEffects.ForEach(x => m_bonusNegative.Add(new FeelingItemNegative(x)));
			m_bonusPositive = new List<FeelingItemPositive>();
			m_feelingsSO.PositiveBonusEffects.ForEach(x => m_bonusPositive.Add(new FeelingItemPositive(x)));
			m_negativeThreshold = m_feelingsSO.NegativeThreshold;
			m_positiveThreshold = m_feelingsSO.PositiveThreshold;
		}                                                                               

		public void UpdateFeeling(int feelingValue)
		{
			m_malusNegative.ForEach(needItem => needItem.CheckEffect(m_feelingValue, m_negativeThreshold));
			m_malusPositive.ForEach(needItem => needItem.CheckEffect(m_feelingValue, m_positiveThreshold));
			m_bonusNegative.ForEach(needItem => needItem.CheckEffect(m_feelingValue, m_negativeThreshold));
			m_bonusPositive.ForEach(needItem => needItem.CheckEffect(m_feelingValue, m_positiveThreshold));
		}
	}
}

