using UnityEngine;
using UnityEngine.UI;

public class ZombieController : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public GameManager gameManager;

    public float speed = 2f; // Vitesse du zombie
    private Transform playerTransform; // Le component Transform du Joueur
    private Rigidbody2D rb; // Rigidbody du zombie
    public int pv; // PV du zombie
    public int damage;

    public Animator animator; // composant Animator du zombie

    public void Start()
    {
        // Trouver automatiquement le GameManager dans la scène
        gameManager = FindObjectOfType<GameManager>();
        GameObject player = gameManager.player;

        if (player != null)
        {
            playerMovement = player.GetComponent<PlayerMovement>();
            playerTransform = player.transform; // Utilisez la référence directe

            if (playerMovement == null)
            {
                Debug.LogError("Le composant PlayerMovement n'a pas été trouvé.");
            }
        }
        else
        {
            Debug.LogError("Aucun GameObject avec le tag 'Player' n'a été trouvé.");
        }

        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        damage = PlayerPrefs.GetInt("NiveauAmélioration4");

        if (playerTransform != null)
        {
            Vector3 direction = (playerTransform.position - transform.position).normalized;
            rb.velocity = new Vector2(direction.x * speed, rb.velocity.y);

            // Flip the zombie sprite when the player is on the right side
            if (direction.x > 0)
            {
                transform.GetComponent<SpriteRenderer>().flipX = false;
            }
            else
            {
                transform.GetComponent<SpriteRenderer>().flipX = true;
            }
        }

        if (pv <= 0)
        {
            playerMovement.kill++;
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            TakeDamage();
        }

        if (collision.gameObject.CompareTag("Ennemi") && playerMovement.isDashing == true)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage()
    {
        pv -= damage;
    }
}