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

    float bulletCooldown;
    float bulletStartCD = 1f;
    float laserCooldown;
    float laserStartCD = 1f;
    float novaeCooldown;
    float novaeStartCD = 5f;
    float projectileDeathTime = 20f;

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
        GameObject newBullet = Instantiate(projectile1, firePoint.transform.position, firePoint.transform.rotation);
        GameObject newBullet2 = Instantiate(projectile1, firePoint2.transform.position, firePoint2.transform.rotation);
        bulletCooldown = 0f;
        bulletImage.fillAmount = 0f;
        DestroyMultiple(newBullet, newBullet2, projectileDeathTime);
    }

    void FireLaser()
    {
        GameObject newLaser = Instantiate(projectile2, firePoint.transform.position, firePoint.transform.rotation);
        GameObject newLaser2 = Instantiate(projectile2, firePoint2.transform.position, firePoint2.transform.rotation);
        laserCooldown = 0f;
        laserImage.fillAmount = 0f;
        DestroyMultiple(newLaser, newLaser2, projectileDeathTime);
    }

    void FireNovae()
    {
        GameObject newNovaBomb = Instantiate(novaeBomb, firePoint3.transform.position, firePoint3.transform.rotation);
        novaeCooldown = 0f;
        novaeImage.fillAmount = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        DetectFiring();
        RunCooldown();
    }

    void DetectFiring()
    {
        bool fire1 = Input.GetButtonDown("Fire1");
        bool fire2 = Input.GetButtonDown("Fire2");
        bool fire3 = Input.GetKeyDown(KeyCode.Space);

        if (fire1 && bulletCooldown >= bulletStartCD)
        {
            FireBullet();
        }

        if (fire2 && laserCooldown >= laserStartCD)
        {
            FireLaser();
        }

        if (fire3 && novaeCooldown >= novaeStartCD)
        {
            FireNovae();
        }
    }

    void RunCooldown()
    {
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

    void DestroyMultiple(GameObject object1, GameObject object2, float time)
    {
        Destroy(object1, time);
        Destroy(object2, time);
    }
}