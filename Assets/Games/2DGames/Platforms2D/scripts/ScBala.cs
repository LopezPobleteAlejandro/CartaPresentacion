using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ScBala : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 Direction;

    public float speed;

    public AudioClip sound;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Camera.main.GetComponent<AudioSource>().PlayOneShot(sound);
    }

    void Update()
    {
        StartCoroutine(AutoDestruccion());
    }

    private void FixedUpdate()
    {
        rb.velocity = Direction * speed;
    }

    public void SetDirection(Vector2 direction)
    {
        Direction = direction;
    }

    IEnumerator AutoDestruccion() 
    { 
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerMv Pmv = collision.GetComponent<PlayerMv>();
        EnemySc Esc = collision.GetComponent<EnemySc>();

        if (Pmv != null)
            Pmv.Hit();

        if (Esc != null)
            Esc.Hit();

        Destroy(gameObject);
    }
}
