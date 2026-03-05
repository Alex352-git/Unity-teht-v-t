using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    // Referenssi TMP_Dropdown-komponenttiin hyppyn‰pp‰imen valitsemiseksi
    [SerializeField] TMP_Dropdown jumpKeyInput;

    // Referenssi Slider-komponenttiin ‰‰nenvoimakkuuden s‰‰t‰miseksi
    [SerializeField] Slider volumeSlider;

    // Referenssi Slider-komponenttiin hiiren herkkyyden s‰‰t‰miseksi
    [SerializeField] Slider sensitivitySlider;

    // Referenssi TMP_Dropdown-komponenttiin grafiikka-asetusten s‰‰t‰miseksi
    [SerializeField] TMP_Dropdown graphicsDropdown;

    private void Start()
    {
        // Lataa hyppyn‰pp‰imen asetus
        jumpKeyInput.value = PlayerPrefs.GetInt("JumpKey", 0);

        // Lataa ‰‰nenvoimakkuus
        volumeSlider.value = PlayerPrefs.GetFloat("Volume", 0.5f);

        // Lataa hiiren herkkyys
        sensitivitySlider.value = PlayerPrefs.GetFloat("Sensitivity", 1.0f);

        // Lataa grafiikka-asetus
        graphicsDropdown.value = PlayerPrefs.GetInt("Graphics", 1);
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetInt("JumpKey", jumpKeyInput.value);
        PlayerPrefs.SetFloat("Volume", volumeSlider.value);
        PlayerPrefs.SetFloat("Sensitivity", sensitivitySlider.value);
        PlayerPrefs.SetInt("Graphics", graphicsDropdown.value);

        PlayerPrefs.Save();
    }

    public void ResetSettings()
    {
        // Poistaa kaikki tallennetut PlayerPrefs-arvot
        PlayerPrefs.DeleteAll();

        // Resetoi UI-komponentit oletusarvoihin
        jumpKeyInput.value = 0;
        volumeSlider.value = 0.5f;
        sensitivitySlider.value = 1.0f;
        graphicsDropdown.value = 1;

        PlayerPrefs.Save();
    }
}
