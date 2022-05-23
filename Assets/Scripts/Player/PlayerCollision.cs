using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.Player
{
    [RequireComponent(typeof(Collider2D))]
    public class PlayerCollision : MonoBehaviour
    {
        [SerializeField] private PlayerAnimator _animator;

        private GameObject _currentGround;

        private Text _scoreInfo;
        private Text _coinsInfo;

        private int _score;
        private int _coins;

        private int _groundLayer;

        public bool IsGround { get; private set; }


        [Inject]
        private void Construct(Text[] indicators)
        {
            this._scoreInfo = indicators[0];
            this._coinsInfo = indicators[1];

            _groundLayer = LayerMask.NameToLayer("Ground");
            _score = -1;
        }

        public void TakeLoot(int coinsAmount)
        {
            StartCoroutine(AddCoins(coinsAmount));
        }

        private IEnumerator AddCoins(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                yield return new WaitForSeconds(0.1f);
                _coins++;
                _coinsInfo.text = _coins.ToString();
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.layer == _groundLayer)
            {
                IsGround = true;
                _animator.Run();

                if(!Equals(_currentGround, collision.gameObject))
                {
                    _score++;
                    _scoreInfo.text = _score.ToString();
                }

                _currentGround = collision.gameObject;
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.layer == _groundLayer)
            {
                IsGround = false;
                _animator.Jump();
            }
        }

    }
}