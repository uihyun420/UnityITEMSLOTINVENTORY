using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using SaveDataVC = SaveDataV3; // 현재 버젼으로 

public class SaveLoadManager
{
    public static int SaveDataVersion { get; } = 3; // 현재 버젼

    public static SaveDataVC Data { get; set; } = new SaveDataVC();

    private static readonly string[] SaveFileName =
    {
        "SaveAuto.json",
        "Save1.json",
        "Save2.json",
        "Save3.json",
    };

    public static string SaveDirectory => $"{Application.persistentDataPath}/Save";

    private static JsonSerializerSettings settings = new JsonSerializerSettings()
    {
        Formatting = Formatting.Indented,
        TypeNameHandling = TypeNameHandling.All,
    };


    public static bool Save(int slot = 0)
    {
        if (Data == null || slot < 0 || slot >= SaveFileName.Length)
            return false;

        try
        {
            if (!Directory.Exists(SaveDirectory))
            {
                Directory.CreateDirectory(SaveDirectory);
            }

            var path = Path.Combine(SaveDirectory, SaveFileName[slot]);
            var json = JsonConvert.SerializeObject(Data, settings);
            File.WriteAllText(path, json);
            return true;  
        }
        catch
        {
            Debug.Log("Save 예외 발생");
            return false;
        }
    }

    public static bool Load(int slot = 0)
    {
        if (slot < 0 || slot >= SaveFileName.Length)
            return false;

        var path = Path.Combine(SaveDirectory, SaveFileName[slot]);
        if (!File.Exists(path))
            return false;

        try
        {
            // 바이트 배열로 바꾸고 스트링을 바이너리모드로 
            // 압축하거나 암호화 해줘야함 C# 라이브러리에 있는 걸 저장하고 
            // 로드 할때는 역으로 
            // 키가 필요함(바이트 배열)
            var json = File.ReadAllText(path);
            var dataSave = JsonConvert.DeserializeObject<SaveData>(json, settings);
            



            while(dataSave.Version < SaveDataVersion) 
            {
                dataSave = dataSave.VersionUp();
            }

            Data = dataSave as SaveDataVC;
            return true;
        }
        catch
        {
            Debug.Log("Load 예외 발생");
            return false;
        }
    }
}
