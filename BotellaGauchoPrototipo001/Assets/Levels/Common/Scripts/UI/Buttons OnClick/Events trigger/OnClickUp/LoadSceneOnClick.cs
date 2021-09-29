using UnityEngine;
using Managers;
using System.Collections;

namespace UnityEngine.UI
{
    public class LoadSceneOnClick : EventTriggerType
    {
        public string scene;
        public GameObject panelLoading;

        public override void Callback()
        {
            GameManager.Instance.LoadScene(scene);
        }

        private IEnumerator PanelLoading()
        {
            yield return new WaitForSeconds(1);
            GameManager.Instance.LoadScene(scene);
            while (GameManager.Instance.progress < 1)
            {
                yield return null;
            }

            panelLoading.GetComponent<Animator>().SetBool("FadeOut", true);
        }
    }
}