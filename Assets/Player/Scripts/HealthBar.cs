using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    PlayerStats stats;
    Text healthText;

    Image imgColor;

    void Start() {
        stats = GameObject.Find("PlayerKnight").GetComponent<PlayerStats>();
        healthText = GameObject.Find("HealthBarText").GetComponent<Text>();
        imgColor = GetComponent<Image>();
    }

    void Update() {
        healthText.text = stats.currentHealth.ToString()+"/"+ stats.maxHealth ;

        if (stats.currentHealth == 100) {
            imgColor.color = new Color32(0, 255, 0, 100);
        }

        if (stats.currentHealth <= 80) {
            imgColor.color= new Color32(0, 255, 80, 100);
        } 
        
        if (stats.currentHealth <= 60) {
            imgColor.color = new Color32(200, 200, 55, 100);
        }

        if (stats.currentHealth <= 40) {
            imgColor.color = new Color32(180, 130, 40, 100);
        }

        if (stats.currentHealth <= 20) {
            imgColor.color = new Color32(220, 40, 20, 100);
        }

    }
}
