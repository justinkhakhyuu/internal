using System;

public class Class1
{
	// incase we want to make streamer run outside localhost in the future 
	// this will allow u to control someone elses panel or your own from far
	private int port;
	private string host;
	public Class1(string host, int port )
	{
		this.host = host;
		this.port = port;
	}


}
