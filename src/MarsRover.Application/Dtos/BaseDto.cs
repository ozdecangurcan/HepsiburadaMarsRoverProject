namespace MarsRover.Application.Dtos
{
    public abstract class BaseDto
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
