using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personagem : MonoBehaviour {

	public int vida, vidaMax, ataque, dano, alcance;
	public float velocidade, fatorVelocidade = 0.25f;

	public SpriteRenderer barraVida;

	public bool atacando;

	void Start() {
		vida = vidaMax;
	}

	public void Atacar( Personagem alvo ){
		if (alvo == null) return;
		if (alvo.vida < 1) return;

		atacando = true;
		alvo.ReceberDano(ataque);
		StartCoroutine(Attacking());
	}

	IEnumerator Attacking(){
		yield return new WaitForSeconds(combatManager.manager.attackCooldown);
		atacando = false;
	}

	public void ReceberDano( int dano){
		vida = Mathf.Max(0, vida - dano);

		if ( vida==0 ) {
			combatManager.manager.Kill(this);
		}
	}

	public bool PodeAtacar(Personagem alvo){
		if (alvo == null) return false;

		float dist = Vector3.Distance(alvo.transform.position, transform.position);
		if (dist < alcance) return true;
		return false;
	}

}