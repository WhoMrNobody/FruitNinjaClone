using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    [SerializeField] GameObject slicedFruitPrefab;
    public float explosionRadius = 5f;
    public int scoreAmount = 3;

    // Update is called once per frame
    void Update()
    {
       
    }

    void CreateSlincedFruit(){

        GameObject instantiate = Instantiate(slicedFruitPrefab, transform.position, transform.rotation);

        Rigidbody[] insGameObjectRb = instantiate.GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody rigidbody in insGameObjectRb)
        {
            rigidbody.transform.rotation = Random.rotation;
            rigidbody.AddExplosionForce(Random.Range(500, 1000), transform.position, explosionRadius);
        }
        FindObjectOfType<GameManager>().IncreaseScore(scoreAmount);
        Destroy(instantiate.gameObject, 5f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        
        BladeController bController = other.GetComponent<BladeController>();

        if(!bController) return;

        CreateSlincedFruit();
    }
}
