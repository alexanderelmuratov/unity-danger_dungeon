using TMPro;
using UnityEngine;

public class LocalizedTextView : MonoBehaviour
{
    [SerializeField] private string key;
    [SerializeField] private TextMeshProUGUI localizedText;
    private object[] parameters;

    private void Start()
    {
        Context.Instance.LocalizationSystem.OnLanguageChangedEvent += DisplayLocalization;
        DisplayLocalization();
    }

    private void OnDestroy()
    {
        Context.Instance.LocalizationSystem.OnLanguageChangedEvent -= DisplayLocalization;
    }

    public void DisplayLocalization()
    {
        var translatedText = Context.Instance.LocalizationSystem.GetTranslation(key);

        if (parameters == null || parameters.Length == 0)
            localizedText.text = translatedText;
        else
            localizedText.text = string.Format(translatedText, parameters);
    }

    public void SetParameters(params object[] parameters)
    {
        this.parameters = parameters;
        DisplayLocalization();
    }
}
