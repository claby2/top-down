using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairBehavior : MonoBehaviour {
    public Camera MainCamera;

    void Start() {
        Cursor.visible = false;
    }

    void FixedUpdate() {
        Vector2 cursorPos = MainCamera.ScreenToWorldPoint(Input.mousePosition);
        transform.position = cursorPos;
    }
}
