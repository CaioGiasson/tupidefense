using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desembarque : MonoBehaviour {

	public Explorador unidade;

	int coolDown = 0;
	public int maxCoolDown = 6;

	private void Start() {
		StartCoroutine(BeginCooldown());
	}

	public void DoRecrutar() {
		Explorador novo = Instantiate(unidade);
		novo.transform.position = transform.position;
		combatManager.manager.AddPortugues(novo);
		coolDown = maxCoolDown;
	}

	IEnumerator BeginCooldown() {
		yield return new WaitForSeconds(1);
		coolDown = Mathf.Max(0, coolDown - 1);
		if (coolDown == 0) DoRecrutar();
		StartCoroutine(BeginCooldown());
	}

}