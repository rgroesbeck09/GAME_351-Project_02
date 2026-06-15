using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Public Variables
    public float rayDistance = 11f;
    public float rotationSpeed = 10f;
    public LayerMask terrainLayer;
    public float hoverAmount = 0.05f;
    public float hoverSpeed = 8f;
    public float hoverHeight = 8;
    public CameraMovement changeCam;
    public Transform nextObj;
    public float hoverCarSpeed;


    // Start is called before the first frame update
    void Start()
    {
        changeCam = Camera.main.GetComponent<CameraMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
        // Hint: The global static variable "Terrain.activeTerrain" 
        // may be helpful or have useful methods for user here or in
        // other scripts.
        Terrain terrain = Terrain.activeTerrain;

        Vector3 position = transform.position;

        // get the active terrain values
        float terrainH = terrain.SampleHeight(position) + hoverHeight;

        // Implementation of Hover
        position.y = terrainH + Mathf.Sin(Time.time * hoverSpeed) * hoverAmount;

        // set the game object's translation (not an increment)
        transform.position = new Vector3(position.x, position.y, position.z);

        // Set the allignment with the terrain
        AlignWithTerrain();

        // Forward and back
        if (Input.GetKey (KeyCode.W))
        {
            // increment the game object's translation
            transform.Translate(0, 0, hoverCarSpeed);
        }
        else if(Input.GetKey (KeyCode.S))
        {
            transform.Translate(0, 0, -hoverCarSpeed);
        }

        // Rotational
        if (Input.GetKey (KeyCode.A))
        {
            // increment the game object's translation
            transform.Rotate(0, -0.1f, 0);
        }
        else if(Input.GetKey (KeyCode.D))
        {
            transform.Rotate(0, 0.1f, 0);
        }

        if (Input.GetKeyUp (KeyCode.C))
        {
            Debug.Log("Pressed C on: " + gameObject.name);

            changeCam = FindObjectOfType<CameraMovement>();

            Debug.Log("CameraMovement found on: " + changeCam.gameObject.name);
            Debug.Log("Trying to switch to: " + nextObj.name);

            // Toggle the cars
            changeCam.SetTarget(nextObj);
        }

    }

    // this function is used to allign the object with the terrain
    void AlignWithTerrain()
    {
        // setup the rays
        Ray ray = new Ray(transform.position + Vector3.up, Vector3.down);

        if(Physics.Raycast(ray, out RaycastHit hit, rayDistance, terrainLayer))
        {
            Vector3 terrainNormal = hit.normal;

            // This is used to keep direction of object
            Vector3 fSlope = Vector3.ProjectOnPlane(transform.forward, terrainNormal).normalized;

            if (fSlope.sqrMagnitude > 0.001f)
            {
                Quaternion tRotation = Quaternion.LookRotation(fSlope, terrainNormal);

                transform.rotation = Quaternion.Slerp(
                    transform.rotation,
                    tRotation,
                    rotationSpeed * Time.deltaTime
                    );
            }
        }
    }
}
