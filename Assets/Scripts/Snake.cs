using System.Collections;
using System.Collections.Generic; // necessary to define list
using UnityEngine;
using TMPro;
using UnityEngine.Rendering;

// Snake requires the GameObject to have a BoxCollider2D component
[RequireComponent(typeof(BoxCollider2D))]
public abstract class Snake : MonoBehaviour
{
    // snake position and movement variables
    public float speed = 8f;
    public float speedMultiplier = 1f;
    public Vector2Int direction = Vector2Int.up;
    protected Vector2Int input = Vector2Int.zero; 
    private Vector2 startPosition; // starting snake position

    // snake segment variables
    public Transform segmentPrefab; // snake body segments
    public int initialSize = 4; // snake length at start
    protected Color myColor;
    private Transform mySegment; // create a copy of the base segment prefab
    private List<Transform> segments = new List<Transform>();

    // manage calculation update rate
    private float deltaTime;
    private float nextUpdate;

    // track score
    public int pointCounter = 0;
    public int pointPenalty = 100;
    public int lifeCounter = 3; // max number of lives
    public TextMeshProUGUI scoreUI;
    public TextMeshProUGUI lifeUI;

     // manage invincibility frames
    private bool isInvulnerable = false;

    private void Awake()
    {
        lifeUI.text = lifeCounter.ToString();
    }

    private void Start()
    // initialise snake with head
    {
        // initialise start position with inspector value
        // ensure rounding to int
        startPosition = new Vector2(
            Mathf.RoundToInt(transform.position.x),
            Mathf.RoundToInt(transform.position.y)
        );
        
        deltaTime = 1f / (speed * speedMultiplier);
        nextUpdate = Time.time + deltaTime;

        myColor = GetComponent<SpriteRenderer>().color;

        ResetState();
    }

    private void Update()
    // Update() is called every frame
    {
        input = GetInput();
    }

    protected virtual Vector2Int GetInput() 
    // Enable different derived classes to get input differently
    {
        // only allow y movement if snake is pointing in x direction
        if (direction.x != 0) 
        {
            if (Input.GetKeyDown(KeyCode.W)) {
                input = Vector2Int.up;
            } else if (Input.GetKeyDown(KeyCode.S)) {
                input = Vector2Int.down;
            }
        } 
        // only allow x movement if snake is pointing in y direction
        else if (direction.y != 0)
        {
            if (Input.GetKeyDown(KeyCode.A)) {
                input = Vector2Int.left;
            } else if (Input.GetKeyDown(KeyCode.D)) {
                input = Vector2Int.right;
            }
        }

        return input;
    }

    private void FixedUpdate()
    // FixedUpdate() is called at fixed time intervals
    // frame-rate independent
    // important for physics (don't use Update())
    {
  
         // Wait until the next update before proceeding
        if (Time.time < nextUpdate) {
            return;
        }

        // Set the new direction based on the input
        if (input != Vector2Int.zero) {
            direction = input;
        }

        Move(direction);

         // Set the next update time based on the speed
        nextUpdate = Time.time + deltaTime;       
    }   

    private void Move(Vector2Int direction)
    {
        // move each segment from tail to head
        for (int i = segments.Count - 1; i > 0; i--){
            segments[i].position = segments[i - 1].position;
        }

        int x = Mathf.RoundToInt(transform.position.x) + direction.x;
        int y = Mathf.RoundToInt(transform.position.y) + direction.y;
        transform.position = new Vector2(x, y);

    }


    private void ResetState()
    {
        for (int i = 1; i < segments.Count; i++) {
            Destroy(segments[i].gameObject);
        }

        segments.Clear();
        segments.Add(transform); // add snake head

        for (int i = 1; i < initialSize; i++) {
            mySegment = Instantiate(segmentPrefab, startPosition, Quaternion.identity);
            mySegment.gameObject.GetComponent<SpriteRenderer>().color = myColor;
            segments.Add(mySegment);
        }

        transform.position = startPosition;
    }

    public bool Occupies(int x, int y)
    // check if a position is occupied by a snake segment
    {
        foreach (Transform segment in segments)
        {
            if (Mathf.RoundToInt(segment.position.x) == x &&
                Mathf.RoundToInt(segment.position.y) == y) {
                return true;
            }
        }

        return false;
    }



    private void OnTriggerEnter2D(Collider2D other)
    // actions when collision occurs
    {
        if (other.tag == "Food") {
            Grow();
            pointCounter += other.gameObject.GetComponent<Food>().points;
        }

        if (other.tag == "Obstacle") {
            ResetState();
            Color otherColor = other.gameObject.GetComponent<SpriteRenderer>().color;
            if (otherColor != myColor && isInvulnerable == false)
            {
                pointCounter -= pointPenalty;
                lifeCounter -= 1;
                lifeUI.text = lifeCounter.ToString();
                
                StartCoroutine(OnInvulnerable());
            }

        }

        scoreUI.text = pointCounter.ToString();
    }

    private IEnumerator OnInvulnerable()
    // coroutine to set period of invulnerability after collision
    {
        int penalty = pointPenalty; 
        isInvulnerable = true;
        pointPenalty = 0;

        // set invulnerability duration
        yield return new WaitForSeconds(0.5f); 

        pointPenalty = penalty;
        isInvulnerable = false;
    }

    private void Grow()
    {
        // clone prefab asset
        Transform segment = Instantiate(mySegment);
        // set position of new segment to the current snake tail
        segment.position = segments[segments.Count - 1].position;
        segments.Add(segment);
    }

}
 