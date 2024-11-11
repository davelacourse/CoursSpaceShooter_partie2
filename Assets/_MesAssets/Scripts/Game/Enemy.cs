using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _points = 100;



    private void Start()
    {

    }

    void Update()
    {
        //D�place l'ennemi vers le bas et s'il sort de l'�cran le replace en
        //haut de la sc�ne � une position al�atoire en X
        DeplacementEnnemi();
     
    }

    private void DeplacementEnnemi()
    {
        transform.Translate(Vector3.down * Time.deltaTime * GameManager.Instance.VitesseEnnemi);
        if (transform.position.y <= -5f)
        {
            float randomX = Random.Range(-8.17f, 8.17f);
            transform.position = new Vector3(randomX, 8f, 0f);
        }
    }

    // G�re les collisions entre les ennemis et les lasers/joueur
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Si la collision survient avec le joueur
        if (other.tag == "Player")
        {
            //R�cup�rer la classe Player afin d'acc�der aux m�thodes publiques
            Player player = other.transform.GetComponent<Player>();
            player.Degats();  // Appeler la m�thode d�gats du joueur
            Destroy(this.gameObject); // D�truire l'objet ennemi
          
            
        }
        // Si la collision se produit avec un laser
        else if(other.tag == "Laser")
        {
            // D�truit l'ennemi et le laser
            
            Destroy(other.gameObject);
            Destroy(this.gameObject); // D�truire l'objet ennemi
            GameManager.Instance.AjouterScore(_points); // Appelle la m�thode dans la classe UIManger pour augmenter le pointage
            
        }
    }
}
