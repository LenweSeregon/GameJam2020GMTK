namespace Equilibrium
{
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	[CreateAssetMenu(fileName = "Need", menuName = "Variables/Need")]
	public class NeedsSO : ScriptableObject
	{
		[Serializable]
		public class NeedsSOItem
		{
			[SerializeField] IntVariable m_feeling;
			[SerializeField] int m_modificationFactor;
		}


		[SerializeField] IntVariable m_value;
		[SerializeField] List<NeedsSOItem> m_bonus = new List<NeedsSOItem>();
		[SerializeField] List<NeedsSOItem> m_malus = new List<NeedsSOItem>();
	}
}
