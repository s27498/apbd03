

using System.Collections.Generic;
using System.Text;

namespace apbd03
{
    public class Ship
    {
        private List<Container>? _containers = new List<Container>();
        private string name;

        private float speed { get; set; }

        private int maxContainerCount { get; set; }

        private float maxWeight { get; set; }


        private float currentWeight { get; set; }


        public Ship(string name, float speed, int maxContainerCount, float maxWeight)
        {
            this.name = name;
            this.speed = speed;
            this.maxContainerCount = maxContainerCount;
            currentWeight = CalculateWeight();
            this.maxWeight = maxWeight;

        }


        private float CalculateWeight()
        {
            float calculated = 0;
            foreach (Container container in _containers)
            {
                calculated += container.OwnWeight + container.CargoWeight;
            }

            calculated /= 1000;
            return calculated;
        }




        public void LoadShip(Container container)
        {

            if (currentWeight + (container.CargoWeight / 1000) + (container.OwnWeight / 1000) > maxWeight || _containers.Count > maxContainerCount)
            {
                Console.WriteLine("Cannot add this container, the ship will be too heavy");
                Console.WriteLine($"Current weight (tons): {currentWeight}");
            }
            else
            {
                _containers.Add(container);
                currentWeight = (int)CalculateWeight();
                Console.WriteLine("Container loaded: " + container);
                Console.WriteLine($"Current weight (tons): {currentWeight}");
            }

        }



        public void LoadShip(List<Container> containers)
        {
            foreach (Container container in containers)
            {
                if (currentWeight + (container.CargoWeight / 1000) + (container.OwnWeight / 1000) > maxWeight || _containers.Count > maxContainerCount)
                {
                    currentWeight = CalculateWeight();
                    Console.WriteLine("Cannot add this container, the ship will be too heavy");
                    Console.WriteLine($"Current weight (tons): {currentWeight}");
                }
                else
                {
                    _containers.Add(container);
                    currentWeight = CalculateWeight();
                    Console.WriteLine("Container loaded: " + container);
                    Console.WriteLine($"Current weight (tons): {currentWeight}");
                }


            }

            currentWeight = CalculateWeight();

        }

        public void RemoveContainerFromShip(Container container)
        {
            _containers.Remove(container);
            Console.WriteLine("Container removed: " + container);

            currentWeight = (int)CalculateWeight();
        }

        public void ReplaceContainer(string replacedSerialNumber, Container newContainer)
        {
            for (int i = 0; i < _containers.Count; i++)
            {
                if (_containers[i].SerialNumber.Equals(replacedSerialNumber))
                {
                    _containers[i] = newContainer;
                    return;
                }
            }


        }



        public override string ToString()
        {
            return $"Ship {name} ( "
                   + $"speed: {speed} knots, "
                   + $"Max container count: {maxContainerCount}, "
                   + $"Max weight: {maxWeight} tons )" +
                    "\nCONTENT: " + DisplayContainers(_containers);
        }

        public string DisplayContainers(List<Container>? containers)
        {
            if (containers == null || containers.Count == 0)
            {
                return "No containers.";
            }

            StringBuilder sb = new StringBuilder();
            foreach (Container container in containers)
            {
                sb.AppendLine(container.ToString());
            }

            return sb.ToString();
        }



        public void MoveContainerBetweenShips(Ship otherShip, string containerSerialNumber)
        {
            Container containerToMove = null;


            foreach (Container container in _containers)
            {
                if (container.SerialNumber.Equals(containerSerialNumber))
                {
                    containerToMove = container;
                    break;
                }
            }


            if (containerToMove != null)
            {

                if (otherShip.currentWeight + (containerToMove.CargoWeight / 1000) + (containerToMove.OwnWeight / 1000) > otherShip.maxWeight)
                {
                    Console.WriteLine("Cannot move this container, the target ship will be too heavy.");
                }
                else
                {

                    _containers.Remove(containerToMove);


                    otherShip._containers.Add(containerToMove);


                    currentWeight = (int)CalculateWeight();
                    otherShip.currentWeight = (int)otherShip.CalculateWeight();

                    Console.WriteLine($"Moved container with serial number {containerSerialNumber} to another ship.");
                }
            }
            else
            {
                Console.WriteLine($"Container with serial number {containerSerialNumber} not found on this ship.");
            }
        }





    }
}
