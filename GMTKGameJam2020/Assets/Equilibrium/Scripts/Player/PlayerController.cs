using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Equilibrium
{
	[RequireComponent(typeof(Rigidbody))]
	public class PlayerController : MonoBehaviour
	{
		private Vector2 m_movementAction;
		private Vector3 m_rollDestination;
		private bool m_shouldRoll;
		private bool m_isRolling;
		
		private bool m_shouldAttack;
		private bool m_isAttacking;
		
		private bool m_overrideAttenuator;
		private float m_attenatorOverride;
		
		[SerializeField] private float m_attenatorBackward = 0.075f;
		[SerializeField] private float m_attenator = 0.25f;
		[SerializeField] private float m_attenatorDash = 0.35f;
		[SerializeField] private float m_rotationSpeed = 160f;
		[SerializeField] private IntVariable m_speed;
		[SerializeField] private Animator m_animator;

		private Rigidbody m_rigidbody;

		private void Awake()
		{
			m_rigidbody = GetComponent<Rigidbody>();
		}

		public void Move(InputAction.CallbackContext ctx)
		{
			m_movementAction = ctx.ReadValue<Vector2>();
		}

		public void Roll(InputAction.CallbackContext ctx)
		{
			if (ctx.started && m_shouldRoll == false && m_isRolling == false && m_isAttacking == false)
			{
				m_shouldRoll = true;
			}
		}

		public void RollEnd(int rollingValue)
		{
			if (rollingValue == 0)
			{
				m_isRolling = false;
			}
		}

		public void Attack(InputAction.CallbackContext ctx)
		{
			if (ctx.started && m_shouldAttack == false && m_isRolling == false && m_isAttacking == false)
			{
				m_shouldAttack = true;
			}
		}
		
		public void AttackEnd(int attackValue)
		{
			if (attackValue == 0)
			{
				m_isAttacking = false;
			}
		}

		private void FixedUpdate()
		{
			
			if (m_isRolling)
			{
				float step =  m_speed.Value * Time.fixedDeltaTime * m_attenatorDash;
				transform.position = Vector3.MoveTowards(transform.position, m_rollDestination, step);
				return;
			}

			if (m_isAttacking)
			{
				return;
			}
			
			float attenuator = m_movementAction.y > 0 ? m_attenator : m_attenatorBackward;
			if (m_overrideAttenuator)
				attenuator = m_attenatorOverride;

			float moveY = (m_movementAction.y * m_speed.Value * Time.fixedDeltaTime) * attenuator;
			
			transform.Translate(new Vector3(0, 0,moveY));
			transform.Rotate(0, m_movementAction.x * Time.fixedDeltaTime * m_rotationSpeed, 0);

			if (m_movementAction.y > 0)
			{
				if (m_speed.Value >= 4f)
				{
					m_animator.SetFloat("Speed", 2f);
				}
				else
				{
					m_animator.SetFloat("Speed", 1f);
				}
			}
			else if (m_movementAction.y < 0)
			{
				m_animator.SetFloat("Speed", -1f);
			}
			else
			{
				m_animator.SetFloat("Speed", 0f);
			}

			if (m_shouldAttack)
			{
				m_shouldAttack = false;
				m_isAttacking = true;
				m_animator.SetTrigger("Attack");
			}
			
			if (m_shouldRoll)
			{
				m_rollDestination = transform.position + (transform.forward * 6.5f);

				m_isRolling = true;
				m_shouldRoll = false;
				m_animator.SetTrigger("Roll");
			}
		}
	}
}
