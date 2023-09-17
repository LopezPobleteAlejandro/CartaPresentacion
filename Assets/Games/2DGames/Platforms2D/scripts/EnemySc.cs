using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySc : MonoBehaviour
{
    public GameObject player;
    public GameObject balaPf;

    private SpriteRenderer sp;

    private float lastSh;
    private int vida = 3;

    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
            return;

        if (player.GetComponent<PlayerMv>().win == true)
            return;

        Vector3 direction = player.transform.position - transform.position;
        if (direction.x >= 0.0f)
            sp.flipX = false;
        else sp.flipX = true;

        float distance = Mathf.Abs(player.transform.position.x - transform.position.x);
        if (distance <= 1f && Time.time > lastSh + 1f)
        {
            Shoot(direction);
            lastSh = Time.time;
        }
    }

    private void Shoot(Vector3 dir)
    {
        Vector3 shDir;
        if (dir.x < 0)
            shDir = Vector2.left;
        else
            shDir = Vector2.right;

        GameObject bala = Instantiate(balaPf, transform.position + shDir * 0.25f, Quaternion.identity);
        bala.GetComponent<ScBala>().SetDirection(shDir);
    }
    public void Hit()
    {
        vida--;
        if(vida == 0 ) 
            Destroy(gameObject);
    }
}