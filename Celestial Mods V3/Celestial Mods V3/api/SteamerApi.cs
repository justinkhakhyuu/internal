class StreamerApi
{
    private string _apiUrl;
    public StreamerApi(string apiUrl)
    {
        _apiUrl = apiUrl;
    }


    public void startApi(string command)
    {
        //  this should connect with the view logic
        IntEndPoints endPoints = new EndPoint(_apiUrl, "8080");
        bool isExecuted = endPoints.executeCommand(command);
        // so we can show error on user phone  and panel
        if (isExecuted)
        {
            Console.WriteLine("Command executed successfully.");
        }
        else
        {
            Console.WriteLine("Failed to execute command.");
        }
    }
}