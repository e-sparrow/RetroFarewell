using UnityEngine;
using Game.Interactions;
using Utils;
using Utils.Extensions;

namespace Game.Map
{
    [AddComponentMenu("Game/Map/Vanishing")]
    public class Vanishing : MonoBehaviour
    {
        [SerializeField] private float appearedAlpha;
        [SerializeField] private float disappearedAlpha;

        [SerializeField] private SpriteRenderer spriteRenderer;

        private bool _isVanished;

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (!_isVanished)
            {
                if (collision.transform.position.y > transform.position.y)
                {
                    var controller = collision.gameObject.GetComponent<InteractController>();
                    if (controller != null && controller.Name == "PlayerRenderer")
                    {
                        Disappear();
                        _isVanished = true;
                    }
                }
            }
            else
            {
                if (collision.transform.position.y <= transform.position.y)
                {
                    var controller = collision.gameObject.GetComponent<InteractController>();
                    if (controller != null && controller.Name == "PlayerRenderer")
                    {
                        Appear();
                        _isVanished = false;
                    }
                }
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (_isVanished)
            {
                var controller = collision.gameObject.GetComponent<InteractController>();
                if (controller != null && controller.Name == "PlayerRenderer")
                {
                    Appear();
                    _isVanished = false;
                }
            }
        }

        private void Appear()
        {
            float tempAlpha = spriteRenderer.color.a;

            StopAllCoroutines();
            StartCoroutine(Coroutines.Graduate(SetProgress, 1f));

            void SetProgress(float progress)
            {
                var color = spriteRenderer.color;
                float alpha = Mathf.Lerp(disappearedAlpha, appearedAlpha, progress);

                spriteRenderer.color = spriteRenderer.color.SetAlpha(Mathf.Lerp(tempAlpha, appearedAlpha, progress));
            }
        }

        private void Disappear()
        {
            float tempAlpha = spriteRenderer.color.a;

            StopAllCoroutines();
            StartCoroutine(Coroutines.Graduate(SetProgress, 1f));

            void SetProgress(float progress)
            {
                var color = spriteRenderer.color;
                float alpha = Mathf.Lerp(disappearedAlpha, appearedAlpha, progress);

                spriteRenderer.color = spriteRenderer.color.SetAlpha(Mathf.Lerp(tempAlpha, disappearedAlpha, progress));
            }
        }
    }
}
