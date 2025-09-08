using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[Serializable]
public abstract class SaveData 
{
    public int Version { get; protected set; }

    public abstract SaveData VersionUp();
}


[Serializable]
public class SaveDataV1 : SaveData
{
    public string PlayerName { get; set; } = string.Empty;
    public SaveDataV1()
    {
        Version = 1;
    }

    public override SaveData VersionUp()
    {
        var saveData = new SaveDataV2();
        saveData.Name = PlayerName;
        saveData.Gold = 0;
        return saveData;
    }
}

public class SaveDataV2 : SaveData
{
    public string Name { get; set; } = string.Empty;
    public int Gold;

    public SaveDataV2()
    {
        Version = 2;
    }

    public override SaveData VersionUp()
    {
        var saveData = new SaveDataV3();
        saveData.Name = Name;
        saveData.Gold = Gold;

        return saveData;
    }
}

public class SaveDataV3 : SaveData
{
    public string Name { get; set; } = string.Empty;
    public List<SaveItemData> ItemList = new List<SaveItemData>();
    public int Gold;


    public SaveDataV3()
    {
        Version = 3;
        ItemList = new List<SaveItemData>();
    }


    public override SaveData VersionUp()
    {
        throw new NotImplementedException();
    }


}


public class SaveDataV4 : SaveData
{
    public int SelectedDifficultyIndex;
    public SaveDataV4()
    {
        Version = 4;      
    }
    public override SaveData VersionUp()
    {
        throw new NotImplementedException();
    }
}

