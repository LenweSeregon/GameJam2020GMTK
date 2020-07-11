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
		public class FeelingSOItem : ScriptableObject
		{
			[SerializeField] IntVariable m_property;
			[SerializeField] float m_factor;
		}


		[SerializeField] IntVariable m_value;
		[SerializeField] List<FeelingSOItem> m_positiveEffects;
		[SerializeField] List<FeelingSOItem> m_negativeEffects;
	}
}
