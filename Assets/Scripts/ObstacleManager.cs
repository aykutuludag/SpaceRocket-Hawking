using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public GameObject originOfUniverse;
    public float currentAngle;
    float obstacleAngle;
    public GameObject obstaclePrefab1;
    public float pathRad;
    public float shipRad;
    //public GameObject testChamber1;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("createObstacle", 0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void createObstacle()
    {
        currentAngle = originOfUniverse.transform.eulerAngles.y;
        obstacleAngle = currentAngle + 1f;

        if (currentAngle >= 180)
        {
            obstacleAngle = 180 - obstacleAngle;
            obstacleAngle = obstacleAngle * -1f;
        }

        int random = Random.Range(0, 2);
        switch (random)
        {
            case 0:
                shipRad = -1.75f;
                break;
            case 1:
                shipRad = 1.75f;
                break;
            default:
                break;
        }


        Vector3 obstaclePosition = new Vector3(pathRad * Mathf.Sin(obstacleAngle) + shipRad, shipRad, pathRad * Mathf.Cos(obstacleAngle));
        GameObject go = Instantiate(obstaclePrefab1);
        //go.transform.SetParent(testChamber1.transform);
        go.transform.position = obstaclePosition;
        Destroy(go, 5f);
    }
}
