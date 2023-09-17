using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMv : MonoBehaviour
{
    public float JumpF, speed;
    public GameObject balaPf;
    public GameObject GranadaPf;
    public AudioClip[] audioAr;
    public bool win;

    private Rigidbody2D Rigidbody2D;
    private Animator Anim;
    private SpriteRenderer sp;
    private AudioSource auS;

    private float horizontal;
    private bool suelo;
    private int vida = 5;
    private int Granadas = 3;

    void Start()
    {
        auS = GetComponent<AudioSource>();
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
        win = false;
    }

    void Update()
    {
        if (win == true)
            return;

        horizontal = Input.GetAxisRaw("Horizontal");

        if (horizontal < 0)
            sp.flipX = true;
        else if (horizontal > 0)    
            sp.flipX = false;
        else sp.flipX = false;

        Anim.SetBool("Run", horizontal != 0.0f);

        Debug.DrawRay(transform.position, Vector3.down * 0.1f, Color.red);
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.2f))
            suelo = true;
        else suelo = false;

        if (Input.GetKeyDown(KeyCode.Space) && suelo == true)
            Jump();

        if (Input.GetKeyDown(KeyCode.Mouse0))
            Shoot();

        if (Input.GetKeyDown(KeyCode.Q) && Granadas !=0)
            LanzarGranada();
    }

    private void LanzarGranada()
    {
        Instantiate(GranadaPf, transform.position + new Vector3(0.1f, 0.1f, 0), Quaternion.identity);
        Granadas--;

        if (Granadas == 0)
            Debug.Log("Sin granadas");
    }

    void Shoot()
    {
        Vector3 direction;
        if(horizontal < 0)
            direction = Vector2.left;
        else
            direction = Vector2.right;

        GameObject bala = Instantiate(balaPf, transform.position + direction * 0.15f, Quaternion.identity);
        bala.GetComponent<ScBala>().SetDirection(direction);
    }

    void Jump()
    {
        Debug.Log("Salto");
        Rigidbody2D.AddForce(Vector2.up * JumpF);
        auS.PlayOneShot(audioAr[0]);
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(horizontal * speed, Rigidbody2D.velocity.y);
    }

    public void Hit()
    {
        if (vida == 0)
            return;

        vida--;
        if (vida == 0)
        {
            Anim.SetBool("Muerto", true);
            StartCoroutine(muelto());
        }
        auS.PlayOneShot(audioAr[1]);
    }

    private IEnumerator muelto()
    { 
        win = true; 
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
