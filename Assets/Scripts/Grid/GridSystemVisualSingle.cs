using UnityEngine;

namespace Grid
{
    /// <summary>
    /// La classe GridSystemVisualSingle gère l'affichage visuel d'une seule position de la grille dans le monde du jeu.
    /// Elle contrôle l'activation et la désactivation du MeshRenderer pour afficher ou masquer la position de la grille.
    /// </summary>
    public class GridSystemVisualSingle : MonoBehaviour
    {
        /// <summary>
        /// Référence au MeshRenderer enfant utilisé pour afficher la position de la grille.
        /// </summary>
        private MeshRenderer _meshRenderer;

        private void Awake()
        {
            // Récupération du MeshRenderer depuis les enfants du GameObject.
            _meshRenderer = GetComponentInChildren<MeshRenderer>();
        }

        /// <summary>
        /// Active le MeshRenderer pour afficher la position de la grille.
        /// </summary>
        public void Show()
        {
            _meshRenderer.enabled = true;
        }

        /// <summary>
        /// Désactive le MeshRenderer pour masquer la position de la grille.
        /// </summary>
        public void Hide()
        {
            _meshRenderer.enabled = false;
        }
    }
}