using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Escenas : MonoBehaviour
{

    public GameObject panel1;
    public GameObject panel2;
    public int tiempoTransicion;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void cambiarEscena ()
    {
        panel1.SetActive(false);
        panel2.SetActive(true);
        StartCoroutine(cambioEscena());
        
    }

    IEnumerator cambioEscena()
    {
        yield return new WaitForSeconds(tiempoTransicion);
        SceneManager.LoadScene("JuegoCoche");
    }

}
