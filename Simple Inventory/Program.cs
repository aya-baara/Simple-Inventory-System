using Simple_Inventory.DataBaseConnection;
using SimpleInventory;
using System;

MsSQLConnection.LoadConnection();
MongoDBConnection.LoadConnection(); 

var menu = new Menu();
menu.showMenu();