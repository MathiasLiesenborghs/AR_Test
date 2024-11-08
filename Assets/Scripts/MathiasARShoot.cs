using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathiasARShoot : MonoBehaviour
{
    public GameObject particles;
    void Update()
    {
        // Gestion des entrées tactiles
        for (int i = 0; i < Input.touchCount; ++i)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) // Utilise RaycastHit pour obtenir l'impact exact
            {
                // Instancier les particules à la position de l'impact du rayon
                GameObject particlesInstance = Instantiate(particles, hit.point, Quaternion.identity);

                // Détruire les particules après 1 seconde
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
                // Instancier les particules à la position de l'impact du rayon
                GameObject particlesInstance = Instantiate(particles, hit.point, Quaternion.identity);

                // Détruire les particules après 1 seconde
                Destroy(particlesInstance, 1f);
            }
        }
    }


}

