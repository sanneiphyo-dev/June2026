// See https://aka.ms/new-console-template for more information
using June2026.ConsoleApp3;

Console.WriteLine("Hello, World!");

AdoDotNetService service = new AdoDotNetService();

//service.ReadWithDataAdapter();
service.ReadExecuteReader();

