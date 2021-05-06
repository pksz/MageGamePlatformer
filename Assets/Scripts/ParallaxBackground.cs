using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    Transform cameraTransform;
    Vector3 lastmovePosition;
    [SerializeField] Vector2 parallaxEffectMultiplier;
    private float textureUnitSizeX;
    private float textureUnitSizeY;
    public bool infiniteHorizontal = true;
    public bool infiniteVertical = false;

    private void Start()
    {
        cameraTransform = Camera.main.transform;
        lastmovePosition = cameraTransform.position;
        Sprite sprite = gameObject.GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        textureUnitSizeX = texture.width / sprite.pixelsPerUnit;
        textureUnitSizeY = texture.height / sprite.pixelsPerUnit;
    }
    void LateUpdate()
    {
        Vector3 deltaMovement = cameraTransform.position - lastmovePosition;
        transform.position += new Vector3(deltaMovement.x * parallaxEffectMultiplier.x, deltaMovement.y * parallaxEffectMultiplier.y);
        lastmovePosition = cameraTransform.position;


        if (infiniteHorizontal)
        {
            if (Mathf.Abs(cameraTransform.position.x - transform.position.x) >= textureUnitSizeX)
            {
                float offsetPositionX = (cameraTransform.position.x - transform.position.x) % textureUnitSizeX;
                transform.position = new Vector3(cameraTransform.position.x + offsetPositionX, transform.position.y);


            }
        }
        if (infiniteVertical)
        {
            if (Mathf.Abs(cameraTransform.position.y - transform.position.y) >= textureUnitSizeY)
            {
                float offsetPositionY = (cameraTransform.position.y - transform.position.y) % textureUnitSizeY;
                transform.position = new Vector3(cameraTransform.position.x + offsetPositionY, transform.position.x);


            }

        }
    }
}
