using System;
using TMPro;
using UnityEngine;

public class LocalizationSwitcher : MonoBehaviour
{
    [SerializeField] private string clickSfxKey;
    [SerializeField] private TextMeshProUGUI langText;
    private Language currentLanguage;

    private void Start()
    {
        currentLanguage = Context.Instance.LocalizationSystem.CurrentLanguageKey;
        UpdateButtonText();
    }

    private void UpdateButtonText()
    {
        langText.text = Context.Instance.LocalizationSystem.CurrentLanguageKey.ToString();
    }

    public void OnLanguageButtonClick()
    {
        currentLanguage = (Language)(((int)currentLanguage + 1) % Enum.GetNames(typeof(Language)).Length);
        Context.Instance.LocalizationSystem.CurrentLanguageKey = currentLanguage;
        Context.Instance.AudioSystem.PlaySFX(new AudioSettings(clickSfxKey, transform.position));
        UpdateButtonText();
    }
}
