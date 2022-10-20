using UnityEngine;

namespace Scrolling
{
    public class Parallax : MonoBehaviour
    {
        [SerializeField] private Camera gameCamera;
        [SerializeField] private float parallaxEffect;
    
        private float _spriteWidth;
        private float _startingXPosition;

        private void Start()
        {
            _startingXPosition = transform.position.x;
            _spriteWidth = GetComponent<SpriteRenderer>().bounds.size.x;
        }

        void FixedUpdate()
        {
            CalculateGameObjectPosition();
        }

        void CalculateGameObjectPosition()
        {
            var cameraPosition = gameCamera.transform.position;
            var distanceTravelled = cameraPosition.x * (1 - parallaxEffect);
            var distance = (cameraPosition.x * parallaxEffect);
            var gameObjectPosition = transform.position;
            gameObjectPosition = new Vector3(_startingXPosition + distance, gameObjectPosition.y, gameObjectPosition.z);
            transform.position = gameObjectPosition;
            
            if (distanceTravelled > _startingXPosition + _spriteWidth)
                _startingXPosition += _spriteWidth;
            else if (distanceTravelled < _startingXPosition - _spriteWidth)
                _startingXPosition -= _spriteWidth;
        }
    }
}
