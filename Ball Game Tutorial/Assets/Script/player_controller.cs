using UnityEngine;
using System.Collections;

public class player_controller : MonoBehaviour 
{
	//Variables
	public float speed;
	private int count;
	public GUIText countText;
	public GUIText winText;

	//initiating the game
	void Start()
	{
		count = 0;
		SetCountText ();
		winText.text = "";
	
	}

	//After each frame
	void FixedUpdate() 
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical); 

		GetComponent<Rigidbody>().AddForce (movement * speed * Time.deltaTime);


	}

	// Set active to false for everything that enters the trigger
	
	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.tag == "Pickup") 
		{
			other.gameObject.SetActive(false);
			count = count + 1;
			SetCountText();

		}
	}
	void SetCountText() //sets the count text
	{
		countText.text = "Count: " + count.ToString ();

		//Check for win condition and display win text
		if (count >= 12) 
		{
			winText.text = "Congratulations! You Win";
		}
	}
}
