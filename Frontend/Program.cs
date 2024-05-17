<<<<<<< Updated upstream
﻿using hospitalManagenetSystemAPI.Automata;
using System;

namespace hospitalManagenetSystemAPI
=======
﻿using System;

namespace TerminalProgram
>>>>>>> Stashed changes
{
    class Program
    {
        static void Main(string[] args)
        {
<<<<<<< Updated upstream
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
=======
            while (true)
            {
                Console.Write("Enter username (neuro1 or neuro2): ");
                string username = Console.ReadLine();

                Console.Write("Enter password: ");
                string password = Console.ReadLine();

                try
                {
                    string storedPassword = Frontend.TableDriven.TableDrivenNeurology.GetPassword(username);

                    if (password == storedPassword)
                    {
                        Console.WriteLine($"Welcome, {username}!");
                    }
                    else
                    {
                        Console.WriteLine("Invalid password.");
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }

                Console.WriteLine("Do you want to try again? (yes/no)");
                string input = Console.ReadLine().ToLower();
                if (input != "yes")
                    break;
            }

            Console.WriteLine("Thank you for using the Terminal Program!");
>>>>>>> Stashed changes
        }
    }
}
