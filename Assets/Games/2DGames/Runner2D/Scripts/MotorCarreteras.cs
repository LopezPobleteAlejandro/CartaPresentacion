using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorCarreteras : MonoBehaviour
{

    public GameObject MainCamara;
    public GameObject[] contenedorCarreteras;
    public int velocidad;

    private int contadorCarreteras;

    // carretera anterior
    public GameObject ultimaCalle;
    public float anteriorPosicion;
    public float siguientePosicion;

    // limite en pantalla
    public int limiteCarrerasEnPantalla;

    // logicas
    public bool inicioJuego;
    public bool terminadoJuego;

    public ControladorCoche contCoche;

    // Start is called before the first frame update
    void Start()
    {
        terminadoJuego = false;
        inicioJuego = false;
        crearCalle();

    }

    // Update is called once per frame
    void Update()
    {
        if (inicioJuego && !terminadoJuego && contCoche.vidas > 0)
        { // si se inicio y no ha terminado se mueve el coche y crea nuevas calles

            if (ultimaCalle.transform.position.y < MainCamara.transform.position.y)
            { // creamos una calle cuando pasamos de la calle anterior
                crearCalle();

                if (this.transform.childCount > limiteCarrerasEnPantalla)
                { // para evitar tener calle ilimitadas borramos la primera de todas
                    Destroy(this.transform.GetChild(0).gameObject);
                }
            }
            moverCoche();
        }

        if (contCoche.vidas == 0)
        {
            terminadoJuego = true;
        }
    }

    public void crearCalle()
    {
        // incrementamos el contador de carreteras
        contadorCarreteras++;

        // creamos una calle nueva aleatoria
        int calleAletoria = Random.Range(0, contenedorCarreteras.Length);
        GameObject calle = Instantiate(contenedorCarreteras[calleAletoria]);
        calle.name = "Calle_" + contadorCarreteras;

        // hacemos hija del motor de carreteras
        calle.transform.parent = this.transform;
        calle.transform.position = new Vector3(0.0f, ultimaCalle.transform.position.y + medirCalle(ultimaCalle) - 0.6f, 0.0f);

        // almacenamos la ultima calle
        ultimaCalle = calle;
    }

    private float medirCalle(GameObject calle)
    {
        float tamanyo = 0.0f;
        foreach (Transform child in calle.transform)
        {
            SpriteRenderer sprite = child.gameObject.GetComponent<SpriteRenderer>();
            if (sprite.name != "Bus" && sprite.name != "PowerUpInvencibilidad" && sprite.name != "TiempoBala")
            {
                tamanyo += sprite.bounds.size.y;
            }

        }

        return tamanyo;
    }
    
    public void moverCoche()
    {
        MainCamara.transform.Translate(Vector3.up * velocidad * Time.deltaTime);
    }
        
 }
