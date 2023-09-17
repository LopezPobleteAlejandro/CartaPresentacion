using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;

public class GeneratorM : MonoBehaviour
{
    public GameObject cube;
    public int width, heigth, large;
    public float detail;
    public int seed;
    public List <GameObject> map;

    void Start()
    {
        seed = Random.Range(10000, 90000);
        GenerateMap();
        BorrarPiezas();
    }

    public void GenerateMap()
    {

        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < large; z++)
            {
                heigth = (int)(Mathf.PerlinNoise((x / 2 + seed) / detail, (z / 2 + seed) / detail) * detail);
                for (int y = 0; y < heigth; y++)
                {
                    Instantiate(cube, new Vector3(x, y, z), Quaternion.identity);
                }
            }
        }
    }

    public void BorrarPiezas()
    {
        foreach (GameObject cube in GameObject.FindGameObjectsWithTag("Player"))
        {

            map.Add(cube);
        }

        for (int d = 0; d < 50; d++)
        {
            if (map.Contains(cube))
            {
                map.Remove(cube);
                Destroy(cube);
            }
        }
    }
}