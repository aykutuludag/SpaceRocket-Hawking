using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam : MonoBehaviour
{

    [Header("BeamPosition")]

    public Vector3[] beamPositions;

    [Header("Prefabs")]
    public GameObject[] beamLineRendererPrefab;
    public GameObject[] beamStartPrefab;
    public GameObject[] beamEndPrefab;

    private int currentBeam = 0;

    private GameObject beamStart;
    private GameObject beamEnd;
    private GameObject beam;
    private LineRenderer line;

    [Header("Adjustable Variables")]
    public float beamEndOffset = 1f; //How far from the raycast hit point the end effect is positioned
    public float textureScrollSpeed = 8f; //How fast the texture scrolls along the beam
    public float textureLengthScale = 3; //Length of the beam texture

    public bool laserActive = false;
    private LineRenderer lr;
    public GameObject merkez;
    public GameObject beamImpact;
    public float laserTurnSpeed;
    void Start()
    {

        lr = merkez.GetComponent<LineRenderer>();
        lr.enabled = false;
        beamImpact.SetActive(false);
        laserActive = true;
        float angle = Random.Range(0, 360);
        merkez.transform.eulerAngles = new Vector3(angle, 0, 0);
    }

    void Update()
    {


        if (laserActive)
        {
            merkez.transform.Rotate(laserTurnSpeed * Time.deltaTime, 0f, 0f);
            ActivateLaser();
        }
        else
        {
            DeactivateLaser();
        }
    }
    void ActivateLaser()
    {
        lr.enabled = true;
        beamImpact.SetActive(true);
        Vector3[] positions = new Vector3[2];
        positions[0] = new Vector3(0f, 0f, 0.0f);
        positions[1] = new Vector3(0f, ShipManager.shipRad, 0.0f);
        //print(ShipManager.shipRad.ToString());
        lr.positionCount = positions.Length;
        lr.SetPositions(positions);
    }
    void DeactivateLaser()
    {
        beamImpact.SetActive(false);
        lr.enabled = false;
    }

}
