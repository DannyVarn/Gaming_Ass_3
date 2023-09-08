using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hp_Bar : MonoBehaviour
{
    [SerializeField] private Slider slider;




    public void UpdateHPBar(float hp,float maxhp)
    {
        slider.value = hp/maxhp;
    }
}
