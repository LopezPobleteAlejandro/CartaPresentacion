using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Cronometro : MonoBehaviour
{

    public float tiempoJuego;
    public float tiempoPartida;
    public float distancia;
    public TextMeshProUGUI textoTiempo;
    public TextMeshProUGUI textoDistancia;
    public TextMeshProUGUI textoVidas;

    public GameObject motorCarreteras;
    private MotorCarreteras motor;

    public ControladorCoche contCoche;

    // Start is called before the first frame update
    void Start()
    {
        distancia = 0.0f;
        tiempoJuego = 0.0f;
        motor = motorCarreteras.GetComponent<MotorCarreteras>();
    }

    // Update is called once per frame
    void Update()
    {
        textoVidas.text = contCoche.vidas.ToString();

        if (motor.inicioJuego && !motor.terminadoJuego && contCoche.vidas > 0)
        {

            if (tiempoJuego < tiempoPartida)
            {

                tiempoJuego += Time.deltaTime;
                if (tiempoJuego < 0.0f)
                {
                    textoTiempo.text = "0.00";
                }
                else
                {
                    int minutos = (int)tiempoJuego / 60;
                    int segundos = (int)tiempoJuego % 60;
                    textoTiempo.text = minutos.ToString() + ":"
                        + segundos.ToString().PadLeft(2, '0') + " Seg";
                }
                distancia += motor.velocidad * Time.deltaTime;
                textoDistancia.text = Math.Round(distancia, 2).ToString().PadLeft(2, '0') + " Mts";
            }
            else
            {
                // hemos sobrepasado el tiempo de partida finaliza el juego
                motor.terminadoJuego = true;
            }    
        }
    }
}
