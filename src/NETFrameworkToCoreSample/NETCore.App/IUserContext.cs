using System;

namespace NETCore.App
{
    public interface IUserContext
    {
        public Guid? UserId { get; }
    }
}