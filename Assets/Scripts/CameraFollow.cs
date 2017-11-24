using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public Transform target;

    public LevelGenerator levelGenerator;
    private float minY = 0;

    public float dampTime = 0.15f;
    private Camera camera;
    private Vector3 velocity = Vector3.zero;

    void Start()
    {
        camera = GetComponent<Camera>();
        minY = levelGenerator.getMinY() - 0.75f;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y >= minY)
        {
            Vector3 point = camera.WorldToViewportPoint(target.position);
            Vector3 delta = target.position - camera.ViewportToWorldPoint(new Vector3(0.5f, 0.7f, point.z)); //(new Vector3(0.5, 0.5, point.z));
            Vector3 destination = transform.position + delta;
            destination = new Vector3(transform.position.x, destination.y, destination.z);
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        }
    }
}
