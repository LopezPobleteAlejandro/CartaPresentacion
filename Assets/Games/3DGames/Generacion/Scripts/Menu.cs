using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void AbrirMine()
    {
        SceneManager.LoadScene("Maincra");
    }
    public void AbrirLab()
    {
        SceneManager.LoadScene("Laberinto");
    }
}
