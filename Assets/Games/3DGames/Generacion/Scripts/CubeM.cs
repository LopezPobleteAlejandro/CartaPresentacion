using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeM : MonoBehaviour
{
    void Start()
    {
        if (Physics.Raycast(transform.position, transform.up))
        {
            Destroy(gameObject);
        }
    }

}
