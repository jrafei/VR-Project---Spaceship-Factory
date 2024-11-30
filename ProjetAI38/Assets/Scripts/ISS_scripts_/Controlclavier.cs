/*Concu pour les entrés clavier
Le script Controlclavier permet de contrôler un objet dans Unity à l'aide des entrées clavier
(flèches directionnelles ou touches configurées pour les axes Horizontal et Vertical).
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlclavier : MonoBehaviour {
	
	void Update()
	{
		var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
		var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

		transform.Rotate(0, x, 0);
		transform.Translate(0, 0, z);
	}
}