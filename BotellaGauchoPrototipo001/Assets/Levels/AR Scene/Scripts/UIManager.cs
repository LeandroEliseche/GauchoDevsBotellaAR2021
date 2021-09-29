namespace UnityEngine.UI
{
    public class UIManager : MonoBehaviour
    {
        bool flashActive;

        public void Flash()
        {
            flashActive = !flashActive;
            Vuforia.CameraDevice.Instance.SetFlashTorchMode(flashActive);
        }

        public void ToUrl(string url)
        {
            Application.OpenURL(url);
        }
    }
}