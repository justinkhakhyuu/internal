public class EndPoint : IntEndPoints
{
    private string _apiUrl;
    private string _port;

    public EndPoint(string apiUrl, string port)
    {
        _apiUrl = apiUrl;
        _port = port;
    }

    public bool executeCommand(string command)
    {
        // Implementation for executing a command
        return true;
    }
}
