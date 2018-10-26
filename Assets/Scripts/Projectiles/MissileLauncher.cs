using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissileLauncher : MonoBehaviour
{
    ActionBarManager actionBars;
    Laser lineLaser;

    [Header("Projectiles")]
    [Tooltip("This should remain empty in the inspector")]
    public GameObject projectile1;
    [Tooltip("This should remain empty in the inspector")]
    public GameObject projectile2;

    [Header("Projectile Objects")]
    public GameObject bullet;
    public GameObject altBullet;
    public GameObject laser;
    public GameObject altLaser;
    public GameObject novaeBomb;
    public GameObject firePoint;
    public GameObject firePoint2;
    public GameObject firePoint3;

    [Header("Cooldowns")]
    public Image bulletImage;
    public Image laserImage;
    public Image novaeImage;

    [HideInInspector]
    public float launchForce = 5f;

    private float bulletCooldown;
    private float bulletStartCD = 1f;
    private float laserCooldown;
    private float laserStartCD = 1f;
    private float novaeCooldown;
    private float novaeStartCD = 5f;

	// Use this for initialization
	void Start ()
    {
        actionBars = FindObjectOfType<ActionBarManager>();
        lineLaser = GetComponent<Laser>();

        projectile1 = bullet;
        projectile2 = laser;

        bulletCooldown = bulletStartCD;
        laserCooldown = laserStartCD;
        novaeCooldown = novaeStartCD;
    }

    void FireBullet()
    {
        Instantiate(projectile1, firePoint.transform.position, firePoint.transform.rotation);
        Instantiate(projectile1, firePoint2.transform.position, firePoint2.transform.rotation);
        bulletCooldown = 0f;
        bulletImage.fillAmount = 0f;
    }

    void FireLaser()
    {
        Instantiate(projectile2, firePoint.transform.position, firePoint.transform.rotation);
        Instantiate(projectile2, firePoint2.transform.position, firePoint2.transform.rotation);
        laserCooldown = 0f;
        laserImage.fillAmount = 0f;
    }

    void FireNovae()
    {
        Instantiate(novaeBomb, firePoint3.transform.position, firePoint3.transform.rotation);
        novaeCooldown = 0f;
        novaeImage.fillAmount = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && bulletCooldown >= 1f)
        {
            FireBullet();
        }

        if (Input.GetButtonDown("Fire2") && laserCooldown >= 1f)
        {
            FireLaser();
        }

        if (Input.GetKeyDown(KeyCode.Space) && novaeCooldown >= 5f)
        {
            FireNovae();
        }

        novaeCooldown += 1f * Time.deltaTime;
        novaeCooldown = Mathf.Clamp(novaeCooldown, 0f, 5f);
        novaeImage.fillAmount = novaeCooldown / novaeStartCD;

        bulletCooldown += 1f * Time.deltaTime;
        bulletCooldown = Mathf.Clamp(bulletCooldown, 0f, 1f);
        bulletImage.fillAmount = bulletCooldown / bulletStartCD;

        laserCooldown += 1f * Time.deltaTime;
        laserCooldown = Mathf.Clamp(laserCooldown, 0f, 1f);
        laserImage.fillAmount = laserCooldown / laserStartCD;
    }

    public void SwapProjectiles()
    {
        if (projectile1 == bullet)
        {
            projectile1 = altBullet;
        }
        else if (projectile1 == altBullet)
        {
            projectile1 = bullet;
        }

        if (projectile2 == laser)
        {
            projectile2 = altLaser;
        }
        else if (projectile2 == altLaser)
        {
            projectile2 = laser;
        }

        actionBars.SwapImages();
    }
}