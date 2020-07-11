using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Equilibrium
{
	[RequireComponent(typeof(Rigidbody2D))]
	public class PlayerController : MonoBehaviour
	{
		private PlayerInputs m_playerInputs;

		private Vector2 m_movementAction;

		[SerializeField] private FloatVariable m_speed;

		private Rigidbody2D m_rigidbody2D;

		private void Awake()
		{
			m_rigidbody2D = GetComponent<Rigidbody2D>();
			m_playerInputs = new PlayerInputs();
		}

		public void Test(InputAction.CallbackContext ctx)
		{
			m_movementAction = ctx.ReadValue<Vector2>();
		}

		private void FixedUpdate()
		{
			float x = m_movementAction.x * m_speed.Value * Time.fixedDeltaTime;
			float y = m_movementAction.y * m_speed.Value * Time.fixedDeltaTime;

			Vector3 move = new Vector3(x, y, 0);

			move += transform.position;

			Debug.Log(m_movementAction);

			m_rigidbody2D.MovePosition(move);
		}
	}
}
