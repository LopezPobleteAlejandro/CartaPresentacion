using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{ 
    public GameObject player;
    public GameObject Canvas;

    void Update()
    {
        Vector3 position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, 10);

        if(player == null)
        {
            transform.position = position;
            Canvas.SetActive(true);
        }
    }
}
