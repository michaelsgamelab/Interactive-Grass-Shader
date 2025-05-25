using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public bool RandomWalk;
    private Vector3 Dir;

    private void Awake()
    {
        InvokeRepeating(nameof(ChangeDirection), 0f, 1f);
    }

    void ChangeDirection()
    {
        Dir = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f));
    }

    private void Update()
    {
        if (!RandomWalk)
        {
            Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
            transform.position += input * speed * Time.fixedDeltaTime;
            return;
        }

        transform.position += Dir.normalized * speed * Time.fixedDeltaTime;
    }
}
