using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMap : MonoBehaviour {
	//把Branch和Mosquito的预制体拖上去
	//public GameObject[] Branch;
	//GameObject[] BranchTop=null;

	public GameObject branch,branch1,branch2,branch1_right,longbranch_right,branch2_left;
	GameObject branch_top,branch1_top,branch2_top,branch1_right_top,longbranch_right_top,branch2_left_top;
	GameObject branchPrefab,branch1Prefab,branch2Prefab,branch1_rightPrefab,longbranch_rightPrefab,branch2_leftPrefab;


	public GameObject Mosquito;
	GameObject MosquitoTop;

	public GameObject Bloodhand;
	GameObject BloodHandTop;
	public GameObject Blood;
	GameObject BloodTop;

	//GameObject[] BranchPrefab=null; 
	 
	void Start () {

		branch_top = GameObject.Find ("branch_top");
		branch1_top = GameObject.Find ("branch1_top");
		branch2_top = GameObject.Find ("branch2_top");
		branch1_right_top = GameObject.Find ("branch1_right_top");
		longbranch_right_top = GameObject.Find ("longbranch_right_top");
		branch2_left_top = GameObject.Find ("branch2_left_top");

		MosquitoTop = GameObject.Find ("MosquitoTop");
		BloodHandTop = GameObject.Find ("blood_handTop");
		BloodTop = GameObject.Find ("blood_Top");


		  
		//BranchPrefab [0] = Resources.Load ("Prefabs/branch") as GameObject;
		//Instantiate (BranchPrefab [0]);
	}

	void Update () {
		
	}
	//生成树枝
	public void GenerateBrach(){
		//print ("正在生成树枝");



		branch1Prefab = Instantiate (branch1)as GameObject;
		branch1Prefab.transform.position = new Vector3 (branch1_top.transform.position.x, branch1_top.transform.position.y + Random.Range (5f, 10f), 0);
		branch1_top = branch1Prefab;

		branch2Prefab = Instantiate (branch2)as GameObject;
		branch2Prefab.transform.position = new Vector3 (branch2_top.transform.position.x, branch2_top.transform.position.y + Random.Range (5f, 10f), 0);
		branch2_top = branch2Prefab;

		branch1_rightPrefab = Instantiate (branch1_right)as GameObject;
		branch1_rightPrefab.transform.position = new Vector3 (branch1_right_top.transform.position.x, branch1_right_top.transform.position.y + Random.Range (5f, 10f), 0);
		branch1_right_top = branch1_rightPrefab;

		longbranch_rightPrefab = Instantiate (longbranch_right)as GameObject;
		longbranch_rightPrefab.transform.position = new Vector3 (longbranch_right_top.transform.position.x, longbranch_right_top.transform.position.y + Random.Range (5f, 10f), 0);
		longbranch_right_top = longbranch_rightPrefab;

		branch2_leftPrefab = Instantiate (branch2_left)as GameObject;
		branch2_leftPrefab.transform.position = new Vector3 (branch2_left_top.transform.position.x, branch2_left_top.transform.position.y + Random.Range (5f, 10f), 0);
		branch2_left_top = branch2_leftPrefab;
		/*
		branchPrefab = Instantiate (branch) as GameObject;
		branchPrefab.transform.position = new Vector3(branch_top.transform.position.x,branch_top.transform.position.y + Random.Range(5f,10f),0);
		branch_top = branchPrefab;
		*/
		//BranchPrefab [0].transform.position = new Vector3 (BranchTop[0].transform.position.x,BranchTop[0].transform.position.y+Random.Range(1f,3f),0);
		//BranchTop [0] = BranchPrefab [0]; 
	}

	// 生成蚊子
	public void GenerateMosquito(){
		//print ("正在生成蚊子");
		GameObject MosquitoPrefab = Instantiate (Mosquito) as GameObject;
		/*这里有要给bug，相当的诡异，竟然不能用MosquitoTop，一用就报错,那是因为生成蚊子的间隔太慢，最后一个MosquiTop已经碰撞检测杀死了，
			所以当你再用预制体做出来一个蚊子的时候，它设置位置的时候，已经找不到Top对象。
		*/
		MosquitoPrefab.transform.position = new Vector3(Random.Range(-2.4f,2.4f),MosquitoTop.transform.position.y + Random.Range(5f,10f),0);
		MosquitoTop = MosquitoPrefab;
	}
	//生成血手印
	public void GenerateBloodHand(){
		//print ("正在生成血手掌");
		GameObject BloodHandPrefab = Instantiate (Bloodhand) as GameObject;
		BloodHandPrefab.transform.position = new Vector3 (Random.Range(-2.4f,2.4f),BloodHandTop.transform.position.y + Random.Range(10f,30f),0);
		BloodHandTop = BloodHandPrefab;

		GameObject BloodPrefab = Instantiate (Blood) as GameObject;
		BloodPrefab.transform.position = new Vector3 (Random.Range(-2.4f,2.4f),BloodTop.transform.position.y + Random.Range(10f,20f),0);
		BloodTop = BloodPrefab;


	}
}
