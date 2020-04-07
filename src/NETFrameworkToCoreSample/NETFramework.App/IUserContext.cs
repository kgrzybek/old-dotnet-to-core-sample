using System;

namespace NETFramework.App
{
    public interface IUserContext
    {
        Guid? UserId { get; }
    }
}