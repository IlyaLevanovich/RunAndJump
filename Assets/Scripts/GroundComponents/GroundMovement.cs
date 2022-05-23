using System.Collections;
using UnityEngine;

namespace Assets.Scripts.GroundComponents
{
    public class GroundMovement : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed;
        [SerializeField] private GameObject _chest;

        private void Start()
        {
            var scale = transform.localScale.x;
            if (scale >= 2 && scale <= 2.3f)
                _chest.SetActive(true);
        }

        private void Update()
        {
            var direction = Vector2.left;

            transform.Translate(_moveSpeed * Time.deltaTime * direction);
        }
    }
}