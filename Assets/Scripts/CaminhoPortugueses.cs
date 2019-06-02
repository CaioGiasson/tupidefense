using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaminhoPortugueses : MonoBehaviour {

	public static Transform[] pontos;

	private void Awake() {
		pontos = new Transform[transform.childCount];
		for (int i = 0; i < transform.childCount; i++ ){
			pontos[i] = transform.GetChild(i);
		}
	}

}