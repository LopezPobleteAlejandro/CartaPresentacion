using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScExplosion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemySc Esc = collision.GetComponent<EnemySc>();

        if (Esc != null)
            Destroy(collision.gameObject);

        StartCoroutine(Vanish());
    }

    IEnumerator Vanish()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
