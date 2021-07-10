using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoBar : MonoBehaviour
{
    public Slider Slider;

    public void SetMaxAmmo(int ammo)
    {
        Slider.maxValue = ammo;
        Slider.value = ammo;
    }
    public void SetAmmo(int ammo)
    {
        Slider.value = ammo;
    }
}
