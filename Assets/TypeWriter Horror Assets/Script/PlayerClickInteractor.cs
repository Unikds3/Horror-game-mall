using UnityEngine;

public class PlayerClickInteractor : MonoBehaviour
{
    public float interactDistance = 5f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = new Ray(transform.position, transform.forward);

            if (Physics.Raycast(ray, out RaycastHit hit, interactDistance))
            {
                TypewriterClickToFocus typewriter = hit.collider.GetComponentInParent<TypewriterClickToFocus>();

                if (typewriter != null)
                {
                    typewriter.Focus();
                }
            }
        }
    }
}