using UnityEngine;

public class EnemyWalk : MonoBehaviour
{
    [SerializeField] private float damage;
    public float speed = 3.0f;
    private Transform target;
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (target != null)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;

            // Xoay mặt về phía nhân vật
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
    private void OnTriggerEnter2D(Collider2D collison)
    {
        if (collison.tag == "Player")
        {
            collison.GetComponent<Health>().TakeDamage(damage);
        }
    } 
}
