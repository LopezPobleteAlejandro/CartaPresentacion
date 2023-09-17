using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bus : MonoBehaviour
{
    public ControladorCoche contCoche;
    AudioSource hit;

    private void Start()
    {
        hit = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        contCoche.vidas--;
        hit.Play();

        StartCoroutine(waitTime());
    }

    IEnumerator waitTime()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }

}
