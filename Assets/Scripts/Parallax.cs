using UnityEngine;

public class Parallax : MonoBehaviour
{
    private MeshRenderer meshRenderer;

    public float animationSpeed = 2f;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void FixedUpdate()
    {
        meshRenderer.material.mainTextureOffset += new Vector2(animationSpeed * Time.fixedDeltaTime, 0);
    }
}
