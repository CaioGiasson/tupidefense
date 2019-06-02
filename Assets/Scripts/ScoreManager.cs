using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public static ScoreManager manager;
	public Text populacaoLabel;

	public int populacaoAtual = 5000;

	void Awake() {
		manager = this;
	}

	public void RemoverPopulacao(int quantos){
		populacaoAtual = Mathf.Max(0, populacaoAtual - quantos);
		UpdateLabel();
	}

	void UpdateLabel(){
		populacaoLabel.text = "População: " + populacaoAtual;
	}

}
