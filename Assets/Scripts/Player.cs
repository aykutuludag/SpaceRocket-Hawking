using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : LivingEntity {

	public GameManager gm;
	[Header("Kontroller")]
	public bool holdingLeft;
	public bool holdingRight;
	Vector2 startPos;
	Vector2 direction;
	bool directionChosen;
	float portion;
	float angle;
	private Vector3 startRotation;
	public static int Score;


	public static bool isGameStarted;
	public static bool paused;
	public static bool isGameOver;

	[Header("Mechanic")]
	public bool chase;

	 Transform merkez;
	 Transform patika;
	 Transform oyuncu_golge;
	float patikaYaricap;

	public float shipTurnRate;
	public static float shipRad = 2.5f;
	public GameObject hyperSpace;

	[Header("Die Settings")]
	public GameObject playerDeathEffect;
	public GameObject playerModels;




	void Awake(){
		
		gm = GameManager.gm;
		gm = GameObject.FindGameObjectWithTag ("GM").GetComponent<GameManager>();
		gm.player = this;

	}
	void Start () {

		merkez = gm.center;
		patika = gm.path;
		oyuncu_golge = gm.player_shadow;
		patikaYaricap = gm.pathRad;
		health = startingHealth;

		///bunu gerektigi zaman update icinde mudahale icin kullancaz


	}
	public void GameStarted(){

		//transform.gameObject.SetActive(false);
		Debug.Log("Oyun başlatılıyor");

		hyperSpace.SetActive(false);
		shipTurnRate = gm.shipTurnRate;
		patika.transform.localPosition = merkez.transform.position + new Vector3(gm.pathRad, 0, 0);
		oyuncu_golge.transform.localPosition = new Vector3(0, -shipRad, 0);
		chase = true;
	}
	public void GameEnded(){
		hyperSpace.SetActive(false);
		chase = false;
	}
	// Update is called once per frame
	void Update () {

		if (Input.GetKey("up"))
		{
			patika.transform.Rotate(0, 0, Time.deltaTime * 10 * shipTurnRate);// turn a little
		}
		if (Input.GetKey("down"))
		{
			patika.transform.Rotate(0, 0, Time.deltaTime * 10 * -shipTurnRate);// turn a -little
		}

		if(chase){
			transform.position = oyuncu_golge.transform.position;
			transform.rotation = oyuncu_golge.transform.rotation;
		}

		//
		if (Input.touchCount > 0)
		{
			int i = 0;
			for (i = 0; i < Input.touchCount; i++)
			{
				Touch touch = Input.GetTouch(i);
				if (touch.position.x < Screen.width / 2)
				{
					holdingLeft = true;
					patika.transform.Rotate(0, 0, Time.deltaTime * shipTurnRate);// turn a little
					// Handle finger movements based on touch phase.
					switch (touch.phase)
					{
					// Record initial touch position.
					case TouchPhase.Began:
						//startPos = touch.position;
						directionChosen = false;
						break;

						// Determine direction by comparing the current touch position with the initial one.
					case TouchPhase.Moved:
						//direction = touch.position - startPos;

						//portion = direction.y / Screen.height;
						//angle = portion * multi;
						//transform.eulerAngles = startRotation + new Vector3(0,angle,0);
						//steering.eulerAngles = steering.eulerAngles+ new Vector3(0,0,angle/60f);


						break;

						// Report that a direction has been chosen when the finger is lifted.
					case TouchPhase.Ended:
						//startRotation = transform.eulerAngles;
						//directionChosen = true;
						//holdingLeft = false;
						//portion = 0;
						//angle = 0;
						break;
					}
				}
				if (touch.position.x > Screen.width / 2)
				{
					holdingRight = true;
					patika.transform.Rotate(0, 0, Time.deltaTime * -shipTurnRate);
					// Handle finger movements based on touch phase.
					switch (touch.phase)
					{
					// Record initial touch position.
					case TouchPhase.Began:
						//startPos = touch.position;
						directionChosen = false;
						break;

						// Determine direction by comparing the current touch position with the initial one.
					case TouchPhase.Moved:
						//direction = touch.position - startPos;

						//portion = direction.y / Screen.height;
						//angle = portion * multi;
						//transform.eulerAngles = startRotation + new Vector3(0,angle,0);
						//steering.eulerAngles = steering.eulerAngles+ new Vector3(0,0,angle/60f);


						break;

						// Report that a direction has been chosen when the finger is lifted.
					case TouchPhase.Ended:
						//startRotation = transform.eulerAngles;
						//directionChosen = true;
						//holdingLeft = false;
						//portion = 0;
						//angle = 0;
						break;
					}
				}
				/*if(touch.position.x > Screen.width/1.5)
                    {
                        if(touch.phase != TouchPhase.Ended)
                        {
                            regen = false;
                            if(mayShoot){
                                StartCoroutine(Attack(rpm));
                            }
                        }
                    */
			}
		}
		///

		if(health<=0){
			KillPlayer();
			//Destroy(Instantiate(playerDeathEffect,transform.position,Quaternion.identity),2f);

		}

	}
	void KillPlayer(){
		Destroy(playerModels);
		Destroy(gameObject,1f);
	}
}
