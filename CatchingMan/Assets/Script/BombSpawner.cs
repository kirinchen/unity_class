﻿using UnityEngine;
using System.Collections;

public class BombSpawner : MonoBehaviour {

	private float Distance;
	private float BeginTime ;

	public float SpawnTime = 2;
	public GameObject bomb;
	public float MoveSpeed = 2;
	private  int MAX_CREATE_COUNT = 1;

	private Scene scene;

	// Use this for initialization
	void Start () {
		Distance = Camera.main.orthographicSize * Camera.main.aspect * 2 * 0.9f;
		BeginTime = Time.time;
		scene = GameObject.Find ("Scene").GetComponent<Scene> ();
	}
	
	// Update is called once per frame
	void Update () {

		if(scene.levelComplated || scene.gameOvered){
			return;
		}

		shiftPos ();
		if ((Time.time - BeginTime) > SpawnTime) {
			CreateAObj();
			
			audio.Play();	
		}

	}

	private void shiftPos(){
		float newPos = Mathf.PingPong (Time.time*MoveSpeed,Distance) - (Distance/2);
		transform.position = new Vector3 (newPos,transform.position.y,transform.position.z);
	}

	private void CreateAObj(){
		GameObject newObj = Instantiate(bomb) as GameObject;
		newObj.transform.position = transform.position;
		BeginTime = Time.time;
	}
}
