using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class Item : MonoBehaviour
{
    [SerializeField] protected Button ActivateButton;
    [SerializeField] protected UITextChanger TextChanger;
    
    public event Action<int> CountChanged;
    
    public int Count { get; private set; }
    
    [field: SerializeField] public ItemType Type { get; private set; }

    private void OnEnable()
    {
        CountChanged += TextChanger.ChangeInt;
        ActivateButton.onClick.AddListener(Activate);
    }

    private void OnDisable()
    {
        CountChanged -= TextChanger.ChangeInt;
        ActivateButton.onClick.RemoveListener(Activate);
    }
    
    public abstract void Activate();

    public void Add(int count)
    {
        if(Count == 0)
            gameObject.SetActive(true);
        
        Count += count;
        CountChanged?.Invoke(Count);
    }

    protected void Consume()
    {
        if (Count - 1 < 0)
            return;
        
        Count--;
        CountChanged?.Invoke(Count);
        
        if (Count == 0)
            gameObject.SetActive(false);
    }
}