using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Generator : MonoBehaviour
{
    public int xMax, zMax;
    public GameObject pieceM1, pieceM2;
    public GameObject[,] map1, map2;
    public int limit;
    public static Generator gen;
    public bool puerta;

    void Start()
    {
        gen = this;
        map1 = new GameObject[xMax, zMax];
        map2 = new GameObject[xMax, zMax];

        GenerateFirstFloor();
        GenerateFirstFloor2();

        StartCoroutine(ResetMaps());
        //StartCoroutine(GenMapMedium(0, 0));
    }

    void Update()
    {
        
    }

    IEnumerator ResetMaps()
    {
        yield return new WaitForSeconds(5f);

        if (puerta == false)
        {
            SceneManager.LoadScene(2);
        }
    }

    public void GenerateFirstFloor()
    {
        Piece newPiece = Instantiate(pieceM1, new Vector3((xMax / 2) * 5, 0, (zMax / 2) * 5),Quaternion.identity).GetComponent<Piece>();
        newPiece.n = true; newPiece.s = true; newPiece.e = true; newPiece.w = true;
        newPiece.x = xMax / 2; newPiece.z = zMax / 2;
        map1[xMax / 2, zMax / 2] = newPiece.gameObject;
    }
    public void GenerateFirstFloor2()
    {
        Piece1 newPiece1 = Instantiate(pieceM2, new Vector3(((xMax * 5) + ((xMax / 2) * 5)), 0, (zMax / 2) * 5), Quaternion.identity).GetComponent<Piece1>();
        newPiece1.n = true; newPiece1.s = true; newPiece1.e = true; newPiece1.w = true;
        newPiece1.x = xMax / 2; newPiece1.z = zMax / 2;
        map2[xMax / 2, zMax / 2] = newPiece1.gameObject;
    }

    //public void GenerateNextPiece(int x, int z)
    //{
    //    if (map[x, z] == null)
    //    {
    //        Piece newPiece = Instantiate(pieceM1, new Vector3(x * 5, 0, z * 5), Quaternion.identity).GetComponent<Piece>();
    //        newPiece.x = x; newPiece.z = z;
    //        map[x, z] = newPiece.gameObject;
    //    }
    //}

    //public IEnumerator GenMapBasic()
    //{
    //    for (int x = 0; x < xMax; x++)
    //    {
    //        for (int z = 0; z < zMax; z++)
    //        {
    //            if (Random.Range(0, 100) < 50)
    //            {
    //                Instantiate(piece, new Vector3(x * 5, 0, z*5), Quaternion.identity);
    //                yield return new WaitForSeconds(0.05f);
    //            }
    //        }
    //    }
    //}

    //public IEnumerator GenMapMedium(int x, int z)
    //{
    //    limit--;
    //    Transform newPiece = Instantiate(piece, new Vector3(x, 0, z), Quaternion.identity).transform;
    //    yield return new WaitForEndOfFrame();
    //    if (limit > 0)
    //    {
    //        bool complete = false;
    //        int cont = 0;

    //        while (!complete && cont < 50)
    //        {
    //            cont++;
    //            int num = Random.Range(0, 100);
    //            if (num < 25 && !Physics.Raycast(newPiece.position, newPiece.forward, 6))
    //            {
    //                StartCoroutine(GenMapMedium(x, z + 5));
    //                complete = true;
    //            }
    //            else if (num < 50 && !Physics.Raycast(newPiece.position, newPiece.forward * -1, 6))
    //            {
    //                StartCoroutine(GenMapMedium(x, z - 5));
    //                complete = true;
    //            }
    //            else if (num < 75 && !Physics.Raycast(newPiece.position, newPiece.right, 6))
    //            {
    //                StartCoroutine(GenMapMedium(x + 5, z));
    //                complete = true;   
    //            }
    //            else if (!Physics.Raycast(newPiece.position, newPiece.right * -1, 6))
    //            {
    //                StartCoroutine(GenMapMedium(x - 5, z));
    //                complete = true;
    //            }
    //        }
    //    }
    //}
}