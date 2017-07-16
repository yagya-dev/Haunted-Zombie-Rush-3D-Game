using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
public class GameManager : MonoBehaviour {
	[SerializeField] private GameObject mainMenu;
	public static GameManager instance = null;
	private bool playerActive = false;
	private bool gameOver = false;
	private bool gameStarted = false;
	public bool GameStarted{
		get{
			return gameStarted;
		}
	}

	public bool PlayerActive{
		get{
			return playerActive; 
		}
	}
	public bool GameOver{
		get{
			return gameOver;
		}
	}
	void Awake(){
		if (instance == null)
			instance = this;
		else if (instance != null)
			Destroy (gameObject);
		DontDestroyOnLoad (gameObject);
		Assert.IsNotNull (mainMenu);
	}
	// Use this for initialization
	void Start () {
		
	}
	public void PlayerCollided(){
		gameOver = true;
	}
	public void PlayerStartedGame(){
		playerActive = true;
	}
	public void EnterGame(){
		Debug.Log ("waah!");
		mainMenu.SetActive (false);
		gameStarted = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
