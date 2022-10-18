using UnityEngine;

namespace Scrolling
{
    public class Swipe : MonoBehaviour
    {
        [SerializeField] private float swipeSpeed = 3.0f;

        private Vector2 _firstPressPos;
        private Vector2 _secondPressPos;
        public float SwipeVelocity { get; set; }

        public void Update()
        {
            CheckSwipe();
        }

        private void CheckSwipe()
        {
            if(Input.GetMouseButtonDown(0))
            {
                _firstPressPos = new Vector2(Input.mousePosition.x,Input.mousePosition.y);
            }
            if(Input.GetMouseButtonUp(0))
            {
                _secondPressPos = new Vector2(Input.mousePosition.x,Input.mousePosition.y);
                SwipeVelocity = -(_secondPressPos.x - _firstPressPos.x) / Screen.width * swipeSpeed;
            }

            SwipeVelocity = Mathf.Lerp(SwipeVelocity, 0.0f, Time.deltaTime);
            var gameObjectPosition = transform.position;
            gameObjectPosition = new Vector3(gameObjectPosition.x + SwipeVelocity, gameObjectPosition.y,
                gameObjectPosition.z);
            transform.position = gameObjectPosition;
        }
    }
}
