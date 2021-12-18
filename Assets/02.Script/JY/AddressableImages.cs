using System.Collections;
using System.Collections.Generic;
using Textures;
using UnityAASample;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;


public class AddressableImages : MonoBehaviour
{
    [SerializeField]
    Texture2D texture;
    public AssetReferenceAtlasedSprite addressableSprite;
    bool isCompleted = false;
    public DownloadManager dm;

    public void _ClickAddressableImages()
    {
        StartCoroutine(LoadImages());
    }

    IEnumerator LoadImages()
    {
        var image = GetComponent<Image>();
        TextureManager tm = GetComponent<TextureManager>();
        //yield return new WaitForSeconds(6);
        // Option A) Load atlas & take a sprite
        //  var asyncOperationHandle = addressableSprite.LoadAssetAsync<Sprite>();

        // Option B) Addressable asset key + subasset selection
        var asyncOperationHandle = Addressables.LoadAssetAsync<Sprite>("Atlas[001]");

        yield return asyncOperationHandle;
        image.sprite = asyncOperationHandle.Result;
        Debug.Log("asyncOperationHandle" + image.sprite);


        texture = ConvertSpriteToTexture2D(image.sprite);
        tm.worldTextures[0] = texture;
        tm.SetTextureTest();
        // Release at some point
        // yield return new WaitForSeconds(6);
        image.sprite = null;
        Addressables.Release(asyncOperationHandle);
    }


    public Texture2D ConvertSpriteToTexture2D(Sprite sprite)
    {

        try
        {
            if (sprite.rect.width != sprite.texture.width)
            {
                int x = Mathf.FloorToInt(sprite.textureRect.x);
                int y = Mathf.FloorToInt(sprite.textureRect.y);
                int width = Mathf.FloorToInt(sprite.textureRect.width);
                int height = Mathf.FloorToInt(sprite.textureRect.height);

                Texture2D newText = new Texture2D(width, height);
                Color[] newColors = sprite.texture.GetPixels(x, y, width, height);

                newText.SetPixels(newColors);
                newText.Apply();
                return newText;
            }
            else
            {
                return sprite.texture;
            }

        }
        catch
        {
            return sprite.texture;
        }


    }


}