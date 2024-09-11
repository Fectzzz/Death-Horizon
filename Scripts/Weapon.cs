using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Weapon : MonoBehaviour
{
    // Points de tir des balles
    public Transform firePoint1;
    public Transform firePoint2;
    // Préfabriqué de la balle
    public GameObject bulletPrefab;
    // Référence au joueur
    public GameObject player;
    // Composant SpriteRenderer du joueur
    public SpriteRenderer rend;
    // Script de mouvement du joueur
    public PlayerMovement playerScript;
    // Script du gestionnaire de jeu
    public GameManager gameManagerScript;

    // Variables pour gérer les tirs multiples
    public int bulletShoot;
    // Capacité maximale d'un chargeur
    public int maxAmmoPerClip = 20;
    // Nombre total de munitions
    public int maxTotalAmmo = 200;

    public int numberAmelioration1;
    public int numberAmelioration2;
    public int numberAmelioration3;

    // Textes UI pour afficher les munitions
    public TextMeshProUGUI textCapicityBullet;
    public GameObject textRecharging;
    public GameObject textNoMunition;

    // Variables internes pour gérer les munitions et le rechargement
    public int currentAmmo; // Munitions actuelles dans le chargeur
    public int totalAmmo; // Munitions totales restantes
    public bool isReloading = false; // Indique si le rechargement est en cours
    public float reloadTime;

    void Start()
    {
        // Initialiser les élèments UI et les munitions
        textRecharging.SetActive(false);
        textNoMunition.SetActive(false);
        rend = player.GetComponent<SpriteRenderer>();
        currentAmmo = maxAmmoPerClip; // Initialiser les munitions du chargeur
        totalAmmo = maxTotalAmmo; // Initialiser les munitions totales
    }

    void Update()
    {
        numberAmelioration1 = PlayerPrefs.GetInt("NiveauAmélioration7");
        numberAmelioration2 = PlayerPrefs.GetInt("NiveauAmélioration8");

        reloadTime = 3;

        // Améliorations
        if(numberAmelioration1 == 1)
        {
            maxAmmoPerClip = 15;
        }

        if (numberAmelioration1 == 2)
        {
            maxAmmoPerClip = 25;
        }

        if (numberAmelioration1 == 3)
        {
            maxAmmoPerClip = 50;
        }

        if (numberAmelioration1 == 4)
        {
            maxAmmoPerClip = 75;
        }

        if (numberAmelioration1 == 5)
        {
            maxAmmoPerClip = 200;
        }

        if(numberAmelioration2 == 1)
        {
            maxTotalAmmo = 150;
        }

        if (numberAmelioration2 == 2)
        {
            maxTotalAmmo = 250;
        }

        if (numberAmelioration2 == 3)
        {
            maxTotalAmmo = 500;
        }

        if (numberAmelioration2 == 4)
        {
            maxTotalAmmo = 750;
        }

        if (numberAmelioration2 == 5)
        {
            maxTotalAmmo = 2000;
        }

        // Mettre à jour l'affichage des munitions
        textCapicityBullet.text = currentAmmo.ToString() + " / " + totalAmmo.ToString();

        // Si on est en train de recharger, on quitte la fonction
        if (isReloading)
            return;

        // Si le chargeur est vide mais qu'il reste des munitions, on recharge
        if (currentAmmo <= 0 && totalAmmo > 0)
        {
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetKeyDown(KeyCode.R) && currentAmmo > 0 && totalAmmo > 0)
        {
            StartCoroutine(Reload());
            return;
        }

        // Si le chargeur est vide et qu'il n'y a plus de munitions, on affiche le message de manque de munitions
        if (currentAmmo <= 0 && totalAmmo <= 0)
        {
            textNoMunition.SetActive(true);
            return;
        }

        // Récupérer le nombre de balles à tirer à partir des préfèrences de l'utilisateur
        bulletShoot = PlayerPrefs.GetInt("NiveauAmélioration1");
        PlayerPrefs.SetInt("BulletFiredAtTheSameTime", bulletShoot);

        // Gérer le tir si les conditions sont remplies
        if (Input.GetButtonDown("Fire1") && playerScript.haveGun && !gameManagerScript.gameIsPaused)
        {
            for (int i = 0; i < bulletShoot; i++)
            {
                if (currentAmmo > 0)
                {
                    Shoot();
                    currentAmmo--;
                }
                else
                {
                    break;
                }
            }
        }
    }

    // Coroutine pour gérer le rechargement avec un délai de 3 secondes
    public IEnumerator Reload()
    {
        isReloading = true; // Indiquer que le rechargement est en cours
        textRecharging.SetActive(true); // Afficher le texte de rechargement
        Debug.Log("Rechargement...");

        yield return new WaitForSeconds(reloadTime); // Attendre 3 secondes

        // Calculer le nombre de munitions à recharger
        int ammoNeeded = maxAmmoPerClip - currentAmmo; // Munitions nécessaires pour remplir le chargeur
        int ammoToReload = Mathf.Min(ammoNeeded, totalAmmo); // Munitions disponibles pour recharger

        currentAmmo += ammoToReload; // Ajouter les munitions au chargeur actuel
        totalAmmo -= ammoToReload; // Réduire le nombre total de munitions

        isReloading = false; // Indiquer que le rechargement est terminé
        textRecharging.SetActive(false); // Cacher le texte de rechargement
    }

    // Fonction pour gérer le tir
    void Shoot()
    {
        // Instancier la balle au bon point de tir en fonction de l'orientation du joueur
        if (rend.flipX == false)
        {
            Instantiate(bulletPrefab, firePoint1.position, firePoint1.rotation);
        }
        else
        {
            Instantiate(bulletPrefab, firePoint2.position, firePoint2.rotation);
        }
    }

    public IEnumerator InfiniteAmmo(float duration)
    {
        int originalAmmo = currentAmmo;
        int originalTotalAmmo = totalAmmo;

        currentAmmo = int.MaxValue;
        totalAmmo = int.MaxValue;

        yield return new WaitForSeconds(duration);

        currentAmmo = originalAmmo;
        totalAmmo = originalTotalAmmo;
    }
}