using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceB : MonoBehaviour
{
    public int x, y;
    public bool boom;
    public Sprite SpInicio, SpPulsado, Sp1, Sp2, Sp3, Sp4, Sp5, Sp6, Sp7, Sp8, SpBomba, SpBandera;
    bool marcado = false;
    public bool derrota = false;
    public static PieceB pc;


    private void Awake()
    {
       marcado = false;
       derrota = false;
    }
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && marcado == false && derrota == false)
        {
            if (boom)
            {
                GetComponent<SpriteRenderer>().sprite = SpBomba;
                derrota = true;
            }
            else
            {            
                if (MapaB.mp.GetBombsArround(x, y) == 0)
                  GetComponent<SpriteRenderer>().sprite = SpPulsado;
                else if (MapaB.mp.GetBombsArround(x, y) == 1)
                  GetComponent<SpriteRenderer>().sprite = Sp1;
                else if (MapaB.mp.GetBombsArround(x, y) == 2)
                   GetComponent<SpriteRenderer>().sprite = Sp2;
                else if (MapaB.mp.GetBombsArround(x, y) == 3)
                   GetComponent<SpriteRenderer>().sprite = Sp3;
                else if (MapaB.mp.GetBombsArround(x, y) == 4)
                   GetComponent<SpriteRenderer>().sprite = Sp4;
                else if (MapaB.mp.GetBombsArround(x, y) == 5)
                   GetComponent<SpriteRenderer>().sprite = Sp5;
                else if (MapaB.mp.GetBombsArround(x, y) == 6)
                   GetComponent<SpriteRenderer>().sprite = Sp6;
                else if (MapaB.mp.GetBombsArround(x, y) == 7)
                   GetComponent<SpriteRenderer>().sprite = Sp7;
                else if (MapaB.mp.GetBombsArround(x, y) == 8)
                   GetComponent<SpriteRenderer>().sprite = Sp8;
                
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (marcado == false)
            {
                GetComponent<SpriteRenderer>().sprite = SpBandera;
                marcado = true;

                if (boom == true)
                {
                    MapaB.mp.bombasMarcadas++;
                }
                return;
            }

            if (marcado == true)
            {
                GetComponent<SpriteRenderer>().sprite = SpInicio;
                marcado = false;
            }
        }
    }
}
