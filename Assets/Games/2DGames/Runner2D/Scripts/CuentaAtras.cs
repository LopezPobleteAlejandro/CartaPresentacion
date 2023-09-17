using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEngine.VFX;

public class CuentaAtras : MonoBehaviour
{

    public Sprite[] sprites;
    public int tiempoTransicion;
    public GameObject coche;
    public GameObject motorCarreteras;

    public MotorCarreteras motor;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(comenzarSecuencia(sprites.Length - 1));       
    }

    // Update is called once per frame
    void Update()
    {
        if (motor.terminadoJuego == true)
        {
            GetComponent<SpriteRenderer>().sprite = sprites[0];
        }
    }

    IEnumerator comenzarSecuencia(int cuentaAtras)
    {
        do {
            cuentaAtras--;
            yield return new WaitForSeconds(tiempoTransicion);

            switch (cuentaAtras)
            {
                case 1: // ponemos el sonido del motor del coche
                    coche.GetComponent<AudioSource>().Play();
                    break;
                case 2: // estamos en el elemento GO
                    this.transform.GetChild(0).GetComponent<AudioSource>().Play();
                    break;
                default: // pitido de cada número
                    this.GetComponent<AudioSource>().Play();
                    break;
            }
            // actualizamos el sprite
            GetComponent<SpriteRenderer>().sprite = sprites[cuentaAtras];
        } while (cuentaAtras > 1);

        // ponemos a true el inicioJuego
        motorCarreteras.GetComponent<MotorCarreteras>().inicioJuego = true;
    }

}
