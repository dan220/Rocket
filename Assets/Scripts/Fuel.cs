using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fuel : MonoBehaviour
{
    Text text;
 
    static public int fuel;

    void Start() {
        fuel = 1000;
    }

    void Awake()
    {
        // Load the Arial font from the Unity Resources folder.
        Font arial;
        arial = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");

        // Create Canvas GameObject.
        GameObject canvasGO = new GameObject();
        canvasGO.name = "Canvas";
        canvasGO.AddComponent<Canvas>();
        canvasGO.AddComponent<CanvasScaler>();
        canvasGO.AddComponent<GraphicRaycaster>();

        // Get canvas from the GameObject.
        Canvas canvas;
        canvas = canvasGO.GetComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;

        // Create the Text GameObject.
        GameObject textGO = new GameObject();
        textGO.transform.parent = canvasGO.transform;
        textGO.AddComponent<Text>();

        // Set Text component properties.
        text = textGO.GetComponent<Text>();
        text.font = arial;
        text.fontSize = 24;
        text.alignment = TextAnchor.UpperLeft;

        // Provide Text position and size using RectTransform.
        RectTransform rectTransform;
        rectTransform = text.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(-250, 100, 0);
        //rectTransform.sizeDelta = new Vector2(50, 50);
    }
 
    void Update () 
    {
        text.text = "Fuel " + fuel.ToString();
 
    }
}
