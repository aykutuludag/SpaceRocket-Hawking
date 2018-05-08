using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipManager : MonoBehaviour
{
    [Header("Kontroller")]
    public bool holdingLeft;
    public bool holdingRight;
    Vector2 startPos;
    Vector2 direction;
    bool directionChosen;
    float portion;
    float angle;
    public int multi;
    private Vector3 startRotation;
    public static int Score;


    [Header("Map")]
    public GameObject center;
    public GameObject path;
    public Transform player_shadow;
    [Header("Canvas")]


    public Canvas gameUI, gamePause, gameOver;


    [Header("PlayerMovements")]
    public float centerAngularSpeed;
    public float centerHorizontalSpeed;
    public float pathRad;
    public float shipTurnRate;
    public static float shipRad = 2.5f;
    public GameObject hyperSpace;

    public static bool isGameStarted;
    public static bool paused;
    public static bool isGameOver;
    public  bool isHyperSpace = true;

    // Use this for initialization
    void Start()
    {
        ///bunu gerektigi zaman update icinde mudahale icin kullancaz
        path.transform.localPosition = center.transform.position + new Vector3(pathRad, 0, 0);
        player_shadow.transform.localPosition = new Vector3(0, -shipRad, 0);

        if (isHyperSpace)
        {
            hyperSpace.gameObject.SetActive(true);
        }
        else
        {
            hyperSpace.gameObject.SetActive(false);
        }

        InvokeRepeating("increaseSpeed", 3f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameStarted && !paused && !isGameOver)
        {
            //collider.enabled = true;
            if (Input.touchCount > 0)
            {
                int i = 0;
                for (i = 0; i < Input.touchCount; i++)
                {
                    Touch touch = Input.GetTouch(i);
                    if (touch.position.x < Screen.width / 2)
                    {
                        holdingLeft = true;
                        path.transform.Rotate(0, 0, Time.deltaTime * shipTurnRate);// turn a little
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
                        path.transform.Rotate(0, 0, Time.deltaTime * -shipTurnRate);
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
        }

        ////
        if (isGameStarted && !paused && !isGameOver)
        {
            center.transform.Translate(0, Time.deltaTime * centerHorizontalSpeed, 0); // move forward
            center.transform.Rotate(0, Time.deltaTime * centerAngularSpeed, 0);
            if (Input.GetKey("up"))
            {
                path.transform.Rotate(0, 0, Time.deltaTime * shipTurnRate);// turn a little
            }
            if (Input.GetKey("down"))
            {
                path.transform.Rotate(0, 0, Time.deltaTime * -shipTurnRate);// turn a little
            }
        }
        if (Input.GetKeyUp(KeyCode.P))
        {
            if (!paused)
            {
                paused = true;
                gamePause.gameObject.SetActive(true);
            }
            else
            {
                paused = false;
                gamePause.gameObject.SetActive(false);

            }
        }
        transform.position = player_shadow.transform.position;
        transform.rotation = player_shadow.transform.rotation;
    }

    void increaseSpeed()
    {
        shipTurnRate++;
    }

    void increaseScore()
    {
        if (!isGameOver && isGameStarted && !paused)
        {
            Score++;
            gameUI.GetComponent<CanvasGameUI>().updateScore();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("ÖLDÜN");
            shipTurnRate -= 20f;
            isGameOver = true;
            gameUI.gameObject.SetActive(false);
            gameOver.gameObject.SetActive(true);
        }
        else if (other.gameObject.tag == "Bonus")
        {
            Destroy(other.gameObject);
            increaseScore();
        }
    }
}
