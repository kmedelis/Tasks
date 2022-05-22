Random rand = new Random();

Console.WriteLine("Pleace select the number of available destinatinos (0-n):");
var destinations = Int32.Parse(Console.ReadLine());

int[] destinationsArr = new int[destinations+1];

Console.WriteLine("Please the number for destination selection strategy, round robin (1) or random (2): ");
var strategy = Int32.Parse(Console.ReadLine());

Console.WriteLine("Please enter the amount of consecutive loads going to the same destination");
var consectuve = Int32.Parse(Console.ReadLine());

Console.WriteLine("Please enter the failure rate (from 0 to 100): ");
var failure = Int32.Parse(Console.ReadLine());

Console.WriteLine("Please enter the total amount of loads:");
var loads = Int32.Parse(Console.ReadLine());

bool work = true;

if (strategy == 1)
{
    while (work)
    {
        for (var i = 1; i < destinations + 1; i++)
        {
            for (int j = 0; j < consectuve; j++)
            {
                if (loads <= 0)
                {
                    work = false;
                    break;
                }
                var success = rand.Next(0, 101);
                loads -= 1;
                if (success >= failure)
                {
                    destinationsArr[i] = destinationsArr[i] + 1;
                    Console.WriteLine($"The package has been successfuly delivered to the destination {i}");
                }
                else
                {
                    destinationsArr[0] = destinationsArr[0] + 1;
                    Console.WriteLine($"The package failed and has been delivered to the destination 0");
                }
            }
        }
    }
}
if (strategy == 2)
{
    while (work)
    {
        int i = rand.Next(1, destinations + 1);
        for (int j = 0; j < consectuve; j++)
        {
            if (loads <= 0)
            {
                work = false;
                break;
            }
            var success = rand.Next(0, 101);
            loads -= 1;
            if (success >= failure)
            {
                destinationsArr[i] = destinationsArr[i] + 1;
                Console.WriteLine($"The package has been successfuly delivered to the destination {i}");
            }
            else
            {
                destinationsArr[0] = destinationsArr[0] + 1;
                Console.WriteLine($"The package failed and has been delivered to the destination 0");
            }
        }
    }
}


for (int i = 0; i < destinationsArr.Length; i++)
{
    Console.WriteLine($"The amount of loads delivered to the destination {i} is {destinationsArr[i]}");
}