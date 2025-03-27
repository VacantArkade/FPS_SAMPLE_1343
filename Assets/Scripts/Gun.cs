using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Gun : MonoBehaviour
{
    // references
    [SerializeField] Transform gunBarrelEnd;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Animator anim;

    [SerializeField] PlayerHUD HUD;
    [SerializeField] ScreenShake shake;

    // stats
    [SerializeField] int maxAmmo;
    [SerializeField] float timeBetweenShots = 0.1f;

    public int ammoSent;

    // private variables
    int ammo;
    float elapsed = 0;

    public UnityEvent<int> OnAmmoChanged;

    // Start is called before the first frame update
    void Start()
    {
        ammo = maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        elapsed += Time.deltaTime;
    }

    public bool AttemptFire()
    {
        if (ammo <= 0)
        {
            return false;
        }

        if(elapsed < timeBetweenShots)
        {
            return false;
        }

        Debug.Log("Bang");
        Instantiate(bulletPrefab, gunBarrelEnd.transform.position, gunBarrelEnd.rotation);
        anim.SetTrigger("shoot");
        timeBetweenShots = 0;
        ammo -= 1;
        HUD.checkAmmo(ammo);
        shake.Recoil.Invoke();
        return true;
    }

    public void AddAmmo(int amount)
    {
        ammo += amount;
        HUD.checkAmmo(ammo);
    }

    /*public void checkAmmo(int amount)
    {
        OnAmmoChanged?.Invoke(ammo);
        ammoSent = amount;
    }*/
}
