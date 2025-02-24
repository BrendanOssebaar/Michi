using System.Dynamic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    private bool _canInteract;
    private gameObject _other;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision Other)
    {
        _other = Other.gameObject;
        Other.gameObject.getComponent<Interactor>();
        _canInteract = true;
    }

    void OnCollisionExit(Collision Other)
    {
        if(Other.gameObject = _other)
        {
            _canInteract = false;
            _other = null;
        }
        
    }

}
