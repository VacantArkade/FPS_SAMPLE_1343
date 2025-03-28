using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class PlayerHUD : MonoBehaviour
{
    [SerializeField] Image healthBar;
    [SerializeField] TMP_Text currentAmmoText;
    [SerializeField] TMP_Text maxAmmoText;

    FPSController player;

    int maxAmmo = 10;
    int ammo = 10;

    public UnityEvent<int> OnAmmoChanged;



    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<FPSController>();
    }

    private void Update()
    {
        currentAmmoText.text = ammo.ToString();
        maxAmmoText.text = maxAmmo.ToString();
    }
    public void checkAmmo(int amount)
    {
        OnAmmoChanged?.Invoke(ammo);
        ammo = amount;
    }
}
