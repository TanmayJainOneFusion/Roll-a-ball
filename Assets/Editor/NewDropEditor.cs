using UnityEditor;
using UnityEngine;
 
[CustomEditor(typeof(NewDrop))]
public class NewDropEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
 
        NewDrop dropScript = (NewDrop)target;

        if (dropScript == null)
        {
            EditorGUILayout.LabelField("Select a GameObject with NewDrop script attached.");
            return;
        }
 
        GUILayout.Space(10);
 
        EditorGUILayout.LabelField("Color Options", EditorStyles.boldLabel);
 
        // Dropdown for selecting color
        int selectedColorIndex = EditorGUILayout.Popup("Selected Color", dropScript.GetCurrentColorIndex(), dropScript.GetColorOptions());
 
        // Color field for changing color in the Inspector
        dropScript.SetSelectedColorIndex(selectedColorIndex);
        dropScript.SetSelectedColor(EditorGUILayout.ColorField("Custom Color", dropScript.GetSelectedColor()));
 
        if (GUILayout.Button("Apply Color"))
        {
            dropScript.ChangetheColor(dropScript.GetSelectedColor());
        }
 
        if (GUILayout.Button("Reset Color"))
        {
            dropScript.ResetColorToOriginal();
        }
    }
}