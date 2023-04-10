using UnityEngine;
using TMPro;
using System.Collections;

public class TypeWriterEffect : MonoBehaviour
{
    [SerializeField] private float delayBetweenCharacters = 0.1f;
    private TMP_Text uiText;
    public string FullText { get; private set; }
    private bool isTyping;

    private void Awake()
    {
        uiText = GetComponent<TMP_Text>();
    }

    public void SetText(string text)
    {
        FullText = text;
        uiText.text = "";
        if (!isTyping)
        {
            StartCoroutine(ShowText());
        }
    }

    private IEnumerator ShowText()
    {
        isTyping = true;
        for (int i = 0; i < FullText.Length; i++)
        {
            uiText.text += FullText[i];
            yield return new WaitForSeconds(delayBetweenCharacters);
        }
        isTyping = false;
    }
    public void StopTyping()
{
    isTyping = false;
    StopAllCoroutines();
}

public void ResumeTyping()
{
    if (!isTyping)
    {
        StartCoroutine(ShowText());
    }
}
}



