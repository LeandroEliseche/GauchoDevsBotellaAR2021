using UnityEngine;

namespace ARScene
{
    public class AudioControl : MonoBehaviour
    {
        public AudioSource source;

        private void OnEnable()
        {
            source.Play();
        }
    }
}