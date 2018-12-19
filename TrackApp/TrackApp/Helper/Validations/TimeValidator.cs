using System;
using System.Collections.Generic;
using System.Text;
using TrackApp.Models.Interfaces;

namespace TrackApp.Helper.Validations
{
    class TimeValidator : IValidationRule<string>
    {

        public string Description => $"Time should not be null";
        public bool Validate(string value) => !string.IsNullOrEmpty(value) && int.Parse(value) != 0;

    }
}
