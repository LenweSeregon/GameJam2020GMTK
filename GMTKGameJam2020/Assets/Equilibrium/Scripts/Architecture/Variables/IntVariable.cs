namespace Equilibrium
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    [CreateAssetMenu(fileName = "IntVariable", menuName = "Variables/IntVariable")]
    public class IntVariable : BaseVariable<int, IntEvent>
    {
        [SerializeField] private bool m_hasMinValue = false;
        [SerializeField] private bool m_hasMaxValue = false;
        [SerializeField] private int m_minValue = 0;
        [SerializeField] private int m_maxValue = 0;

        public bool HasMinValue => m_hasMinValue;
        public bool HasMaxValue => m_hasMaxValue;
        public int MinValue => m_minValue;
        public int MaxValue => m_maxValue;
    }
}