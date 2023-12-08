using System;
using System.Collections.Generic;

public interface ILocalizationSystem
{
    Language CurrentLanguageKey { get; set; }
    event Action OnLanguageChangedEvent;

    string GetTranslation(string key);
}

public class LocalizationSystem : ILocalizationSystem
{
    public const string SaveKey = "current_language";

    private Dictionary<string, Dictionary<Language, string>> dictionary;

    private Language currentLanguageKey;
    public Language CurrentLanguageKey
    {
        get => currentLanguageKey;
        set
        {
            currentLanguageKey = value;
            OnLanguageChangedEvent?.Invoke();
        }
    }

    public event Action OnLanguageChangedEvent;

    public LocalizationSystem()
    {
        InitCurrentLanguage();
        OnLanguageChangedEvent += SaveLanguage;
        dictionary = new Dictionary<string, Dictionary<Language, string>>();

        var localizationData = Context.Instance.DataSystem.LocalizationData;

        foreach (var data in localizationData)
        {
            foreach (var localization in data.localizations)
            {
                if (!dictionary.ContainsKey(data.key))
                    dictionary.Add(data.key, new Dictionary<Language, string>());

                dictionary[data.key].Add(localization.language, localization.translation);
            }
        }
    }

    private void InitCurrentLanguage()
    {
        var currentLanguage = Context.Instance.SaveSystem.Load<CurrentLanguage>(SaveKey);

        if (currentLanguage == null)
            currentLanguage = new CurrentLanguage(Language.en);

        CurrentLanguageKey = currentLanguage.language;
    }

    private void SaveLanguage()
    {
        Context.Instance.SaveSystem.Save(SaveKey, new CurrentLanguage(CurrentLanguageKey));
    }

    public string GetTranslation(string key)
    {
        if (dictionary.ContainsKey(key))
            if (dictionary[key].ContainsKey(CurrentLanguageKey))
                return dictionary[key][CurrentLanguageKey];

        return key;
    }
}

public class CurrentLanguage
{
    public Language language;

    public CurrentLanguage(Language language)
    {
        this.language = language;
    }
}
