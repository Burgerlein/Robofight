using Robofight;

Console.WriteLine("Spiel wird gestartet!");
Console.WriteLine("Roboter werden geladen ...");

GameManger gamerGameManger = new GameManger();
var robos = gamerGameManger.AddPlayer();
var robot1 = robos[0];
var robot2 = robos[1];
Console.Clear();
Console.WriteLine(robot1.Name + " geht in den Kampf mit einem " + robot1.Weapon.Name);
Console.WriteLine(robot2.Name + " geht in den Kampf mit einem " + robot2.Weapon.Name);

var roundNumber = 1;
round();
while (robot1.IsAlive && robot2.IsAlive)
{
    Console.WriteLine("[N] für nexte Runde | [F] um die nächsten Fünf runden zu skippen | [A] um zum ende zu springen ");
    string roundManger = Console.ReadLine();
    Console.Clear();
    if (roundManger == "n" || roundManger == "N")
    {
        round();
        roundNumber++;
    } else if (roundManger == "f" || roundManger == "F")
    {
        for (int i = 1; i <= 5; i++)
        {
            round();
            roundNumber++;
        }
    } else if (roundManger == "a" || roundManger == "A")
    {
        while (robot1.IsAlive && robot2.IsAlive)
        {
            round();
            roundNumber++;
        }
    }
}

void round()
{        
    Console.WriteLine("____________________");
    Console.WriteLine("Runde " + roundNumber + ":");
    Random rnd = new Random();
    int num1 = rnd.Next(2);
    int num2 = rnd.Next(2);
    while (num2 == num1)
    {
        num2 = rnd.Next(2);
    }
    Console.WriteLine(robos[num1].Name + " greift " + robos[num2].Name + " an");
    var totalDamage = robos[num1].Attack(robos[num2]);
    Console.WriteLine(robos[num1].Name + " hat noch " + robos[num1].HealthPoints + " Leben");
    Console.WriteLine(robos[num2].Name + " hat noch " + robos[num2].HealthPoints + " Leben");
    Console.WriteLine("____________________");

}

var winner = robot2.IsAlive ? robot2.Name : robot1.Name;
Console.WriteLine("");
Console.WriteLine("");
Console.WriteLine(winner + " hat gewonnen");