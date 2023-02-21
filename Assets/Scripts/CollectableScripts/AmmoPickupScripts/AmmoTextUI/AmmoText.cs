using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AmmoText : MonoBehaviour
{
    public Gun gun;
    public TextMeshProUGUI ammoText;

    private void Start()
    {
        UpdateAmmoText();
    }
    private void Update()
    {
        UpdateAmmoText();
    }
    void UpdateAmmoText()
    {
        ammoText.SetText($"{gun.currentAmmo} / {gun.maxAmmo}");
    }
}
