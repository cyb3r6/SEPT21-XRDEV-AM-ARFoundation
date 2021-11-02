using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class TapToPlace : MonoBehaviour
{
    public GameObject robotPrefab;

    private GameObject spawnedPrefab;
    private ARRaycastManager aRRaycastManager;
    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Start()
    {
        aRRaycastManager = GetComponent<ARRaycastManager>();
    }

    
    void Update()
    {
        if(spawnedPrefab == null)
        {
            if(Input.touchCount > 0)
            {
                Vector2 touchPosition = Input.GetTouch(0).position;

                if(aRRaycastManager.Raycast(touchPosition,hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon))
                {
                    var hitPose = hits[0].pose;
                    spawnedPrefab = Instantiate(robotPrefab, hitPose.position, hitPose.rotation);
                }
            }
        }
    }
}
