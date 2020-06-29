using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostCamera : MonoBehaviour {
	GameObject MainCamera,Ghost;
	Vector2 MainCameraPos,GhostPos;
	Rigidbody2D GetR;

	// Use this for initialization
	void Start () {

		MainCamera = GameObject.Find ("MainCamera");
		Ghost = GameObject.Find ("Ghost");
		GetR = Ghost.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame--Update是每帧调用
	void Update () {

		//获取相机的位置
		MainCameraPos = MainCamera.transform.position;
		//获取幽灵的位置
		GhostPos = Ghost.transform.position;
		//让相机跟随幽灵而移动
		if (GhostPos.y > MainCameraPos.y) {
			MainCamera.transform.position = Vector2.MoveTowards (MainCameraPos, new Vector2 (MainCameraPos.x, GhostPos.y),GetR.velocity.y);
		}
	}
}
