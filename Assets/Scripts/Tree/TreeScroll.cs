using UnityEngine;

namespace Tree
{
    public class TreeScroll : MonoBehaviour
    {
        public float threshold = 110.0f;
        public GameObject gameCamera;

        private void Awake()
        {
            gameCamera = FindObjectOfType<Camera>().gameObject;
        }
    
        private void Update()
        {
            var relativePosition = transform.position.x - gameCamera.transform.position.x;
            if (relativePosition <= -threshold * 0.5f)
            {
                var cachedTransform = transform;
                var cachedPosition = cachedTransform.position;
                cachedPosition = new Vector3(cachedPosition.x + threshold, cachedPosition.y,
                    cachedPosition.z);
                cachedTransform.localPosition = cachedPosition;
            }
            else if (relativePosition >= threshold * 0.5f)
            {
                var cachedTransform = transform;
                var cachedPosition = cachedTransform.position;
                cachedPosition = new Vector3(cachedPosition.x - threshold, cachedPosition.y,
                    cachedPosition.z);
                cachedTransform.position = cachedPosition;
            }
        }
    }
}
