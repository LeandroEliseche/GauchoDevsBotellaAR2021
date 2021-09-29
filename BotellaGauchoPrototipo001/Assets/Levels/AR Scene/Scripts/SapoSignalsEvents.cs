using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ARScene.Animations
{
    public class SapoSignalsEvents : MonoBehaviour
    {
        [Header("Setting")]
        public Transform sapoTongueBone;
        public Transform grillo;

        public AnimationCurve curve;

        public float speed;

        private Vector3 startGrilloSize;
        private Vector3 startGrilloPosition;
        private Transform startGrilloParent;

        [Header("Debug")]
        [SerializeField] private float size;
        [SerializeField] private float t;

        private void Awake()
        {
            startGrilloSize = grillo.localScale;
            startGrilloPosition = grillo.position;
            startGrilloParent = grillo.parent;
        }

        public void ResetGrillo()
        {
            grillo.SetParent(startGrilloParent);
            grillo.position = startGrilloPosition;
            grillo.localScale = startGrilloSize;
        }

        public void Comelon()
        {
            grillo.SetParent(sapoTongueBone);
            StartCoroutine(SizeAnimation());
        }

        private IEnumerator SizeAnimation()
        {
            t = 0;

            while (true)
            {
                size = curve.Evaluate(t);

                grillo.localScale = new Vector3(grillo.localScale.x * size, grillo.localScale.y * size, grillo.localScale.z * size);

                t += Time.deltaTime * speed;

                yield return null;
            }
        }
    }
}