namespace LogicTests
{
    [TestClass]
    public class ExampleTests
    {
        private void TestExamples((string given, string then)[] examples)
        {
            foreach (var example in examples)
            {
                var given = GridBuilder.FromRleString(example.given);
                var then = GridBuilder.FromRleString(example.then);
                given.NextGeneration().Should().Be(then);
            }
        }


        [TestMethod]
        public void Check_1_by_1_examples()
        {
            TestExamples(new[]{
                ("x=1,y=1\r\nb!", "x=1,y=1\r\nb!"),
                ("x=1,y=1\r\no!", "x=1,y=1\r\nb!")
            });
        }

        [TestMethod]
        public void Check_2_by_2_examples()
        {
            TestExamples(new[]{
                ("x=2,y=2\r\n$!", "x=2,y=2\r\n$!"),

                ("x=2,y=2\r\nob$!", "x=2,y=2\r\n$!"),
                ("x=2,y=2\r\nbo$!", "x=2,y=2\r\n$!"),
                ("x=2,y=2\r\n$ob!", "x=2,y=2\r\n$!"),
                ("x=2,y=2\r\n$bo!", "x=2,y=2\r\n$!"),

                ("x=2,y=2\r\noo$!", "x=2,y=2\r\n$!"),
                ("x=2,y=2\r\n$oo!", "x=2,y=2\r\n$!"),
                ("x=2,y=2\r\nob$ob!", "x=2,y=2\r\n$!"),
                ("x=2,y=2\r\nbo$bo!", "x=2,y=2\r\n$!"),
                ("x=2,y=2\r\nob$bo!", "x=2,y=2\r\n$!"),
                ("x=2,y=2\r\nbo$ob!", "x=2,y=2\r\n$!"),

                ("x=2,y=2\r\noo$ob!", "x=2,y=2\r\noo$oo!"),
                ("x=2,y=2\r\noo$bo!", "x=2,y=2\r\noo$oo!"),
                ("x=2,y=2\r\nob$oo!", "x=2,y=2\r\noo$oo!"),
                ("x=2,y=2\r\nbo$oo!", "x=2,y=2\r\noo$oo!"),

                ("x=2,y=2\r\noo$oo!", "x=2,y=2\r\noo$oo!")
            });
        }

        [TestMethod]
        public void Check_3_by_3_examples()
        {
            // there are 512 combinations...
            TestExamples(new[]{
                ("x=3,y=3\r\no$$!", "x=3,y=3\r\n$$!"),
                ("x=3,y=3\r\nbo$$!", "x=3,y=3\r\n$$!"),
                ("x=3,y=3\r\nbbo$$!", "x=3,y=3\r\n$$!"),
                ("x=3,y=3\r\n$o$!", "x=3,y=3\r\n$$!"),
                ("x=3,y=3\r\n$bo$!", "x=3,y=3\r\n$$!"),
                ("x=3,y=3\r\n$bbo$!", "x=3,y=3\r\n$$!"),
                ("x=3,y=3\r\n$$o!", "x=3,y=3\r\n$$!"),
                ("x=3,y=3\r\n$$bo!", "x=3,y=3\r\n$$!"),
                ("x=3,y=3\r\n$$bbo!", "x=3,y=3\r\n$$!"),

                ("x=3,y=3\r\noob$$!", "x=3,y=3\r\n$$!"),
                ("x=3,y=3\r\nboo$$!", "x=3,y=3\r\n$$!"),
                ("x=3,y=3\r\nobo$$!", "x=3,y=3\r\n$$!"),
                ("x=3,y=3\r\n$oob$!", "x=3,y=3\r\n$$!"),
                ("x=3,y=3\r\n$obo$!", "x=3,y=3\r\n$$!"),
                ("x=3,y=3\r\n$boo$!", "x=3,y=3\r\n$$!"),
                ("x=3,y=3\r\n$$oob!", "x=3,y=3\r\n$$!"),
                ("x=3,y=3\r\n$$obo!", "x=3,y=3\r\n$$!"),
                ("x=3,y=3\r\n$$boo!", "x=3,y=3\r\n$$!"),

                ("x=3,y=3\r\nobo$bob$obo!", "x=3,y=3\r\nbob$obo$bob!"),
                ("x=3,y=3\r\nbob$obo$bob!", "x=3,y=3\r\nbob$obo$bob!"),

                ("x=3,y=3\r\n$ooo$!", "x=3,y=3\r\nbob$bob$bob!"),
                ("x=3,y=3\r\nbob$bob$bob!", "x=3,y=3\r\n$ooo$!")
            });
        }
    }
}