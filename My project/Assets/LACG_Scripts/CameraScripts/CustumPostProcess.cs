using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustumPostProcess : MonoBehaviour
{

    /// <summary>
    /// Efecto de pixel en el post processing
    /// </summary>
    /// 

    public Material mat;

    //Tomamos la imagen de la camara en tiempo real y la guardamos a una textura//

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, mat);
    }


}
