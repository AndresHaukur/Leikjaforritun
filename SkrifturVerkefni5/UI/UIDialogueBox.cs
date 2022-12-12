using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// þessi klasa er notað til að uppfæra texta og mynd í UI
/// er að nota singleton pattern til að geta notað þetta í öðrum klasa sem ekki eru children af þessum
/// </summary>
public class UIDialogueBox : MonoBehaviour
{
	public static UIDialogueBox Instance { get; private set; }
	
	public Image portrait;
	public TextMeshProUGUI text;

	void Awake()
	{
		Instance = this;
	}

	// notað fyrir initialization	
	void Start () 
	{
		// eytt út þegar þetta er notað í UI
		gameObject.SetActive(false);	
	}


	public void DisplayText(string content)
	{
		text.text = content;
	}

	public void DisplayPortrait(Sprite spr)
	{
		portrait.sprite = spr;
	}

	public void Show()
	{
		gameObject.SetActive(true);
	}
	
	public void Hide()
	{
		gameObject.SetActive(false);
	}
}
