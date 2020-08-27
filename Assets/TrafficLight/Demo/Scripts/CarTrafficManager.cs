using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CarTrafficManager : MonoBehaviour
{
    public Vehicle CarPrefab;
    public int CarLimit;
    public float Interval;
    public float DestroyPoint;

    private float _timer;
    private List<Vehicle> _cars = new List<Vehicle>();

    private void Update()
    {
        if (Time.time > _timer + Interval)
        {
            _timer = Time.time;
            spawnCar();
        }
        checkDestroy();
    }

    private void spawnCar()
    {
        if (_cars.Count < CarLimit)
        {
            int xPosition = Random.Range(0,100);
            Vector3 carPosition = new Vector3(xPosition >= 50?1:-1, transform.position.y, transform.position.z);
            Vehicle car = Instantiate<Vehicle>(CarPrefab, carPosition, Quaternion.identity);
            _cars.Add(car);
        }        
    }

    private void checkDestroy()
    {
        Vehicle[] carsForDestroy = _cars.Where(x => x.transform.position.z > DestroyPoint).ToArray();
        foreach (Vehicle car in carsForDestroy)
        {
            _cars.Remove(car);
            Destroy(car.gameObject);
        }
    }
}
