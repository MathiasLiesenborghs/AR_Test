using UnityEngine;
using UnityEngine.XR.ARFoundation;
using System.Collections;

public class ARObjectSpawner : MonoBehaviour
{
    private Camera _camera; 
    private ARRaycastManager m_RaycastManager;
    [SerializeField] private GameObject _objectPrefab; 
    [SerializeField] private float spawnRadius = 10f; 
    [SerializeField] private float speed = 2f; 
    [SerializeField] private float spawnInterval = 4f; 

    private void Awake()
    {
        m_RaycastManager = GetComponent<ARRaycastManager>();
    }

    private void Start()
    {
        _camera = Camera.main; 
        StartCoroutine(SpawnObjectsRandomly()); 
    }

    private IEnumerator SpawnObjectsRandomly()
    {
        while (true)
        {
            
            Vector3 randomOffset = new Vector3(
                Random.Range(-spawnRadius, spawnRadius), // X axis
                0f, // Y axis
                Random.Range(-spawnRadius, spawnRadius) // Z axis
            );

            
            Vector3 spawnPosition = _camera.transform.position + randomOffset;

            
            GameObject newObject = Instantiate(_objectPrefab, spawnPosition, Quaternion.identity);

            
            StartCoroutine(MoveObjectTowardsCamera(newObject));

            
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private IEnumerator MoveObjectTowardsCamera(GameObject obj)
    {
        while (Vector3.Distance(obj.transform.position, _camera.transform.position) > 0.5f)
        {
            
            obj.transform.position = Vector3.MoveTowards(obj.transform.position, _camera.transform.position, speed * Time.deltaTime);
            obj.transform.LookAt(_camera.transform.position);

            yield return null;

        }

        
        Destroy(obj);
    }

    private void Update()
    {
        transform.LookAt(_camera.transform.position);
    }
}
