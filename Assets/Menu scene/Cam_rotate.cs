using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam_rotate : MonoBehaviour
{
    public float _speed;

    void FixedUpdate()
    {
        transform.Rotate(0, _speed * Time.deltaTime, 0);
    }
}
