using Managers;
using UnityEngine;
using Utils;
using Vuforia;

namespace ARScene
{
    public class ARSceneManager : Singleton<ARSceneManager>
    {
        [Header("Setting")]
        public TrackableBehaviour tracker;

        [Header("Debug")]
        public bool vuforiaIsEnabled;

        private void Start()
        {
            EventManager.StartListening("Pause", () => {
                OnPause();
            });
        }

        private void OnDisable()
        {
            EventManager.StopListening("Pause", () => {
                OnPause();
            });
        }

        private void OnPause()
        {
            if (GameManager.Instance.pause)
                StopTracking();
            else
                StartTracking();
        }

        /// <summary>
        /// Start vuforia tracking
        /// </summary>
        public void StartTracking()
        {
            CameraDevice.Instance.Start();

            //Remember saltpepper
            //TrackerManager.Instance.GetTracker<tracker>().Stop();
        }

        /// <summary>
        /// Stop vuforia tracking
        /// </summary>
        public void StopTracking()
        {
            CameraDevice.Instance.Stop();

            //Remember saltpepper
            //TrackerManager.Instance.GetTracker<tracker>().Stop();
        }
    }
}