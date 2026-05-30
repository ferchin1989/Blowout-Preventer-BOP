using UnityEngine;

public class ControlTornillo : MonoBehaviour
{
    Animator anim;
    Renderer rend;
    Color colorOriginal;
    static ControlTornillo tornilloSeleccionado; 

    void OnMouseDown()
    {
        anim.SetTrigger("girarTuerca");
        if(rend != null)
        rend.material.color = Color.blue;

        if (tornilloSeleccionado != null && tornilloSeleccionado != this)
        {
            tornilloSeleccionado.rend.material.color = tornilloSeleccionado.colorOriginal;
        }
        tornilloSeleccionado = this;
        controlSecuencia.instancia.VerificarSecuencia(this);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake()
    {
        anim = GetComponent<Animator>();
        rend = GetComponentInChildren<Renderer>();
        if(rend != null)
        colorOriginal = rend.material.color;
    }
}
