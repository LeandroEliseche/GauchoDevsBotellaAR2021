using UnityEngine;

namespace ARScene.UI
{
    public class ResetSize_EventTrigger : MonoBehaviour
    {
        private Vector3 startSize;

        private void Awake()
        {
            startSize = transform.localScale;
        }

        public void OnClick()
        {
            transform.localScale = startSize;
        }
    }
}