using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explorador : Personagem {

	Transform proximoPonto;
	int qualPonto = 0;

	void Start() {
		proximoPonto = CaminhoPortugueses.pontos[0];
	}

	void Update() {
		if ( !atacando ) {
			Vector3 dir = proximoPonto.position - transform.position;
			transform.Translate( dir.normalized * ( velocidade * fatorVelocidade ) * Time.deltaTime, Space.World );
		}

		if (Vector3.Distance(proximoPonto.position, transform.position) < 0.2f) 
			ProximoPonto();

		UpdateVida();
	}

	void ProximoPonto(){
		qualPonto++;
		if ( qualPonto>= CaminhoPortugueses.pontos.Length ) {
			AtingirAldeia();
			return;
		} 

		if (CaminhoPortugueses.pontos[qualPonto]!=null ) 
			proximoPonto = CaminhoPortugueses.pontos[qualPonto];

	}

	void AtingirAldeia(){
		ScoreManager.manager.RemoverPopulacao(100);
		Destroy(gameObject);
	}


	protected void UpdateVida() {
		float sx = (160.0f * vida) / vidaMax;
		barraVida.transform.localScale = new Vector3(sx, 35f);
	}
}