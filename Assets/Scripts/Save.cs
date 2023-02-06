using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Save
{
    private const string BestTimeIdentifier = "BestTime";

    public static bool HasBestTime()
    {
        return PlayerPrefs.HasKey(BestTimeIdentifier);
    }

    public static float GetBestTime()
    {
        return PlayerPrefs.GetFloat(BestTimeIdentifier);
    }

    public static void SaveBestTime(float time)
    {
        PlayerPrefs.SetFloat(BestTimeIdentifier, time);
    }
}
