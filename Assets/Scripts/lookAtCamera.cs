using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAtCamera : MonoBehaviour
{
    private Transform mainCamera;

    private void Start()
    {
        mainCamera = Camera.main.GetComponent<Transform>();
    }
    private void Update()
    {
        transform.LookAt(mainCamera);

    }
}
