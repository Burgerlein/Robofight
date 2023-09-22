using Robofight;

var Robot1 = new Robot() { Name = "Tim", HealthPoints = 100, Damage = 10};
var Robot2 = new Robot() { Name = "Ian", HealthPoints = 100, Damage = 10};

var Robos = new List<Robot>(){Robot1, Robot2};

while (Robot1.IsAlive && Robot2.IsAlive)
{
    Random rnd = new Random();
    int num1 = rnd.Next(2);
    int num2 = rnd.Next(2);
    while (num2 == num1)
    {
        num2 = rnd.Next(2);
    }
    Robos[num1].Attack(Robos[num2]);
    Console.WriteLine(Robos[num1].Name + " hat " + Robos[num2].Name + " schaden in der Höhe von " + Robos[num1].Damage + " hinzgefügt und hat noch " + Robos[num2].HealthPoints + " Leben");
}

var winner = Robot2.IsAlive ? Robot2.Name : Robot1.Name;
Console.WriteLine(winner + " hat gewonnen");

