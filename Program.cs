/*Programa com a finalidade de adicionar veículos a um estacionamento. Os veículos sáo registrados através de uma List<string> da 
classe ParkingLot, e seus métodos são utilizados para armazenar, remover, e listar veículos do estacionamento. O programa apresenta
um menu com opções de 1 a 4 lidos e adicionados a uma variável percorrida em uma instrução Switch. cada case de Switch usará os métodos
de ParkingLot adequados. O programa também tem a capacidade de validar as repostas do usuário conforme o que for requerido*/
using System;
using System.Security.Cryptography.X509Certificates;
using TrilhaNetFundamentosDesafio.ParkingLot;

ParkingLot vehicle = new();
bool endTask = true;
string initialTax;
string perHourParked;
int perHourParkedInt = 0;
int initialTaxInt = 0;
do
{
    Console.WriteLine("Digite a taxa inicial: \n");
    initialTax = Console.ReadLine();
    Console.Clear();
    Console.WriteLine("\nDigite o preço por hora estacionda: \n");
    perHourParked = Console.ReadLine();
    Console.Clear();
    //Verifica se os valores digitados são válidos.
    if (int.TryParse(initialTax, out initialTaxInt) && int.TryParse(perHourParked, out perHourParkedInt))
        endTask = false;
    else
        Console.WriteLine("Comando inválido. Por favor, adicione um número válido");
    Console.ReadKey();
    Console.Clear();
} while (endTask);
endTask = true;
do
{
    Console.WriteLine(@"=========================
Estacionmento de veículos
=========================
");
    Console.WriteLine(@"MENU DE OPÇÕES

1. Cadastrar Veículo.
2. Remover Veículo.
3. Listar Veículo.
4. Encerrar.");
    string readResult = Console.ReadLine();
    Console.Clear();

    switch (readResult)
    {
        //Cadastra um veículo através da placa.
        case "1":
            Console.WriteLine("Digite a placa do veículo: \n");
            readResult = Console.ReadLine().ToUpper().Trim();
            Console.Clear();
            vehicle.AddVehicle(readResult);
            break;
        /*Remove um veículo do estacionamento e cálcula o total a pagar baseado na quantidade de 
        horas estacionado x preço por hora + taxa inicial.*/
        case "2":
            Console.WriteLine("Digite a plaqua do veículo que deseja remover: \n");
            string readResult2 = Console.ReadLine().ToUpper().Trim();
            Console.WriteLine("Quantidade de horas estacionado: \n");
            string hoursParked = Console.ReadLine();
            Console.Clear();
            int hoursParkedInt = 0;
            //Verifica se o valor digitado é válido.
            if (int.TryParse(hoursParked, out hoursParkedInt))
                vehicle.VehiclesRemoved(readResult2, perHourParkedInt, hoursParkedInt, initialTaxInt);
            else
                Console.WriteLine("Comando inválido. Por favor, adicione um número válido.");
            Console.ReadKey();
            Console.Clear();
            break;
        //Lista os veículos estacionados.
        case "3":
            vehicle.VehiclesParked();
            Console.ReadKey();
            Console.Clear();
            break;
        case "4":
            Console.WriteLine("Programa encerrado.");
            endTask = false;
            break;
        default:
            Console.WriteLine("Comando inválido.");
            Console.ReadKey();
            Console.Clear();
            break;
    }
} while (endTask);
