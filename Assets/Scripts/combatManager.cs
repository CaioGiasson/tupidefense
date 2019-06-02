using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combatManager : MonoBehaviour {

	public static combatManager manager;
	public float attackCooldown = 1.0f;

	ArrayList indios = new ArrayList();
	ArrayList portugueses = new ArrayList();

	void Awake() {
		manager = this;
	}
	void Start() {
		StartCoroutine(CheckAttacks());
	}

	IEnumerator CheckAttacks() {
		yield return new WaitForSeconds(attackCooldown);

		// ATAQUES DOS INDIOS
		for (int a = 0; a < indios.Count; a++) {
			Indio i = (Indio)indios[a];

			for (int b = 0; b < portugueses.Count; b++) {
				Explorador e = (Explorador)portugueses[b];
				if (i != null && e != null)
					if (i.PodeAtacar(e)) 
						i.Atacar(e);
			}
		}

		yield return new WaitForSeconds(0.05f);

		// ATAQUES DOS PORTUGUESES
		for (int b = 0; b < portugueses.Count; b++) {
			Explorador e = (Explorador)portugueses[b];

			for (int a = 0; a < indios.Count; a++) {
				Indio i = (Indio)indios[a];
				if (i != null && e != null)
					if (e.PodeAtacar(i))
						e.Atacar(i);
			}
		}

		yield return new WaitForSeconds(0.1f);
		StartCoroutine(CheckAttacks());
	}

	public void AddIndio(Indio i) {
		indios.Add(i);
	}

	public void AddPortugues(Explorador e) {
		portugueses.Add(e);
	}

	public void Kill(Personagem x) {
		for (int a = 0; a < indios.Count; a++) {
			Personagem i2 = (Personagem)indios[a];

			if (x == i2) {
				indios.Remove(i2);
				Destroy(x.gameObject);
				ScoreManager.manager.RemoverPopulacao(10);
			}
		}
		for (int a = 0; a < indios.Count; a++) {
			Personagem e2 = (Personagem)portugueses[a];

			if (x == e2) {
				portugueses.Remove(e2);
				Destroy(x.gameObject);
			}
		}

	}

}