using UnityEngine;
using System.Collections;

public class NPC : MonoBehaviour {

	//how long before NPC chooses a new direction to move
	public float wanderLength;
	public float speed;
	public float size=1;

	//MUST match object location
	public float Xstart;
	public float Zstart;

	//keeps track of location
	private float Xpos=0;
	private float Zpos=0;

	private int counter=0;
	private int direction=0;
	/*directions are clockwise
	 * 812
	 * 7-3
	 * 654*/





	// Use this for initialization
	void Start () {
		Xpos = Xstart;
		Zpos = Zstart;
	}
	
	// Update is called once per frame
	void Update () {
		Wander ();

	}

	void Wander(){
		//After [WanderLength] turns, a new direction is randomly selected
		if (counter % wanderLength == 0){
			direction = Random.Range (1, 8);
		}
		//Counts how many turns have gone by
		counter++;


		if ((direction==8)||(direction==1)||(direction==2)) {
			if (Xpos>0){//Don't move if on the border
				transform.Translate (-speed, 0, 0);//move
				Xpos-=speed;//Keep track of location
			}//NOTE: Boundary code only activates if player is already out of bounds.
			//It does not keep them within the boundaries
		}
		if (direction==4||direction==5||direction==6) {
			if (Xpos < 50) {
				transform.Translate (speed, 0, 0);
				Xpos += speed;
			}
		}
		if (direction==6||direction==7||direction==8) {
			if(Zpos>0){
				transform.Translate (0, 0, -speed);
				Zpos-=speed;
			}
		}
		if (direction==2||direction==3||direction==4){
			if (Zpos < 50) {
				transform.Translate (0, 0, speed);
				Zpos += speed;
			}
		}
	}
}
