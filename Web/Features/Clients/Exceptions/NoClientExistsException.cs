using System;
namespace Web.Features.Clients.Exceptions;

public class NoClientExistsException : Exception
{
    public NoClientExistsException(int clientId) : base($"Client with id: {clientId} doesn't exist.") { }
}

