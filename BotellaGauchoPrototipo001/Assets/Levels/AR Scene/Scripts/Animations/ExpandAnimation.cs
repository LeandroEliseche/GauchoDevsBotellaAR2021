using System.Collections;
using UnityEngine;

namespace Utils.Animation
{
    public class ExpandAnimation : MonoBehaviour
    {
        [Header("Setting")]
        public float speed;
        public float delay;

        [SerializeField]private Vector3 startScale;

        private void Awake()
        {
            startScale = transform.localScale;
        }

        private void OnEnable()
        {
            StartCoroutine(Expand());
        }

        /// <summary>
        /// Scale the object to a target scale
        /// </summary>
        /// <returns></returns>
        private IEnumerator Expand()
        {
            transform.localScale = Vector3.zero;

            float scalePercent = (startScale.x + startScale.y + startScale.z) * (speed / 100);

            yield return new WaitForSeconds(delay);

            WaitForFixedUpdate fixedUpdate = new WaitForFixedUpdate();
            while (Mathf.Abs(transform.localScale.y - startScale.y) > 0f)
            {
                transform.localScale = Vector3.MoveTowards(transform.localScale, startScale, scalePercent * Time.deltaTime);
                yield return fixedUpdate;
            }
        }
    }
}