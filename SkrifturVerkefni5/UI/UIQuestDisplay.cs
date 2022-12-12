using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// þessi klasa er notað til að uppfæra texta í UI
/// er að nota singleton pattern til að geta notað þetta í öðrum klasa sem ekki eru children af þessum
/// </summary>
public class UIQuestDisplay : MonoBehaviour
{
    public static UIQuestDisplay Instance { get; private set; }
    
    public Text questText;

    void Awake()
    {
        Instance = this;
        gameObject.SetActive(false);
    }

    public void Display()
    {
        gameObject.SetActive(true);
    }

    public void SetText(string text)
    {
        questText.text = text;
    }
}
