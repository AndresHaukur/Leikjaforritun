using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// þessi klasa er notað til að uppfæra ammo count í UI
/// er að nota singleton pattern til að geta notað þetta í öðrum klasa sem ekki eru children af þessum
/// </summary>
public class UIAmmoCount : MonoBehaviour 
{
	public static UIAmmoCount Instance { get; private set;}

	public Text countText;
	
	// notað fyrir initialization
	void Awake ()
	{
		Instance = this;
	}

	public void SetAmmo(int count, int max)
	{
		countText.text = "x" + count + "/" + max;
	}
}
