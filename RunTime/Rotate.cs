using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField]
    Transform objectToRotate;
    [SerializeField]
    Vector3 rotateAxis = Vector3.forward;
    [SerializeField, Range(0,360f)]
    float speed;

    private void Update()
    {
        objectToRotate.transform.Rotate(rotateAxis, speed * Time.deltaTime);
    }
}
