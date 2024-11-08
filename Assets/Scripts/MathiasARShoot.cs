using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathiasARShoot : MonoBehaviour
{
    public GameObject particles;
    void Update()
    {
        // Gestion des entr�es tactiles
        for (int i = 0; i < Input.touchCount; ++i)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) // Utilise RaycastHit pour obtenir l'impact exact
            {
                // Instancier les particules � la position de l'impact du rayon
                GameObject particlesInstance = Instantiate(particles, hit.point, Quaternion.identity);

                // D�truire les particules apr�s 1 seconde
                Destroy(particlesInstance, 1f);
            }
        }

        // Gestion des clics de souris
        if (Input.GetMouseButtonDown(0)) // 0 est pour le clic gauche de la souris
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) // Utilise RaycastHit pour obtenir l'impact exact
            {
                // Instancier les particules � la position de l'impact du rayon
                GameObject particlesInstance = Instantiate(particles, hit.point, Quaternion.identity);

                // D�truire les particules apr�s 1 seconde
                Destroy(particlesInstance, 1f);
            }
        }
    }


}

