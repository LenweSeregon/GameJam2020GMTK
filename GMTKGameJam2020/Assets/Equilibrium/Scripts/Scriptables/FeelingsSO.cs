namespace Equilibrium
{
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	[CreateAssetMenu(fileName = "Feeling", menuName = "Variables/Feeling")]
	public class FeelingsSO : ScriptableObject
	{
		[Serializable]
		public class FeelingSOItem
		{
			[SerializeField] IntVariable m_property;
			[SerializeField] float m_EffectMaxValue;
			[SerializeField] Sprite m_Sprite;
			[SerializeField] Color m_Color;
		}


		[SerializeField] IntVariable m_value;
		[SerializeField] List<FeelingSOItem> m_positiveBonusEffects;
		[SerializeField] List<FeelingSOItem> m_negativeBonusEffects;
		[SerializeField] List<FeelingSOItem> m_positiveMalusEffects;
		[SerializeField] List<FeelingSOItem> m_negativeMalusEffects;
		[SerializeField] int m_negativeThreshold;
		[SerializeField] int m_positiveThreshold;
	}
}
