using UnityEngine;
using static Unity.VisualScripting.Icons;

public enum Languages
{
    Korean,
    English,
    Japanese,
}

public static class DataTableIds
{
    public static readonly string[] StringTableIds =
    {
        "StringTableKr",
        "StringTableEn",
        "StringTableJp",
    };
    public static string String => StringTableIds[(int)Variables.Language];

    public static readonly string Item = "ItemTable";
}


public static class Variables
{
    public static Languages Language = Languages.Korean;
}

