using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerCampaign : MonoBehaviour
{
    public int maxHealth = 10; // Vie max du joueur
    public int currentHealth; // Vie actuel du joueur

    public float speed = 100f; // vitesse de d�placement du joueur
    public float jumpSpeed = 5f; // force de saut du joueur

    private bool IsJumping; // est-ce qu'il saute ?
    private bool IsGrounded; // est-ce qu'il touche le sol ?
    public bool haveGun = false; // il a le pistolet ?
    public bool haveSword = false; // Il a l'�p�e ?

    public Transform groundChekLeft; // Pied gauche
    public Transform groundChekRight; // Pied droit

    public Rigidbody2D rb; // composant Rigidbody2D du joueur
    private Vector3 velocity = Vector3.zero; // Velocit�

    public SpriteRenderer Rend; // composant Sprite Renderer du joueur


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // on r�cup�re le composant Rigidbody2D du joueur
        Rend = GetComponent<SpriteRenderer>(); // on r�cup�re le composant Sprite Renderer du joueur
        currentHealth = maxHealth; // On met la vie du joueur � 10 quand la partie commence
    }

    private void FixedUpdate()
    {
        if (currentHealth > 10f)
        {
            currentHealth = maxHealth; // Si les PV du joueur sont sup�rieur � 10, alors on le remet � 10
        }

        IsGrounded = Physics2D.OverlapArea(groundChekLeft.position, groundChekRight.position); // Est-ce qu'il touche le sol avec ses pieds

        float h = Input.GetAxis("Horizontal") * speed; // on r�cup�re la valeur de l'axe horizontal (fl�ches gauche/droite)

        // on d�place le joueur horizontalement
        float horizontalMovement = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        // on v�rifie si l'utilisateur appuie sur la touche de saut
        if (Input.GetButtonDown("Jump") && IsGrounded)
        {
            IsJumping = true; // Il est en train de sauter
        }

        MovePlayer(horizontalMovement);

        float characterVelocity = Mathf.Abs(rb.velocity.x);

        if (h > 0)
        {
            Rend.flipX = false;
        }

        if (h < 0)
        {
            Rend.flipX = true;
        }
    }

    void MovePlayer(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);

        if (IsJumping == true)
        {
            rb.AddForce(new Vector2(0f, jumpSpeed));
            IsJumping = false;

        }
    }
}
