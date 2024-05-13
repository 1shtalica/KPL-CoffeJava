using Frontend.Automata;
using System;
using System.Diagnostics;

namespace hospitalManagenetSystemAPI.Automata
{
    public class automata
    {
        public enum State { LOGIN, REGISTRASI, DASHBOARD, LOGOUT, TEST };
        public static State posisi, nextPosisi;


        public automata() { }

        public static void setPosisi(State pos, State nextPos)

        {
            Debug.Assert(Enum.IsDefined(typeof(State), pos));
            Debug.Assert(Enum.IsDefined(typeof(State), nextPos));




            posisi = pos;
            nextPosisi = nextPos;
        }

        public static State getPosisi()
        {

            Debug.Assert(Enum.IsDefined(typeof(State), posisi));

            return posisi;
        }

        public static void posisiTransition(State nextPos)
        {
            Console.WriteLine($"Transisi dari state {posisi} ke state {nextPos}");

            Debug.Assert(posisi != nextPos);
            switch (posisi)
            {
                case State.LOGIN:
                    switch (nextPos)
                    {
                        case State.DASHBOARD:
                            Dashboard dashboard = new Dashboard();
                            dashboard.Show();
                            posisi = State.DASHBOARD;
                            break;
                        case State.REGISTRASI:
                            Registrasi registrasi = new Registrasi();
                            registrasi.Show();
                            posisi = State.REGISTRASI;
                            break;
                        case State.LOGOUT:
                            Logout logout = new Logout();
                            logout.Show();
                            posisi = State.LOGOUT;
                            break;
                        default:
                            Console.WriteLine("Next state tidak valid");
                            break;
                    }
                    break;
                case State.REGISTRASI:

                    switch (nextPos)
                    {
                        case State.LOGIN:
                            Login login = new Login();
                            login.Show();
                            posisi = State.LOGIN;
                            break;
                        case State.LOGOUT:
                            Logout logout = new Logout();
                            logout.Show();
                            posisi = State.LOGOUT;
                            break;
                        default:
                            Console.WriteLine("Next state tidak valid");
                            break;
                    }
                    break;
                case State.DASHBOARD:
                    switch (nextPos)
                    {
                        case State.LOGOUT:
                            Logout logout = new Logout();
                            logout.Show();
                            posisi = State.LOGOUT;
                            break;
                        default:
                            Console.WriteLine("Next state tidak valid");
                            break;
                    }
                    break;
                case State.LOGOUT:
                    switch (nextPos)
                    {
                        case State.LOGIN:
                            Login login = new Login();
                            login.Show();
                            posisi = State.LOGIN;
                            break;
                        case State.REGISTRASI:
                            Registrasi registrasi = new Registrasi();
                            registrasi.Show();
                            posisi = State.REGISTRASI;
                            break;
                    }
                    break;
                default:
                    Console.WriteLine("Current state tidak valid");
                    break;

            }
        }
    }
}
