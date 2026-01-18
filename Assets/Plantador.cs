using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.EventSystems;

public class Plantador : MonoBehaviour
{
    public List<GameObject> listaDePlantas;
    public ARRaycastManager raycastManager;
    
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private int indiceAtual = 0;
    
    // NOVA LISTA: Guarda as plantas que já colocamos no chão
    private List<GameObject> plantasNaCena = new List<GameObject>();

    void Update()
    {
        // Bloqueia clique se estiver tocando em botão (UI)
        if (EventSystem.current.IsPointerOverGameObject() || 
           (Input.touchCount > 0 && EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId)))
        {
            return;
        }

        bool tentouPlantar = false;
        Vector2 posicaoNaTela = Vector2.zero;

        // Lógica para Mouse (PC) e Toque (Celular)
        if (Input.GetMouseButtonDown(0))
        {
            tentouPlantar = true;
            posicaoNaTela = Input.mousePosition;
        }
        else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            tentouPlantar = true;
            posicaoNaTela = Input.GetTouch(0).position;
        }

        if (tentouPlantar)
        {
            if (raycastManager.Raycast(posicaoNaTela, hits, TrackableType.PlaneWithinPolygon))
            {
                Pose hitPose = hits[0].pose;
                
                // --- MUDANÇA AQUI ---
                // Criamos a planta e guardamos numa variável temporária
                GameObject novaPlanta = Instantiate(listaDePlantas[indiceAtual], hitPose.position, hitPose.rotation);
                
                // Adicionamos essa nova planta na nossa lista de controle
                plantasNaCena.Add(novaPlanta);
                // --------------------
            }
        }
    }

    public void MudarPlanta()
    {
        indiceAtual++;
        if (indiceAtual >= listaDePlantas.Count)
        {
            indiceAtual = 0;
        }
    }

    // --- NOVA FUNÇÃO PARA O BOTÃO REMOVER ---
    public void RemoverUltimaPlanta()
    {
        // Verifica se tem alguma planta para remover
        if (plantasNaCena.Count > 0)
        {
            // Pega o índice da última planta da lista
            int ultimoIndex = plantasNaCena.Count - 1;

            // Destrói o objeto lá na cena do jogo
            Destroy(plantasNaCena[ultimoIndex]);

            // Remove o objeto da nossa lista de controle
            plantasNaCena.RemoveAt(ultimoIndex);
        }
    }
}