using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSc : MonoBehaviour
{
    public GameObject player;

    void Update()
    {
        if (player == null)
            return;

        Vector3 position = transform.position;
        position.x = player.transform.position.x + 1;
        position.y = player.transform.position.y;
        transform.position = position;
    }
}
