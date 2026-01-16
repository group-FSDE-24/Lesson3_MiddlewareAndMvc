// See https://aka.ms/new-console-template for more information
using Lesson2_Middleware.Hosts.Concrete;

var host = new WebHost(27001);

host.UseStartUp<StartUp>();

host.Run();