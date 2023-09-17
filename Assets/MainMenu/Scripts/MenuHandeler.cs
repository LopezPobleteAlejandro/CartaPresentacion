using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuHandeler : MonoBehaviour
{
    public void CambiarPantalla(Button button)
    {
        if (button.name.Equals("Plataformas"))
        {
            SceneManager.LoadScene("TittlePlataformas");
        }
        else if (button.name.Equals("Runner"))
        {
            SceneManager.LoadScene("InicioCoche");
        }
        else if (button.name.Equals("Sokoban"))
        {
            SceneManager.LoadScene("Sokoban");
        }
        else if (button.name.Equals("Generator"))
        {
            SceneManager.LoadScene("MenuGenerator");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            print("Al Menu");
            SceneManager.LoadScene("MainMenu");
        }
    }
}
