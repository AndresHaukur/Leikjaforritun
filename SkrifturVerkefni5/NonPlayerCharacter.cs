using UnityEngine;

/// <summary>
/// þessi scripta er tengd NonPlayerCharacter objectinu sem er sett á skjáinn og þegar Ruby snertir það þá tekur hún skaða.
/// playerinn getur snert NonPlayerCharacter objectið og þá kemur upp textabox sem segir "Hello World".
/// (þetta er bara til að sýna hvernig það virkar)
/// </summary>
public class NonPlayerCharacter : MonoBehaviour
{
    public float displayTime = 4.0f;
    public GameObject dialogBox;
    float timerDisplay;
    
    void Start()
    {
        dialogBox.SetActive(false);
        timerDisplay = -1.0f;
    }

    void Update()
    {
        if (timerDisplay >= 0)
        {
            timerDisplay -= Time.deltaTime;
            if (timerDisplay < 0)
            {
                dialogBox.SetActive(false);
            }
        }
    }
    
    public void DisplayDialog()
    {
        timerDisplay = displayTime;
        dialogBox.SetActive(true);
    }
}
