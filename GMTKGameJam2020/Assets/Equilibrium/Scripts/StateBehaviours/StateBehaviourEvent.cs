namespace Equilibrium
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class StateBehaviourEvent : StateMachineBehaviour
    {
        [SerializeField] private string name;

        public Action<string> m_eventEnter;
        public Action<string> m_eventExit;
        
        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            m_eventEnter?.Invoke(name);
        }

        //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            m_eventExit?.Invoke(name);
        }
    }

}
