/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ModelSpawner : MonoBehaviour
{
    public GameObject modelPrefab;
    private Camera arCamera;
    private bool isPlaced = false;
    public ARRaycastManager arRaycastManager;

    void Start()
    {
        arCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isPlaced)
        {
            Ray ray = arCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            List<ARRaycastHit> hits = new List<ARRaycastHit>();
            if (arRaycastManager.Raycast(Input.mousePosition, hits, TrackableType.PlaneWithinBounds))
            {
                Pose hitPose = hits[0].pose;
                Instantiate(modelPrefab, hitPose.position, hitPose.rotation);
                isPlaced = true;
            }
        }
    }
}*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ModelSpawner : MonoBehaviour
{
    public GameObject modelPrefab;
    private Camera arCamera;
    private bool isPlaced = false;
    public ARRaycastManager arRaycastManager;

    void Start()
    {
        arCamera = Camera.main;
        if (arRaycastManager == null)
        {
            Debug.LogError("ARRaycastManager is not assigned!");
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isPlaced)
        {
            List<ARRaycastHit> hits = new List<ARRaycastHit>();

            if (arRaycastManager.Raycast(Input.mousePosition, hits, TrackableType.PlaneWithinPolygon))
            {
                if (hits.Count > 0)
                {
                    Pose hitPose = hits[0].pose;
                    Instantiate(modelPrefab, hitPose.position, hitPose.rotation);
                    isPlaced = true;
                    Debug.Log("Model instantiated at: " + hitPose.position);
                }
            }
            else
            {
                Debug.Log("No AR planes detected.");
            }
        }
    }
}
