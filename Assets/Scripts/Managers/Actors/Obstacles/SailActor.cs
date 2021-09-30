using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SailActor : MonoBehaviour
{
    [SerializeField] float rotateSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.GetChild(0).Rotate(new Vector3(0f, 1f, 0f), -rotateSpeed * Time.deltaTime);
    }
}
