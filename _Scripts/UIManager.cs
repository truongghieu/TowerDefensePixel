using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    
 
    [SerializeField] private TextMeshProUGUI goldText;
    [SerializeField] private Image HealthBar;
    private int MaxHealth;

    void Start(){
        MaxHealth = GameManager.instance.Health;
    }
    void Update()
    {
        updateText();
        UpdateSlider();
    }


    void updateText(){
        goldText.text = GameManager.instance.Gold.ToString()+"$";
    }
    void UpdateSlider(){
        HealthBar.fillAmount = (float)GameManager.instance.Health / MaxHealth ;
    }
}
