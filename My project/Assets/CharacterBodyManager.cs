using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBodyManager : MonoBehaviour
{
    [SerializeField] private GameObject _character;
    [SerializeField] private GameObject _head;
    [SerializeField] private GameObject _body;



    [Range(1, 10)] public float rotCorrectSpeed = 2;

    private void Start()
    {
        Vector2 _headPos = _head.transform.position;
        Vector2 _bodyPos = _body.transform.position;
        float _headToBodyDistInitial = Mathf.Sqrt(Mathf.Pow(_bodyPos[0] - _headPos[0], 2) + Mathf.Pow(_bodyPos[1] - _headPos[1],2)); // Pythagorean baybeehh!
    }

    private void FixedUpdate()
    {
        BodyStablizer();
        HeadStablizer();
        
    }

    private void BodyStablizer()
    {
        float rot = _character.GetComponent<Rigidbody2D>().rotation;

        Debug.Log(rot + " correcting with " + rot/rotCorrectSpeed);

        if (rot != 0)
        {

            _character.GetComponent<Rigidbody2D>().rotation = rot / rotCorrectSpeed;
        }
    }

    private void HeadStablizer()
    {
        Vector2 _headPos = _head.transform.position;
        Vector2 _bodyPos = _body.transform.position;

        float _headToBodyDist = Mathf.Sqrt(Mathf.Pow(_bodyPos[0] - _headPos[0], 2) + Mathf.Pow(_bodyPos[1] - _headPos[1], 2)); // Pythagorean baybeehh!

        float _xDif = _headPos[0] - _bodyPos[0];
        float _yDif = _headPos[1] - _bodyPos[1];

        float slope = _yDif / _xDif;

        //if (slope < Mathf.Infinity)
        //{
        //    _head.transform.Translate(new Vector2(_xDif / rotCorrectSpeed, _yDif / rotCorrectSpeed));
        //}

        //if (slope > Mathf.Infinity)
        //{
        //    _head.transform.Translate(new Vector2(_xDif / rotCorrectSpeed, _yDif / rotCorrectSpeed));

        //}
    }
}
