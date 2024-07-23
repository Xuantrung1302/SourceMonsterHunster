using UnityEngine;

public class EnemyFlying : MonoBehaviour
{
    public float speed = 3.0f;
    public float distanceFromPlayer = 5.0f;
    public float rotationSpeed = 50.0f;
    private Transform target;
    private Vector3 offset;
    private SpriteRenderer spriteRenderer;
    
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        offset = new Vector3(distanceFromPlayer, 0, 0);
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (target != null)
        {
            Vector3 targetPosition = target.position + offset;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            transform.RotateAround(target.position, Vector3.forward, rotationSpeed * Time.deltaTime);

            // Xoay mặt về phía nhân vật
            Vector3 direction = target.position - transform.position;
            if (direction.x < 0)
            {
                spriteRenderer.flipX = true;
            }
            else
            {
                spriteRenderer.flipX = false;
            }
        }
    }
}
