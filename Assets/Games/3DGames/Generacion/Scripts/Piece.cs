using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    public int x, z, chance;
    public bool n, s, e, w;

    void Start()
    {
        int num = Random.Range(0, 100);
        if (num < chance && z < Generator.gen.zMax - 1)
            n = true;
        num = Random.Range(0, 100);
        if (num < chance && z > 0)
            s = true;
        num = Random.Range(0, 100);
        if (num < chance && x < Generator.gen.xMax - 1)
            e = true;
        num = Random.Range(0, 100);
        if (num < chance && x > 0)
            w = true;
        GenerateNeightbours();

        if (z < Generator.gen.zMax - 1 && Generator.gen.map1[x, z + 1] != null)
            n = true;
        if (z > 0 && Generator.gen.map1[x, z - 1] != null)
            s = true;
        if (x < Generator.gen.xMax - 1 && Generator.gen.map1[x + 1, z] != null)
            e = true;
        if (x > 0 && Generator.gen.map1[x - 1 , z] != null)
            w = true;

        CheckWalls();
    }

    public void GenerateNeightbours()
    {
        if (n)
            GenerateNextPiece(x, z + 1);
        if (s)
            GenerateNextPiece(x, z - 1);
        if (e)
            GenerateNextPiece(x + 1, z);
        if (w)
            GenerateNextPiece(x - 1, z);
    }

    public void CheckWalls()
    {
        if (w)
            transform.GetChild(3).gameObject.SetActive(false);
        if (e)
            transform.GetChild(2).gameObject.SetActive(false);
        else if (x == (Generator.gen.xMax - 1) && Generator.gen.map1[x, z] != null && Generator.gen.map2[0, z])
        {
            transform.GetChild(2).gameObject.SetActive(false);
            Generator.gen.map2[0, z].transform.GetChild(3).gameObject.SetActive(false);
            Generator.gen.puerta= true;
        }
        if (s)
            transform.GetChild(1).gameObject.SetActive(false);
        if (n)
            transform.GetChild(0).gameObject.SetActive(false);
    }

    public void GenerateNextPiece(int x, int z)
    {
        if (Generator.gen.map1[x, z] == null)
        {
            Piece newPiece = Instantiate(Generator.gen.pieceM1, new Vector3(x * 5, 0, z * 5), Quaternion.identity).GetComponent<Piece>();
            newPiece.x = x; newPiece.z = z;
            Generator.gen.map1[x, z] = newPiece.gameObject;
        }
    }
    //public void CheckWalls()
    //{
    //    if (Physics.Raycast(transform.position, transform.right * -1, 6))
    //        Destroy(transform.GetChild(3).gameObject);
    //    if (Physics.Raycast(transform.position, transform.right, 6))
    //        Destroy(transform.GetChild(2).gameObject);
    //    if (Physics.Raycast(transform.position, transform.forward * -1, 6))
    //        Destroy(transform.GetChild(1).gameObject);
    //    if (Physics.Raycast(transform.position, transform.forward, 6))
    //        Destroy(transform.GetChild(0).gameObject);
    //}
}