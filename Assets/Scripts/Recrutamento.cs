using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Recrutamento : MonoBehaviour {

	public GameObject aldeia;
	public Indio unidade;
	public Text cdCounter;

	int coolDown = 0;
	//Button btn;

	private void Start() {
		PrintCoolDown();
		//btn = GetComponent<Button>();
	}

	public void DoRecrutar(){
		if (coolDown > 0) return;

		Indio novo = Instantiate(unidade);
		novo.transform.position = aldeia.transform.position;
		combatManager.manager.AddIndio(novo);

		coolDown = 5;
		//btn.interactable = false;
		StartCoroutine(BeginCooldown());
		PrintCoolDown();
	}

	IEnumerator BeginCooldown(){
		yield return new WaitForSeconds(1);
		coolDown = Mathf.Max(0, coolDown-1);
		PrintCoolDown();
		if ( coolDown>0 ) StartCoroutine(BeginCooldown());
	}

	void PrintCoolDown(){
		if (coolDown > 0) cdCounter.text = "" + coolDown;
		else {
			//btn.interactable = true;
			cdCounter.text = "";
		}
	}

}