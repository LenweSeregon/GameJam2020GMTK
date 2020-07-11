namespace Equilibrium
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    public class FeelingEffectDisplayer : MonoBehaviour
    {
        [SerializeField] private Image m_image;

        public void Init(Sprite sprite, Color color)
        {
            m_image.sprite = sprite;
            m_image.color = color;
        }
    }
}

