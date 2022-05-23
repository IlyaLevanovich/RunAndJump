using System.Collections;
using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
    public class CubeRenderer : MonoBehaviour
    {
        private SpriteRenderer _cubeRenderer;

        [Inject]
        private void Construct(SpriteRenderer cubeRenderer)
        {
            this._cubeRenderer = cubeRenderer;
            //StartCoroutine(ChangeColor());
        }

        private IEnumerator ChangeColor()
        {
            while(true)
            {
                yield return new WaitForSeconds(0.5f);
                _cubeRenderer.material.color = Color.red;

                yield return new WaitForSeconds(0.5f);
                _cubeRenderer.material.color = Color.black;
            }
        }
    }
}