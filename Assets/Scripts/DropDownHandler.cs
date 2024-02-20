using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DropDownHandler : MonoBehaviour
{
   
    private TMP_Dropdown dropdown;

    private void Awake() => dropdown = GetComponent<TMP_Dropdown>();

    public void LoadFruitOptions()
    {
        dropdown.ClearOptions();
        var option1 = new TMP_Dropdown.OptionData("Apple");
        dropdown.options.Add(option1);
        var option2 = new TMP_Dropdown.OptionData("Mango");
        dropdown.options.Add(option2);
         var option3 = new TMP_Dropdown.OptionData("Banana");
        dropdown.options.Add(option3);
        dropdown.RefreshShownValue();
    }

    public void LoadDrinkOptions()
    {
        dropdown.ClearOptions();
        var option1 = new TMP_Dropdown.OptionData("ColdDrink");
        dropdown.options.Add(option1);
        var option2 = new TMP_Dropdown.OptionData("MilkShake");
        dropdown.options.Add(option2);
        dropdown.RefreshShownValue();
    }

}
