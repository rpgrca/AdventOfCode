namespace Day2.Logic;

public interface IResult
{
    IResult WhenSuccessful(Action action);
    IResult WhenInvalid(Action result);
}
