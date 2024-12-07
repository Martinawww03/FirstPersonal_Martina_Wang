using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class WaterEfect : MonoBehaviour
{
    private Volume volume;
    private LensDistortion distorsionEffects;
    [SerializeField] private float velocidadAngular;
    // Start is called before the first frame update
    void Start()
    {
        volume = GetComponent<Volume>();
        if(volume.profile.TryGet(out LensDistortion lensDistortion))
        {
            distorsionEffects = lensDistortion;
        }

    }

    // Update is called once per frame
    void Update()
    {
        //Metemos un seno y coseno en el efecto de agua y sumamos 1 para que vaya de 0 a 2 y dividimos entre 2 para que vaya de 0 a 1.
        FloatParameter ejemplo = new FloatParameter(1 + Mathf.Sin(velocidadAngular*Time.time / 2)); //Mathf.Sin(Time.time)= -1 hasta 1
        FloatParameter ejemplo2 = new FloatParameter(1 + Mathf.Cos(velocidadAngular*Time.time / 2)); //Mathf.Cos(Time.time)= 1 hasta -1 (a reves)
        distorsionEffects.xMultiplier.SetValue(ejemplo);
        distorsionEffects.xMultiplier.SetValue(ejemplo2);
    }
}
