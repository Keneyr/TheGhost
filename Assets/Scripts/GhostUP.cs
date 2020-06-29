using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GhostUP : MonoBehaviour {
	
    

    [Range(2, 10)] [SerializeField] private int Velocity = 9;
    [Range(2, 10)] [SerializeField] private float LVelocity = 10,RVelocity = 10;

	Rigidbody2D GetR;
	private float _h;
	
    //树枝和蚊子的时间
	private float _branchTime = 2f;
	private float _mosquitoTime = 2f;

	//血手印的时间
	private float _bloodhandTime = 3f;

	//幽灵向上位移
	private Vector3 move = new Vector2(0f,1.0f);
	public AudioSource audioscream;

    GhostMap _ghostMap;


    void Start () {
		//获取幽灵的刚体
		GetR = transform.GetComponent<Rigidbody2D> ();

        //调用别的类来声明对象-add by keneyr 2019
        _ghostMap = GetComponent<GhostMap>();

	}
	
	// Update is called once per frame
	void Update () {
		
		_branchTime -= Time.deltaTime;
		_mosquitoTime -= Time.deltaTime;
		_bloodhandTime -= Time.deltaTime;

		/*防止幽灵从两边飞出
		if (transform.position.x > 2.4f) {
			transform.position = new Vector2 (2.2f, transform.position.y);
		}
		if (transform.position.x < -2.4f) {
			transform.position = new Vector2 (-2.2f, transform.position.y);
		}*/
		transform.position = new Vector3 (Mathf.Clamp(transform.position.x,-2.2f,2.2f),
			transform.position.y,
			0
		);


		//小幽灵匀速移动
		GetR.velocity = Velocity * move;

		if(Input.GetKey(KeyCode.A)){
			
			GetR.velocity = (Vector2.left * LVelocity);
		}
		if(Input.GetKey(KeyCode.D)){
			
			GetR.velocity = (Vector2.right * RVelocity);
		}

        //最好不要在start或者awake以外的地方去GetComponent，因为这个方法很慢，效率很低
        //if (_branchTime < 0)
        //{
        //    transform.GetComponent<GhostMap>().GenerateBrach();
        //    _branchTime = Random.Range(2, 5);
        //}
        //if (_mosquitoTime < 0)
        //{
        //    transform.GetComponent<GhostMap>().GenerateMosquito();
        //    _mosquitoTime = Random.Range(2, 5);
        //}
        //if (_bloodhandTime < 0)
        //{
        //    transform.GetComponent<GhostMap>().GenerateBloodHand();
        //    _bloodhandTime = Random.Range(2, 5);
        //}
        if(_branchTime<0)
        {
            _ghostMap.GenerateBrach();
            _branchTime = Random.Range(2, 5);
        }
        if(_mosquitoTime < 0)
        {
            _ghostMap.GenerateMosquito();
            _mosquitoTime = Random.Range(2, 5);
        }
        if(_bloodhandTime < 0)
        {
            _ghostMap.GenerateBloodHand();
            _bloodhandTime = Random.Range(2, 5);
        }
    }
	void OnCollisionEnter2D(Collision2D other){
		
		//碰到树枝就死掉
		if (other.gameObject.CompareTag ("Branch")) {
			
			//print ("Oh Branch");
			//audioscream.Play ();
			SceneManager.LoadScene ("Ghostscare");

		}


		//碰到蚊子就死掉,重新回到场景
		if (other.gameObject.CompareTag ("Mosquito")) {
			//transform.GetComponent<GhostMap>().GenerateMosquito ();
			//print ("Oh Mosquito");
			//audioscream.Play ();
			SceneManager.LoadScene ("Ghostscare");

		}
		//碰到血手印就死掉
		if (other.gameObject.CompareTag ("Blood")) {
			//print ("oh blood");
			//audioscream.Play ();
			SceneManager.LoadScene ("Ghostscare");
		}

	}
}
