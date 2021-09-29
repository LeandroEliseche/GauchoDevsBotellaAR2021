using Managers;

namespace UnityEngine.UI {
    public class ReplayButton : MonoBehaviour
    {
        public void RestartScene()
        {
            GameManager.Instance.LoadScene(GameManager.Instance.currentScene);
        }
    }
}