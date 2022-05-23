using UnityEngine;

namespace Assets.Scripts.Utilities
{
    [RequireComponent(typeof(Collider2D))]
    public class LevelBorder : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            Destroy(collision.gameObject);
        }
    }
}