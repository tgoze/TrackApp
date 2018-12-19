using System;
using System.Collections.Generic;
using System.Text;

namespace TrackApp.Models.Interfaces
{
    public interface IValidationRule<T>
    
    {
        string Description { get; }
        bool Validate(T value);
    }
}
