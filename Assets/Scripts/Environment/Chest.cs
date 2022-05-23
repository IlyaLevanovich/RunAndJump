using Assets.Scripts.Player;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Environment
{
    [RequireComponent(typeof(Collider2D), typeof(Animator))]
    public class Chest : MonoBehaviour
    {
        [SerializeField] private int _minGold, _maxGold;
        private Animator _animator;


        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(!Equals(collision.gameObject, transform.parent.gameObject))
            {
                var player = collision.gameObject.GetComponent<PlayerCollision>();
                if(player != null)
                {
                    _animator.SetBool("IsOpen", true);
                    player.TakeLoot(Random.Range(_minGold, _maxGold));
                }
            }
        }
    }

}