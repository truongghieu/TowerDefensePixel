using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    
 
    [SerializeField] private TextMeshProUGUI goldText;
    [SerializeField] private TextMeshProUGUI healthText;
   

    
  
    void Update()
    {
        updateText();
    
    }


    void updateText(){
        goldText.text = GameManager.instance.Gold.ToString()+"$";
        healthText.text = GameManager.instance.Health.ToString() + "♥";
    }
    
}
