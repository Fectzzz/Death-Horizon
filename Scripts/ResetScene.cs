using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class ResetScene : MonoBehaviour
{
    [Header("Games Objects")]
    public GameObject shop;
    public GameObject shop2;
    public GameObject shop3;
    public GameObject player;
    public GameObject panelShop;

    [Header("External Scripts")]
    public PlayerMovement playerScript;
    public Bullet bulletScript;
    public Weapon weaponScript;
    public ZombieController zombieScript;

    [Header("Variables Ameliorations")]
    public int nivAmelioration1 = 1;
    public int nivAmelioration2 = 1;
    public int nivAmelioration3 = 1;
    public int nivAmelioration4 = 1;
    public int nivAmelioration5 = 1;
    public int nivAmelioration6 = 1;
    public int nivAmelioration7 = 1;
    public int nivAmelioration8 = 1;

    [Header("Text Elements")]
    public TextMeshProUGUI textPay1;
    public TextMeshProUGUI textNiv1;
    public TextMeshProUGUI textPay2;
    public TextMeshProUGUI textNiv2;
    public TextMeshProUGUI textPay3;
    public TextMeshProUGUI textNiv3;
    public TextMeshProUGUI textPay4;
    public TextMeshProUGUI textNiv4;
    public TextMeshProUGUI textPay5;
    public TextMeshProUGUI textNiv5;
    public TextMeshProUGUI textPay6;
    public TextMeshProUGUI textNiv6;
    public TextMeshProUGUI textPay7;
    public TextMeshProUGUI textNiv7;
    public TextMeshProUGUI textPay8;
    public TextMeshProUGUI textNiv8;

    public void Start()
    {
        bulletScript = GameObject.FindWithTag("Bullet").GetComponent<Bullet>();
        zombieScript = GameObject.FindWithTag("EnnemiSans").GetComponent<ZombieController>();
        panelShop.SetActive(false);
    }

    public void Update()
    {
        PlayerPrefs.SetInt("BulletVitesse", bulletScript.speed);
        PlayerPrefs.SetInt("NiveauAmélioration1", nivAmelioration1);
        PlayerPrefs.SetInt("NiveauAmélioration2", nivAmelioration2);
        PlayerPrefs.SetInt("NiveauAmélioration3", nivAmelioration3);
        PlayerPrefs.SetInt("NiveauAmélioration4", nivAmelioration4);
        PlayerPrefs.SetInt("NiveauAmélioration5", nivAmelioration5);
        PlayerPrefs.SetInt("NiveauAmélioration6", nivAmelioration6);
        PlayerPrefs.SetInt("NiveauAmélioration7", nivAmelioration7);
        PlayerPrefs.SetInt("NiveauAmélioration8", nivAmelioration8);

        // Bullet total
        if (PlayerPrefs.GetInt("NiveauAmélioration8") == 1)
        {
            textPay8.text = "500$";
            textNiv8.text = "LEVEL 1";
        }

        if (PlayerPrefs.GetInt("NiveauAmélioration8") == 2)
        {
            textPay8.text = "1000$";
            textNiv8.text = "LEVEL 2";
        }

        if (PlayerPrefs.GetInt("NiveauAmélioration8") == 3)
        {
            textPay8.text = "2500$";
            textNiv8.text = "LEVEL 3";
        }

        if (PlayerPrefs.GetInt("NiveauAmélioration8") == 4)
        {
            textPay8.text = "5000$";
            textNiv8.text = "LEVEL 4";
        }

        if (PlayerPrefs.GetInt("NiveauAmélioration8") == 5)
        {
            textPay8.text = "MAX";
            textNiv8.text = "LEVEL MAX";
        }

        // Bullet actual
        if (PlayerPrefs.GetInt("NiveauAmélioration7") == 1)
        {
            textPay7.text = "500$";
            textNiv7.text = "LEVEL 1";
        }

        if (PlayerPrefs.GetInt("NiveauAmélioration7") == 2)
        {
            textPay7.text = "1000$";
            textNiv7.text = "LEVEL 2";
        }

        if (PlayerPrefs.GetInt("NiveauAmélioration7") == 3)
        {
            textPay7.text = "2500$";
            textNiv7.text = "LEVEL 3";
        }

        if (PlayerPrefs.GetInt("NiveauAmélioration7") == 4)
        {
            textPay7.text = "5000$";
            textNiv7.text = "LEVEL 4";
        }

        if (PlayerPrefs.GetInt("NiveauAmélioration7") == 5)
        {
            textPay7.text = "MAX";
            textNiv7.text = "LEVEL MAX";
        }

        // Jump Power
        if (PlayerPrefs.GetInt("NiveauAmélioration6") == 1)
        {
            playerScript.jumpSpeed = 100;
            textPay6.text = "500$";
            textNiv6.text = "LEVEL 1";
        }

        if (PlayerPrefs.GetInt("NiveauAmélioration6") == 2)
        {
            playerScript.jumpSpeed = 200;
            textPay6.text = "1000$";
            textNiv6.text = "LEVEL 2";
        }

        if (PlayerPrefs.GetInt("NiveauAmélioration6") == 3)
        {
            playerScript.jumpSpeed = 300;
            textPay6.text = "2500$";
            textNiv6.text = "LEVEL 3";
        }

        if (PlayerPrefs.GetInt("NiveauAmélioration6") == 4)
        {
            playerScript.jumpSpeed = 400;
            textPay6.text = "5000$";
            textNiv6.text = "LEVEL 4";
        }

        if (PlayerPrefs.GetInt("NiveauAmélioration6") == 5)
        {
            playerScript.jumpSpeed = 550;
            textPay6.text = "MAX";
            textNiv6.text = "LEVEL MAX";
        }

        // Powers
        if (PlayerPrefs.GetInt("NiveauAmélioration5") == 1)
        {
            playerScript.UseDash = true;
            textPay5.text = "500$";
            textNiv5.text = "LEVEL 1";
        }

        if (PlayerPrefs.GetInt("NiveauAmélioration5") == 2)
        {
            playerScript.UseShockWave = true;
            textPay5.text = "1000$";
            textNiv5.text = "LEVEL 2";
        }

        if (PlayerPrefs.GetInt("NiveauAmélioration5") == 3)
        {
            playerScript.UseSpawnDouble = true;
            textPay5.text = "2500$";
            textNiv5.text = "LEVEL 3";
        }

        if (PlayerPrefs.GetInt("NiveauAmélioration5") == 4)
        {
            playerScript.UseDashInfinitely = true;
            textPay5.text = "5000$";
            textNiv5.text = "LEVEL 4";
        }

        if (PlayerPrefs.GetInt("NiveauAmélioration5") == 5)
        {
            playerScript.UseShootInfinity = true;
            textPay5.text = "MAX";
            textNiv5.text = "LEVEL MAX";
        }

        // Weapon Level
        if (PlayerPrefs.GetInt("NiveauAmélioration4") == 1)
        {
            zombieScript.damage = 1;
            textPay4.text = "500$";
            textNiv4.text = "LEVEL 1";
        }

        if (PlayerPrefs.GetInt("NiveauAmélioration4") == 2)
        {
            zombieScript.damage = 2;
            textPay4.text = "1000$";
            textNiv4.text = "LEVEL 2";
        }

        if (PlayerPrefs.GetInt("NiveauAmélioration4") == 3)
        {
            zombieScript.damage = 4;
            textPay4.text = "2500$";
            textNiv4.text = "LEVEL 3";
        }

        if (PlayerPrefs.GetInt("NiveauAmélioration4") == 4)
        {
            zombieScript.damage = 6;
            textPay4.text = "5000$";
            textNiv4.text = "LEVEL 4";
        }

        if (PlayerPrefs.GetInt("NiveauAmélioration4") == 5)
        {
            zombieScript.damage = 10;
            textPay4.text = "MAX";
            textNiv4.text = "LEVEL MAX";
        }

        // Player Vitesse
        if (PlayerPrefs.GetInt("NiveauAmélioration3") == 1)
        {
            playerScript.speed = 100f;
            textPay3.text = "500$";
            textNiv3.text = "LEVEL 1";
        }

        if (PlayerPrefs.GetInt("NiveauAmélioration3") == 2)
        {
            playerScript.speed = 150f;
            textPay3.text = "1000$";
            textNiv3.text = "LEVEL 2";
        }

        if (PlayerPrefs.GetInt("NiveauAmélioration3") == 3)
        {
            playerScript.speed = 200f;
            textPay3.text = "2500$";
            textNiv3.text = "LEVEL 3";
        }

        if (PlayerPrefs.GetInt("NiveauAmélioration3") == 4)
        {
            playerScript.speed = 300f;
            textPay3.text = "5000";
            textNiv3.text = "LEVEL 4";
        }

        if (PlayerPrefs.GetInt("NiveauAmélioration3") == 5)
        {
            playerScript.speed = 400f;
            textPay3.text = "MAX";
            textNiv3.text = "LEVEL MAX";
        }

        // Bullet Vitesse
        if (PlayerPrefs.GetInt("NiveauAmélioration2") == 1)
        {
            bulletScript.speed = 3;
            textPay2.text = "500$";
            textNiv2.text = "LEVEL 1";
        }

        if (PlayerPrefs.GetInt("NiveauAmélioration2") == 2)
        {;
            bulletScript.speed = 5;
            textPay2.text = "1000$";
            textNiv2.text = "LEVEL 2";
        }

        if (PlayerPrefs.GetInt("NiveauAmélioration2") == 3)
        {
            bulletScript.speed = 10;
            textPay2.text = "2500$";
            textNiv2.text = "LEVEL 3";
        }

        if (PlayerPrefs.GetInt("NiveauAmélioration2") == 4)
        {
            bulletScript.speed = 20;
            textPay2.text = "5000$";
            textNiv2.text = "LEVEL 4";
        }

        if (PlayerPrefs.GetInt("NiveauAmélioration2") == 5)
        {
            bulletScript.speed = 50;
            textPay2.text = "MAX";
            textNiv2.text = "LEVEL MAX";
        }

        // Bullet Number
        if (PlayerPrefs.GetInt("NiveauAmélioration1") == 1)
        {
            weaponScript.bulletShoot = 1;
            textPay1.text = "500$";
            textNiv1.text = "LEVEL 1";
        }

        if (PlayerPrefs.GetInt("NiveauAmélioration1") == 2)
        {
            weaponScript.bulletShoot = 2;
            textPay1.text = "1000$";
            textNiv1.text = "LEVEL 2";
        }

        if (PlayerPrefs.GetInt("NiveauAmélioration1") == 3)
        {
            weaponScript.bulletShoot = 3;
            textPay1.text = "2500$";
            textNiv1.text = "LEVEL 3";
        }

        if (PlayerPrefs.GetInt("NiveauAmélioration1") == 4)
        {
            weaponScript.bulletShoot = 4;
            textPay1.text = "5000$";
            textNiv1.text = "LEVEL 4";
        }

        if (PlayerPrefs.GetInt("NiveauAmélioration1") == 5)
        {
            weaponScript.bulletShoot = 5;
            textPay1.text = "MAX";
            textNiv1.text = "LEVEL MAX";
        }
    }

    public void ShopTrue()
    {
        shop.SetActive(true);
        shop2.SetActive(false);
        shop3.SetActive(false);
        panelShop.SetActive(true);
    }

    public void ShopFalse()
    {
        shop.SetActive(false);
        shop2.SetActive(false);
        shop3.SetActive(false);
        panelShop.SetActive(false);
    }

    public void Shop1()
    {
        shop.SetActive(true);
        shop2.SetActive(false);
        shop3.SetActive(false);
    }

    public void Shop2()
    {
        shop2.SetActive(true);
        shop3.SetActive(false);
        shop.SetActive(false);
    }

    public void Shop3()
    {
        shop3.SetActive(true);
        shop2.SetActive(false);
        shop.SetActive(false);
    }

    public void PayBulletNumber()
    {
        if(playerScript.allCoin >= 500 && nivAmelioration1 == 1)
        {
            nivAmelioration1 = 2;
            textPay1.text = "1000$";
            textNiv1.text = "LEVEL 2";
            weaponScript.bulletShoot = 2;
            playerScript.allCoin -= 500;
        }

        if (playerScript.allCoin >= 1000 && nivAmelioration1 == 2)
        {
            nivAmelioration1 = 3;
            textPay1.text = "2500";
            textNiv1.text = "LEVEL 3";
            weaponScript.bulletShoot = 3;
            playerScript.allCoin -= 1000;
        }

        if (playerScript.allCoin >= 2500 && nivAmelioration1 == 3)
        {
            nivAmelioration1 = 4;
            textPay1.text = "5000$";
            textNiv1.text = "LEVEL 4";
            weaponScript.bulletShoot = 4;
            playerScript.allCoin -= 2500;
        }

        if (playerScript.allCoin >= 5000 && nivAmelioration1 == 4)
        {
            nivAmelioration1 = 5;
            textPay1.text = "MAX";
            textNiv1.text = "LEVEL MAX";
            weaponScript.bulletShoot = 5;
            playerScript.allCoin -= 5000;
        }
    }

    public void PayBulletVitesse()
    {
        if (playerScript.allCoin >= 500 && nivAmelioration2 == 1)
        {
            nivAmelioration2 = 2;
            textPay2.text = "1000$";
            textNiv2.text = "LEVEL 2";
            bulletScript.speed = 13;
            playerScript.allCoin -= 500;
        }

        if (playerScript.allCoin >= 1000 && nivAmelioration2 == 2)
        {
            nivAmelioration2 = 3;
            textPay2.text = "2500";
            textNiv2.text = "LEVEL 3";
            bulletScript.speed = 25;
            playerScript.allCoin -= 1000;
        }

        if (playerScript.allCoin >= 2500 && nivAmelioration2 == 3)
        {
            nivAmelioration2 = 4;
            textPay2.text = "5000$";
            textNiv2.text = "LEVEL 4";
            bulletScript.speed = 40;
            playerScript.allCoin -= 2500;
        }

        if (playerScript.allCoin >= 5000 && nivAmelioration2 == 4)
        {
            nivAmelioration2 = 5;
            textPay2.text = "MAX";
            textNiv2.text = "LEVEL MAX";
            bulletScript.speed = 75;
            playerScript.allCoin -= 5000;
        }
    }

    public void PayPlayerVitesse()
    {
        if (playerScript.allCoin >= 500 && nivAmelioration3 == 1)
        {
            nivAmelioration3 = 2;
            textPay3.text = "1000$";
            textNiv3.text = "LEVEL 2";
            playerScript.speed = 150f;
            playerScript.allCoin -= 500;
        }

        if (playerScript.allCoin >= 1000 && nivAmelioration3 == 2)
        {
            nivAmelioration3 = 3;
            textPay3.text = "2500";
            textNiv3.text = "LEVEL 3";
            playerScript.speed = 200f;
            playerScript.allCoin -= 1000;
        }

        if (playerScript.allCoin >= 2500 && nivAmelioration3 == 3)
        {
            nivAmelioration3 = 4;
            textPay3.text = "5000$";
            textNiv3.text = "LEVEL 4";
            playerScript.speed = 300f;
            playerScript.allCoin -= 2500;
        }

        if (playerScript.allCoin >= 5000 && nivAmelioration3 == 4)
        {
            nivAmelioration3 = 5;
            textPay3.text = "MAX";
            textNiv3.text = "LEVEL MAX";
            playerScript.speed = 400f;
            playerScript.allCoin -= 5000;
        }
    }

    public void PayWeaponLevel()
    {
        if (playerScript.allCoin >= 500 && nivAmelioration4 == 1)
        {
            nivAmelioration4 = 2;
            textPay4.text = "1000$";
            textNiv4.text = "LEVEL 2";
            // Amelioration
            playerScript.allCoin -= 500;
        }

        if (playerScript.allCoin >= 1000 && nivAmelioration4 == 2)
        {
            nivAmelioration4 = 3;
            textPay4.text = "2500";
            textNiv4.text = "LEVEL 3";
            // Amelioration
            playerScript.allCoin -= 1000;
        }

        if (playerScript.allCoin >= 2500 && nivAmelioration4 == 3)
        {
            nivAmelioration4 = 4;
            textPay4.text = "5000$";
            textNiv4.text = "LEVEL 4";
            // Amelioration
            playerScript.allCoin -= 2500;
        }

        if (playerScript.allCoin >= 5000 && nivAmelioration4 == 4)
        {
            nivAmelioration4 = 5;
            textPay4.text = "MAX";
            textNiv4.text = "LEVEL MAX";
            // Amelioration
            playerScript.allCoin -= 5000;
        }
    }

    public void PayPowers()
    {
        if (playerScript.allCoin >= 500 && nivAmelioration5 == 1)
        {
            nivAmelioration5 = 2;
            textPay5.text = "1000$";
            textNiv5.text = "LEVEL 2";
            playerScript.allCoin -= 500;
        }

        if (playerScript.allCoin >= 1000 && nivAmelioration5 == 2)
        {
            nivAmelioration5 = 3;
            textPay5.text = "2500";
            textNiv5.text = "LEVEL 3";
            playerScript.allCoin -= 1000;
        }

        if (playerScript.allCoin >= 2500 && nivAmelioration5 == 3)
        {
            nivAmelioration5 = 4;
            textPay5.text = "5000$";
            textNiv5.text = "LEVEL 4";
            playerScript.allCoin -= 2500;
        }

        if (playerScript.allCoin >= 5000 && nivAmelioration5 == 4)
        {
            nivAmelioration5 = 5;
            textPay5.text = "MAX";
            textNiv5.text = "LEVEL MAX";
            playerScript.allCoin -= 5000;
        }
    }

    public void PayJumpPower()
    {
        if (playerScript.allCoin >= 500 && nivAmelioration6 == 1)
        {
            nivAmelioration6 = 2;
            textPay6.text = "1000$";
            textNiv6.text = "LEVEL 2";
            playerScript.jumpSpeed = 200;
            playerScript.allCoin -= 500;
        }

        if (playerScript.allCoin >= 1000 && nivAmelioration6 == 2)
        {
            nivAmelioration6 = 3;
            textPay6.text = "2500";
            textNiv6.text = "LEVEL 3";
            playerScript.jumpSpeed = 300;
            playerScript.allCoin -= 1000;
        }

        if (playerScript.allCoin >= 2500 && nivAmelioration6 == 3)
        {
            nivAmelioration6 = 4;
            textPay6.text = "5000$";
            textNiv6.text = "LEVEL 4";
            playerScript.jumpSpeed = 400;
            playerScript.allCoin -= 2500;
        }

        if (playerScript.allCoin >= 5000 && nivAmelioration6 == 4)
        {
            nivAmelioration6 = 5;
            textPay6.text = "MAX";
            textNiv6.text = "LEVEL MAX";
            playerScript.jumpSpeed = 500;
            playerScript.allCoin -= 5000;
        }
    }

    public void PayActualBullet()
    {
        if (playerScript.allCoin >= 500 && nivAmelioration7 == 1)
        {
            nivAmelioration7 = 2;
            textPay7.text = "1000$";
            textNiv7.text = "LEVEL 2";
            playerScript.allCoin -= 500;
        }

        if (playerScript.allCoin >= 1000 && nivAmelioration7 == 2)
        {
            nivAmelioration7 = 3;
            textPay7.text = "2500";
            textNiv7.text = "LEVEL 3";
            playerScript.allCoin -= 1000;
        }

        if (playerScript.allCoin >= 2500 && nivAmelioration7 == 3)
        {
            nivAmelioration7 = 4;
            textPay7.text = "5000$";
            textNiv7.text = "LEVEL 4";
            playerScript.allCoin -= 2500;
        }

        if (playerScript.allCoin >= 5000 && nivAmelioration7 == 4)
        {
            nivAmelioration7 = 5;
            textPay7.text = "MAX";
            textNiv7.text = "LEVEL MAX";
            playerScript.allCoin -= 5000;
        }
    }

    public void PayTotalBullet()
    {
        if (playerScript.allCoin >= 500 && nivAmelioration8 == 1)
        {
            nivAmelioration8 = 2;
            textPay8.text = "1000$";
            textNiv8.text = "LEVEL 2";
            playerScript.allCoin -= 500;
        }

        if (playerScript.allCoin >= 1000 && nivAmelioration8 == 2)
        {
            nivAmelioration8 = 3;
            textPay8.text = "2500";
            textNiv8.text = "LEVEL 3";
            playerScript.allCoin -= 1000;
        }

        if (playerScript.allCoin >= 2500 && nivAmelioration8 == 3)
        {
            nivAmelioration8 = 4;
            textPay8.text = "5000$";
            textNiv8.text = "LEVEL 4";
            playerScript.allCoin -= 2500;
        }

        if (playerScript.allCoin >= 5000 && nivAmelioration8 == 4)
        {
            nivAmelioration8 = 5;
            textPay8.text = "MAX";
            textNiv8.text = "LEVEL MAX";
            playerScript.allCoin -= 5000;
        }
    }
}
