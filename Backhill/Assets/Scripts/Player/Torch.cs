using UnityEngine;

public class Torch : MonoBehaviour
{
    private bool isLightOn = false;

    public void Toggle()
    {
        isLightOn = !isLightOn;

        gameObject.SetActive(isLightOn);
    }
}
