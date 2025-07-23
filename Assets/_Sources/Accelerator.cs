using UnityEngine;

public class Accelerator : Item
{
    [SerializeField] private int _countAcceleration;
    [SerializeField] private PrometeoCarController _carController;
    
    public override void Activate()
    {
        _carController.maxSpeed += _countAcceleration;
        
        Consume();
    }
}