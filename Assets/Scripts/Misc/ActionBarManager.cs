using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionBarManager : MonoBehaviour
{
    [Header("Action Bar Images")]
    public Image bulletImage;
    public Image laserImage;
    public Image novaeImage;
    public Image bulletBackground;
    public Image laserBackground;

    [Header("Image Sprites")]
    public Sprite regBullet;
    public Sprite regLaser;
    public Sprite altBullet;
    public Sprite altLaser;

    public void SwapImages()
    {
        if (bulletImage.sprite == regBullet && bulletBackground.sprite == regBullet)
        {
            bulletImage.sprite = altBullet;
            bulletBackground.sprite = altBullet;
        }
        else if (bulletImage.sprite == altBullet && bulletBackground.sprite == altBullet)
        {
            bulletImage.sprite = regBullet;
            bulletBackground.sprite = regBullet;
        }

        if (laserImage.sprite == regLaser && laserBackground.sprite == regLaser)
        {
            laserImage.sprite = altLaser;
            laserBackground.sprite = altLaser;
        }
        else if (laserImage.sprite == altLaser && laserBackground.sprite == altLaser)
        {
            laserImage.sprite = regLaser;
            laserBackground.sprite = regLaser;
        }
    }
}
