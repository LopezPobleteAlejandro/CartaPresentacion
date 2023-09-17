using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MuevePlayer : MonoBehaviour {

    private Vector3 dirMov = Vector3.right; 


    public string dir = "R";

	public bool tecladoActivo = true;

	private int nGoals = 2;
	public int goalsOk = 0;
	public int nMoves = 0;


	// Use this for initialization
	void Start ()
	{
		

	}
	
	// Update is called once per frame
	void Update ()
	{
		//Exito
		if (goalsOk == nGoals)
		{
			Debug.Log("¡¡CONSEGUIDO!! - Nº total de movimientos: " + nMoves);
			tecladoActivo = false;
		}

		//Reset
		if (Input.GetKeyUp(KeyCode.Space)) SceneManager.LoadScene(0);
		
		if (tecladoActivo) { 

			if (Input.GetKeyDown(KeyCode.RightArrow))
			{
				if (dir != "R") rotarDir("R");
				else tirarRayo(Vector3.right);
			}
			if (Input.GetKeyDown(KeyCode.LeftArrow))
			{
				if (dir != "L") rotarDir("L");
				else tirarRayo(Vector3.left);
			}
			if (Input.GetKeyDown(KeyCode.UpArrow))
			{
				if (dir != "U") rotarDir("U");
				else tirarRayo(Vector3.up);
			}
			if (Input.GetKeyDown(KeyCode.DownArrow))
			{
				if (dir != "D") rotarDir("D");
				else tirarRayo(Vector3.down);
			}

		}//End if moverse

	}
    //-------------------------------------------------------------
    void rotarDir(string d)
    {

		Vector3 auxRot = Vector3.zero;
		switch (d)
		{
			case "R":
			default:
				this.transform.rotation = Quaternion.Euler(auxRot);
				dir = d;
				dirMov = Vector3.right;
				break;
			case "L":
				auxRot.z = 180;
				this.transform.rotation = Quaternion.Euler(auxRot);
				dir = d;
				dirMov = Vector3.left;
				break;
			case "D":
				auxRot.z = 270;
				this.transform.rotation = Quaternion.Euler(auxRot);
				dir = d;
				dirMov = Vector3.down;
				break;
			case "U":
				auxRot.z = 90;
				this.transform.rotation = Quaternion.Euler(auxRot);
				dir = d;
				dirMov = Vector3.up;
				break;
		}
    }
    //-------------------------------------------------------------
    void tirarRayo(Vector3 dv3)
    {
		RaycastHit hit;
		if (Physics.Raycast(transform.position, dv3, out hit, 1))
		{
			if (hit.transform.tag == "Hielo")
			{
				hit.transform.GetComponent<MueveHielo>().checkSiPuedoMover(dv3);
			}
		}
		else
		{
			tecladoActivo = false;
			StartCoroutine(moverse());
		}
    }
	//-------------------------------------------------------------
	IEnumerator moverse()
	{
		
		Vector3 dest = this.transform.position + dirMov;

		while (dest != this.transform.position)
		{
			this.transform.position = Vector3.MoveTowards(this.transform.position,
															dest, 4 * Time.deltaTime);
			yield return new WaitForEndOfFrame();
		}
		nMoves++;
		tecladoActivo = true;
		

	}
	//-------------------------------------------------------------
}
