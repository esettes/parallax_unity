using UnityEngine;

public class ParallaxOffset : MonoBehaviour
{
    [SerializeField] private Transform mainCamPosition;
    [SerializeField] private float backgroundMoveSpeed;
    [SerializeField] private float offsetByX = 13f;
    private float directionX;

    void Update()
    {
        directionX = Input.GetAxis("Horizontal") * backgroundMoveSpeed * Time.deltaTime;

        transform.position = new Vector2(transform.position.x + directionX, transform.position.y);

        if (transform.position.x - mainCamPosition.position.x < -offsetByX)
            transform.position = new Vector2(mainCamPosition.position.x + offsetByX, transform.position.y);
        else if (transform.position.x + mainCamPosition.position.x > offsetByX)
            transform.position = new Vector2(mainCamPosition.position.x + offsetByX, transform.position.y);
    }
}
