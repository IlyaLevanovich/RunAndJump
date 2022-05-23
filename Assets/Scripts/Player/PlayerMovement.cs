using Assets.Scripts.Interfaces;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        private const int _forceMax = 15;

        private ITouchService _touchService;
        private Slider _slider;

        private Rigidbody2D _rigidbody;
        private PlayerCollision _collision;

        private float _jumpForce;
        private float _jumpOffset = 1;

        private bool _isTouch;

        [Inject]
        private void Construct(ITouchService touchService, Slider slider)
        {
            this._touchService = touchService;
            this._slider = slider;

            _touchService.OnTouch += SetJumpState;

            _slider.value = 0;
            _slider.maxValue = _forceMax;
        }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _collision = GetComponentInChildren<PlayerCollision>();
        }

        private void SetJumpState(bool isTouch)
        {
            _isTouch = isTouch;
        }

        private void FixedUpdate()
        {
            if (!_collision.IsGround) return;

            if (_isTouch)
            {
                SetJumpForce();
            }
            else if (_jumpForce > 0)
            {
                Jump();
            }
        }

        private void SetJumpForce()
        {

            if (_jumpForce <= 0)
                _jumpOffset = 1;

            float offset = _jumpOffset;
            var value = Mathf.PingPong(offset, _forceMax);

            _jumpForce = value;
            _slider.value = _jumpForce;

            _jumpOffset += 1;
        }

        private void Jump()
        {
            _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);

            _jumpForce = 0;
            _slider.value = _jumpForce;

        }

        private void OnDestroy()
        {
            _touchService.OnTouch -= SetJumpState;
        }
    }
}