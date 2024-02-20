using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewDrop : MonoBehaviour
{
    public TMP_Text Textbox;
    private  TMP_Dropdown dropdown;

    public Material material;
    private Color originalColor;
    private Color selectedColor;

    public Color[] colors;

    private Dictionary<string, Color> colorOptions = new Dictionary<string, Color>();

    void Start()
    {
        dropdown = transform.GetComponent<TMP_Dropdown>();
        dropdown.options.Clear();

        originalColor = Color.white;

        colorOptions.Add("Choose Color", originalColor);

        // Add colors from the public array
        for (int i = 0; i < colors.Length; i++)
        {
            string colorName = "Color " + i;
            colorOptions.Add(colorName, colors[i]);
        }

        UpdateDropdown();
        DropdownItemSelected(dropdown);

        dropdown.onValueChanged.AddListener(delegate { DropdownItemSelected(dropdown); });
    }

    void UpdateDropdown()
    {
        dropdown.options.Clear(); // Clear existing options before updating

        foreach (var item in colorOptions.Keys)
        {
            dropdown.options.Add(new TMP_Dropdown.OptionData() { text = item });
        }

        dropdown.RefreshShownValue(); // Ensure the correct value is displayed in the dropdown
    }

    void DropdownItemSelected(TMP_Dropdown dropdown)
    {
        int index = dropdown.value;
        string selectedColorName = dropdown.options[index].text;

        if (colorOptions.ContainsKey(selectedColorName))
        {
            Color selectedColor = colorOptions[selectedColorName];
            if (selectedColorName == "Choose Color")
            {
                ResetColorToOriginal();
                Textbox.text = "Choose the Color";
            }
            else
            {
                ChangetheColor(selectedColor);
                Textbox.text = selectedColorName+"-" + ColorUtility.ToHtmlStringRGB(selectedColor);
            }
        }
    }

    public void ChangetheColor(Color newColor)
    {
        material.color = (newColor == Color.white) ? selectedColor : newColor;
    }

    public void ResetColorToOriginal()
    {
        material.color = originalColor;
    }

    public int GetCurrentColorIndex()
    {
        return dropdown.value;
    }

    public string[] GetColorOptions()
    {
        List<string> colorNames = new List<string>(colorOptions.Keys);
        return colorNames.ToArray();
    }

    public void SetSelectedColorIndex(int index)
    {
        dropdown.value = index;
    }

    public void SetSelectedColor(Color color)
    {
        selectedColor = color;

        string selectedColorName = dropdown.options[dropdown.value].text;
        colorOptions[selectedColorName] = selectedColor;

        UpdateDropdown(); // Update dropdown to reflect the changes
    }

    public Color GetSelectedColor()
    {
        string selectedColorName = dropdown.options[dropdown.value].text;
        return colorOptions.ContainsKey(selectedColorName) ? colorOptions[selectedColorName] : Color.white;
    }

}
