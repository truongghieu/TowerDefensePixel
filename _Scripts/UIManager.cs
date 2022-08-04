using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    
 
    [SerializeField] private TextMeshProUGUI goldText;

    void Update()
    {
        updateText();
    }


    void updateText(){
        goldText.text = GameManager.instance.Gold.ToString();
    }
}
