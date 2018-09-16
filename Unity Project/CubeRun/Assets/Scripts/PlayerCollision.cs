using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    public float cubeSize = 0.2f;
    public int cubesInRow = 5;

    bool hasExploded = false;
    float cubesPivotDistance;
    Vector3 cubesPivot;

    public float explosionForce = 20f;
    public float explosionRadius = 20f;
    public float explosionUpward = 1f;

    void Start()
    {
        //calculate pivot distance
        cubesPivotDistance = cubeSize * cubesInRow / 2;
        //use this value to create pivot vector)
        cubesPivot = new Vector3(cubesPivotDistance, cubesPivotDistance, cubesPivotDistance);
    }

    private void OnCollisionEnter(Collision collisionInfo)
    {
        // player hit an obstacle

        if (collisionInfo.collider.tag == "Obstacle")
        {
            if (!hasExploded)
            {
                FindObjectOfType<GameManager>().EndGame();

                Explode();
                hasExploded = true;
            }
        }

    }
    
    public void Explode()
    {

        GameObject allPieces = new GameObject();

        //loop 3 times to create 5x5x5 pieces in x,y,z coordinates
        for (int x = 0; x < cubesInRow; x++)
        {
            for (int y = 0; y < cubesInRow; y++)
            {
                for (int z = 0; z < cubesInRow; z++)
                {
                    GameObject newPiece = CreatePiece(x, y, z);
                    newPiece.transform.parent = allPieces.transform;

                }
            }
        }

        //position the little cubes in the same position of the cube
        allPieces.transform.position = gameObject.transform.position;
        allPieces.transform.rotation = gameObject.transform.rotation;

        //make object disappear
        gameObject.SetActive(false);

        // give the momentum of the cube to the little cubes
        GameObject[] pieces = GameObject.FindGameObjectsWithTag("piece");
        foreach (GameObject piece in pieces)
        {
            piece.GetComponent<Rigidbody>().AddForce(gameObject.GetComponent<Rigidbody>().velocity / 2, ForceMode.VelocityChange);
            piece.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, transform.position, explosionRadius, explosionUpward);
        }

    }

    GameObject CreatePiece(int x, int y, int z)
    {
        //create piece
        GameObject piece;
        piece = GameObject.CreatePrimitive(PrimitiveType.Cube);

        piece.tag = "piece";

        //set piece position and scale
        piece.transform.position = new Vector3(cubeSize * x, cubeSize * y, cubeSize * z) - cubesPivot;
        piece.transform.localScale = new Vector3(cubeSize, cubeSize, cubeSize);

        // set piece color
        piece.GetComponent<Renderer>().material.color = gameObject.GetComponent<Renderer>().material.color;

        //add rigidbody and set mass
        piece.AddComponent<Rigidbody>();
        piece.GetComponent<Rigidbody>().mass = cubeSize;
        
        return piece;
    }

}