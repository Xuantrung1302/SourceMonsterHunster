using UnityEngine;

public class GunProtiles : MonoBehaviour
{
    [SerializeField] private float speedGun;
    private Vector2 direction;
    private bool hit;
    private CircleCollider2D cirCollider;
    private Animator anim;
    private float lifetime;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        cirCollider = GetComponent<CircleCollider2D>();
    }

    private void Update()
    {
        //if (hit) return;
        transform.Translate(direction * speedGun * Time.deltaTime);
        lifetime += Time.deltaTime;

        if (lifetime > 5f){
            Debug.Log(gameObject.name);
         gameObject.SetActive(false);

            }    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
        cirCollider.enabled = false;
        anim.SetTrigger("explode");
    }

    public void SetDirection(Vector2 _direction)
    {
        Debug.Log("Gun");
        lifetime = 0;
        direction = _direction.normalized;
        gameObject.SetActive(true);
        hit = false;
        cirCollider.enabled = true;

        // float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        // transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
