using UnityEngine;

namespace SimpleGame.AxeInHand {
	[RequireComponent(typeof(Rigidbody), typeof(Animator))]
	public class Controller : MonoBehaviour {

		private Rigidbody _body;
		private Animator _animator;
		private float _speed = 5f, _rotationSpeed = 10f;

		private void Awake() {
			_body = GetComponent<Rigidbody>();
			_animator = GetComponent<Animator>();
			}

		private void Update() {
			float xAxis = Input.GetAxis("Horizontal");

			if (Mathf.Abs(xAxis) > .1f)
				transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y + _rotationSpeed * xAxis, 0);

			if (Input.GetKey(KeyCode.W))
				_body.velocity = transform.forward * _speed;

			_animator.SetFloat("speed", _body.velocity.magnitude);
			}

		}
	}