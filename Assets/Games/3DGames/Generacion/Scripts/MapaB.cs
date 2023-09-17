using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapaB : MonoBehaviour
{
    public GameObject casilla;
    public int widht, height;
    public GameObject[][] map;
    public int Nbombas;
    public static MapaB mp;
    public int bombasMarcadas;
    [SerializeField] GameObject Win;
    [SerializeField] GameObject Lose;

    private void Awake()
    {
        StartGame();
    }

    private void Update()
    {
        if (bombasMarcadas == Nbombas)
        {
            Win.SetActive(true);
        }

        if (PieceB.pc.derrota == true)
        {
            Lose.SetActive(true);
        }
    }

    public void NewGame()
    {
        SceneManager.LoadScene(0);
    }

    public void StartGame()
    {
        bombasMarcadas = 0;
        mp = this;
        map = new GameObject[widht][];

        for (int i = 0; i < map.Length; i++)
        {
            map[i] = new GameObject[height];
        }

        for (int i = 0; i < widht; i++)
        {
            for (int j = 0; j < height; j++)
            {
                map[i][j] = Instantiate(casilla, new Vector2(i, j), Quaternion.identity);
                map[i][j].GetComponent<PieceB>().x = i;
                map[i][j].GetComponent<PieceB>().x = j;
            }
        }

        for (int i = 0; i < Nbombas; i++)
        {
            int x = Random.Range(0, widht);
            int y = Random.Range(0, height);
            if (map[x][y].GetComponent<PieceB>().boom)
            {
                i--;
            }
            else map[x][y].GetComponent<PieceB>().boom = true;              
        }

        Camera.main.transform.position = new Vector3((float)widht/2 - 0.5f, (float)height /2 - 0.5f, -10);
    }

    public int GetBombsArround(int x, int y)
    {
        int cont = 0;
        if (x > 0 && y < height - 1 && map[x - 1][y + 1].GetComponent<PieceB>().boom)
            cont++;
        if (y < height - 1 && map[x][y + 1].GetComponent<PieceB>().boom)
            cont++;
        if (x < widht - 1 && y < height - 1 && map[x + 1][y + 1].GetComponent<PieceB>().boom)
            cont++;
        if (x > 0 && map[x - 1][y].GetComponent<PieceB>().boom)
            cont++;
        if (x < widht - 1 && map[x + 1][y].GetComponent<PieceB>().boom)
            cont++;
        if (x > 0 && y > 0 && map[x - 1][y - 1].GetComponent<PieceB>().boom)
            cont++;
        if (y > 0 && map[x][y - 1].GetComponent<PieceB>().boom)
            cont++;
        if (x < widht - 1 && y > 0 && map[x + 1][y - 1].GetComponent<PieceB>().boom)
            cont++;

        return cont;
    }
}
