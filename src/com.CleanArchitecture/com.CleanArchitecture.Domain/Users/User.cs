using com.CleanArchitecture.Domain.Abstractions;
using com.CleanArchitecture.Domain.Users.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.CleanArchitecture.Domain.Users
{
    public sealed class User : Entity
    {
        private User() { }
        private User(Guid id,
            Nombre nombre,
            Apellido apellido,
            Email email
            ) : base(id)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
        }
        public Nombre? Nombre { get; private set; }
        public Apellido? Apellido { get; private set; }
        public Email? Email { get; private set; }
        public static User Create(
            Guid id,
            Nombre nombre,
            Apellido apellido,
            Email email
            )
        {
           var user = new User( Guid.NewGuid(),nombre,apellido,email);
            user.RaiseDomainEvent(new UserCreateDomainEvent(user.Id));
            return user;
        }

    }
}
