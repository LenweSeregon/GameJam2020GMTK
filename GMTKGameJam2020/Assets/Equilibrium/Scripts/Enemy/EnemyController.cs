using System;
using UnityEngine.AI;

namespace Equilibrium
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private Animator m_animator;
        [SerializeField] private IntVariable m_playerAttractionDistance;
        [SerializeField] private Transform m_playerPosition;
        [SerializeField] private Vector3 m_offsetRaycast = new Vector3(0, 1, 0);
        [SerializeField] private Slider m_slider;
        [SerializeField] private GameObject m_canvas;
        [SerializeField] private IntVariable m_nbEnemyKilled;

        [SerializeField] private WeaponColliderEnemy m_weapon;

        [SerializeField] private int m_damage = 30;
        [SerializeField] private int m_maxLife = 100;
        [SerializeField] private float m_range = 0.5f;

        private StateBehaviourEvent[] m_eventsAnimator;
        private bool m_isAttacking;
        private bool m_isDying;
        private int m_currentLife;

        private Rigidbody m_rigidbody;
        private NavMeshAgent m_navMeshAgent;

        public int Damage => m_damage;
        
        private void Awake()
        {
            m_isAttacking = false;
            m_isDying = false;
            m_currentLife = m_maxLife;
            m_navMeshAgent = GetComponent<NavMeshAgent>();
            m_rigidbody = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            m_eventsAnimator = m_animator.GetBehaviours<StateBehaviourEvent>();
            foreach(var eventAnimator in m_eventsAnimator)
            {
                eventAnimator.m_eventExit += (animName) =>
                {
                    if (animName == "Death")
                    {
                        m_isDying = false;
                        m_nbEnemyKilled.Value += 1;
                        Destroy(gameObject);
                    }

                    if (animName == "Attack")
                    {
                        m_navMeshAgent.isStopped = false;
                        m_isAttacking = false;
                    }
                };
            }
        }

        public void FixedUpdate()
        {
            float distance = Vector3.Distance(transform.position, m_playerPosition.position);

            if (distance >= m_playerAttractionDistance.Value)
                m_navMeshAgent.isStopped = true;

            // Displacement
            if (m_isAttacking == false && m_isDying == false)
            {
                if (distance <= m_playerAttractionDistance.Value)
                {
                    Vector3 direction = m_playerPosition.position- transform.position;
                    if(Physics.Raycast(transform.position + m_offsetRaycast, direction, out var hit, m_playerAttractionDistance.Value))
                    {
                        PlayerController playerController = hit.transform.GetComponent<PlayerController>();
                        if (playerController != null)
                        {
                            transform.LookAt(m_playerPosition);
                            m_navMeshAgent.isStopped = false;
                            m_navMeshAgent.SetDestination(m_playerPosition.position);
                        }
                    }
                }
            }

            // Attack
            if (distance <= m_range && m_isAttacking == false)
            {
                m_weapon.CanTrigger(true);
                m_isAttacking = true;
                m_animator.SetTrigger("Attack");
                m_navMeshAgent.isStopped = true;
            }
            
            // Death
            if (m_currentLife <= 0)
            {
                m_currentLife = 0;
                m_isDying = true;
                m_canvas.gameObject.SetActive(false);
                m_animator.SetTrigger("Death");
                m_navMeshAgent.isStopped = true;
            }
            
            // Display life
            m_slider.value = m_currentLife / (float) m_maxLife;

            float speed = (m_navMeshAgent.velocity.magnitude > 0f) ? 1f : 0f; 
            m_animator.SetFloat("Speed", speed);
        }

        public void GetHit(int damage, Vector3 pushDirection, float factorPush)
        {
            m_currentLife -= damage;
            Vector3 directionPlayerToEnemy = transform.position - m_playerPosition.position;
            Vector3 finalDirection = pushDirection + directionPlayerToEnemy;
            Vector3 finalDirectionMultiplied = finalDirection * factorPush;
            m_rigidbody.AddForce(finalDirectionMultiplied, ForceMode.Force);
        }
    }
}