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

    private void Awake() {
        /* Hier wird ueberprueft, ob bereits eine Instanz von ScoreManager existiert
           Falls nicht, wird diese Instanz als Singleton festgelegt
           Falls ja und es ist nicht diese Instanz, wird diese Instanz zerstoert */
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject); // Punkteleiste bleibt ueber verschiedene Szenen hinweg bestehen und wird nicht zurueckgesetzt, wenn ein neues Level geladen wird
        } else if (instance != this) {
            Destroy(gameObject);
        }
    }

    // Funktion, um den Slider in der Szene zu finden und zu referenzieren
    public void FindScoreSlider() {
        scoreSlider = GameObject.FindObjectOfType<Slider>();
    }

    // Getter-Methode, um den aktuellen Punktestand zurueckzugeben
    public int GetScore() {
        return score;
    }

    // Punktestand wird um einen bestimmten Betrag erhoeht und Punkteleiste wird aktualisiert
    public void AddScore(int scoreToAdd) {
        score += scoreToAdd;
        UpdateScoreSlider();
    }

    // Punktestand wird zurueckgesetzt und Punkteleiste wird aktualisiert
    public void ResetScore() {
        score = 0;
        UpdateScoreSlider();
    }

    // Aktualisiert die Position des Sliders basierend auf der aktuellen Gesamtpunktzahl
    public void UpdateScoreSlider() {
        scoreSlider.value = score;
    }
}
