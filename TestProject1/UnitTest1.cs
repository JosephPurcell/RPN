namespace TestProject1
{
    using RPN;

    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void TestMethod1()
        {
            string[] tokens = ["2", "1", "+", "3", "*"];
            int expected = 9;
            Solution solution = new Solution();

            int result = solution.EvalRPN(tokens);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestMethod2()
        {
            string[] tokens = ["4", "13", "5", "/", "+"];
            int expected = 6;
            Solution solution = new Solution();

            int result = solution.EvalRPN(tokens);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestMethod3()
        {
            string[] tokens = ["10", "6", "9", "3", "+", "-11", "*", "/", "*", "17", "+", "5", "+"];
            int expected = 22;
            Solution solution = new Solution();

            int result = solution.EvalRPN(tokens);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestMethod4()
        {
            string[] tokens = ["2", "1", "+", "3", "*", "8"];
            Solution solution = new Solution();

            try
            {
                int result = solution.EvalRPN(tokens);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "invalid statement, one or more missing operands and operator(s)");
                return;
            }
            Assert.Fail();
        }
    }
}