using UnityEngine;
using System.Collections;
using UnityEngine.XR;
using Unity.VisualScripting;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private float jumpForce = 7f;

    private float jumpCoolDown = 0.5f;
    private bool canJump = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (Input.GetButton("Jump") || Input.GetMouseButton(0) && canJump)
        {
            Jump();
        }
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Jump();
            }
        }
    }

    private void Jump()
    {
        rb.linearVelocity = new Vector2(0, jumpForce);
        canJump = false;
        StartCoroutine(ResetJump());
    }

    private IEnumerator ResetJump()
    {
        yield return new WaitForSeconds(jumpCoolDown);
        canJump = true;
    }

    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        rb.linearVelocity = Vector2.zero;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            Object.FindAnyObjectByType<GameManager>().GameOver();
        }
        else if(collision.gameObject.tag == "Scoring")
        {
            Object.FindAnyObjectByType<GameManager>().IncraseScore();
        }
    }
}
