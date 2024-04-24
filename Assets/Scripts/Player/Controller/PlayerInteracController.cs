using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteracController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody2D;
    [SerializeField] private float offsetDistance = 1f;
    [SerializeField] private float sizeOfInteractableArea = 1.2f;
    [SerializeField] private Player player;
    [SerializeReference] HighLightController highLightController;
    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Checked();
    }
    public void InputUseInteractable(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Interac();
        }
    }
    private void Interac()
    {
        Vector2 position = rigidbody2D.position + player.lastVelocity * offsetDistance;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);
        foreach (Collider2D collider in colliders)
        {
            Interactable hit = collider.GetComponent<Interactable>();
            if (hit != null)
            {
                hit.Interact(player);
                break;
            }
        }
    }
    private void Checked()
    {
        Vector2 position = rigidbody2D.position + player.lastVelocity * offsetDistance;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);
        foreach (Collider2D collider in colliders)
        {
            Interactable hit = collider.GetComponent<Interactable>();
            if (hit != null)
            {
                highLightController.HighLight(hit.gameObject);
                return;
            }
        }
        highLightController.Hide();
    }
}
