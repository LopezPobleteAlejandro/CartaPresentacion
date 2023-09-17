using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorCoche : MonoBehaviour
{
    public int vidas;
    public int velocidad;
    public GameObject coche;
    private float anguloGiro = 45.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(Input.GetAxis("Horizontal") * velocidad * Time.deltaTime, 0, 0));
        coche.transform.rotation = Quaternion.Euler(0, 0, Input.GetAxis("Horizontal") * -anguloGiro);
    }
}
