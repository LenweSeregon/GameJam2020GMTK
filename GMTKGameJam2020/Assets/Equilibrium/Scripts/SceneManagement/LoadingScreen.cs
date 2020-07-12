namespace Equilibrium
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class LoadingScreen : MonoBehaviour
    {
        private readonly string TRIGGER_FADE_IN = "FadeIn";
        private readonly string TRIGGER_FADE_OUT = "FadeOut";
        
        [SerializeField] private Animator m_animator;

        private Action m_callbackFadeIn;
        private Action m_callbackFadeOut;
        
        public void FadeIn(Action callbackFadeInEnd)
        {
            gameObject.SetActive(true);
            m_callbackFadeIn = callbackFadeInEnd;
            m_animator.SetTrigger(TRIGGER_FADE_IN);
        }

        public void FadeInEnd()
        {
            m_callbackFadeIn?.Invoke();
        }

        public void FadeOut(Action callbackFadeOutEnd)
        {
            m_callbackFadeOut = callbackFadeOutEnd;
            m_animator.SetTrigger(TRIGGER_FADE_OUT);
        }

        public void FadeOutEnd()
        {
            gameObject.SetActive(false);
            m_callbackFadeOut?.Invoke();
        }
    }
}

