using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public Transform target;
    Vector3 offset;

    void FixedUpdate() {
        Vector3 tempPosition = transform.position;
        tempPosition.x = target.position.x;
        tempPosition.y = target.position.y;
        transform.position = tempPosition;
    }
}
