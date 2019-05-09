using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desembarque : MonoBehaviour {

	public Explorador unidade;

	int coolDown = 0;

	private void Start() {
		StartCoroutine(BeginCooldown());
	}

	public void DoRecrutar() {
		Explorador novo = Instantiate(unidade);
		novo.SetP0(transform.position);
		combatManager.manager.AddPortugues(novo);
		coolDown = 3;
	}

	IEnumerator BeginCooldown() {
		yield return new WaitForSeconds(1);
		coolDown = Mathf.Max(0, coolDown - 1);
		if (coolDown == 0) DoRecrutar();
		StartCoroutine(BeginCooldown());
	}

}
