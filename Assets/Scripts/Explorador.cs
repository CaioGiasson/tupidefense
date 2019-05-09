using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explorador : Personagem {

	public int maxPosicao = 500, offset = 180, amplitude = 9;
	Vector3 p0;
	float dX, dY;

	void Start() {
	}

	void Update() {
		if (posicao < maxPosicao)
			posicao += velocidade / 20;
		AtualizaMapa();
	}

	public void SetP0(Vector3 posicao) {
		dX = Random.Range(-0.5f, 0.5f);
		dY = Random.Range(-0.3f, 0.3f);
		p0 = new Vector3(posicao.x + dX, posicao.y + dY, posicao.z);
		transform.position = p0;
	}

	void AtualizaMapa() {
		float x=0, dT=0, y=transform.position.y, z= transform.position.z;

		//float x = p0.x + posicao * amplitude / maxPosicao;


		if ( posicao<50 ) {
			x = transform.position.x - velocidade/maxPosicao;
			y = transform.position.y;
		} else if ( posicao < 104 ){
			x = transform.position.x;
			y = transform.position.y + velocidade / maxPosicao;
		} else if ( posicao < 145 ){
			x = transform.position.x - velocidade / maxPosicao;
			y = transform.position.y;
		}
		else if (posicao < 205 ) {
			x = transform.position.x - velocidade / maxPosicao;
			y = transform.position.y - 1.9f * velocidade / maxPosicao;
		}
		else if (posicao < 225) {
			x = transform.position.x - velocidade / maxPosicao;
			y = transform.position.y;
		}
		else if (posicao < 245) {
			x = transform.position.x - velocidade / maxPosicao;
			y = transform.position.y + 2.1f * velocidade / maxPosicao;
		}
		else if (posicao < 268) {
			x = transform.position.x;
			y = transform.position.y + velocidade / maxPosicao;
		} else {
			print("CHEGOU BORA DESCONTAR POPULAÇÃO");
		}

		gameObject.transform.position = new Vector3(x, y, z);

	}

}
