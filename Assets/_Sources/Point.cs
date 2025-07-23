using UnityEngine;

public class Point : Item
{
    [SerializeField] private int _countPoint;
    [SerializeField] private Wallet _wallet;
    
    public override void Activate()
    {
        _wallet.Add(_countPoint);
        
        Consume();
    }
}
