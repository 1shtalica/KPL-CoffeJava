namespace hospitalManagenetSystemAPI.Automata
{
    public class automata
    {
        public enum State { LOGIN, REGISTRASI, DASHBOARD, LOGOUT, TEST }; 
        public static State posisi, nextPosisi;


        public automata() { }

        public static void setPosisi(State pos, State nextPos)
        {
            posisi = pos;
            nextPosisi = nextPos;
        }

        public static State getPosisi()
        {
            return posisi;
        }

        public static void posisiTransition(State nextPos) {

            // Jika keadaan pada posisi masuk pada login.
            if (posisi == State.LOGIN)
            {
                if (nextPos == State.DASHBOARD)
                {
                    Dashboard dashboard = new Dashboard();
                    dashboard.Show();
                }
                else if (nextPos == State.REGISTRASI) 
                {
                    Registrasi registrasi = new Registrasi();
                    registrasi.Show();
                }
            }
    }
}
