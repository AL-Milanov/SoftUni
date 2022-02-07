using CustomList;

var list = new MyList<string>();

for (int i = 0; i < 17; i++)
{
    list.Add($"element : {i}");
}

list.Remove($"element : {19}");
Console.WriteLine(list.Count);

foreach (var item in list)
{
    Console.WriteLine(item);
}
