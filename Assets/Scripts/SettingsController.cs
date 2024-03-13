using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour {
    [SerializeField] Slider slider;
    [SerializeField] AudioSource audioSource;
    [SerializeField] Toggle toggle;

    void Start() {
        float savedVolume = PlayerPrefs.GetFloat("BackgroundMusicVolume", 0.5f);
        int savedMute = PlayerPrefs.GetInt("BackgroundMusicMute", 0);
        LoadVolume(savedVolume);
        LoadMute(savedMute);
    }
    void LoadVolume(float volume) {
        slider.value = volume;
        audioSource.volume = volume;
    }
    void LoadMute(int mute) {
        toggle.isOn = (mute == 1);
        audioSource.mute = !(mute == 1);
    }


    public void ChangeVolume() {
        audioSource.volume = slider.value;
        PlayerPrefs.SetFloat("BackgroundMusicVolume", audioSource.volume);
    }

    public void MuteMusic() {
        audioSource.mute = !toggle.isOn;
        PlayerPrefs.SetInt("BackgroundMusicMute", audioSource.mute == true ? 0 : 1);
    }

    public void ExitGame() {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #elif UNITY_STANDALONE_WIN
            Application.Quit();
        #endif
    }

    public void SaveSettings() { 
        PlayerPrefs.Save();
    }

}
