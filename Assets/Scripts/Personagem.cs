using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personagem : MonoBehaviour {

	public int vida, vidaMax, ataque, dano, alcance;
	public float velocidade;
	protected float posicao;

	bool atacando = false;

	void Start() {
		vida = vidaMax;
	}

	public void Atacar( Personagem alvo ){
		alvo.ReceberDano(this.ataque);
		atacando = true;
	}

	public void ReceberDano( int dano){
		vida = Mathf.Max(0, vida - dano);

		if ( vida==0 ) {
			combatManager.manager.Kill(this);
			Destroy(this.gameObject);
			print("ESSE AQUI MORREU");
		}
	}

	public bool PodeAtacar(Personagem alvo){
		bool retorno = false;

		float dist = Vector3.Distance(alvo.transform.position, transform.position);
		if (dist < alcance) retorno = true;

		atacando = retorno;
		return retorno;
	}

}
