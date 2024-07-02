using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class door : MonoBehaviour
{
    [SerializeField] BoxCollider2D boxCollider2D;
    private basevalue basevalue;
    private void Awake()
    {
        basevalue = GetComponent<basevalue>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
