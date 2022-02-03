using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTest : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    [SerializeField] private GameObject Ninja;
    private Vector2 _currentPosition;

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _currentPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Ninja.transform.position - transform.position) * Time.deltaTime;
    }
}
