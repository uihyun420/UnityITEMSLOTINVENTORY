using UnityEditor.Overlays;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyWindow : GenericWindow
{
    public int index = 1;
    public ToggleGroup toggleGroup;
    public Toggle[] toggles;

    public override void Open()
    {
        base.Open();
        index = SaveLoadManager.Data.SelectedDifficultyIndex;
        toggles[index].isOn = true;
        Debug.Log("오픈 왜 안돼");
    }


    public void OnToggle()
    {
        for(int i = 0; i < toggles.Length; i++)
        {
            if (toggles[i].isOn)
            {
                var saveData = SaveLoadManager.Data;
                if(saveData != null)
                {
                    saveData.SelectedDifficultyIndex = i;
                    SaveLoadManager.Save();
                }
                Debug.Log(i);
                break;
            }
        }
    }
    



    public void OnClickEasy(bool value)
    {
        if(value)
        {
            Debug.Log("이지모드");
        }
        
    }
    public void OnClickMiddle(bool value)
    {
        if (value)
        {
            Debug.Log("중간모드");
        }
    }
    public void OnClickHard(bool value)
    {
        if (value)
        {
            Debug.Log("하드모드");
        }
    }
}
