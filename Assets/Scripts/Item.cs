using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string name = "Ziege";
    public string description = "Eine Ziege";
    public string property;
    public float value;
    public Sprite popUp;
    public bool isPickup = false;

    // This is for the tooltip
    private GUIStyle guiStyleFore;
    private GUIStyle guiStyleBack;
    private bool visible = false;


    public void Start()
    {
        guiStyleFore = new GUIStyle();
        guiStyleFore.normal.textColor = Color.white;
        guiStyleFore.alignment = TextAnchor.UpperCenter;
        guiStyleFore.fontSize = 25;

        guiStyleBack = new GUIStyle();
        guiStyleBack.normal.textColor = Color.white;
        guiStyleBack.alignment = TextAnchor.UpperCenter;
        guiStyleBack.fontSize = 25;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        visible = true;
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        visible = false;
    }

    public void Update()
    {
        if (isPickup)
        {
            //move to player
            transform.position = Vector3.MoveTowards(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position, 0.05f);
        }
    }

    private void OnGUI()
    {
        if (visible && !isPickup)
        {
            Vector2 pos = Camera.main.WorldToScreenPoint(transform.position);
            GUI.Label(new Rect(pos.x - 50, Screen.height - pos.y - 50, 100, 100), name, guiStyleBack);
            GUI.Label(new Rect(pos.x - 50, Screen.height - pos.y - 50, 100, 100), name, guiStyleFore);
        }
    }
}
