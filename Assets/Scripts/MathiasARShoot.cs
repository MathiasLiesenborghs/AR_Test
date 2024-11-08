using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathiasARShoot : MonoBehaviour
{
    public GameObject particles;
    void Update()
    {
        
        for (int i = 0; i < Input.touchCount; ++i)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) 
            {
                
                GameObject particlesInstance = Instantiate(particles, hit.point, Quaternion.identity);

                
                Destroy(particlesInstance, 1f);
            }
        }

        
        if (Input.GetMouseButtonDown(0)) 
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) 
            {
                
                GameObject particlesInstance = Instantiate(particles, hit.point, Quaternion.identity);

                
                Destroy(particlesInstance, 1f);
            }
        }
    }


}

