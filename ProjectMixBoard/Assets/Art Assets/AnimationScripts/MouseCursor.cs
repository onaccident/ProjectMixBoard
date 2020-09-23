﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursor : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        Cursor.visible = false;
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 cursorPose = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = cursorPose;
    }
}
