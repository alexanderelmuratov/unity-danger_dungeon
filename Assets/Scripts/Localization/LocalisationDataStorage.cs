using System;
using UnityEngine;

[CreateAssetMenu(fileName = "LocalisationStorage")]
public class LocalisationDataStorage : ScriptableObject
{
    public LocalizationData[] localizationData;
}

[Serializable]
public class LocalizationData
{
    public string key;
    public Localization[] localizations;
}

[Serializable]
public class Localization
{
    public Language language;
    public string translation;
}

public enum Language
{
    en,
    ua,
    pl,
    fr
}
