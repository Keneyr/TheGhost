using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosquitoMove : MonoBehaviour {

	public int Velocity = 1;

	void Start () {
		
	}

    //蚊子如果在右侧边界，并马上要出界，那就把它调在左侧边界，这样在玩家看来就是蚊子从左到右不断出入的···
	void Update () {

		//控制毒蚊子移动
		if (transform.position.x > 2.4f) {
			transform.position = new Vector2 (-2.4f, transform.position.y); 
		}
		if (transform.position.x < -2.4f) {
			//transform.position.x = 2.4f;
			transform.position = new Vector2(2.4f,transform.position.y);
		}
        //毒蚊子只会左右移动，物体沿着自身X轴方向，每秒移动Velocity=1米运动
        //不加Time.deltaTime就是每一帧移动1米，加了就是每秒移动1米，一秒可能有60帧或者其他帧，看个人电脑情况
        //https://blog.csdn.net/chinarcsdn/article/details/82914420

        transform.Translate (Velocity*Time.deltaTime,0,0);
	}
}
