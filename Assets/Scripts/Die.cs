using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour {


	void Start () {
		
	}
	

	void Update () {
		
	}


	//不断的消除多余的物体，防止内存爆炸
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("Branch")) {
			print("find branch");
			Destroy (other.gameObject);
		}
		if (other.gameObject.CompareTag ("Mosquito")) {
			Destroy (other.gameObject);
		}
		if (other.gameObject.CompareTag ("Blood")) {
			Destroy (other.gameObject);
		}
	}
}
