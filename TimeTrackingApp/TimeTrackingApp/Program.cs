// See https://aka.ms/new-console-template for more information
using TimeTracking.Services.Menu;

Console.Title = "        ***Time Tracking App***";
MenuService menuService = new();
menuService.StartApp();