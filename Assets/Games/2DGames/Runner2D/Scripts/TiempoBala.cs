using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiempoBala : MonoBehaviour
{
    IEnumerator actividad()
    {
        Time.timeScale = 0.6f;

        yield return new WaitForSeconds(2);

        Time.timeScale = 1;

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<SpriteRenderer>().enabled = false;

        StartCoroutine(actividad());
    }
}

// Este script hace qeu al cojer el item, el tiempo se relentize
// de manera abrupta durante diez segundos, sin afectar al tiempo de juego.