using hospitalManagenetSystemAPI.Automata;
using Xunit;

namespace AutoTes
{
    public class AutomataTests
    {
        [Fact]
        public void TestLoginTransitionToDashboard()
        {
            automata.setPosisi(automata.State.LOGIN, automata.State.DASHBOARD);
            automata.posisiTransition(automata.State.DASHBOARD);
            Assert.Equal(automata.State.DASHBOARD, automata.getPosisi());
        }

        [Fact]
        public void TestLoginTransitionToRegistrasi()
        {
            automata.setPosisi(automata.State.LOGIN, automata.State.REGISTRASI);
            automata.posisiTransition(automata.State.REGISTRASI);
            Assert.Equal(automata.State.REGISTRASI, automata.getPosisi());
        }

        [Fact]
        public void TestRegistrasiTransitionToLogin()
        {
            automata.setPosisi(automata.State.REGISTRASI, automata.State.LOGIN);
            automata.posisiTransition(automata.State.LOGIN);
            Assert.Equal(automata.State.LOGIN, automata.getPosisi());
        }



        // Add more tests for other transitions as needed
    }
}
