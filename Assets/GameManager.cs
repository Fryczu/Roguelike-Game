using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Weapon weapon;
    public TextMeshProUGUI text;

    void Start()
    {
        UpdateAmmoText();       
    }

    private void Update() 
    {
        UpdateAmmoText();    
    }

    private void UpdateAmmoText()
    {
        text.text = $"{weapon.currentClip} / {weapon.maxClipSize} | {weapon.currentAmmo} / {weapon.maxAmmoSize}";
    }
}
