using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class PlayerConf : MonoBehaviour {
    [SerializeField] Slider slider;
    [SerializeField] TMP_InputField inputField;
    [SerializeField] TMP_Text fuelText;

    string dataFilePath = "datos.json";

    void Start() {
        ReadData();
    }

    public void SaveData() {
        PlayerData playerData = new PlayerData(inputField.text, slider.value);

        string jsonData = JsonUtility.ToJson(playerData, true);
        File.WriteAllText(dataFilePath, jsonData);
    }

    public void ReadData() {
        if (File.Exists(dataFilePath)) {
            string jsonData = File.ReadAllText(dataFilePath);
            PlayerData playerData = JsonUtility.FromJson<PlayerData>(jsonData);
            SetData(playerData);
        }
    }

    public void SetData(PlayerData playerData) {
        inputField.text = playerData.playerName;
        slider.value = playerData.fuelQuantity;
    }

    public void UpdateFuelText() {
        fuelText.text = slider.value.ToString();
    }
}