using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    public GameObject player;
    public GameObject Canvas;

    private void Start()
    {
        Canvas.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        player.GetComponent<PlayerMv>().win = true;

        Vector3 position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, 10);
        transform.GetChild(0).transform.position = position;
        Canvas.SetActive(true);
    }
}
