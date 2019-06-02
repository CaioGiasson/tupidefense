using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indio : Personagem {

	Transform proximoPonto;
	int qualPonto = 0;

	void Start () {
		proximoPonto = CaminhoIndios.pontos[0];
	}

	private void Update() {
		if ( !atacando ) {
			Vector3 dir = proximoPonto.position - transform.position;
			transform.Translate(dir.normalized * ( velocidade * fatorVelocidade) * Time.deltaTime, Space.World);
		}

		if (Vector3.Distance(proximoPonto.position, transform.position) < 0.2f)
			ProximoPonto();


		UpdateVida();
	}

	void ProximoPonto() {
		qualPonto++;
		if (qualPonto >= CaminhoIndios.pontos.Length) {
			Parar();
			return;
		}
		if (CaminhoIndios.pontos[qualPonto]!=null)
			proximoPonto = CaminhoIndios.pontos[qualPonto];
	}

	void Parar() {
	}

	protected void UpdateVida() {
		float sx = (300.0f * vida) / vidaMax;
		barraVida.transform.localScale = new Vector3(sx, 60f);
	}
	//private override  void Atacar(Personagem alvo) {
	//	alvo.ReceberDano(this.ataque);
	//	atacando = true;
	//}

}