using System;
using System.Security.Cryptography.X509Certificates;

static void Main() { }
namespace TrilhaNetFundamentosDesafio.ParkingLot
{
    public class ParkingLot
    {
        public List<string> VehiclePlaque = new List<string>();
        /// <summary>
        ///  verifica se o usuário digitou uma plaqua válida e adiciona um veículo ao estacionamento.
        /// </summary>
        /// <param name="readResult">Plaqua do veículo estacionado.</param>
        public void AddVehicle(string readResult)
        {
            bool validatePlaque = false;
            if (readResult.Length == 7)
            {
                bool validateIndex = true;
                bool validateNumber = true;
                //Adiciona os caracteres separados de uma cadeia de caracteres pelo método Substring do valor lido e atribui a uma variável
                string index = readResult.Substring(0, 4);
                string numbers = readResult.Substring(4, 3);
                char[] indexLetters = index.ToCharArray();
                char[] numbersLetters = numbers.ToCharArray();
                /* Verifica se cada letra de uma plaqua de veículo digitada pelo usuário está nos conformes requeridos pelo programa.
                Se sim, adicione o veículo ao estacionamento.*/
                int validate = 0;
                for (int count = 0; count < indexLetters.Length; count++)
                {
                    if (int.TryParse(Convert.ToString(indexLetters[count]), out validate))
                        validateIndex = false;
                }
                for (int count = 0; count < numbersLetters.Length; count++)
                {

                    if (!int.TryParse(Convert.ToString(numbersLetters[count]), out validate))
                        validateNumber = false;
                }
                if (validateIndex && validateNumber && index.IndexOf("-") == 3)
                {
                    VehiclePlaque.Add(readResult);
                    Console.WriteLine($"Veículo com a plaqua {readResult} adicionado.");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                    validatePlaque = true;
            }
            else
                validatePlaque = true;
            if (validatePlaque)
            {
                Console.WriteLine("Por favor, adicione uma plaqua válida.\n");
                Console.WriteLine("Formato aceito: ABC-123.");
                Console.ReadKey();
                Console.Clear();
            }
        }
        /// <summary>
        /// Lista todos os veículos estacionados.
        /// </summary>
        /// <param name="vehiclesPlaque">Total de veículos estacionados</param>
        public void VehiclesParked()
        {
            Console.WriteLine("Veículos estacionados: \n");
            for (int count = 0; count < VehiclePlaque.Count; count++)
                Console.WriteLine($"Plaqua do veículo: {VehiclePlaque[count]}");
        }

        /// <summary>
        /// Remove um veículo estacionado.
        /// </summary>
        /// <param name="readResult">Plaqua do veículo.</param>
        /// <param name="perHourParked">Preço por hora estacionado.</param>
        /// <param name="hoursParked">Total de horas estacionado</param>
        /// <param name="initialTax">Taxa inicial ao estacionar.</param>
        public void VehiclesRemoved(string readResult, int perHourParked, int hoursParked, int initialTax)
        {
            /*Verifica se a plaqua de veículo digitada pelo usuário está armazenada na List<string> VehiclePlaque.
            Se sim, Remova e calcule o total a pagar pelo tempo estacionado*/
            if (VehiclePlaque.Contains(readResult))
            {
                Console.WriteLine($"Veículo com a plaqua {readResult} removido.");
                VehiclePlaque.Remove(readResult);
                int payment = perHourParked * hoursParked + initialTax;
                Console.WriteLine($"Total a pagar: {payment:c}");
            }
            else
                Console.WriteLine("Veículo não encontrado. Verifique se digitou a plaqua corretamente.");
        }
    }
}

