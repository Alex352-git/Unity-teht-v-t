using UnityEngine;

public class LightController : MonoBehaviour
{

    private Light lampLight;

    private void Avake()
    {
        lampLight = GetComponent<Light>();
    }

    private void Start()
    {
        if (lampLight == null)
        {
            Debug.LogError("Valokomponentti puuttuu");
        }
    }

    public void TurnOn()
    {
        lampLight.enabled = true;
    }
    public void TurnOff()
    {
        lampLight.enabled = true;
        Debug.Log("Lamppu: P‰‰ll‰");
    }
    void Update()
    {

    }
}