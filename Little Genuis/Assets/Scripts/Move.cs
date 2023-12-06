using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private Transform _form;
    private Vector2 _startPosition;
    private Vector2 _resetPosition;
    private bool _isMoving;
    private bool _isLevelComplete;

    void Awake()
    {
        _resetPosition = transform.position;
    }

    void Update()
    {
        if (_isLevelComplete == false && _isMoving)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(mousePosition.x - _startPosition.x, mousePosition.y - _startPosition.y);
        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0) && _isLevelComplete == false)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _startPosition = mousePosition - (Vector2)transform.position;
            _isMoving= true;
        }
    }

    private void OnMouseUp()
    {
        if (_isLevelComplete == false)
        {
            if (Mathf.Abs(transform.position.x - _form.position.x) <= 0.5f && 
                Mathf.Abs(transform.position.y - _form.position.y) <= 0.5f)
            {
                transform.position = _form.position;
                _isLevelComplete = true;
            }
            else
            {
                transform.localPosition = _resetPosition;
            }
        }

        _isMoving = false;
    }
}
