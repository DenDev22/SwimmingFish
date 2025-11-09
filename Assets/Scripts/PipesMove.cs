using UnityEngine;

public class PipesMove : MonoBehaviour
{
    private float speed = 5f;
    private float leftEdge;

    private void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
    }

    private void FixedUpdate()
    {
        transform.position += Vector3.left * speed * Time.fixedDeltaTime;

        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }
    }
}
