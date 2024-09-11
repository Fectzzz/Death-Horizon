using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    // Références aux différents GameObjects et composants
    [Header("UI Elements")]
    public GameObject canvas;
    public GameObject chronoText;
    public GameObject gun;
    public GameObject firePoint;
    public GameObject waveSpawner;
    public GameObject CurrentWave;
    public GameObject Kill;

    [Header("UI Powers")]
    public GameObject imagePower1;
    public GameObject imagePower2;
    public GameObject imagePower3;
    public GameObject imagePower4;
    public GameObject imagePower5;
    public GameObject imageGreyPower1;
    public GameObject imageGreyPower2;
    public GameObject imageGreyPower3;
    public GameObject imageGreyPower4;
    public GameObject imageGreyPower5;
    public GameObject Power1;
    public GameObject Power2;
    public GameObject Power3;
    public GameObject Power4;
    public GameObject Power5;

    [Header("Player Stats")]
    public float maxHealth = 10f;
    public float currentHealth;
    public int allCoin = 500;
    public int coinGame;
    public int kill;  

    [Header("Movement")]
    public float speed = 100f;
    public float jumpSpeed;
    public int levelJumpSpeed;
    private bool isJumping;
    private bool isGrounded;
    public bool haveGun = false;

    [Header("Dash")]
    [SerializeField] private bool canDash = true;
    public bool isDashing = false;
    [SerializeField] private float dashingPower = 24f;
    [SerializeField] private float dashingTime = 0.2f;
    [SerializeField] private float dashingCooldown = 30f;

    [Header("Components")]
    public Transform groundCheckLeft;
    public Transform groundCheckRight;
    private Rigidbody2D rb;
    private Vector3 velocity = Vector3.zero;
    private SpriteRenderer rend;
    private Animator animator;
    [SerializeField] private TrailRenderer tr;

    [Header("External Scripts")]
    public HealthBar healthBar;
    public WaveEnnemy waveEnnemyScript;
    public GameManager gameManagerScript;
    public Weapon weaponScript;

    [Header("Text Elements")]
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI textPieceMenu2;
    public TextMeshProUGUI textPieceMenu3;
    public TextMeshProUGUI textKill;
    public TextMeshProUGUI textKill2;
    public TextMeshProUGUI textCurrentWaveNumber;
    public TextMeshProUGUI textPieceMenu;
    public TextMeshProUGUI textPower1;
    public TextMeshProUGUI textPower2;
    public TextMeshProUGUI textPower3;
    public TextMeshProUGUI textPower4;
    public TextMeshProUGUI textPower5;

    [Header("Powers")]
    public int levelPowers;
    public bool UseDash;
    public bool UseShockWave;
    public bool UseSpawnDouble;
    public bool UseDashInfinitely;
    public bool UseShootInfinity;

    [Header("Cooldowns")]
    [SerializeField] private bool canUseShockwave = true;
    [SerializeField] private bool canSpawnDouble = true;
    [SerializeField] private bool canDashInfinitely = true;
    [SerializeField] private bool canShootInfiniteAmmo = true;
    public float infiniteAmmoCooldown = 30f;
    public float dashCooldown = 10f;
    public float shockWaveCooldown = 20f;
    public float spawnDoubleCooldown = 40f;
    public float infiniteDashCooldown = 60f;


    void Start()
    {
        // Initialisation des variables et désactivation des éléments de l'UI
        Kill.SetActive(false);
        CurrentWave.SetActive(false);
        currentHealth = maxHealth;
        canvas.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        healthBar.SetMaxHealth(maxHealth);
        UseDash = true;
        UseShockWave = true;
        UseSpawnDouble = true;
        UseDashInfinitely = true;
        UseShootInfinity = true;
        imagePower1.SetActive(true);
        imagePower2.SetActive(true);
        imagePower3.SetActive(true);
        imagePower4.SetActive(true);
        imagePower5.SetActive(true);
        imageGreyPower1.SetActive(false);
        imageGreyPower2.SetActive(false);
        imageGreyPower3.SetActive(false);
        imageGreyPower4.SetActive(false);
        imageGreyPower5.SetActive(false);
        Power5.SetActive(false);
        Power4.SetActive(false);
        Power3.SetActive(false);
        Power2.SetActive(false);
        Power1.SetActive(false);

        UpdatePowers();
        UpdateUI();
    }

    void FixedUpdate()
    {
        UpdatePlayerPrefs();
        UpdatePowers();
        UpdateJumpLevel();
        UpdateUI();

        levelPowers = PlayerPrefs.GetInt("NiveauAmélioration5");

        // Activer ou désactiver le spawner de vagues en fonction de la possession du pistolet
        waveSpawner.GetComponent<WaveEnnemy>().enabled = haveGun;

        if (isDashing)
        {
            return;
        }

        // Vérifier si le joueur touche le sol
        isGrounded = Physics2D.OverlapArea(groundCheckLeft.position, groundCheckRight.position);

        // Récupérer la valeur de l'axe horizontal (flèches gauche/droite)
        float horizontalMovement = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        // Vérifier si l'utilisateur appuie sur la touche de saut
        if (Input.GetButtonDown("Jump") && isGrounded && !gameManagerScript.gameIsPaused)
        {
            isJumping = true;
        }

        if (Input.GetKeyDown(KeyCode.X) && canDash == true && !gameManagerScript.gameIsPaused && haveGun == true)
        {
            StartCoroutine(Dash());
        }

        // Gestion des nouvelles actions
        if (Input.GetKeyDown(KeyCode.C) && canUseShockwave && haveGun && !gameManagerScript.gameIsPaused && UseShockWave == true)
        {
            StartCoroutine(UseShockwave());
        }

        if (Input.GetKeyDown(KeyCode.V) && canSpawnDouble && haveGun && !gameManagerScript.gameIsPaused && UseSpawnDouble == true)
        {
            StartCoroutine(SpawnDouble());
        }

        if (Input.GetKeyDown(KeyCode.B) && canDashInfinitely && haveGun && !gameManagerScript.gameIsPaused && UseDashInfinitely == true)
        {
            StartCoroutine(DashInfinitely());
        }

        if (Input.GetKeyDown(KeyCode.N) && canShootInfiniteAmmo && haveGun && !gameManagerScript.gameIsPaused && UseShootInfinity == true && weaponScript.isReloading == false)
        {
            StartCoroutine(ShootInfiniteAmmo());
        }

        // Déplacer le joueur
        MovePlayer(horizontalMovement);

        // Mettre à jour l'animation de déplacement
        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));

        // Retourner le sprite du joueur uniquement si le mouvement horizontal est différent de zéro
        if (horizontalMovement < 0)
        {
            rend.flipX = true;
        }
        else if (horizontalMovement > 0)
        {
            rend.flipX = false;
        }

        // Gérer la mort du joueur
        HandleDeath();

        // Limiter la vie du joueur à la valeur maximale
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    void MovePlayer(float horizontalMovement)
    {
        // Déplacement horizontal
        Vector3 targetVelocity = new Vector2(horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);

        // Gérer le saut
        if (isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpSpeed));
            isJumping = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Gérer les collisions avec différents objets
        if (isDashing && collision.gameObject.CompareTag("Ennemi"))
        {
            Destroy(collision.gameObject);
        }
        
        if (!isDashing && collision.gameObject.CompareTag("Ennemi"))
        {
            TakeDamage(1);
        }

        switch (collision.gameObject.tag)
        {
            case "Gun":
                haveGun = true;
                animator.SetBool("IsGun", true);
                gun.SetActive(false);
                break;
            case "Bas":
                TakeDamage(10f);
                break;
            case "Potion":
                TakeHealth(5f);
                Destroy(collision.gameObject);
                break;
            case "Coin":
                coinGame += 50;
                allCoin += 50;
                Destroy(collision.gameObject);
                break;
        }
    }

    public void TakeDamage(float damage)
    {
        // Appliquer des dégâts au joueur
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    public void TakeHealth(float health)
    {
        // Restaurer la santé du joueur
        currentHealth += health;
        healthBar.SetHealth(currentHealth);
    }

    private void UpdatePlayerPrefs()
    {
        // Mise à jour des préférences du joueur
        PlayerPrefs.SetInt("Coins", allCoin);
        jumpSpeed = PlayerPrefs.GetInt("NiveauAmélioration6", (int)jumpSpeed);
    }

    private void UpdatePowers()
    {
        if(levelPowers == 1)
        {
            UseDash = true;
        }

        if (levelPowers == 2)
        {
            UseShockWave = true;
        }       

        if (levelPowers == 3)
        {
            UseSpawnDouble = true;
        }

        if (levelPowers == 4)
        {
            UseDashInfinitely = true;
        }

        if (levelPowers == 5)
        {
            UseShootInfinity = true;
        }

        if(canDash == true && UseDash == true)
        {
            imagePower1.SetActive(true);
            imageGreyPower1.SetActive(false);
        }
        else
        {
            imageGreyPower1.SetActive(true);
            imagePower1.SetActive(false);
        }

        if (canUseShockwave == true && UseShockWave == true)
        {
            imagePower2.SetActive(true);
            imageGreyPower2.SetActive(false);
        }
        else
        {
            imageGreyPower2.SetActive(true);
            imagePower2.SetActive(false);
        }

        if (canSpawnDouble == true && UseSpawnDouble == true)
        {
            imagePower3.SetActive(true);
            imageGreyPower3.SetActive(false);
        }
        else
        {
            imageGreyPower3.SetActive(true);
            imagePower3.SetActive(false);
        }

        if (canDashInfinitely == true && UseDashInfinitely == true)
        {
            imagePower4.SetActive(true);
            imageGreyPower4.SetActive(false);
        }
        else
        {
            imageGreyPower4.SetActive(true);
            imagePower4.SetActive(false);
        }

        if (canShootInfiniteAmmo == true && UseShootInfinity == true)
        {
            imagePower5.SetActive(true);
            imageGreyPower5.SetActive(false);
        }
        else
        {
            imageGreyPower5.SetActive(true);
            imagePower5.SetActive(false);
        }
    }

    private void UpdateJumpLevel()
    {
        levelJumpSpeed = PlayerPrefs.GetInt("NiveauAmélioration6");

        if(levelJumpSpeed == 1)
        {
            jumpSpeed = 250f;
        }

        if (levelJumpSpeed == 2)
        {
            jumpSpeed = 400f;
        }

        if (levelJumpSpeed == 3)
        {
            jumpSpeed = 500f;
        }

        if (levelJumpSpeed == 4)
        {
            jumpSpeed = 600f;
        }

        if (levelJumpSpeed == 5)
        {
            jumpSpeed = 700f;
        }
    }

    private void UpdateUI()
    {
        // Mise à jour des éléments d'interface utilisateur
        textPieceMenu.text = allCoin.ToString();
        textCurrentWaveNumber.text = waveEnnemyScript.currentWaveNumber + " Wave(s)";
        textKill.text = kill + " Kill";
        textKill2.text = kill + " Kill";
        coinText.text = coinGame.ToString();
        textPieceMenu2.text = allCoin.ToString();
        textPieceMenu3.text = allCoin.ToString();
    }

    private void HandleDeath()
    {
        // Gérer la mort du joueur
        if (currentHealth <= 0f)
        {
            gameManagerScript.audioGame.Stop();
            Kill.SetActive(true);
            CurrentWave.SetActive(true);
            canvas.SetActive(true);
            chronoText.SetActive(false);
            animator.SetBool("Dead", true);
            GetComponent<AudioSource>().Play();
            this.enabled = false;
            waveSpawner.GetComponent<WaveEnnemy>().enabled = false;
        }
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;

        // Modifier la direction du dash en fonction de l'orientation du joueur
        float dashDirection = rend.flipX ? -1f : 1f;
        rb.velocity = new Vector2(dashDirection * dashingPower, 0f);

        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        Power1.SetActive(true);

        // Compte à rebours pour le cooldown
        float countdown = dashCooldown;
        while (countdown > 0)
        {
            textPower1.text = countdown.ToString("F1"); // Affiche le temps restant avec une décimale
            yield return new WaitForSeconds(0.1f);
            countdown -= 0.1f;
        }

        Power1.SetActive(false);
        canDash = true;
    }

    private IEnumerator UseShockwave()
    {
        canUseShockwave = false;
        // Trouver tous les zombies dans un rayon de 6 unités
        Collider2D[] zombies = Physics2D.OverlapCircleAll(transform.position, 6f);

        foreach (var zombie in zombies)
        {
            if (zombie.CompareTag("Ennemi"))
            {
                Destroy(zombie.gameObject);
            }
        }

        Power2.SetActive(true);

        // Compte à rebours pour le cooldown
        float countdown = shockWaveCooldown;
        while (countdown > 0)
        {
            textPower2.text = countdown.ToString("F1");
            yield return new WaitForSeconds(0.1f);
            countdown -= 0.1f;
        }

        Power2.SetActive(false);
        canUseShockwave = true;
    }

    private IEnumerator SpawnDouble()
    {
        canSpawnDouble = false;
        GameObject playerDouble = Instantiate(gameObject, transform.position + new Vector3(1f, 0f, 0f), Quaternion.identity);
        Animator doubleAnimator = playerDouble.GetComponent<Animator>();
        doubleAnimator.runtimeAnimatorController = animator.runtimeAnimatorController;
        Destroy(playerDouble, 10f); // Le double disparaît après 10 secondes
        Power3.SetActive(true);

        float countdown = spawnDoubleCooldown;
        while (countdown > 0)
        {
            textPower3.text = countdown.ToString("F1");
            yield return new WaitForSeconds(0.1f);
            countdown -= 0.1f;
        }

        Power3.SetActive(false);
        canSpawnDouble = true;
    }

    private IEnumerator DashInfinitely()
    {
        canDashInfinitely = false;
        float originalSpeed = speed;
        float originalJumpSpeed = jumpSpeed;
        float originalGravityScale = rb.gravityScale;
        float dashEndTime = Time.time + 5f; // Dash pendant 5 secondes

        while (Time.time < dashEndTime)
        {
            if (Input.GetButtonDown("Jump"))
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
                yield return new WaitForSeconds(1f); // Pause avant la descente rapide
                rb.velocity = new Vector2(rb.velocity.x, -jumpSpeed * 2); // Descente rapide
                                                                          // Créer une onde de choc qui tue les zombies
                Collider2D[] zombies = Physics2D.OverlapCircleAll(transform.position, 4f);
                foreach (var zombie in zombies)
                {
                    if (zombie.CompareTag("Ennemi"))
                    {
                        Destroy(zombie.gameObject);
                    }
                }
            }
            yield return null;
        }

        speed = originalSpeed;
        jumpSpeed = originalJumpSpeed;
        rb.gravityScale = originalGravityScale;
        Power4.SetActive(true);

        // Compte à rebours pour le cooldown
        float countdown = infiniteDashCooldown;
        while (countdown > 0)
        {
            textPower4.text = countdown.ToString("F1");
            yield return new WaitForSeconds(0.1f);
            countdown -= 0.1f;
        }

        Power4.SetActive(false);
        canDashInfinitely = true;
    }

    private IEnumerator ShootInfiniteAmmo()
    {
        canShootInfiniteAmmo = false;

        // Activer les munitions infinies dans le script de l'arme
        StartCoroutine(weaponScript.InfiniteAmmo(5f));

        // Compte à rebours pour le cooldown
        Power5.SetActive(true);
        float countdown = infiniteAmmoCooldown;
        while (countdown > 0)
        {
            textPower5.text = countdown.ToString("F1");
            yield return new WaitForSeconds(0.1f);
            countdown -= 0.1f;
        }

        Power5.SetActive(false);
        canShootInfiniteAmmo = true;
    }
}