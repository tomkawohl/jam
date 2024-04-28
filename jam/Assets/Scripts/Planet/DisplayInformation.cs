using UnityEngine;
using TMPro;

public class PlanetInfoUI : MonoBehaviour
{
    public TMP_Text planetNameText;
    public TMP_Text descriptionText;
    public TMP_Text pollutionText;

    private void Start()
    {
        // Assurez-vous que la fenêtre est désactivée au démarrage du jeu
        gameObject.SetActive(false);
    }

    public void UpdatePlanetInfo(string name, string description, float pollution)
    {
        // Mettez à jour les textes avec les nouvelles informations de la planète
        planetNameText.text = "Nom: " + name;
        descriptionText.text = "Description: " + description;

        // Créer une chaîne de texte avec différentes couleurs pour le niveau de pollution
        string pollutionColorText = "Niveau de pollution: ";
        if (pollution >= 100)
        {
            pollutionColorText += "<color=red>" + pollution.ToString() + "</color>";
        }
        else if (pollution > 50)
        {
            pollutionColorText += "<color=yellow>" + pollution.ToString() + "</color>";
        }
        else if (pollution > 0)
        {
            pollutionColorText += "<color=green>" + pollution.ToString() + "</color>";
        }

        pollutionText.text = pollutionColorText;
        pollutionText.color = Color.white; // Définir la couleur du texte entier en blanc
    }
}
