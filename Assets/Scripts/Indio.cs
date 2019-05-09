using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indio : Personagem {

	public int maxPosicao = 270, offset = 0, amplitude = 9;
	public GameObject flecha;

	Vector3 p0;
	float dX, dY;

	void Start () {
	}

	void Update () {
		if ( posicao < maxPosicao ) 
			posicao += this.velocidade / 20;
		AtualizaMapa();
	}

	public void SetP0(Vector3 posicao){
		dX = Random.Range(-0.5f, 0.5f);
		dY = Random.Range(-0.3f, 0.3f);
		p0 = new Vector3( posicao.x + dX, posicao.y + dY, posicao.z );
		transform.position = p0;
	}

	void AtualizaMapa(){
		float x = p0.x + posicao * amplitude / maxPosicao;
		float dT = Mathf.Sin( Mathf.Deg2Rad * (posicao + offset) );
		float y = p0.y - dT * amplitude/2;
		float z = this.gameObject.transform.position.z;

		this.gameObject.transform.position = new Vector3(x, y, z);
	}

	//private override  void Atacar(Personagem alvo) {
	//	alvo.ReceberDano(this.ataque);
	//	atacando = true;
	//}

}
