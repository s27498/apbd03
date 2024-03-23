using apbd03;

GasContainer gasContainer = new GasContainer(0, 10, 1000, 50, 20000, 450);

gasContainer.LoadContainer(10000);

LiquidContainer liquidContainer = new LiquidContainer(0, 23, 1500, 23, 20000, "safe");
liquidContainer.LoadContainer(10000);

RefrigeratedContainer refrigeratedContainer = new RefrigeratedContainer(10000, 12, 100, 30, 10000, "Bananas");

Ship ship = new Ship("Black Pearl", 100, 10, 30);

List<Container> list = new();

list.Add(refrigeratedContainer);
list.Add(gasContainer);
list.Add(liquidContainer);

ship.LoadShip(list);


Ship ship2 = new Ship("Titanic", 200, 10, 40);

ship.MoveContainerBetweenShips(ship2, "CON-C-4");

// ship.ReplaceContainer("CON-L-2", refrigeratedContainer);


Console.WriteLine(ship);
Console.WriteLine(ship2);
