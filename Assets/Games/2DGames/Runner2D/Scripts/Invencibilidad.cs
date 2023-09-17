using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invencibilidad : MonoBehaviour
{
    public GameObject coche;

    IEnumerator actividad()
    {
        coche.GetComponent<Collider2D>().isTrigger = true;

        yield return new WaitForSeconds(3);

        coche.GetComponent<Collider2D>().isTrigger = false;

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<SpriteRenderer>().enabled = false;
        StartCoroutine(actividad());
    }
}
