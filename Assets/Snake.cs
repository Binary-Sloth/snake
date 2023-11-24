
using System.Collections.Generic; // necessary to define list
using UnityEngine;

public class Snake : MonoBehaviour
{
    private Vector2 _direction = Vector2.right;
    // a Transform is like an object
    private List<Transform> _segments;
    public Transform segmentPrefab;


    private void Start()
    // initialise snake with head
    {
        _segments = new List<Transform>();
        _segments.Add(this.transform);
    }

    private void Update()
    // Update() is called every frame
    {
        if (Input.GetKeyDown(KeyCode.W)) {
            _direction = Vector2.up;
        } else if (Input.GetKeyDown(KeyCode.S)) {
            _direction = Vector2.down;
        } else if (Input.GetKeyDown(KeyCode.A)) {
            _direction = Vector2.left;
        } else if (Input.GetKeyDown(KeyCode.D)) {
            _direction = Vector2.right;
        }
    }

    private void FixedUpdate()
    // FixedUpdate() is called at fixed time intervals
    // frame-rate independent
    // important for physics (don't use Update())
    {
        // move each segment from tail to head
        for (int i = _segments.Count - 1; i > 0; i--){
            _segments[i].position = _segments[i - 1].position;
        }

        
        // 3D vector for position, even in 2D game
        this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x) + _direction.x,
            Mathf.Round(this.transform.position.y) + _direction.y,
            0.0f
        );
    }   

    private void Grow()
    {
        // clone prefab asset
        Transform segment = Instantiate(this.segmentPrefab);
        // set position of new segment to the current snake tail
        segment.position = _segments[_segments.Count - 1].position;
        _segments.Add(segment);
    }

    // action when collision occurs
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Food") {
            Grow();
        }
    }

}
 