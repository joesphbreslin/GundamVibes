using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

	public float speed, speedMod;
	public Animator anim;
	public KeyCode moveKey, runKey;
	int move;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		move = 0;
	}
	
	// Update is called once per frame
	void Update () {
		MoveAss();
		Rotate();
		anim.SetInteger("Move",move);
			
	}

	void Rotate(){

		float rotation = Input.GetAxis("Horizontal") * 1.5f;
		transform.Rotate(0, rotation, 0);
	}

	void MoveAss(){
		if(Input.GetKey(moveKey) && Input.GetKey(runKey)){

			
			move = 2;
			transform.Translate(Vector3.forward * speed  * Time.deltaTime * speedMod);
			Debug.Log(move);
		} else if(Input.GetKey(moveKey) && !Input.GetKey(runKey)){

			move = 1;
			Debug.Log(move);
			transform.Translate(Vector3.forward * speed * Time.deltaTime );
		}else{
			move = 0;
		}
	}
}
