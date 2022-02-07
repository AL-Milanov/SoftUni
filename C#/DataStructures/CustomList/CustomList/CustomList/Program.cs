using CustomList;


var list = new MyList<string>();

for (int i = 0; i < 17; i++)
{
    list.Add($"element : {i}");
}

for (int i = 0; i < list.Count; i++)
{
    Console.WriteLine(list[i]);
}

list[1] = "hiii";

Console.WriteLine("-----------------------------------------------------------");

foreach (var item in list)
{
    Console.WriteLine(item);
}
