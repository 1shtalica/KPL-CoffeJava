using hospitalManagenetSystemAPI.Automata;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Frontend;
namespace autotest

{
    [TestClass]
    public class AutomataTests
    {
        [TestMethod]
        public void TestLoginToDashboardTransition()
        {
            automata.setPosisi(automata.State.LOGIN, automata.State.DASHBOARD);
            automata.posisiTransition(automata.State.DASHBOARD);
            Assert.AreEqual(automata.State.DASHBOARD, automata.getPosisi());
        }

        [TestMethod]
        public void TestLoginToRegistrationTransition()
        {
            automata.setPosisi(automata.State.LOGIN, automata.State.REGISTRASI);
            automata.posisiTransition(automata.State.REGISTRASI);
            Assert.AreEqual(automata.State.REGISTRASI, automata.getPosisi());
        }

        [TestMethod]
        public void TestLoginToLogoutTransition()
        {
            automata.setPosisi(automata.State.LOGIN, automata.State.LOGOUT);
            automata.posisiTransition(automata.State.LOGOUT);
            Assert.AreEqual(automata.State.LOGOUT, automata.getPosisi());
        }

        // Add more test methods to cover other state transitions
    }
}
