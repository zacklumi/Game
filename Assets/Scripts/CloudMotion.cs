using UnityEngine;

public class CloudMotion : MonoBehaviour
{
    [SerializeField] [Range(-0.5f, -1.0f)] private float speed;
    [SerializeField] private Camera gameCamera;

    private void Update()
    {
        UpdateCloudPosition();
        if (CloudIsOffScreen()) 
            ResetCloud();
    }

    private void UpdateCloudPosition()
    {
        var gameObjectTransform = transform;
        var gameObjectPosition = gameObjectTransform.position;
        gameObjectPosition = new Vector3(gameObjectPosition.x + speed * Time.deltaTime, gameObjectPosition.y,
            gameObjectPosition.z);
        gameObjectTransform.position = gameObjectPosition;
    }

    private bool CloudIsOffScreen()
    {
        var cloudRenderer = GetComponent<Renderer>();
        // Time's a quickie bandage here to fix a unity issue
        return !cloudRenderer.isVisible && transform.position.x < gameCamera.transform.position.x && Time.time > 1.0f;
    }
    
    private void ResetCloud()
    {
        var cloudWidth = GetComponent<SpriteRenderer>().bounds.size.x;
        var camHeight = 2.0f * gameCamera.orthographicSize;
        var cameraWidth = camHeight * gameCamera.aspect;
        var randomHeight = Random.Range(0.0f, 5.0f);
        transform.position = new Vector3(gameCamera.transform.position.x + cloudWidth + cameraWidth, randomHeight, transform.position.z);
        speed = Random.Range(-0.5f, -1.0f);
    }
}
