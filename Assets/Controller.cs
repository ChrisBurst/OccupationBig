using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

	//adjustable speed of player
	public float speed;
	public float size=1;

	//Xpos and Zpos do not move Player, but keep track of its location
	public float Xpos;
	public float Zpos;

	private float TempSpeed=0;


	void OnTriggerEnter(Collider other){
		print (other.gameObject.name + " is touching "+gameObject.name);

		//Lava is a killzone
		if (other.gameObject.tag=="Lava") {
			Destroy (gameObject);
			print ("You BURN.");
		}

		//Thorn bushes slow down a dino. The bigger they are, the more they slow.
		if (other.gameObject.tag == "Thorn") {
			TempSpeed=speed; //Store a variable for what the speed should go back to on exit.
			speed = speed*(.5f/size);
			print ("Speed reduced to "+speed);
		}

		//Tall Grass hides smaller dinos. Exact size limit not determined
		if (other.gameObject.tag == "Grass") {
			if(size<4){ //NOTE: 5 is placeholder number
				print ("You are Hidden");
			}else{
				print ("You are too large to be hidden");
			}
		}

		if (other.gameObject.tag == "NPCDino") {
			Destroy(other.gameObject);
			print ("You eat the dino.");
			transform.localScale+= new Vector3(1f,0,1f);
			size++;
		}
	}

	//Undo effects of terrain once player leaves
	void OnTriggerExit(Collider other){
		if (other.gameObject.tag == "Thorn") {
			speed=TempSpeed; //return speed to normal.
			print ("Speed back to "+speed);
		}
		if (other.gameObject.tag == "Grass") {
			print ("Out of grass, no longer hidden");
		}
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.UpArrow)) {
			if(Xpos>0){//Don't move if on the border
				transform.Translate (-speed, 0, 0);//move
				Xpos-=speed;//Keep track of location
			}//NOTE: Boundary code only activates if player is already out of bounds.
			//It does not keep them within the boundaries
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			if (Xpos < 50) {
				transform.Translate (speed, 0, 0);
				Xpos += speed;
			}
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			if(Zpos>0){
				transform.Translate (0, 0, -speed);
				Zpos-=speed;
			}
		}
		if (Input.GetKey (KeyCode.RightArrow)){
			if (Zpos < 50) {
				transform.Translate (0, 0, speed);
				Zpos += speed;
			}
		}

		//DEBUG ABILITY
		if (Input.GetKey (KeyCode.G)) {
			print ("AWESOME!");
			//Placeholder until we have something we want to alter during testing
		}

	}
}
