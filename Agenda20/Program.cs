Console.WriteLine("Bienvenido a mi lista de Contactes");

//
//names, lastnames, addresses, telephones, emails, ages, bestfriend
bool runing = true;
List<int> ids = new List<int>();
Dictionary<int, string> names = new Dictionary<int, string>();
Dictionary<int, string> lastnames = new Dictionary<int, string>();
Dictionary<int, string> addresses = new Dictionary<int, string>();
Dictionary<int, string> telephones = new Dictionary<int, string>();
Dictionary<int, string> emails = new Dictionary<int, string>();
Dictionary<int, int> ages = new Dictionary<int, int>();
Dictionary<int, bool> bestFriends = new Dictionary<int, bool>();


while (runing)
{
    try
    {
        Console.WriteLine(@"1. Agregar Contacto     2. Ver Contactos    3. Buscar Contactos     4. Modificar Contacto    5. Eliminar Contacto    6. Salir");
        Console.WriteLine("Digite el numero de la opcion deseada");

        int typeOption = Convert.ToInt32(Console.ReadLine());

        switch (typeOption)
        {
            case 1:
                {
                    AddContact(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);
                }
                break;

            case 2:
                {
                    Console.WriteLine($"Nombre          Apellido            Direccion           Telefono            Email           Edad            Es Mejor Amigo?");
                    Console.WriteLine($"____________________________________________________________________________________________________________________________");
                    foreach (var id in ids)
                    {
                        var isBestFriend = bestFriends[id];
                        string isBestFriendStr = (isBestFriend == true) ? "Si" : "No";
                        Console.WriteLine($"{names[id]}         {lastnames[id]}         {addresses[id]}         {telephones[id]}            {emails[id]}            {ages[id]}          {isBestFriendStr}");
                    }
                }
                break;

            case 3: //buscar contacto
                {
                    Console.WriteLine("Digite el nombre o apellido del contacto que desea buscar:");
                    string term = Console.ReadLine().ToLower();
                    bool found = false;

                    foreach (var id in ids)
                    {
                        if (names[id].ToLower().Contains(term) || lastnames[id].ToLower().Contains(term))
                        {
                            string isBestFriendStr = bestFriends[id] ? "Si" : "No";
                            Console.WriteLine($"ID: {id}");
                            Console.WriteLine($"Nombre: {names[id]}");
                            Console.WriteLine($"Apellido: {lastnames[id]}");
                            Console.WriteLine($"Direccion: {addresses[id]}");
                            Console.WriteLine($"Telefono: {telephones[id]}");
                            Console.WriteLine($"Email: {emails[id]}");
                            Console.WriteLine($"Edad: {ages[id]}");
                            Console.WriteLine($"Mejor amigo: {isBestFriendStr}");
                            Console.WriteLine("------------------------------------------------------");
                            found = true;
                        }
                    }

                    if (!found)
                    {
                        Console.WriteLine("No se encontro ningun contacto con ese nombre o apellido.");
                    }
                }
                break;

            case 4: //modificar contacto
                {
                    try
                    {
                        Console.WriteLine("Digite el ID del contacto que desea modificar:");
                        int id = Convert.ToInt32(Console.ReadLine());

                        if (!ids.Contains(id))
                        {
                            Console.WriteLine("El ID ingresado no existe.");
                            break;
                        }

                        Console.WriteLine("Deje el campo vacio si no desea modificarlo.");

                        Console.WriteLine($"Nombre actual ({names[id]}):");
                        string newName = Console.ReadLine();
                        if (!string.IsNullOrEmpty(newName)) { names[id] = newName; }

                        Console.WriteLine($"Apellido actual ({lastnames[id]}):");
                        string newLastname = Console.ReadLine();
                        if (!string.IsNullOrEmpty(newLastname)) { lastnames[id] = newLastname; }

                        Console.WriteLine($"Direccion actual ({addresses[id]}):");
                        string newAddress = Console.ReadLine();
                        if (!string.IsNullOrEmpty(newAddress)) { addresses[id] = newAddress; }

                        Console.WriteLine($"Telefono actual ({telephones[id]}):");
                        string newPhone = Console.ReadLine();
                        if (!string.IsNullOrEmpty(newPhone)) { telephones[id] = newPhone; }

                        Console.WriteLine($"Email actual ({emails[id]}):");
                        string newEmail = Console.ReadLine();
                        if (!string.IsNullOrEmpty(newEmail)) { emails[id] = newEmail; }

                        Console.WriteLine($"Edad actual ({ages[id]}):");
                        string newAgeStr = Console.ReadLine();
                        if (!string.IsNullOrEmpty(newAgeStr))
                        {
                            int newAge = Convert.ToInt32(newAgeStr);
                            ages[id] = newAge;
                        }

                        Console.WriteLine($"Es mejor amigo actual ({(bestFriends[id] ? "Si" : "No")}). Digite 1 para Si o 2 para No (deje vacio si no cambia):");
                        string newBestStr = Console.ReadLine();
                        if (!string.IsNullOrEmpty(newBestStr))
                        {
                            bestFriends[id] = Convert.ToInt32(newBestStr) == 1;
                        }

                        Console.WriteLine("Contacto modificado correctamente.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error al modificar contacto: {ex.Message}");
                    }
                }
                break;

            case 5: //eliminar contacto
                {
                    try
                    {
                        Console.WriteLine("Digite el ID del contacto que desea eliminar:");
                        int id = Convert.ToInt32(Console.ReadLine());

                        if (!ids.Contains(id))
                        {
                            Console.WriteLine("El ID ingresado no existe.");
                            break;
                        }

                        Console.WriteLine($"Esta seguro que desea eliminar a {names[id]} {lastnames[id]}?  (1. Si / 2. No)");
                        int confirm = Convert.ToInt32(Console.ReadLine());

                        if (confirm == 1)
                        {
                            ids.Remove(id);
                            names.Remove(id);
                            lastnames.Remove(id);
                            addresses.Remove(id);
                            telephones.Remove(id);
                            emails.Remove(id);
                            ages.Remove(id);
                            bestFriends.Remove(id);

                            Console.WriteLine("Contacto eliminado correctamente.");
                        }
                        else
                        {
                            Console.WriteLine("Operacion cancelada.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error al eliminar contacto: {ex.Message}");
                    }
                }
                break;

            case 6:
                runing = false;
                Console.WriteLine("Gracias por usar la lista de contactos!");
                break;

            default:
                Console.WriteLine("Tu eres o te haces el idiota?");
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
        Console.WriteLine("Por favor, intente nuevamente.\n");
    }
}


static void AddContact(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames, Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
{
    try
    {
        Console.WriteLine("Digite el nombre de la persona");
        string name = Console.ReadLine();
        Console.WriteLine("Digite el apellido de la persona");
        string lastname = Console.ReadLine();
        Console.WriteLine("Digite la direccion");
        string address = Console.ReadLine();
        Console.WriteLine("Digite el telefono de la persona");
        string phone = Console.ReadLine();
        Console.WriteLine("Digite el email de la persona");
        string email = Console.ReadLine();
        Console.WriteLine("Digite la edad de la persona en numeros");
        int age = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Especifique si es mejor amigo: 1. Si, 2. No");

        bool isBestFriend = Convert.ToInt32(Console.ReadLine()) == 1;

        var id = ids.Count + 1;
        ids.Add(id);
        names.Add(id, name);
        lastnames.Add(id, lastname);
        addresses.Add(id, address);
        telephones.Add(id, phone);
        emails.Add(id, email);
        ages.Add(id, age);
        bestFriends.Add(id, isBestFriend);

        Console.WriteLine("Contacto agregado correctamente.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error al agregar contacto: {ex.Message}");
    }
}
