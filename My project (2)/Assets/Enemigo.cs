using UnityEngine;
public class Enemigo : MonoBehaviour
{
    [SerializeField] private float vida;
    [SerializeField] private Animator enemyAnimator;
    [SerializeField] private float range;
    [SerializeField] private float speed;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform gunPivot;
    [SerializeField] private float fireRate = 2f;
    private Transform player;
    private SpriteRenderer enemySpriteRenderer;
    private Rigidbody2D rb2D;
    private float nextFireTime;
    public float radioDeteccion;
    public new  AudioSource audio;

    private void Start()
    {
        enemyAnimator = GetComponent<Animator>();
        enemySpriteRenderer = GetComponent<SpriteRenderer>();
        rb2D = GetComponent<Rigidbody2D>();
        nextFireTime = Time.time;
    }

    public void TomarDaño(float daño)
    {
        vida -= daño;
        if (vida <= 0)
        {
            Debug.Log("muerto");
            Muerte();
        }
    }

    private void Muerte()
    {
        enemyAnimator.Play("explosion-animation");
        Destroy(gameObject, 1f);
    }

    private void FixedUpdate()
    {
        if (player != null)
        {
            float distanciaAlJugador = Vector3.Distance(transform.position, player.position);
            if (distanciaAlJugador <= radioDeteccion)
            {
                rb2D.velocity = Vector2.zero;
                if (Time.time >= nextFireTime)
                {
                    Disparar();
                    nextFireTime = Time.time + fireRate;
                }
            }
            else
            {
                DetectarPlayer();
            }
        }
        else
        {
            DetectarPlayer();
        }
    }

    private void DetectarPlayer()
    {
        Collider2D[] colliderArray = Physics2D.OverlapCircleAll(transform.position, range);
        float step = 1;
        foreach (Collider2D collider2D in colliderArray)
        {
            if (collider2D.CompareTag("Player"))
            {
                step = speed * Time.deltaTime;
                player = collider2D.gameObject.transform;
                transform.position = Vector3.MoveTowards(transform.position, player.position, step);
                if (player.position.x > transform.position.x)
                {
                    enemySpriteRenderer.flipX = true;
                }
                else
                {
                    enemySpriteRenderer.flipX = false;
                }
            }
        }
    }

    private void Disparar()
    {
        Vector2 direction = player.position - gunPivot.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        GameObject bullet = Instantiate(bulletPrefab, gunPivot.position, Quaternion.Euler(0f, 0f, angle));

        Rigidbody2D bulletRb2D = bullet.GetComponent<Rigidbody2D>();
        bulletRb2D.AddForce(direction.normalized * 500f);
        audio.Play();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(transform.position, range);
    }
}