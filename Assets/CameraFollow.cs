using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform target;

	void LateUpdate () {
        Vector3 newPos = new Vector3(0f, target.position.y, -10f);
        transform.position = newPos;
	}
}
