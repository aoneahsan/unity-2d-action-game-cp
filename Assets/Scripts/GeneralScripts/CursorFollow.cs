using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorFollow : MonoBehaviour
{
    void Awake()
    {
        Cursor.visible = false;
    }

    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.visible = false;
        transform.position = Input.mousePosition;
    }
}
