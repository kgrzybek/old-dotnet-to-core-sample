using System;

namespace NETFramework.App
{
    public class UserContextMock : IUserContext
    {
        public Guid? UserId { get; set; }
    }
}