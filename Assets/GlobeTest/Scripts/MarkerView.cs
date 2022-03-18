using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MarkerView : MonoBehaviour
{
    public LineRenderer line;
    public TMP_Text label;

    private void Update()
    {
        label.transform.parent.transform.gameObject.transform.LookAt(Camera.main.transform);
    }
    public void SetLabel(string labelText)
    {
        GetComponentInChildren<Canvas>().worldCamera = Camera.main;
        label.text = labelText;
    }

    public void OnButtonClick()
    {
        /* 
         * HOW TO CREATE 3D BUTTON
         * Add a button component to the background
         * Make sure the TextMesh does not have Raycast Target checked in Extra Settings
         * Make sure the EventCamera for the Canvas is being set (see below link for better optimization)
         * Uncheck the Ignore Reversed Graphics setting in the Graphic Raycaster for the Canvas
         * LINK: https://unity.com/how-to/unity-ui-optimization-tips - how best to optimize multiple canvas
         */
        Debug.Log($"You selected {label.text}!");
    }
}
