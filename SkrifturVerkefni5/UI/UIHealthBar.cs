using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// þessi klasi sér um aðp stækka eða minnka health bar í UI
/// er að nota singleton pattern til að geta notað þetta í öðrum klasa sem ekki eru children af þessum
/// </summary>
public class UIHealthBar : MonoBehaviour
{
	public static UIHealthBar Instance { get; private set; }

	public Image bar;

	float originalSize;

	// notað fyrir initialization
	void Awake ()
	{
		Instance = this;
	}

	void OnEnable()
	{
		originalSize = bar.rectTransform.rect.width;
	}

	public void SetValue(float value)
	{		
		bar.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSize * value);
	}
}
