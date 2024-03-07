using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.Rendering.Universal;

public class LightPulse : MonoBehaviour
{
    public Light2D myLight;
    public float maxIntensity = 2f;
    public float minIntensity = 1f;
    public float pulseSpeed = 1f;

    private float targetIntensity = 1f;
    private float currentIntensity;

    void Update()
    {
        currentIntensity = Mathf.MoveTowards(myLight.intensity, targetIntensity, Time.deltaTime * pulseSpeed);

        if (currentIntensity >= maxIntensity)
        {
            targetIntensity = minIntensity;
        }
        else if (currentIntensity <= minIntensity)
        {
            targetIntensity = maxIntensity;
        }

        myLight.intensity = currentIntensity;
    }
}
