using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class MathiasInputARManager : MonoBehaviour
{
    private Camera _camera;
    private ARRaycastManager m_raycastManager;
    [SerializeField] GameObject _gameObject;


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
        if ((Input.touchCount == 0)) return;

        Touch currentFinger = Input.GetTouch(0);
        var screenPosition = currentFinger.position;
        var ray = Camera.main.ScreenPointToRay(screenPosition);
        var raycastHits = new List<ARRaycastHit>();

        if (m_raycastManager.Raycast(ray, raycastHits, TrackableType.Planes))
        {
            ARRaycastHit firsthit = raycastHits[0];
            Pose hitpose = firsthit.pose;
            var spawnPosition = hitpose.position;
            var current = Instantiate(_gameObject, spawnPosition, Quaternion.identity);
        }
    }
}
