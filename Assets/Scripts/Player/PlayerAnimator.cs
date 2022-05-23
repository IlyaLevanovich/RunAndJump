using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Player
{
    [RequireComponent(typeof(Animator))]
    public class PlayerAnimator : MonoBehaviour
    {
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void Run()
        {
            _animator.SetBool("IsRun", true);
        }

        public void Jump()
        {
            _animator.SetBool("IsRun", false);
        }

        
    }
}