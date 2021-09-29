using UnityEngine;

namespace ARScene.UI
{
    public class ReduceSize_EventTrigger : MonoBehaviour
    {
        public float reduceAmount = 1.0f;

        private Vector3 startSize;

        private void Awake()
        {
            startSize = transform.localScale;
        }

        public void OnClick()
        {
            transform.localScale -= startSize * reduceAmount;
        }
    }
}