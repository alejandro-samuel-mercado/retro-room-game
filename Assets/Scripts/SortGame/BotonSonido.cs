using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BotonSonido : MonoBehaviour
{

    public Button boton;
    public AudioSource audioSource;


    void Start()
    {
        boton.onClick.AddListener(ReproducirSonido);        
    }

    void ReproducirSonido()
    {
        audioSource.Play();
    }
}
