using hospitalManagenetSystemAPI.Automata;
using System;

namespace hospitalManagenetSystemAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Hospital Management System!");

            string input;
            do
            {
                // Prompt the user to set the initial state
                Console.WriteLine("Pilih initial state initial state:");
                foreach (var state in Enum.GetValues(typeof(automata.State)))
                {
                    Console.WriteLine($"{(int)state}: {state}");
                }
                int initialStateValue;
                while (!int.TryParse(Console.ReadLine(), out initialStateValue) || !Enum.IsDefined(typeof(automata.State), initialStateValue))
                {
                    Console.WriteLine("Invalid input, masukkan angka yang valid");
                }
                automata.State initialState = (automata.State)initialStateValue;

                // Set the initial state
                automata.setPosisi(initialState, automata.State.TEST);

                // Get and print the current state
                Console.WriteLine("Current State: " + automata.getPosisi());

                // Prompt the user to perform state transition
                Console.WriteLine("Pilih next state:");
                foreach (var state in Enum.GetValues(typeof(automata.State)))
                {
                    Console.WriteLine($"{(int)state}: {state}");
                }
                int nextStateValue;
                while (!int.TryParse(Console.ReadLine(), out nextStateValue) || !Enum.IsDefined(typeof(automata.State), nextStateValue))
                {
                    Console.WriteLine("Invalid input, masukkan angka yang valid");
                }
                automata.State nextState = (automata.State)nextStateValue;

                // Perform state transition
                automata.posisiTransition(nextState);

                // Get and print the new state after transition
                Console.WriteLine("New State: " + automata.getPosisi());

                // Prompt the user to continue or exit
                Console.WriteLine("Ketik '-1' untuk keluar atau ketik apa saja untuk lanjut:");
                input = Console.ReadLine();
            } while (input != "-1");
        }
    }
}
