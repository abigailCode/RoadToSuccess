using System;

[Serializable]
public class PlayerData {

    public string playerName;
    public float fuelQuantity;

    public PlayerData(string name, float fuel) {
        playerName = name;
        fuelQuantity = fuel;
    }
}

