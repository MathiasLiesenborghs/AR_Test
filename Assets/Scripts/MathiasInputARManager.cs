using UnityEngine;
using UnityEngine.XR.ARFoundation;
using System.Collections.Generic;

public class TouchObjectManager : MonoBehaviour
{
    private Camera _camera;
    private ARRaycastManager m_raycastManager;
    [SerializeField] GameObject _gameObject;

    
    private List<GameObject> instantiatedObjects = new List<GameObject>();

    private void Awake()
    {
        m_raycastManager = GetComponent<ARRaycastManager>();
    }

    void Start()
    {
        _camera = Camera.main;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.touchCount == 0) return;

        Touch currentFinger = Input.GetTouch(0);
        var screenPosition = currentFinger.position;
        var ray = Camera.main.ScreenPointToRay(screenPosition);
        var raycastHits = new List<ARRaycastHit>();

        if (m_raycastManager.Raycast(ray, raycastHits, UnityEngine.XR.ARSubsystems.TrackableType.Planes))
        {
            ARRaycastHit firstHit = raycastHits[0];
            Pose hitPose = firstHit.pose;
            Vector3 spawnPosition = hitPose.position;

            
            if (currentFinger.phase == TouchPhase.Began)
            {
                bool touchedObject = false;
                foreach (var obj in instantiatedObjects)
                {
                    
                    if (Vector3.Distance(obj.transform.position, spawnPosition) < 0.1f)
                    {
                        
                        Destroy(obj);
                        instantiatedObjects.Remove(obj);
                        touchedObject = true;
                        break;
                    }
                }                
                if (!touchedObject)
                {
                    GameObject newObject = Instantiate(_gameObject, spawnPosition, Quaternion.identity);
                    instantiatedObjects.Add(newObject);
                }
            }
        }
    }
}
