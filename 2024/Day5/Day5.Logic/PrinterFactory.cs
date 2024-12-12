
using Day5.Logic;

public static class PrinterFactory
{
    public static IPrinter WithoutReordering(string input) =>
        new PrinterWithoutReordering(input);

    public static IPrinter WithReordering(string input) =>
        new PrinterWithReordering(input);
}