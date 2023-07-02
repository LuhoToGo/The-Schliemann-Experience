using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // Singleton-Instanz des ScoreManagers, damit es von anderen Skripten aufgerufen werden kann
    public static ScoreManager instance;

    // UI-Slider, der den Punktestand repraesentiert
    public Slider scoreSlider;

    // Die aktuelle Punktzahl
    private int score;

    private void Awake()
    {
        /* Hier wird ueberprueft, ob bereits eine Instanz von ScoreManager existiert
           Falls nicht, wird diese Instanz als Singleton festgelegt
           Falls ja und es ist nicht diese Instanz, wird diese Instanz zerstoert */
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Punktestand wird um einen bestimmten Betrag erhoeht und Punkteleiste wird aktualisiert
    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        UpdateScoreSlider();
    }

    // Aktualisiert die Position des Sliders basierend auf der aktuellen Gesamtpunktzahl
    private void UpdateScoreSlider()
    {
        scoreSlider.value = score;
    }
}
