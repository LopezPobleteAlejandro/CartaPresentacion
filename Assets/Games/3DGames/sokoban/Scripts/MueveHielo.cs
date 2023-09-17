using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MueveHielo : MonoBehaviour {

	public LayerMask Mask;

	private Vector3 dirEmp = Vector3.zero;
	private MuevePlayer mp;
	
	// Use this for initialization
	void Start () {
		mp = GameObject.Find("Jugador").GetComponent<MuevePlayer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	//----------------------------------------------
	public void checkSiPuedoMover(Vector3 dir)
	{

		dirEmp = dir; //Dejar para la recursión
		RaycastHit hit;
		if (Physics.Raycast(transform.position, dirEmp, out hit, 1, Mask))
		{
			mp.tecladoActivo = true;
		}
		else
		{
			StartCoroutine(moverse());
		}

	}
	//----------------------------------------------
	IEnumerator moverse()
	{
		Vector3 dest = transform.position + dirEmp;

		while (dest != transform.position)
		{
			transform.position = Vector3.MoveTowards(transform.position, dest, 4 * Time.deltaTime);
			yield return new WaitForEndOfFrame();
		}
		mp.nMoves++;
		checkSiPuedoMover(dirEmp);
	}
	//----------------------------------------------

}
